using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MonthCheckExtensions;

namespace Smart_Saver.Backend
{
    class RecurringIncome
    {
        /*
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         * Instance Configuration
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         */
        private RecurringIncome() { }
        private static RecurringIncome _instance = null; //Singleton pattern

        public static RecurringIncome Instance() //Lazy Load initiation
        {
            if (_instance == null)
            {
                _instance = new RecurringIncome();
            }
            return _instance;
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         * IncomeDB methods and variables
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         */
        public struct Income
        {
            public decimal amount;
        }
 
        public void AddIncome(decimal amount)
        {
            try
            {
                //Generate entry string
                string incomeToAddString = $"{amount}";
                //Add new expense
                using (StreamWriter incomeDBFileWriter = new StreamWriter(incomeDBFilePath, true))
                {
                    incomeDBFileWriter.WriteLine(incomeToAddString);
                }
            }
            catch (Exception e)
            {
                Logger.Instance().Log(e.ToString());
            }
        }

        public decimal MonthlyIncome()
        {
            List<Income> income = RecurringIncome.Instance().ParseIncomes();

            decimal incomeTotal = 0;

            foreach(Income i in income)
            {
                incomeTotal += i.amount;
            }

            return incomeTotal;
        }

        public List<Income> ParseIncomes()
        {
            List<Income> income = new List<Income>();
            try
            {
                List<string> item = new List<string>();
                item = File.ReadAllLines(incomeDBFilePath).ToList();

                foreach (string it in item)
                {
                    string[] elements = it.Split(',');
                    decimal incomeAmount = decimal.Parse(elements[0]);

                    Income newIncome = new Income();
                    newIncome.amount = incomeAmount;

                    income.Add(newIncome);
                }
            }
            catch (Exception e)
            {
                Logger.Instance().Log(e.ToString());
            }
            return income;
        }

        public readonly string incomeDBFilePath = DBPathConfig.Instance().RecuringIncomeDBPath;
    }
}