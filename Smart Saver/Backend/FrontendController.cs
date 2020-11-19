using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;
using Smart_Saver.Frontend;

namespace Smart_Saver.Backend
{
    class FrontendController
    {
        /*
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         * Instance Configuration
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         */
        private FrontendController() { }
        private static FrontendController _instance = null; //Singleton pattern

        public static FrontendController Instance() //Lazy Load initiation
        {
            if (_instance == null)
            {
                _instance = new FrontendController();
            }
            return _instance;
        }
        /*
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         * ExpenseDB methods and variables
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         */

        /*-----------------------------------------------------------------------------------------
         * Main Form
         ------------------------------------------------------------------------------------------*/

        public void userInfo(TextBox Usertextarea)
        {
            try
            {
                using (var reader = new StreamReader(userDBFilePath))
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
                Logger.Instance().Log(e.ToString());
            }
        }
        public List<String> Get_Items_For_Menu()
        {
            List<String> menu_item = new List<String>();
            menu_item.Add("Add Income");

            return menu_item;
        }
        public List<String> Get_Items_For_Expense()
        {
            List<String> menu_item = new List<String>();
            menu_item.Add("Add Expense");
            return menu_item;
        }
        public List<String> Get_Items_For_Settings()
        {
            List<String> menu_item = new List<String>();
            menu_item.Add("Edit Profile");
            menu_item.Add("Log out");

            return menu_item;
        }
        /*-----------------------------------------------------------------------------------------
         * Savings Deposit Representation
         ------------------------------------------------------------------------------------------*/

        public decimal GetMonthlyExpenses()
        {
            return ExpenseClass.Instance().MonthlyExpenses();
        }
        public decimal GetMonthlyIncome()
        {
            return IncomeClass.Instance().MonthlyIncome();
        }
        public decimal GetMonthlyBalance()
        {
            return (IncomeClass.Instance().MonthlyIncome() - ExpenseClass.Instance().MonthlyExpenses());
        }
        public decimal GetGoalAmount()
        {
            return GoalClass.Instance().ParseGoal().amount;
        }
        public decimal GetAmountToReachGoal()
        {
            return (GetGoalAmount() - GetMonthlyBalance());
        }
        public int TimeLeftUntilGoal()
        {
            return (GoalClass.Instance().GetMonthCountUntilGoalIsReached());
        }

        /*-----------------------------------------------------------------------------------------
         * CategoriesLoad
         ------------------------------------------------------------------------------------------*/
        public void LoadCategories(Form form, EventHandler btn_msg, EventHandler btn_msg_Back, EventHandler btn_AddCategory)
        {
            CategoriesClass.Instance().load(form, btn_msg, btn_msg_Back, btn_AddCategory);
        }

        private readonly string userDBFilePath = DBPathConfig.Instance().UserDBPath;
    }
}
