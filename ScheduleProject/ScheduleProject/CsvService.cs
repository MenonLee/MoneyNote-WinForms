using System.Globalization;
using System.Text;
using ScheduleProject.Models;

namespace ScheduleProject
{
    public static class CsvService
    {
        public static void ExportExpenses(List<ExpenseItem> expenses, string filePath)
        {
            using var writer = new StreamWriter(filePath, false, Encoding.UTF8);

            writer.WriteLine("Title,Amount,Category,PaymentMethod,ExpenseDate,Memo,IsFixed");

            foreach (var expense in expenses)
            {
                writer.WriteLine(string.Join(",", new[]
                {
                    Escape(expense.Title),
                    expense.Amount.ToString(CultureInfo.InvariantCulture),
                    Escape(expense.Category),
                    Escape(expense.PaymentMethod),
                    expense.ExpenseDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Escape(expense.Memo),
                    expense.IsFixed ? "1" : "0"
                }));
            }
        }

        public static List<ExpenseItem> ImportExpenses(string filePath)
        {
            var expenses = new List<ExpenseItem>();
            var records = ReadCsvRecords(filePath).ToList();

            for (int i = 1; i < records.Count; i++)
            {
                var columns = records[i];
                if (columns.All(string.IsNullOrWhiteSpace))
                {
                    continue;
                }

                if (columns.Count < 6)
                {
                    throw new InvalidDataException($"{i + 1}번째 CSV 레코드 형식이 올바르지 않습니다.");
                }

                expenses.Add(new ExpenseItem
                {
                    Title = columns[0],
                    Amount = int.Parse(columns[1], CultureInfo.InvariantCulture),
                    Category = columns[2],
                    PaymentMethod = columns[3],
                    ExpenseDate = DateTime.Parse(columns[4], CultureInfo.InvariantCulture),
                    Memo = columns[5],
                    IsFixed = columns.Count > 6 && (columns[6] == "1" || columns[6].Equals("true", StringComparison.OrdinalIgnoreCase)),
                    CreatedAt = DateTime.Now
                });
            }

            return expenses;
        }

        private static string Escape(string value)
        {
            value ??= "";

            if (!value.Contains(',') && !value.Contains('"') && !value.Contains('\n') && !value.Contains('\r'))
            {
                return value;
            }

            return "\"" + value.Replace("\"", "\"\"") + "\"";
        }

        private static IEnumerable<List<string>> ReadCsvRecords(string filePath)
        {
            using var reader = new StreamReader(filePath, Encoding.UTF8, true);
            var values = new List<string>();
            var builder = new StringBuilder();
            bool insideQuote = false;
            bool hasData = false;

            while (reader.Read() is int read && read >= 0)
            {
                char current = (char)read;
                hasData = true;

                if (current == '"')
                {
                    if (insideQuote && reader.Peek() == '"')
                    {
                        builder.Append('"');
                        reader.Read();
                    }
                    else
                    {
                        insideQuote = !insideQuote;
                    }
                }
                else if (current == ',' && !insideQuote)
                {
                    values.Add(builder.ToString());
                    builder.Clear();
                }
                else if ((current == '\r' || current == '\n') && !insideQuote)
                {
                    if (current == '\r' && reader.Peek() == '\n')
                    {
                        reader.Read();
                    }

                    values.Add(builder.ToString());
                    yield return values;

                    values = new List<string>();
                    builder.Clear();
                    hasData = false;
                }
                else
                {
                    builder.Append(current);
                }
            }

            if (insideQuote)
            {
                throw new InvalidDataException("CSV 따옴표가 닫히지 않았습니다.");
            }

            if (hasData || values.Count > 0 || builder.Length > 0)
            {
                values.Add(builder.ToString());
                yield return values;
            }
        }
    }
}
