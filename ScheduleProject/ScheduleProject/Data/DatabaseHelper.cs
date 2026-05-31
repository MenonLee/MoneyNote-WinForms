using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using ScheduleProject.Models;
using System.IO;

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
                string tableCommand = @"
                    CREATE TABLE IF NOT EXISTS Tasks (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT NOT NULL,
                        Description TEXT,
                        DueDate TEXT NOT NULL,
                        Category TEXT,
                        Priority TEXT,
                        IsCompleted INTEGER NOT NULL DEFAULT 0,
                        CreatedAt TEXT NOT NULL
                    )";

                using (var command = new SqliteCommand(tableCommand, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void AddTask(TaskItem task)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string insertCommand = @"
                    INSERT INTO Tasks (Title, Description, DueDate, Category, Priority, IsCompleted, CreatedAt)
                    VALUES (@Title, @Description, @DueDate, @Category, @Priority, @IsCompleted, @CreatedAt)";

                using (var command = new SqliteCommand(insertCommand, connection))
                {
                    command.Parameters.AddWithValue("@Title", task.Title);
                    command.Parameters.AddWithValue("@Description", task.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DueDate", task.DueDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@Category", task.Category ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Priority", task.Priority ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@IsCompleted", task.IsCompleted ? 1 : 0);
                    command.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    
                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<TaskItem> GetAllTasks()
        {
            var tasks = new List<TaskItem>();

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string selectCommand = "SELECT * FROM Tasks ORDER BY DueDate ASC";

                using (var command = new SqliteCommand(selectCommand, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tasks.Add(new TaskItem
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Description = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                DueDate = DateTime.Parse(reader.GetString(3)),
                                Category = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                Priority = reader.IsDBNull(5) ? "" : reader.GetString(5),
                                IsCompleted = reader.GetInt32(6) == 1,
                                CreatedAt = DateTime.Parse(reader.GetString(7))
                            });
                        }
                    }
                }
            }
            return tasks;
        }

        public static TaskItem GetTaskById(int id)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string selectCommand = "SELECT * FROM Tasks WHERE Id = @Id";

                using (var command = new SqliteCommand(selectCommand, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new TaskItem
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Description = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                DueDate = DateTime.Parse(reader.GetString(3)),
                                Category = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                Priority = reader.IsDBNull(5) ? "" : reader.GetString(5),
                                IsCompleted = reader.GetInt32(6) == 1,
                                CreatedAt = DateTime.Parse(reader.GetString(7))
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static void UpdateTask(TaskItem task)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string updateCommand = @"
                    UPDATE Tasks 
                    SET Title = @Title, 
                        Description = @Description, 
                        DueDate = @DueDate, 
                        Category = @Category, 
                        Priority = @Priority, 
                        IsCompleted = @IsCompleted 
                    WHERE Id = @Id";

                using (var command = new SqliteCommand(updateCommand, connection))
                {
                    command.Parameters.AddWithValue("@Title", task.Title);
                    command.Parameters.AddWithValue("@Description", task.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DueDate", task.DueDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@Category", task.Category ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Priority", task.Priority ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@IsCompleted", task.IsCompleted ? 1 : 0);
                    command.Parameters.AddWithValue("@Id", task.Id);
                    
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteTask(int id)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string deleteCommand = "DELETE FROM Tasks WHERE Id = @Id";

                using (var command = new SqliteCommand(deleteCommand, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<TaskItem> SearchTasks(string keyword)
        {
            var tasks = new List<TaskItem>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string searchCommand = "SELECT * FROM Tasks WHERE Title LIKE @Keyword OR Description LIKE @Keyword ORDER BY DueDate ASC";

                using (var command = new SqliteCommand(searchCommand, connection))
                {
                    command.Parameters.AddWithValue("@Keyword", $"%{keyword}%");
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tasks.Add(new TaskItem
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Description = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                DueDate = DateTime.Parse(reader.GetString(3)),
                                Category = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                Priority = reader.IsDBNull(5) ? "" : reader.GetString(5),
                                IsCompleted = reader.GetInt32(6) == 1,
                                CreatedAt = DateTime.Parse(reader.GetString(7))
                            });
                        }
                    }
                }
            }
            return tasks;
        }

        public static int GetTotalTaskCount()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string countCommand = "SELECT COUNT(*) FROM Tasks";
                using (var command = new SqliteCommand(countCommand, connection))
                {
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public static int GetCompletedTaskCount()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string countCommand = "SELECT COUNT(*) FROM Tasks WHERE IsCompleted = 1";
                using (var command = new SqliteCommand(countCommand, connection))
                {
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public static Dictionary<string, int> GetCategoryCount()
        {
            var counts = new Dictionary<string, int>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string countCommand = "SELECT Category, COUNT(*) FROM Tasks GROUP BY Category";
                using (var command = new SqliteCommand(countCommand, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string category = reader.IsDBNull(0) ? "None" : reader.GetString(0);
                            counts[category] = reader.GetInt32(1);
                        }
                    }
                }
            }
            return counts;
        }
    }
}
