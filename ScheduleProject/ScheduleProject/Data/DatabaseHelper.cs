using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using ScheduleProject.Models;
using System.IO;
using System.Linq;

namespace ScheduleProject.Data
{
    public class DatabaseHelper
    {
        private static string dbName = "schedule.db";
        private static string connectionString = $"Data Source={dbName}";

        public static void InitializeDatabase()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                
                string expenseTable = @"
                    CREATE TABLE IF NOT EXISTS Expenses (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT NOT NULL,
                        Amount INTEGER NOT NULL,
                        Category TEXT,
                        PaymentMethod TEXT,
                        ExpenseDate TEXT NOT NULL,
                        Memo TEXT,
                        FixedExpenseRefId INTEGER, 
                        CreatedAt TEXT NOT NULL
                    )";

                string budgetTable = @"
                    CREATE TABLE IF NOT EXISTS Budgets (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Year INTEGER NOT NULL,
                        Month INTEGER NOT NULL,
                        Category TEXT,
                        Amount INTEGER NOT NULL,
                        CreatedAt TEXT NOT NULL
                    )";

                string fixedExpenseTable = @"
                    CREATE TABLE IF NOT EXISTS FixedExpenses (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT NOT NULL,
                        Amount INTEGER NOT NULL,
                        Category TEXT,
                        PaymentMethod TEXT,
                        DayOfMonth INTEGER NOT NULL,
                        Memo TEXT,
                        IsActive INTEGER DEFAULT 1,
                        CreatedAt TEXT NOT NULL
                    )";

                string aiLogTable = @"
                    CREATE TABLE IF NOT EXISTS AiAnalysisLogs (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Year INTEGER NOT NULL,
                        Month INTEGER NOT NULL,
                        Summary TEXT NOT NULL,
                        CreatedAt TEXT NOT NULL
                    )";

                using (var command = new SqliteCommand(expenseTable, connection)) { command.ExecuteNonQuery(); }
                using (var command = new SqliteCommand(budgetTable, connection)) { command.ExecuteNonQuery(); }
                using (var command = new SqliteCommand(fixedExpenseTable, connection)) { command.ExecuteNonQuery(); }
                using (var command = new SqliteCommand(aiLogTable, connection)) { command.ExecuteNonQuery(); }
            }
        }

        #region 1. Expenses (일반 지출)
        public static void AddExpense(ExpenseItem expense, int? fixedExpenseRefId = null)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string insertCommand = @"
                    INSERT INTO Expenses (Title, Amount, Category, PaymentMethod, ExpenseDate, Memo, FixedExpenseRefId, CreatedAt)
                    VALUES (@Title, @Amount, @Category, @PaymentMethod, @ExpenseDate, @Memo, @FixedRefId, @CreatedAt)";

                using (var command = new SqliteCommand(insertCommand, connection))
                {
                    command.Parameters.AddWithValue("@Title", expense.Title);
                    command.Parameters.AddWithValue("@Amount", expense.Amount);
                    command.Parameters.AddWithValue("@Category", expense.Category ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PaymentMethod", expense.PaymentMethod ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ExpenseDate", expense.ExpenseDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@Memo", expense.Memo ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@FixedRefId", fixedExpenseRefId ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.ExecuteNonQuery();
                }
            }
        }

        private static ExpenseItem MapReaderToExpense(SqliteDataReader reader)
        {
            return new ExpenseItem
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                Amount = reader.GetInt32(2),
                Category = reader.IsDBNull(3) ? "" : reader.GetString(3),
                PaymentMethod = reader.IsDBNull(4) ? "" : reader.GetString(4),
                ExpenseDate = DateTime.Parse(reader.GetString(5)),
                Memo = reader.IsDBNull(6) ? "" : reader.GetString(6),
                FixedExpenseRefId = reader.IsDBNull(7) ? (int?)null : reader.GetInt32(7),
                CreatedAt = DateTime.Parse(reader.GetString(8))
            };
        }

        public static List<ExpenseItem> GetAllExpenses()
        {
            var expenses = new List<ExpenseItem>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string selectCommand = "SELECT * FROM Expenses ORDER BY ExpenseDate DESC";
                using (var command = new SqliteCommand(selectCommand, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            expenses.Add(MapReaderToExpense(reader));
                        }
                    }
                }
            }
            return expenses;
        }

        public static List<ExpenseItem> SearchExpenses(string keyword, string category = null, string paymentMethod = null)
        {
            var expenses = new List<ExpenseItem>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Expenses WHERE (Title LIKE @Keyword OR Memo LIKE @Keyword)";
                if (!string.IsNullOrEmpty(category)) sql += " AND Category = @Category";
                if (!string.IsNullOrEmpty(paymentMethod)) sql += " AND PaymentMethod = @PaymentMethod";
                sql += " ORDER BY ExpenseDate DESC";

                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Keyword", $"%{keyword}%");
                    if (!string.IsNullOrEmpty(category)) command.Parameters.AddWithValue("@Category", category);
                    if (!string.IsNullOrEmpty(paymentMethod)) command.Parameters.AddWithValue("@PaymentMethod", paymentMethod);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            expenses.Add(MapReaderToExpense(reader));
                        }
                    }
                }
            }
            return expenses;
        }

        public static void UpdateExpense(ExpenseItem expense)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string updateCommand = @"
                    UPDATE Expenses 
                    SET Title = @Title, Amount = @Amount, Category = @Category, 
                        PaymentMethod = @PaymentMethod, ExpenseDate = @ExpenseDate, Memo = @Memo 
                    WHERE Id = @Id";
                using (var command = new SqliteCommand(updateCommand, connection))
                {
                    command.Parameters.AddWithValue("@Title", expense.Title);
                    command.Parameters.AddWithValue("@Amount", expense.Amount);
                    command.Parameters.AddWithValue("@Category", expense.Category);
                    command.Parameters.AddWithValue("@PaymentMethod", expense.PaymentMethod);
                    command.Parameters.AddWithValue("@ExpenseDate", expense.ExpenseDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@Memo", expense.Memo);
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
        #endregion

        #region 2. Budgets (예산)
        public static void SetBudget(BudgetItem budget)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string checkSql = "SELECT Id FROM Budgets WHERE Year = @Year AND Month = @Month AND (Category = @Category OR (Category IS NULL AND @Category IS NULL))";
                using (var checkCmd = new SqliteCommand(checkSql, connection))
                {
                    checkCmd.Parameters.AddWithValue("@Year", budget.Year);
                    checkCmd.Parameters.AddWithValue("@Month", budget.Month);
                    checkCmd.Parameters.AddWithValue("@Category", string.IsNullOrEmpty(budget.Category) ? (object)DBNull.Value : budget.Category);
                    
                    var existingId = checkCmd.ExecuteScalar();
                    if (existingId != null)
                    {
                        string updateSql = "UPDATE Budgets SET Amount = @Amount WHERE Id = @Id";
                        using (var updateCmd = new SqliteCommand(updateSql, connection))
                        {
                            updateCmd.Parameters.AddWithValue("@Amount", budget.Amount);
                            updateCmd.Parameters.AddWithValue("@Id", existingId);
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string insertSql = "INSERT INTO Budgets (Year, Month, Category, Amount, CreatedAt) VALUES (@Year, @Month, @Category, @Amount, @CreatedAt)";
                        using (var insertCmd = new SqliteCommand(insertSql, connection))
                        {
                            insertCmd.Parameters.AddWithValue("@Year", budget.Year);
                            insertCmd.Parameters.AddWithValue("@Month", budget.Month);
                            insertCmd.Parameters.AddWithValue("@Category", string.IsNullOrEmpty(budget.Category) ? (object)DBNull.Value : budget.Category);
                            insertCmd.Parameters.AddWithValue("@Amount", budget.Amount);
                            insertCmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public static List<BudgetItem> GetMonthlyBudgets(int year, int month)
        {
            var budgets = new List<BudgetItem>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string selectCommand = "SELECT * FROM Budgets WHERE Year = @Year AND Month = @Month";
                using (var command = new SqliteCommand(selectCommand, connection))
                {
                    command.Parameters.AddWithValue("@Year", year);
                    command.Parameters.AddWithValue("@Month", month);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            budgets.Add(new BudgetItem {
                                Id = reader.GetInt32(0), Year = reader.GetInt32(1), Month = reader.GetInt32(2),
                                Category = reader.IsDBNull(3) ? "" : reader.GetString(3), Amount = reader.GetInt32(4),
                                CreatedAt = DateTime.Parse(reader.GetString(5))
                            });
                        }
                    }
                }
            }
            return budgets;
        }
        #endregion

        #region 3. FixedExpenses (고정지출)
        public static void AddFixedExpense(FixedExpenseItem fixedExpense)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string insertCommand = @"
                    INSERT INTO FixedExpenses (Title, Amount, Category, PaymentMethod, DayOfMonth, Memo, CreatedAt)
                    VALUES (@Title, @Amount, @Category, @PaymentMethod, @DayOfMonth, @Memo, @CreatedAt)";
                using (var command = new SqliteCommand(insertCommand, connection))
                {
                    command.Parameters.AddWithValue("@Title", fixedExpense.Title);
                    command.Parameters.AddWithValue("@Amount", fixedExpense.Amount);
                    command.Parameters.AddWithValue("@Category", fixedExpense.Category);
                    command.Parameters.AddWithValue("@PaymentMethod", fixedExpense.PaymentMethod);
                    command.Parameters.AddWithValue("@DayOfMonth", fixedExpense.DayOfMonth);
                    command.Parameters.AddWithValue("@Memo", fixedExpense.Memo);
                    command.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<FixedExpenseItem> GetActiveFixedExpenses()
        {
            var list = new List<FixedExpenseItem>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string selectCommand = "SELECT * FROM FixedExpenses WHERE IsActive = 1";
                using (var command = new SqliteCommand(selectCommand, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new FixedExpenseItem {
                                Id = reader.GetInt32(0), Title = reader.GetString(1), Amount = reader.GetInt32(2),
                                Category = reader.IsDBNull(3) ? "" : reader.GetString(3), PaymentMethod = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                DayOfMonth = reader.GetInt32(5), Memo = reader.IsDBNull(6) ? "" : reader.GetString(6),
                                IsActive = reader.GetInt32(7) == 1, CreatedAt = DateTime.Parse(reader.GetString(8))
                            });
                        }
                    }
                }
            }
            return list;
        }

        public static int GetTotalFixedExpenseAmount()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT SUM(Amount) FROM FixedExpenses WHERE IsActive = 1";
                using (var command = new SqliteCommand(sql, connection))
                {
                    var result = command.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            }
        }
        #endregion

        #region 4. Statistics (통계)
        public static int GetTotalExpenseByMonth(int year, int month)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT SUM(Amount) FROM Expenses WHERE strftime('%Y', ExpenseDate) = @Year AND strftime('%m', ExpenseDate) = @Month";
                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Year", year.ToString());
                    command.Parameters.AddWithValue("@Month", month.ToString("D2"));
                    var result = command.ExecuteScalar();
                    return (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                }
            }
        }

        public static Dictionary<string, int> GetCategorySpending(int year, int month)
        {
            var dict = new Dictionary<string, int>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string sql = @"SELECT Category, SUM(Amount) FROM Expenses 
                               WHERE strftime('%Y', ExpenseDate) = @Year AND strftime('%m', ExpenseDate) = @Month
                               GROUP BY Category";
                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Year", year.ToString());
                    command.Parameters.AddWithValue("@Month", month.ToString("D2"));
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dict[reader.IsDBNull(0) ? "미분류" : reader.GetString(0)] = reader.GetInt32(1);
                        }
                    }
                }
            }
            return dict;
        }

        public static List<ExpenseItem> GetRecentExpenses(int limit)
        {
            var list = new List<ExpenseItem>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Expenses ORDER BY ExpenseDate DESC LIMIT @Limit";
                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Limit", limit);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(MapReaderToExpense(reader));
                        }
                    }
                }
            }
            return list;
        }
        #endregion

        #region 5. AiAnalysisLogs (AI 로그)
        public static void AddAiAnalysisLog(AiAnalysisLog log)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string insertCommand = "INSERT INTO AiAnalysisLogs (Year, Month, Summary, CreatedAt) VALUES (@Year, @Month, @Summary, @CreatedAt)";
                using (var command = new SqliteCommand(insertCommand, connection))
                {
                    command.Parameters.AddWithValue("@Year", log.Year);
                    command.Parameters.AddWithValue("@Month", log.Month);
                    command.Parameters.AddWithValue("@Summary", log.Summary);
                    command.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.ExecuteNonQuery();
                }
            }
        }

        public static string GetLastAiAnalysis(int year, int month)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string selectCommand = "SELECT Summary FROM AiAnalysisLogs WHERE Year = @Year AND Month = @Month ORDER BY CreatedAt DESC LIMIT 1";
                using (var command = new SqliteCommand(selectCommand, connection))
                {
                    command.Parameters.AddWithValue("@Year", year);
                    command.Parameters.AddWithValue("@Month", month);
                    var result = command.ExecuteScalar();
                    return result != null ? result.ToString() : null;
                }
            }
        }
        #endregion

        #region 6. Automation (자동화)
        public static void ProcessMonthlyFixedExpenses()
        {
            var now = DateTime.Now;
            var activeFixedExpenses = GetActiveFixedExpenses();

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                foreach (var fixedExp in activeFixedExpenses)
                {
                    string checkSql = @"SELECT COUNT(*) FROM Expenses 
                                        WHERE FixedExpenseRefId = @RefId 
                                        AND strftime('%Y-%m', ExpenseDate) = @CurrentMonth";
                    
                    using (var checkCmd = new SqliteCommand(checkSql, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@RefId", fixedExp.Id);
                        checkCmd.Parameters.AddWithValue("@CurrentMonth", now.ToString("yyyy-MM"));

                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count == 0)
                        {
                            DateTime expenseDate;
                            try {
                                expenseDate = new DateTime(now.Year, now.Month, fixedExp.DayOfMonth);
                            } catch {
                                expenseDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month));
                            }

                            var newExpense = new ExpenseItem
                            {
                                Title = fixedExp.Title,
                                Amount = fixedExp.Amount,
                                Category = fixedExp.Category,
                                PaymentMethod = fixedExp.PaymentMethod,
                                ExpenseDate = expenseDate,
                                Memo = $"[자동생성] {fixedExp.Memo}"
                            };

                            AddExpense(newExpense, fixedExp.Id);
                        }
                    }
                }
            }
        }
        #endregion
    }
}
