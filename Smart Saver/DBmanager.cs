using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;


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
        public static void AddCategoryToDB(string category)
        {
            try
            {
                //Check if file exists, if not - create
                if (!File.Exists(expenseDBFilePath))
                {
                    FileStream fs = File.Create(expenseDBFilePath);
                    fs.Close();
                }
                //Check if category already exists in the DB
                List<string> items = new List<string>();
                items = File.ReadAllLines(expenseDBFilePath).ToList();
                foreach (string item in items)
                {
                    string[] elements = item.Split(',');
                    if (elements[0] == category) throw new Exception("Specified category already exists");
                }

                //If catgory is new, then it is added to DB
                using (StreamWriter expenseDBFileWriter = new StreamWriter(expenseDBFilePath, true))
                {
                    expenseDBFileWriter.WriteLine($"{category},{0}");
                    expenseDBFileWriter.Flush();
                }
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
            }
        }
        public static void AddCategoryToDB(string category, int amount)
        {
            try
            {
                //Check if file exists, if not - create
                if (!File.Exists(expenseDBFilePath))
                {
                    FileStream fs = File.Create(expenseDBFilePath);
                    fs.Close();
                }
                //Check if category already exists in the DB
                List<string> items = new List<string>();
                items = File.ReadAllLines(expenseDBFilePath).ToList();
                foreach (string item in items)
                {
                    string[] elements = item.Split(',');
                    if (elements[0] == category) throw new Exception("Specified category already exists");
                }

                //If catgory is new, then it is added to DB
                using (StreamWriter expenseDBFileWriter = new StreamWriter(expenseDBFilePath, true))
                {
                    expenseDBFileWriter.WriteLine($"{category},{amount}");
                    expenseDBFileWriter.Flush();
                }
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
            }
        }
        public static int GetExpenseAmountFromDB(string category)
        {
            try
            {
                //Check if category exists in the DB, then parse the amount of expense
                List<string> items = new List<string>();
                items = File.ReadAllLines(expenseDBFilePath).ToList();
                foreach (string item in items)
                {
                    string[] elements = item.Split(',');
                    if (elements[0] == category)
                    {
                        return int.Parse(elements[1]);
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
        public static void IncreaseExpenseAmount(string category, int amount)
        {
            try
            {
                //Find category in DB
                List<string> items = new List<string>();
                items = File.ReadAllLines(expenseDBFilePath).ToList();
                bool categoryWasNotFound = true;
                for (int i = 0; i < items.Count; i++)
                {
                    string[] elements = items[i].Split(',');
                    if (elements[0] == category)
                    {
                        int increasedAmount = int.Parse(elements[1]);
                        increasedAmount += amount;
                        items[i] = $"{elements[0]}, {increasedAmount}";
                        categoryWasNotFound = false;
                        break;
                    }
                }
                //If category wasn't fount - throw exception
                if (categoryWasNotFound) throw new Exception("Specified category was not found");
                //Else proceed with adding the data
                File.WriteAllLines(expenseDBFilePath, items);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
            }
        }
        public static void ChangeExpenseAmount(string category, int amount)
        {
            try
            {
                //Find category in DB
                List<string> items = new List<string>();
                items = File.ReadAllLines(expenseDBFilePath).ToList();
                bool categoryWasNotFound = true;
                for (int i = 0; i < items.Count; i++)
                {
                    string[] elements = items[i].Split(',');
                    if (elements[0] == category)
                    {
                        items[i] = $"{elements[0]}, {amount}";
                        categoryWasNotFound = false;
                        break;
                    }
                }
                //If category wasn't fount - throw exception
                if (categoryWasNotFound) throw new Exception("Specified category was not found");
                //Else proceed with adding the data
                File.WriteAllLines(expenseDBFilePath, items);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
            }
        }
        public static void RemoveExpenseCategory(string category)
        {
            try
            {
                //Find category in DB
                List<string> items = new List<string>();
                items = File.ReadAllLines(expenseDBFilePath).ToList();
                bool categoryWasNotFound = true;
                for (int i = 0; i < items.Count; i++)
                {
                    string[] elements = items[i].Split(',');
                    if (elements[0] == category)
                    {
                        items.RemoveAt(i);
                        categoryWasNotFound = false;
                        break;
                    }
                }
                //If category wasn't fount - throw exception
                if (categoryWasNotFound) throw new Exception("Specified category was not found");
                //Else proceed with adding the data
                File.WriteAllLines(expenseDBFilePath, items);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
            }
        }
        public static void InitialiseExpenseDB()
        {
            DBmanager.AddCategoryToDB("Food");
            DBmanager.AddCategoryToDB("Transport");
            DBmanager.AddCategoryToDB("Clothing");
            DBmanager.AddCategoryToDB("Leisure Activities");
            DBmanager.AddCategoryToDB("Taxes");
            DBmanager.AddCategoryToDB("Entertainment");
            DBmanager.AddCategoryToDB("Work");
            DBmanager.AddCategoryToDB("Investments");
            DBmanager.AddCategoryToDB("Savings");
            DBmanager.AddCategoryToDB("Household Items");
            DBmanager.AddCategoryToDB("Real Estate");
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
    }
}
