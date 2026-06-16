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

        private const string ExpenseColumns =
            "Id, Title, Amount, Category, PaymentMethod, ExpenseDate, Memo, IsFixed, FixedExpenseRefId, CreatedAt";

        public static void InitializeDatabase()
        {
            Directory.CreateDirectory(dbFolder);

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                ExecuteNonQuery(connection, @"
                    CREATE TABLE IF NOT EXISTS Expenses (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT NOT NULL,
                        Amount INTEGER NOT NULL,
                        Category TEXT,
                        PaymentMethod TEXT,
                        ExpenseDate TEXT NOT NULL,
                        Memo TEXT,
                        IsFixed INTEGER DEFAULT 0,
                        FixedExpenseRefId INTEGER,
                        CreatedAt TEXT NOT NULL
                    )");

                ExecuteNonQuery(connection, @"
                    CREATE TABLE IF NOT EXISTS Budgets (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Year INTEGER NOT NULL,
                        Month INTEGER NOT NULL,
                        Category TEXT,
                        Amount INTEGER NOT NULL,
                        CreatedAt TEXT NOT NULL
                    )");

                ExecuteNonQuery(connection, @"
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
                    )");

                ExecuteNonQuery(connection, @"
                    CREATE TABLE IF NOT EXISTS AiAnalysisLogs (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Year INTEGER NOT NULL,
                        Month INTEGER NOT NULL,
                        Summary TEXT NOT NULL,
                        CreatedAt TEXT NOT NULL
                    )");

                AddColumnIfMissing(connection, "Expenses", "IsFixed", "IsFixed INTEGER DEFAULT 0");
                AddColumnIfMissing(connection, "Expenses", "FixedExpenseRefId", "FixedExpenseRefId INTEGER");
            }
        }

        public static void AddExpense(ExpenseItem expense)
        {
            AddExpense(expense, expense.FixedExpenseRefId);
        }

        public static void AddExpense(ExpenseItem expense, int? fixedExpenseRefId)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string insertCommand = @"
                    INSERT INTO Expenses
                        (Title, Amount, Category, PaymentMethod, ExpenseDate, Memo, IsFixed, FixedExpenseRefId, CreatedAt)
                    VALUES
                        (@Title, @Amount, @Category, @PaymentMethod, @ExpenseDate, @Memo, @IsFixed, @FixedExpenseRefId, @CreatedAt)";

                var createdAt = expense.CreatedAt == default ? DateTime.Now : expense.CreatedAt;

                using (var command = new SqliteCommand(insertCommand, connection))
                {
                    command.Parameters.AddWithValue("@Title", expense.Title);
                    command.Parameters.AddWithValue("@Amount", expense.Amount);
                    command.Parameters.AddWithValue("@Category", ToDbValue(expense.Category));
                    command.Parameters.AddWithValue("@PaymentMethod", ToDbValue(expense.PaymentMethod));
                    command.Parameters.AddWithValue("@ExpenseDate", expense.ExpenseDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@Memo", ToDbValue(expense.Memo));
                    command.Parameters.AddWithValue("@IsFixed", expense.IsFixed ? 1 : 0);
                    command.Parameters.AddWithValue("@FixedExpenseRefId", fixedExpenseRefId ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedAt", createdAt.ToString("yyyy-MM-dd HH:mm:ss"));

                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<ExpenseItem> GetAllExpenses()
        {
            return ReadExpenses($"SELECT {ExpenseColumns} FROM Expenses ORDER BY ExpenseDate DESC");
        }

        public static ExpenseItem? GetExpenseById(int id)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string selectCommand = $"SELECT {ExpenseColumns} FROM Expenses WHERE Id = @Id";

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
                        IsFixed = @IsFixed,
                        FixedExpenseRefId = @FixedExpenseRefId
                    WHERE Id = @Id";

                using (var command = new SqliteCommand(updateCommand, connection))
                {
                    command.Parameters.AddWithValue("@Title", expense.Title);
                    command.Parameters.AddWithValue("@Amount", expense.Amount);
                    command.Parameters.AddWithValue("@Category", ToDbValue(expense.Category));
                    command.Parameters.AddWithValue("@PaymentMethod", ToDbValue(expense.PaymentMethod));
                    command.Parameters.AddWithValue("@ExpenseDate", expense.ExpenseDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@Memo", ToDbValue(expense.Memo));
                    command.Parameters.AddWithValue("@IsFixed", expense.IsFixed ? 1 : 0);
                    command.Parameters.AddWithValue("@FixedExpenseRefId", expense.FixedExpenseRefId ?? (object)DBNull.Value);
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
                using (var command = new SqliteCommand("DELETE FROM Expenses WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<ExpenseItem> SearchExpenses(string keyword, string? category = null, string? paymentMethod = null)
        {
            return ReadExpenses(
                $@"SELECT {ExpenseColumns}
                   FROM Expenses
                   WHERE (Title LIKE @Keyword
                      OR Category LIKE @Keyword
                      OR PaymentMethod LIKE @Keyword
                      OR Memo LIKE @Keyword)
                     AND (@Category IS NULL OR Category = @Category)
                     AND (@PaymentMethod IS NULL OR PaymentMethod = @PaymentMethod)
                   ORDER BY ExpenseDate DESC",
                command =>
                {
                    command.Parameters.AddWithValue("@Keyword", $"%{keyword}%");
                    command.Parameters.AddWithValue("@Category", string.IsNullOrWhiteSpace(category) ? (object)DBNull.Value : category);
                    command.Parameters.AddWithValue("@PaymentMethod", string.IsNullOrWhiteSpace(paymentMethod) ? (object)DBNull.Value : paymentMethod);
                }
            );
        }

        public static List<ExpenseItem> GetExpensesByDate(DateTime date)
        {
            return ReadExpenses(
                $"SELECT {ExpenseColumns} FROM Expenses WHERE date(ExpenseDate) = date(@Date) ORDER BY ExpenseDate DESC",
                command => command.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd"))
            );
        }

        public static List<ExpenseItem> GetThisMonthExpenses(int year, int month)
        {
            return ReadExpenses(
                $"SELECT {ExpenseColumns} FROM Expenses WHERE strftime('%Y', ExpenseDate) = @Year AND strftime('%m', ExpenseDate) = @Month ORDER BY ExpenseDate DESC",
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

        public static int GetTotalExpenseByMonth(int year, int month)
        {
            return GetMonthlyExpenseAmount(year, month);
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
                    SELECT IFNULL(Category, 'Other'), IFNULL(SUM(Amount), 0)
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

        public static Dictionary<string, int> GetCategorySpending(int year, int month)
        {
            var spending = new Dictionary<string, int>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT IFNULL(Category, 'Other'), IFNULL(SUM(Amount), 0)
                    FROM Expenses
                    WHERE strftime('%Y', ExpenseDate) = @Year
                      AND strftime('%m', ExpenseDate) = @Month
                    GROUP BY Category
                    ORDER BY SUM(Amount) DESC";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Year", year.ToString());
                    command.Parameters.AddWithValue("@Month", month.ToString("00"));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            spending[reader.GetString(0)] = Convert.ToInt32(reader.GetValue(1));
                        }
                    }
                }
            }

            return spending;
        }

        public static List<ExpenseItem> GetRecentExpenses(int limit)
        {
            return ReadExpenses(
                $"SELECT {ExpenseColumns} FROM Expenses ORDER BY ExpenseDate DESC LIMIT @Limit",
                command => command.Parameters.AddWithValue("@Limit", limit)
            );
        }

        public static void SaveBudget(BudgetItem budget)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string selectCommand = @"
                    SELECT Id
                    FROM Budgets
                    WHERE Year = @Year
                      AND Month = @Month
                      AND ((Category IS NULL AND @Category IS NULL) OR Category = @Category)";

                using (var checkCommand = new SqliteCommand(selectCommand, connection))
                {
                    checkCommand.Parameters.AddWithValue("@Year", budget.Year);
                    checkCommand.Parameters.AddWithValue("@Month", budget.Month);
                    checkCommand.Parameters.AddWithValue("@Category", ToDbValue(budget.Category));

                    var existingId = checkCommand.ExecuteScalar();
                    if (existingId == null)
                    {
                        InsertBudget(connection, budget);
                    }
                    else
                    {
                        using (var updateCommand = new SqliteCommand("UPDATE Budgets SET Amount = @Amount WHERE Id = @Id", connection))
                        {
                            updateCommand.Parameters.AddWithValue("@Amount", budget.Amount);
                            updateCommand.Parameters.AddWithValue("@Id", existingId);
                            updateCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public static void SetBudget(BudgetItem budget)
        {
            SaveBudget(budget);
        }

        public static int GetMonthlyBudget(int year, int month)
        {
            return ExecuteScalarInt(
                "SELECT IFNULL(SUM(Amount), 0) FROM Budgets WHERE Year = @Year AND Month = @Month AND (Category IS NULL OR Category = '')",
                command =>
                {
                    command.Parameters.AddWithValue("@Year", year);
                    command.Parameters.AddWithValue("@Month", month);
                }
            );
        }

        public static Dictionary<string, int> GetCategoryBudgets(int year, int month)
        {
            var budgets = new Dictionary<string, int>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT Category, Amount
                    FROM Budgets
                    WHERE Year = @Year
                      AND Month = @Month
                      AND Category IS NOT NULL
                      AND Category <> ''";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Year", year);
                    command.Parameters.AddWithValue("@Month", month);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            budgets[reader.GetString(0)] = Convert.ToInt32(reader.GetValue(1));
                        }
                    }
                }
            }

            return budgets;
        }

        public static List<BudgetItem> GetMonthlyBudgets(int year, int month)
        {
            var budgets = new List<BudgetItem>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string selectCommand = "SELECT Id, Year, Month, Category, Amount, CreatedAt FROM Budgets WHERE Year = @Year AND Month = @Month";

                using (var command = new SqliteCommand(selectCommand, connection))
                {
                    command.Parameters.AddWithValue("@Year", year);
                    command.Parameters.AddWithValue("@Month", month);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            budgets.Add(new BudgetItem
                            {
                                Id = Convert.ToInt32(reader.GetValue(0)),
                                Year = Convert.ToInt32(reader.GetValue(1)),
                                Month = Convert.ToInt32(reader.GetValue(2)),
                                Category = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                Amount = Convert.ToInt32(reader.GetValue(4)),
                                CreatedAt = DateTime.Parse(reader.GetString(5))
                            });
                        }
                    }
                }
            }

            return budgets;
        }

        public static int AddFixedExpense(FixedExpenseItem fixedExpense)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string insertCommand = @"
                    INSERT INTO FixedExpenses
                        (Title, Amount, Category, PaymentMethod, DayOfMonth, Memo, IsActive, CreatedAt)
                    VALUES
                        (@Title, @Amount, @Category, @PaymentMethod, @DayOfMonth, @Memo, @IsActive, @CreatedAt)";

                using (var command = new SqliteCommand(insertCommand, connection))
                {
                    command.Parameters.AddWithValue("@Title", fixedExpense.Title);
                    command.Parameters.AddWithValue("@Amount", fixedExpense.Amount);
                    command.Parameters.AddWithValue("@Category", ToDbValue(fixedExpense.Category));
                    command.Parameters.AddWithValue("@PaymentMethod", ToDbValue(fixedExpense.PaymentMethod));
                    command.Parameters.AddWithValue("@DayOfMonth", fixedExpense.DayOfMonth);
                    command.Parameters.AddWithValue("@Memo", ToDbValue(fixedExpense.Memo));
                    command.Parameters.AddWithValue("@IsActive", fixedExpense.IsActive ? 1 : 0);
                    command.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.ExecuteNonQuery();
                }

                using (var idCommand = new SqliteCommand("SELECT last_insert_rowid()", connection))
                {
                    return Convert.ToInt32(idCommand.ExecuteScalar());
                }
            }
        }

        public static int SaveFixedExpenseFromExpense(ExpenseItem expense)
        {
            var fixedExpense = new FixedExpenseItem
            {
                Id = expense.FixedExpenseRefId ?? 0,
                Title = expense.Title,
                Amount = expense.Amount,
                Category = expense.Category,
                PaymentMethod = expense.PaymentMethod,
                DayOfMonth = expense.ExpenseDate.Day,
                Memo = expense.Memo,
                IsActive = true,
                CreatedAt = DateTime.Now
            };

            if (fixedExpense.Id > 0 && FixedExpenseExists(fixedExpense.Id))
            {
                UpdateFixedExpense(fixedExpense);
                return fixedExpense.Id;
            }

            return AddFixedExpense(fixedExpense);
        }

        public static void UpdateFixedExpense(FixedExpenseItem fixedExpense)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string updateCommand = @"
                    UPDATE FixedExpenses
                    SET Title = @Title,
                        Amount = @Amount,
                        Category = @Category,
                        PaymentMethod = @PaymentMethod,
                        DayOfMonth = @DayOfMonth,
                        Memo = @Memo,
                        IsActive = @IsActive
                    WHERE Id = @Id";

                using (var command = new SqliteCommand(updateCommand, connection))
                {
                    command.Parameters.AddWithValue("@Title", fixedExpense.Title);
                    command.Parameters.AddWithValue("@Amount", fixedExpense.Amount);
                    command.Parameters.AddWithValue("@Category", ToDbValue(fixedExpense.Category));
                    command.Parameters.AddWithValue("@PaymentMethod", ToDbValue(fixedExpense.PaymentMethod));
                    command.Parameters.AddWithValue("@DayOfMonth", fixedExpense.DayOfMonth);
                    command.Parameters.AddWithValue("@Memo", ToDbValue(fixedExpense.Memo));
                    command.Parameters.AddWithValue("@IsActive", fixedExpense.IsActive ? 1 : 0);
                    command.Parameters.AddWithValue("@Id", fixedExpense.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<FixedExpenseItem> GetActiveFixedExpenses()
        {
            var fixedExpenses = new List<FixedExpenseItem>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string selectCommand = @"
                    SELECT Id, Title, Amount, Category, PaymentMethod, DayOfMonth, Memo, IsActive, CreatedAt
                    FROM FixedExpenses
                    WHERE IsActive = 1
                    ORDER BY DayOfMonth ASC";

                using (var command = new SqliteCommand(selectCommand, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fixedExpenses.Add(new FixedExpenseItem
                        {
                            Id = Convert.ToInt32(reader.GetValue(0)),
                            Title = reader.GetString(1),
                            Amount = Convert.ToInt32(reader.GetValue(2)),
                            Category = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            PaymentMethod = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            DayOfMonth = Convert.ToInt32(reader.GetValue(5)),
                            Memo = reader.IsDBNull(6) ? "" : reader.GetString(6),
                            IsActive = Convert.ToInt32(reader.GetValue(7)) == 1,
                            CreatedAt = DateTime.Parse(reader.GetString(8))
                        });
                    }
                }
            }

            return fixedExpenses;
        }

        public static int GetTotalFixedExpenseAmount()
        {
            return ExecuteScalarInt("SELECT IFNULL(SUM(Amount), 0) FROM FixedExpenses WHERE IsActive = 1");
        }

        public static void GenerateMonthlyFixedExpenses(int year, int month)
        {
            foreach (var fixedExpense in GetActiveFixedExpenses())
            {
                if (MonthlyFixedExpenseExists(fixedExpense.Id, year, month))
                {
                    continue;
                }

                int day = Math.Min(fixedExpense.DayOfMonth, DateTime.DaysInMonth(year, month));
                var expense = new ExpenseItem
                {
                    Title = fixedExpense.Title,
                    Amount = fixedExpense.Amount,
                    Category = fixedExpense.Category,
                    PaymentMethod = fixedExpense.PaymentMethod,
                    ExpenseDate = new DateTime(year, month, day),
                    Memo = fixedExpense.Memo,
                    IsFixed = true,
                    FixedExpenseRefId = fixedExpense.Id
                };

                AddExpense(expense, fixedExpense.Id);
            }
        }

        public static void ProcessMonthlyFixedExpenses()
        {
            var today = DateTime.Today;
            GenerateMonthlyFixedExpenses(today.Year, today.Month);
        }

        public static void AddAiAnalysisLog(AiAnalysisLog log)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string insertCommand = @"
                    INSERT INTO AiAnalysisLogs (Year, Month, Summary, CreatedAt)
                    VALUES (@Year, @Month, @Summary, @CreatedAt)";

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

        public static string? GetLastAiAnalysis(int year, int month)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string selectCommand = @"
                    SELECT Summary
                    FROM AiAnalysisLogs
                    WHERE Year = @Year AND Month = @Month
                    ORDER BY CreatedAt DESC
                    LIMIT 1";

                using (var command = new SqliteCommand(selectCommand, connection))
                {
                    command.Parameters.AddWithValue("@Year", year);
                    command.Parameters.AddWithValue("@Month", month);
                    return command.ExecuteScalar()?.ToString();
                }
            }
        }

        private static bool MonthlyFixedExpenseExists(int fixedExpenseId, int year, int month)
        {
            return ExecuteScalarInt(
                @"SELECT COUNT(*)
                  FROM Expenses
                  WHERE FixedExpenseRefId = @FixedExpenseRefId
                    AND strftime('%Y', ExpenseDate) = @Year
                    AND strftime('%m', ExpenseDate) = @Month",
                command =>
                {
                    command.Parameters.AddWithValue("@FixedExpenseRefId", fixedExpenseId);
                    command.Parameters.AddWithValue("@Year", year.ToString());
                    command.Parameters.AddWithValue("@Month", month.ToString("00"));
                }
            ) > 0;
        }

        private static bool FixedExpenseExists(int fixedExpenseId)
        {
            return ExecuteScalarInt(
                "SELECT COUNT(*) FROM FixedExpenses WHERE Id = @Id",
                command => command.Parameters.AddWithValue("@Id", fixedExpenseId)
            ) > 0;
        }

        private static void InsertBudget(SqliteConnection connection, BudgetItem budget)
        {
            string insertCommand = @"
                INSERT INTO Budgets (Year, Month, Category, Amount, CreatedAt)
                VALUES (@Year, @Month, @Category, @Amount, @CreatedAt)";

            using (var command = new SqliteCommand(insertCommand, connection))
            {
                command.Parameters.AddWithValue("@Year", budget.Year);
                command.Parameters.AddWithValue("@Month", budget.Month);
                command.Parameters.AddWithValue("@Category", ToDbValue(budget.Category));
                command.Parameters.AddWithValue("@Amount", budget.Amount);
                command.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                command.ExecuteNonQuery();
            }
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
                    var value = command.ExecuteScalar();
                    return value == null || value == DBNull.Value ? 0 : Convert.ToInt32(value);
                }
            }
        }

        private static void ExecuteNonQuery(SqliteConnection connection, string query)
        {
            using (var command = new SqliteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        private static void AddColumnIfMissing(SqliteConnection connection, string tableName, string columnName, string columnDefinition)
        {
            using (var command = new SqliteCommand($"PRAGMA table_info({tableName})", connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (string.Equals(reader.GetString(1), columnName, StringComparison.OrdinalIgnoreCase))
                    {
                        return;
                    }
                }
            }

            ExecuteNonQuery(connection, $"ALTER TABLE {tableName} ADD COLUMN {columnDefinition}");
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
                FixedExpenseRefId = reader.IsDBNull(8) ? (int?)null : Convert.ToInt32(reader.GetValue(8)),
                CreatedAt = DateTime.Parse(reader.GetString(9))
            };
        }

        private static object ToDbValue(string? value)
        {
            return string.IsNullOrWhiteSpace(value) ? (object)DBNull.Value : value;
        }
    }
}
