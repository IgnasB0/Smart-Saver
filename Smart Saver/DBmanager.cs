using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms.VisualStyles;



//static class DBmanager - DataBase manager

namespace Smart_Saver
{
    static class DBmanager
    {


        /*
         * ---------------------------------------------------------------------------------------------------------------
         * Functions for User Database
         * ---------------------------------------------------------------------------------------------------------------
         */


        public struct Expense
        {
            public String name;
            public Decimal amount;
            public DateTime expenseDate;
            public String category;
        }

        public struct Income
        {
            public decimal amount;
            public DateTime date;
        }
        public struct Goal
        {
            public string name;
            public DateTime date;
            public decimal amount;
        }

        public static void AddUserToDB(User user)
        {
            try
            {
                using (StreamWriter userDBFileWriter = new StreamWriter(userDBFilePath, true))
                {
                    userDBFileWriter.WriteLine("" + user.Id + "," + user.FirstNames + "," + user.Surname + "," + user.Email + "," + user.Income);
                    userDBFileWriter.Flush();
                }
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
            }
        }
        public static void ClearUserDB()
        {
            try
            {
                File.Delete(userDBFilePath);
                File.Create(userDBFilePath);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
            }
        }
        public static User GetUserById(int id)
        {
            try
            {
                List<string> users = new List<string>();
                User user = null;
                users = File.ReadAllLines(userDBFilePath).ToList();
                foreach (string userData in users)
                {
                    string[] currentUser = userData.Split(',');
                    if (int.Parse(currentUser[0]) == id)
                    {
                        user = new User(id, currentUser[1], currentUser[2], currentUser[3], int.Parse(currentUser[4]));
                        return user;
                    }
                }
                throw new Exception("Specified user cannot be found. Make sure written ID is correct");
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
                return null;
            }

        }

        /*
         * ---------------------------------------------------------------------------------------------------------------
         * Functions for Expense Database
         * ---------------------------------------------------------------------------------------------------------------
         */

        public static Goal ParseGoal()
        {
            //List<Goal> Goals = new Goal();
            Goal newGoal = new Goal();
            try
            {
                List<string> item = new List<string>();
                item = File.ReadAllLines(GoalFilePath).ToList();

                foreach (string it in item)
                {
                    string[] elements = it.Split(',');
                    string goalName = elements[0];
                    decimal goalAmount = decimal.Parse(elements[1]);
                    DateTime goalDate = DateTime.Parse(elements[2]);

                    newGoal.name = goalName;
                    newGoal.amount = goalAmount;
                    newGoal.date = goalDate;
                    
                    //Goals.Add(newGoal);
                }
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
            }
            return newGoal;
        }

        public static List<Income> ParseIncomes()
        {
            List<Income> income = new List<Income>();
            try
            {
                List<string> item = new List<string>();
                item = File.ReadAllLines(incomeFilePath).ToList();

                foreach (string it in item)
                {
                    string[] elements = it.Split(',');
                    decimal incomeAmount = decimal.Parse(elements[0]);
                    DateTime incomeDate = DateTime.Parse(elements[1]);

                    Income newIncome = new Income();
                    newIncome.amount = incomeAmount;
                    newIncome.date = incomeDate;

                    income.Add(newIncome);
                }
            }
            catch(Exception e)
            {
                Logger.Log(e.ToString());
            }
            return income;
        }
        public static List<Expense> ParseExpenses()
        {
            List<Expense> expenses = new List<Expense>();

            try
            {

                List<string> items = new List<string>();
                items = File.ReadAllLines(expenseDBFilePath).ToList();

                foreach (string item in items)
                {
                    String[] elements = item.Split(',');

                    String expenseName = elements[0];
                    Decimal expenseAmount = Decimal.Parse(elements[1]);
                    DateTime expenseDate = DateTime.Parse(elements[2]);
                    String category = elements[3];

                    Expense newExpense = new Expense();
                    newExpense.name = expenseName;
                    newExpense.amount = expenseAmount;
                    newExpense.expenseDate = expenseDate;
                    newExpense.category = category;

                    expenses.Add(newExpense);
                    //Console.WriteLine(item);
                }
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
            }

            foreach(Expense oneExpense in expenses)
            {
                Console.WriteLine(oneExpense.name + ' ' + oneExpense.amount + ' ' + oneExpense.expenseDate.ToShortDateString() + ' ' + oneExpense.category);
            }

            return expenses;
        }



        public static decimal MonthlyExpenses()
        {
            List<Expense> expenses = DBmanager.ParseExpenses();

            decimal expenseTotal = 0;

            foreach (DBmanager.Expense oneExpense in expenses)
            {
                expenseTotal = CheckMonth(oneExpense.expenseDate, oneExpense.amount, expenseTotal);
            }

            return expenseTotal;
        }

        public static decimal MonthlyIncome()
        {
            List<Income> income = DBmanager.ParseIncomes();

            decimal incomeTotal = 0;

            foreach (DBmanager.Income oneIncome in income)
            {
                incomeTotal = CheckMonth(oneIncome.date, oneIncome.amount, incomeTotal);
            }

            return incomeTotal;
        }


        private static decimal CheckMonth(DateTime date, decimal amount, decimal Total)
        {

            DateTime thisDay = Convert.ToDateTime(DateTime.Now);
            int monthdt = date.Month;
            int monththis = thisDay.Month;
            if (monthdt == monththis)
            {
                return Total += amount;
            }
            else
            {
                return Total;
            }
        }

        public static void DisplayExpenseDB()
        {
            try
            {
                List<string> items = new List<string>();
                items = File.ReadAllLines(expenseDBFilePath).ToList();
                foreach (string item in items)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
            }
        }
        public static void AddCategory(string categoryToAdd)
        {
            try
            {
                ExpenseCategories.Add(categoryToAdd);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
            }
        }
        public static decimal GetCategoryExpenseAmount(string neededCategory)
        {
            try
            {
                List<string> items = new List<string>();
                List<Expense> expenses = new List<Expense>();
                
                //Gather information from database
                items = File.ReadAllLines(expenseDBFilePath).ToList();
                foreach (string item in items)
                {
                    String[] elements = item.Split(',');

                    String expenseName = elements[0];
                    Decimal expenseAmount = Decimal.Parse(elements[1]);
                    DateTime expenseDate = DateTime.Parse(elements[2]);
                    String expenseCategory = elements[3];

                    Expense newExpense = new Expense();
                    newExpense.name = expenseName;
                    newExpense.amount = expenseAmount;
                    newExpense.expenseDate = expenseDate;
                    newExpense.category = expenseCategory;
                    expenses.Add(newExpense);
                }

                //Group expenses by categories
                var categories = from expense in expenses
                                 group expense.amount by expense.category into categoryGroup //<-----------------------------------LINQ
                                 select new { Name = categoryGroup.Key, Amount = categoryGroup.Sum() };

                //Check if category exists in the DB, then parse the amount of expense
                foreach (var category in categories)
                {
                    if (category.Name == neededCategory)
                    {
                        return category.Amount;
                    }
                }
                //If category wasn;t found throw exception
                throw new Exception("Specified category was not found in the database.");
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
                return -1;
            }
        }
        public static decimal GetTotalExpenseAmount()
        {
            List<string> items = new List<string>();
            items = File.ReadAllLines(expenseDBFilePath).ToList();
            Decimal totalAmount = 0;
            foreach (string item in items)
            {
                String[] elements = item.Split(',');
                Decimal expenseAmount = Decimal.Parse(elements[1]);
                totalAmount += expenseAmount;
            }
            return totalAmount;
        }
        
        public static void AddExpense(Expense expenseToAdd)
        {
            try
            {
                //Generate entry string
                string expenseToAddString = $"{expenseToAdd.name},{expenseToAdd.amount},{expenseToAdd.expenseDate},{expenseToAdd.category}";
                //Add new expense
                using (StreamWriter expenseDBFileWriter = new StreamWriter(expenseDBFilePath, true))
                {
                    expenseDBFileWriter.WriteLine(expenseToAddString);
                    expenseDBFileWriter.Flush();
                }
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
            }
        }
        public static void RemoveExpenseFromCategory(string neededCategory, string neededName)
        {
            try
            {
                //Find category in DB
                List<string> items = new List<string>();
                items = File.ReadAllLines(expenseDBFilePath).ToList();
                bool categoryWasNotFound = true;
                int numberOfItem = -1;
                for (int i = 0; i < items.Count; i++)
                {
                    string[] elements = items[i].Split(',');
                    if (elements[0] == neededName && elements[3] == neededCategory)
                    {
                        numberOfItem = i;
                        categoryWasNotFound = false;
                        break;
                    }
                }
                //If category wasn't fount - throw exception
                if (categoryWasNotFound) throw new Exception("Specified category was not found");
                //Else proceed with adding the data
                items.RemoveAt(numberOfItem);
                File.WriteAllLines(expenseDBFilePath, items);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
            }
        }
        public static void RemoveExpenseCategory(string neededCategory)
        {
            try
            {
                //Find all items of specified category in DB adn clear them
                List<string> items = new List<string>();
                items = File.ReadAllLines(expenseDBFilePath).ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    string[] elements = items[i].Split(',');
                    if (elements[3] == neededCategory)
                    {
                        items.RemoveAt(i);
                        i--;
                    }
                }
                //Else proceed with adding the data
                File.WriteAllLines(expenseDBFilePath, items);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
            }
        }
        public static void ClearExpenseDB()
        {
            try
            {
                File.Delete(expenseDBFilePath);
                File.Create(expenseDBFilePath);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
            }
        }
        private static readonly string userDBFilePath = "..\\..\\..\\UserDB.csv";
        private static readonly string expenseDBFilePath = "..\\..\\..\\ExpenseDB.csv";
        private static readonly string incomeFilePath = "..\\..\\..\\IncomeDB.csv";
        private static readonly string GoalFilePath = "..\\..\\..\\GoalDB.csv";
        public static List<string> ExpenseCategories = new List<string>
        { "Food", "Transport", "Clothing", "Leisure Activities", "Taxes", "Work", "Investments", "Savings", "HouseholdItems", "RealEstate", "Health" };
    }

}
