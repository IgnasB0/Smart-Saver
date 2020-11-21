using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MonthCheckExtensions;
using static Smart_Saver.Backend.BalanceClass;

namespace Smart_Saver.Backend
{
    class GoalClass
    {
        /*
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         * Instance Configuration
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         */
        private GoalClass() { }
        private static GoalClass _instance = null; //Singleton pattern

        public static GoalClass Instance() //Lazy Load initiation
        {
            if (_instance == null)
            {
                _instance = new GoalClass();
            }
            return _instance;
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         * GoalDB methods and variables
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         */

        public struct Goal
        {
            public string name;
            public DateTime date;
            public decimal amount;
        }

        public Goal ParseGoal() //Do not use this for several goals
        {
            //List<Goal> Goals = new Goal();
            Goal newGoal = new Goal();
            try
            {
                List<string> item = new List<string>();
                item = File.ReadAllLines(goalDBFilePath).ToList();

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
                Logger.Instance().Log(message: e.ToString());
            }
            return newGoal;
        }

        public int GetMonthCountUntilGoalIsReached() //Aplicable only for one goal
        {
            try
            {
                int monthCount;
                List<TraceableBalance> balances = (List<TraceableBalance>) BalanceClass.Instance().GetMonthlyBalances();
                decimal averageBalance = 0;
                decimal currentSum = 0;
                foreach (var balance in balances) //LINQ greiciau
                {
                    currentSum += balance.amount;
                }
                averageBalance = currentSum / balances.Count;
                Goal goal = ParseGoal();
                monthCount = (int)Math.Round((goal.amount - currentSum) / averageBalance);
                return monthCount;
            }
            catch (Exception e)
            {
                Logger.Instance().Log(e.ToString());
                return -1;
            }
        }

        private readonly string goalDBFilePath = DBPathConfig.Instance().GoalDBPath;

    }
}
