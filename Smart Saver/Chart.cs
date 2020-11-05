using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace Smart_Saver
{
    class Chart
    {
        public Chart()
        {
            var c = WriteBalance();
            string fullpath = DBmanager.Index;
            string fullpath2 = DBmanager.OUTPUT;
            //Read HTML from file
            var content = File.ReadAllText(fullpath);
            string _write = "var data = google.visualization.arrayToDataTable([";

            _write += "['Date', 'Balance'],";
            int i = 0;
            foreach (var cat in c)
            {
                foreach (var categ in c)
                {
                    if (categ.monthAndYear == cat.monthAndYear && categ.Type == "Expense" && cat.Type == "Income")
                    {
                        i++;
                        i++;
                        if (i - 1 == c.Count() - 1)
                        {
                            _write += "['" + categ.monthAndYear + "'," + (cat.amount - categ.amount) + "]]);";
                        }
                        else
                        {
                            _write += "['" + categ.monthAndYear + "'," + (cat.amount - categ.amount) + "],";
                        }
                    }
                }
            }
            content = content.Replace("var data = google.visualization.arrayToDataTable([]);", _write);
            File.WriteAllText(fullpath2, content);
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/c" + "\"" + fullpath2 + "\"";
            System.Diagnostics.Process.Start(startInfo);
        }
        public IEnumerable<Result> WriteBalance()
        {
            List<IncomeClass.Income> incomes = IncomeClass.ParseIncomes();
            List<ExpenseClass.Expense> expenses = ExpenseClass.ParseExpenses();
            var _expenses = from expense in expenses
                            orderby expense.expenseDate ascending
                            group expense.amount by new
                            {
                                Year = expense.expenseDate.Year,
                                Month = expense.expenseDate.Month                 // LINQ using
                            } into g
                            select new Result
                            {
                                monthAndYear = g.Key.Year + "-" + g.Key.Month,
                                amount = g.Sum(),
                                Type = "Expense"
                            };

            var _incomes = from income in incomes
                           orderby income.date ascending
                           group income.amount by new
                           {
                               Year = income.date.Year,
                               Month = income.date.Month
                           } into g
                           select new Result
                           {
                               monthAndYear = g.Key.Year + "-" + g.Key.Month,
                               amount = g.Sum(),
                               Type = "Income"
                           };

            var o = _expenses.Concat(_incomes).ToList();
            return o;
        }
    }
}
