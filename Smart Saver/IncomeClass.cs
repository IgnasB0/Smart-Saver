using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MonthCheckExtensions;

namespace Smart_Saver
{
    class IncomeClass
    {
        public struct Income
        {
            public decimal amount;
            public DateTime date;
        }
        public static void AddIncome(Income incomeToAdd)
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
                Logger.Log(e.ToString());
            }
        }
        public static void AddIncome(decimal amount, DateTime date)
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
                Logger.Log(e.ToString());
            }
        }

        public static decimal MonthlyIncome()
        {
            List<Income> income = IncomeClass.ParseIncomes();

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

        public static List<Income> ParseIncomes()
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
                Logger.Log(e.ToString());
            }
            return income;
        }

        public static readonly string incomeDBFilePath = "..\\..\\..\\IncomeDB.csv";
    }
}
