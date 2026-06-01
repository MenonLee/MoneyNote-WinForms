using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Data.Sqlite;
using ScheduleProject.Models;

namespace ScheduleProject.Data
{
    public class DatabaseHelper
    {
        private static readonly string dbFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "MoneyNote"
        );

        private static readonly string dbPath = Path.Combine(dbFolder, "expense.db");
        private static readonly string connectionString = $"Data Source={dbPath}";

        public static void InitializeDatabase()
        {
            Directory.CreateDirectory(dbFolder);

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string tableCommand = @"
                    CREATE TABLE IF NOT EXISTS Expenses (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT NOT NULL,
                        Amount INTEGER NOT NULL,
                        Category TEXT,
                        PaymentMethod TEXT,
                        ExpenseDate TEXT NOT NULL,
                        Memo TEXT,
                        IsFixed INTEGER DEFAULT 0,
                        CreatedAt TEXT NOT NULL
                    )";

                using (var command = new SqliteCommand(tableCommand, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void AddExpense(ExpenseItem expense)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string insertCommand = @"
                    INSERT INTO Expenses (Title, Amount, Category, PaymentMethod, ExpenseDate, Memo, IsFixed, CreatedAt)
                    VALUES (@Title, @Amount, @Category, @PaymentMethod, @ExpenseDate, @Memo, @IsFixed, @CreatedAt)";

                var createdAt = expense.CreatedAt == default ? DateTime.Now : expense.CreatedAt;

                using (var command = new SqliteCommand(insertCommand, connection))
                {
                    command.Parameters.AddWithValue("@Title", expense.Title);
                    command.Parameters.AddWithValue("@Amount", expense.Amount);
                    command.Parameters.AddWithValue("@Category", expense.Category ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PaymentMethod", expense.PaymentMethod ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ExpenseDate", expense.ExpenseDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@Memo", expense.Memo ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@IsFixed", expense.IsFixed ? 1 : 0);
                    command.Parameters.AddWithValue("@CreatedAt", createdAt.ToString("yyyy-MM-dd HH:mm:ss"));

                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<ExpenseItem> GetAllExpenses()
        {
            return ReadExpenses("SELECT * FROM Expenses ORDER BY ExpenseDate DESC");
        }

        public static ExpenseItem? GetExpenseById(int id)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string selectCommand = "SELECT * FROM Expenses WHERE Id = @Id";

                using (var command = new SqliteCommand(selectCommand, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read() ? MapExpense(reader) : null;
                    }
                }
            }
        }

        public static void UpdateExpense(ExpenseItem expense)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string updateCommand = @"
                    UPDATE Expenses
                    SET Title = @Title,
                        Amount = @Amount,
                        Category = @Category,
                        PaymentMethod = @PaymentMethod,
                        ExpenseDate = @ExpenseDate,
                        Memo = @Memo,
                        IsFixed = @IsFixed
                    WHERE Id = @Id";

                using (var command = new SqliteCommand(updateCommand, connection))
                {
                    command.Parameters.AddWithValue("@Title", expense.Title);
                    command.Parameters.AddWithValue("@Amount", expense.Amount);
                    command.Parameters.AddWithValue("@Category", expense.Category ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PaymentMethod", expense.PaymentMethod ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ExpenseDate", expense.ExpenseDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@Memo", expense.Memo ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@IsFixed", expense.IsFixed ? 1 : 0);
                    command.Parameters.AddWithValue("@Id", expense.Id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteExpense(int id)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string deleteCommand = "DELETE FROM Expenses WHERE Id = @Id";

                using (var command = new SqliteCommand(deleteCommand, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<ExpenseItem> SearchExpenses(string keyword)
        {
            var expenses = new List<ExpenseItem>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string searchCommand = @"
                    SELECT * FROM Expenses
                    WHERE Title LIKE @Keyword
                       OR Category LIKE @Keyword
                       OR PaymentMethod LIKE @Keyword
                       OR Memo LIKE @Keyword
                    ORDER BY ExpenseDate DESC";

                using (var command = new SqliteCommand(searchCommand, connection))
                {
                    command.Parameters.AddWithValue("@Keyword", $"%{keyword}%");
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            expenses.Add(MapExpense(reader));
                        }
                    }
                }
            }

            return expenses;
        }

        public static List<ExpenseItem> GetExpensesByDate(DateTime date)
        {
            return ReadExpenses(
                "SELECT * FROM Expenses WHERE date(ExpenseDate) = date(@Date) ORDER BY ExpenseDate DESC",
                command => command.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd"))
            );
        }

        public static List<ExpenseItem> GetThisMonthExpenses(int year, int month)
        {
            return ReadExpenses(
                "SELECT * FROM Expenses WHERE strftime('%Y', ExpenseDate) = @Year AND strftime('%m', ExpenseDate) = @Month ORDER BY ExpenseDate DESC",
                command =>
                {
                    command.Parameters.AddWithValue("@Year", year.ToString());
                    command.Parameters.AddWithValue("@Month", month.ToString("00"));
                }
            );
        }

        public static int GetTotalExpenseCount()
        {
            return ExecuteScalarInt("SELECT COUNT(*) FROM Expenses");
        }

        public static int GetTotalExpenseAmount()
        {
            return ExecuteScalarInt("SELECT IFNULL(SUM(Amount), 0) FROM Expenses");
        }

        public static int GetMonthlyExpenseAmount(int year, int month)
        {
            return ExecuteScalarInt(
                "SELECT IFNULL(SUM(Amount), 0) FROM Expenses WHERE strftime('%Y', ExpenseDate) = @Year AND strftime('%m', ExpenseDate) = @Month",
                command =>
                {
                    command.Parameters.AddWithValue("@Year", year.ToString());
                    command.Parameters.AddWithValue("@Month", month.ToString("00"));
                }
            );
        }

        public static int GetAverageExpenseAmount()
        {
            return ExecuteScalarInt("SELECT IFNULL(AVG(Amount), 0) FROM Expenses");
        }

        public static Dictionary<string, int> GetCategoryExpenseSummary()
        {
            var summary = new Dictionary<string, int>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string summaryCommand = @"
                    SELECT IFNULL(Category, '기타'), IFNULL(SUM(Amount), 0)
                    FROM Expenses
                    GROUP BY Category
                    ORDER BY SUM(Amount) DESC";

                using (var command = new SqliteCommand(summaryCommand, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        summary[reader.GetString(0)] = Convert.ToInt32(reader.GetValue(1));
                    }
                }
            }

            return summary;
        }

        private static List<ExpenseItem> ReadExpenses(string query, Action<SqliteCommand>? configure = null)
        {
            var expenses = new List<ExpenseItem>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqliteCommand(query, connection))
                {
                    configure?.Invoke(command);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            expenses.Add(MapExpense(reader));
                        }
                    }
                }
            }

            return expenses;
        }

        private static int ExecuteScalarInt(string query, Action<SqliteCommand>? configure = null)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqliteCommand(query, connection))
                {
                    configure?.Invoke(command);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        private static ExpenseItem MapExpense(SqliteDataReader reader)
        {
            return new ExpenseItem
            {
                Id = Convert.ToInt32(reader.GetValue(0)),
                Title = reader.GetString(1),
                Amount = Convert.ToInt32(reader.GetValue(2)),
                Category = reader.IsDBNull(3) ? "" : reader.GetString(3),
                PaymentMethod = reader.IsDBNull(4) ? "" : reader.GetString(4),
                ExpenseDate = DateTime.Parse(reader.GetString(5)),
                Memo = reader.IsDBNull(6) ? "" : reader.GetString(6),
                IsFixed = Convert.ToInt32(reader.GetValue(7)) == 1,
                CreatedAt = DateTime.Parse(reader.GetString(8))
            };
        }
    }
}
