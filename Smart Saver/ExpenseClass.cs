using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MonthCheckExtensions;


namespace Smart_Saver
{
    class ExpenseClass
    {
        public struct Expense
        {
            public String name;
            public Decimal amount;
            public DateTime expenseDate;
            public String category;
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
                }
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
            }

            foreach (Expense oneExpense in expenses)
            {
                Console.WriteLine(oneExpense.name + ' ' + oneExpense.amount + ' ' + oneExpense.expenseDate.ToShortDateString() + ' ' + oneExpense.category);
            }

            return expenses;
        }

        public static decimal MonthlyExpenses()
        {
            var expenses = ParseExpenses(); // Generics

            decimal expenseTotal = 0;

            foreach (Expense oneExpense in expenses)
            {
                if (oneExpense.expenseDate.CheckIfCurrentMonth())
                {
                    expenseTotal += oneExpense.amount;

                }
            }

            return expenseTotal;
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
                }
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
            }
        }
        public static void AddExpense(string expenseName, decimal expenseAmount, DateTime expenseDate, string expenseCategory)
        {
            try
            {
                //Generate entry string
                string expenseToAddString = $"{expenseName},{expenseAmount},{expenseDate},{expenseCategory}";
                //Add new expense
                using (StreamWriter expenseDBFileWriter = new StreamWriter(expenseDBFilePath, true))
                {
                    expenseDBFileWriter.WriteLine(expenseToAddString);
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

        public static readonly string expenseDBFilePath = "..\\..\\..\\ExpenseDB.csv";
        public static List<string> ExpenseCategories = new List<string>
        { "Food", "Transport", "Clothing", "Leisure Activities", "Taxes", "Work", "Investments", "Savings", "HouseholdItems", "RealEstate", "Health", "Entertainment" };
    }
}
