using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MonthCheckExtensions;


//static class DBmanager - DataBase manager

namespace Smart_Saver
{
    class DBmanager
    {
        /*
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         * Instance Configuration
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         */
        private DBmanager() { }
        private static DBmanager _instance = null; //Singleton pattern

        public static DBmanager Instance() //Lazy Load initiation
        {
            if (_instance == null)
            {
                _instance = new DBmanager();
            }
            return _instance;
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         * Functions for User Database
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         */
        public void AddUserToDB(User user)
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
                Logger.Instance().Log(e.ToString());
            }
        }
        public void ClearUserDB()
        {
            try
            {
                File.Delete(userDBFilePath);
                File.Create(userDBFilePath);
            }
            catch (Exception e)
            {
                Logger.Instance().Log(e.ToString());
            }
        }
        public User GetUserById(int id)
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
                Logger.Instance().Log(e.ToString());
                return null;
            }

        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------
         * DBmanager class variables
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------
         */

        private readonly string userDBFilePath = "..\\..\\..\\UserDB.csv";
        public readonly string Index = "..\\..\\..\\index.html";
        public readonly string OUTPUT = "..\\..\\..\\output.html";
    }

}
