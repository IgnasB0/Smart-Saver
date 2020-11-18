using System;
using System.Collections.Generic;
using static Smart_Saver.IncomeClass;
using static Smart_Saver.ExpenseClass;

namespace Smart_Saver {
    public class BalanceClass
    {
        /*
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         * Instance Configuration
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         */
        private BalanceClass() { }
        private static BalanceClass _instance = null; //Singleton pattern

        public static BalanceClass Instance() //Lazy Load initiation
        {
            if (_instance == null)
            {
                _instance = new BalanceClass();
            }
            return _instance;
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         * IncomeDB methods and variables
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         */
        public struct TraceableBalance
        {
            public decimal amount;
            public int year;
            public int month;
            public int dateID;
        }

        public IEnumerable<TraceableBalance> GetMonthlyBalances() //Gets list of every year-month balances
        {
            List<TraceableIncome> tIncomes = (List<TraceableIncome>)IncomeClass.Instance().GetMonthlyIncomes();
            List<TraceableExpense> tExpenses = (List<TraceableExpense>)ExpenseClass.Instance().GetMonthlyExpenses();
            List<TraceableBalance> tBalances = new List<TraceableBalance>();
            for (int i = 0; i < tIncomes.Count; i++)
            {
                if (tIncomes[i].dateID == tExpenses[i].dateID)
                {
                    TraceableBalance tBalance = new TraceableBalance()
                    {
                        amount = tIncomes[i].amount - tExpenses[i].amount,
                        year = tIncomes[i].year,
                        month = tIncomes[i].month,
                        dateID = tIncomes[i].dateID
                    };
                    tBalances.Add(tBalance);
                }
                else throw new Exception("Balances cannot be calculated because of missing income or expense data, or errors in parsing data");
            }
            return tBalances;
        }
    }
}
