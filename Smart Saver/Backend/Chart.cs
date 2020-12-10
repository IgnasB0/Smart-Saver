using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace Smart_Saver.Backend
{
    class Chart
    {
        public Chart()
        {
            string fullpath = DBmanager.Instance().Index;
            string fullpath2 = DBmanager.Instance().OUTPUT;
            //Read HTML from file
            var content = File.ReadAllText(fullpath);
            string _write = "var data = google.visualization.arrayToDataTable([";
            _write += "['Date', 'Balance'],";
            content = content.Replace("var data = google.visualization.arrayToDataTable([]);", ChartRepresenation(_write));
            File.WriteAllText(fullpath2, content);
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/c" + "\"" + fullpath2 + "\"";
            System.Diagnostics.Process.Start(startInfo);
        }

        private string ChartRepresenation(string _write)
        {
            List<ExpenseClass.Expense> _expenses = ExpenseClass.Instance().ParseExpenses();
            List<IncomeClass.Income> _incomes = IncomeClass.Instance().ParseIncomes();
            var expenses = Expenses(_expenses);
            var incomes = Incomes(_incomes);
            if (expenses.Count() == incomes.Count())
            {
                _write = CalculateEqual(expenses, incomes, _write);
            }
            else if (incomes.Count() > expenses.Count())
            {
                _write = CalculateIncomeMore(expenses, incomes, _write);
            }
            else
            {
                _write = CalculateExpenseMore(expenses, incomes, _write);
            }
            return _write;
        }
        private string CalculateExpenseMore(IEnumerable<Result> expenses, IEnumerable<Result> incomes, string _write)
        {
            int i = 1;
            bool sign = true;
            foreach (var _expense in expenses)
            {
                foreach (var _incomes in incomes)
                {
                    if (_incomes.monthAndYear == _expense.monthAndYear && _expense.Type == "Expense" && _incomes.Type == "Income")
                    {
                        if (i == expenses.Count())
                        {
                            _write += "['" + _incomes.monthAndYear + "'," + (_incomes.amount - _expense.amount) + "]]);";
                        }
                        else
                        {
                            _write += "['" + _incomes.monthAndYear + "'," + (_incomes.amount - _expense.amount) + "],";
                        }
                        i++;
                        sign = true;
                        break;
                    }
                    else
                    {
                        sign = false;
                    }
                }
                if (sign == false && i != expenses.Count())
                {
                    _write += "['" + _expense.monthAndYear + "'," + (-_expense.amount) + "],";
                    sign = true;
                    i++;
                }
                else if (i == expenses.Count() && sign == false)
                {
                    _write += "['" + _expense.monthAndYear + "'," + (-_expense.amount) + "]]);";
                }
            }
            return _write;
        }

        private string CalculateIncomeMore(IEnumerable<Result> expenses, IEnumerable<Result> incomes, string _write)
        {
            int i = 1;
            bool sign = true;
            foreach (var _incomes in incomes)
            {
                foreach (var _expenses in expenses)
                {
                    if (_expenses.monthAndYear == _incomes.monthAndYear && _expenses.Type == "Expense" && _incomes.Type == "Income")
                    {
                        if (i == incomes.Count())
                        {
                            _write += "['" + _expenses.monthAndYear + "'," + (_incomes.amount - _expenses.amount) + "]]);";
                        }
                        else
                        {
                            _write += "['" + _expenses.monthAndYear + "'," + (_incomes.amount - _expenses.amount) + "],";
                        }
                        i++;
                        sign = true;
                        break;
                    }
                    else
                    {
                        sign = false;
                    }
                }
                if (sign == false && i != incomes.Count())
                {
                    _write += "['" + _incomes.monthAndYear + "'," + (_incomes.amount - 0) + "],";
                    sign = true;
                    i++;
                }
                else if (i == incomes.Count() && sign == false)
                {
                    _write += "['" + _incomes.monthAndYear + "'," + (_incomes.amount - 0) + "]]);";
                }
            }
            return _write;
        }
        private string CalculateEqual(IEnumerable<Result> expenses, IEnumerable<Result> incomes, string _write)
        {
            int i = 1;
            foreach (var _incomes in incomes)
            {
                foreach (var _expenses in expenses)
                {
                    if (_expenses.monthAndYear == _incomes.monthAndYear && _expenses.Type == "Expense" && _incomes.Type == "Income")
                    {
                        if (i == incomes.Count())
                        {
                            _write += "['" + _expenses.monthAndYear + "'," + (_incomes.amount - _expenses.amount) + "]]);";
                        }
                        else
                        {
                            _write += "['" + _expenses.monthAndYear + "'," + (_incomes.amount - _expenses.amount) + "],";
                        }
                        i++;
                    }
                }
            }
            return _write;
        }


        public IEnumerable<Result> Incomes(List<IncomeClass.Income> incomes)
        {
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

            return _incomes;
        }

        public IEnumerable<Result> Expenses(List<ExpenseClass.Expense> expenses)
        {
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
            return _expenses;
        }
    }
}
