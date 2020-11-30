using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MonthCheckExtensions.Backend;

namespace Smart_Saver.Backend
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
        public struct TraceableIncome
        {
            public decimal amount;
            public int year;
            public int month;
            public int dateID;
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
                Lazy<string> incomeToAddString = new Lazy<string>($"{amount},{date}"); // Lazy type

                if (amount != 0)
                {
                    //Add new income
                    using (StreamWriter incomeDBFileWriter = new StreamWriter(incomeDBFilePath, true))
                    {
                        incomeDBFileWriter.WriteLine(incomeToAddString.Value);
                    }
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

            return incomeTotal + RecurringIncome.Instance().MonthlyIncome();
        }

        public IEnumerable<TraceableIncome> GetMonthlyIncomes()
        {
            List<Income> incomes = IncomeClass.Instance().ParseIncomes();
            List<TraceableIncome> tIncomes = new List<TraceableIncome>();
            foreach (Income income in incomes)
            {
                TraceableIncome tIncome = new TraceableIncome()
                {
                    amount = income.amount,
                    year = income.date.Year,
                    month = income.date.Month,
                    dateID = (income.date.Year * 100) + income.date.Month
                };
                tIncomes.Add(tIncome);
            }
            var traceableIncomes = from income in tIncomes
                                   group income.amount  by income.dateID into incomeGroup
                                   select new TraceableIncome { dateID = incomeGroup.Key, 
                                                                amount = incomeGroup.Sum(), 
                                                                month = incomeGroup.Key % 100, 
                                                                year = incomeGroup.Key / 100 };
            return traceableIncomes.ToList<TraceableIncome>();
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
        public DateTime GetFirstEntryDate() //Gets earliest entry date
        {
            try
            {
                List<string> items = new List<string>();
                items = File.ReadAllLines(incomeDBFilePath).ToList();
                DateTime earliestDate = new DateTime(9999, 12, 31);
                foreach (string item in items)
                {
                    string[] elements = item.Split(',');
                    DateTime incomeDate = DateTime.Parse(elements[1]);
                    if (earliestDate > incomeDate)
                    {
                        earliestDate = incomeDate;
                    }
                }
                return earliestDate;
            }
            catch (Exception e)
            {
                Logger.Instance().Log(e.ToString());
                return new DateTime(0000, 00, 00);
            }
        }

        public readonly string incomeDBFilePath = DBPathConfig.Instance().IncomeDBPath;
    }
}
