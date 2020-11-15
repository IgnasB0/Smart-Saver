using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MonthCheckExtensions;

namespace Smart_Saver
{
    class IncomeClass
    {
        /*
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         * Instance Configuration
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         */
        private IncomeClass() { }
        private static IncomeClass _instance = null; //Singleton pattern

        public static IncomeClass Instance() //Lazy Load initiation
        {
            if (_instance == null)
            {
                _instance = new IncomeClass();
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
            public DateTime date;
        }
        public void AddIncome(Income incomeToAdd)
        {
            try
            {
                //Generate entry string
                string incomeToAddString = $"{incomeToAdd.amount},{incomeToAdd.date}";
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
        public void AddIncome(decimal amount, DateTime date)
        {
            try
            {
                //Generate entry string
                string incomeToAddString = $"{amount},{date}";
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
            List<Income> income = IncomeClass.Instance().ParseIncomes();

            decimal incomeTotal = 0;

            foreach (IncomeClass.Income oneIncome in income)
            {
                if (oneIncome.date.CheckIfCurrentMonth())
                {
                    incomeTotal += oneIncome.amount;
                }
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
                    DateTime incomeDate = DateTime.Parse(elements[1]);

                    Income newIncome = new Income();
                    newIncome.amount = incomeAmount;
                    newIncome.date = incomeDate;

                    income.Add(newIncome);
                }
            }
            catch (Exception e)
            {
                Logger.Instance().Log(e.ToString());
            }
            return income;
        }

        public readonly string incomeDBFilePath = "..\\..\\..\\IncomeDB.csv";
    }
}
