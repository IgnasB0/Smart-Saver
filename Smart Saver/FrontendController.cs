using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace Smart_Saver
{
    class FrontendController
    {

        /*-----------------------------------------------------------------------------------------
         * Main Form
         ------------------------------------------------------------------------------------------*/

        public static void userInfo(TextBox Usertextarea)
        {
            try
            {
                using (var reader = new StreamReader("..\\..\\..\\UserDB.csv"))
                {
                    List<string> listA = new List<string>();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        listA.Add(values[0]);
                        listA.Add(values[1]);
                        listA.Add(values[2]);
                    }
                    Usertextarea.AppendText(listA[1] + " " + listA[2]);
                }
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
            }
        }
        public static List<String> Get_Items_For_Menu()
        {
            List<String> menu_item = new List<String>();
            menu_item.Add("Add Income");

            return menu_item;
        }
        public static List<String> Get_Items_For_Expense()
        {
            List<String> menu_item = new List<String>();
            menu_item.Add("Add Expense");
            menu_item.Add("Add Category");

            return menu_item;
        }
        public static List<String> Get_Items_For_Settings()
        {
            List<String> menu_item = new List<String>();
            menu_item.Add("Edit Profile");
            menu_item.Add("Log out");

            return menu_item;
        }

        //----------Chart---------------------------------------------------
        public static void ChartRepresentation()
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
        public static IEnumerable<Result> WriteBalance()
        {
            List<DBmanager.Income> incomes = DBmanager.ParseIncomes();
            List<DBmanager.Expense> expenses = DBmanager.ParseExpenses();
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

        /*-----------------------------------------------------------------------------------------
         * Savings Deposit Representation
         ------------------------------------------------------------------------------------------*/

        public static decimal GetMonthlyExpenses()
        {
            return DBmanager.MonthlyExpenses();
        }
        public static decimal GetMonthlyIncome()
        {
            return DBmanager.MonthlyIncome();
        }
        public static decimal GetMonthlyBalance()
        {
            return (DBmanager.MonthlyIncome() - DBmanager.MonthlyExpenses());
        }
        public static decimal GetGoalAmount()
        {
            return DBmanager.ParseGoal().amount;
        }
        public static decimal GetAmountToReachGoal()
        {
            return (GetGoalAmount() - GetMonthlyBalance());
        }
        public static TimeSpan TimeLeftUntilGoal()
        {
            return (DBmanager.ParseGoal().date.Subtract(DateTime.Now)); //Wrong implementation, for now. Fix including calculations over monthly balances.
        }
    }
}
