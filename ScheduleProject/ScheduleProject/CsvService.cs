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
            var lines = File.ReadAllLines(filePath, Encoding.UTF8);

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }

                var columns = ParseLine(lines[i]);
                if (columns.Count < 6)
                {
                    throw new InvalidDataException($"{i + 1}번째 줄의 CSV 형식이 올바르지 않습니다.");
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

        private static List<string> ParseLine(string line)
        {
            var values = new List<string>();
            var builder = new StringBuilder();
            bool insideQuote = false;

            for (int i = 0; i < line.Length; i++)
            {
                char current = line[i];

                if (current == '"')
                {
                    if (insideQuote && i + 1 < line.Length && line[i + 1] == '"')
                    {
                        builder.Append('"');
                        i++;
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
                else
                {
                    builder.Append(current);
                }
            }

            values.Add(builder.ToString());
            return values;
        }
    }
}
