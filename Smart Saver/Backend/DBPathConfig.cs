using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Saver.Backend
{
    class DBPathConfig
    {
        /*
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         * DBPathConfig Configuration
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         */
        private DBPathConfig() { }
        private static DBPathConfig _instance = null; //Singleton pattern

        public static DBPathConfig Instance() //Lazy Load initiation
        {
            if (_instance == null)
            {
                _instance = new DBPathConfig();
            }
            return _instance;
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         * DBPathConfig methods and variables
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         */

        public readonly string ExpenseDBPath = "..\\..\\..\\Databases\\ExpenseDB.csv";
        public readonly string IncomeDBPath = "..\\..\\..\\Databases\\IncomeDB.csv";
        public readonly string BalanceDBPath = "..\\..\\..\\Databases\\BalanceDB.csv";
        public readonly string GoalDBPath = "..\\..\\..\\Databases\\GoalDB.csv";
        public readonly string CategoriesDBPath = "..\\..\\..\\Databases\\CategoriesDB.csv";
        public readonly string RecuringIncomeDBPath = "..\\..\\..\\Databases\\RecuringIncomeDB.csv";
        public readonly string UserDBPath = "..\\..\\..\\Databases\\UserDB.csv";

    }
}
