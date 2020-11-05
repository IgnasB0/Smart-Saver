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
        /*-----------------------------------------------------------------------------------------
         * Savings Deposit Representation
         ------------------------------------------------------------------------------------------*/

        public static decimal GetMonthlyExpenses()
        {
            return ExpenseClass.MonthlyExpenses();
        }
        public static decimal GetMonthlyIncome()
        {
            return IncomeClass.MonthlyIncome();
        }
        public static decimal GetMonthlyBalance()
        {
            return (IncomeClass.MonthlyIncome() - ExpenseClass.MonthlyExpenses());
        }
        public static decimal GetGoalAmount()
        {
            return GoalClass.ParseGoal().amount;
        }
        public static decimal GetAmountToReachGoal()
        {
            return (GetGoalAmount() - GetMonthlyBalance());
        }
        public static TimeSpan TimeLeftUntilGoal()
        {
            return (GoalClass.ParseGoal().date.Subtract(DateTime.Now)); //Wrong implementation, for now. Fix including calculations over monthly balances.
        }
    }
}
