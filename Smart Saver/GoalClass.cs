using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MonthCheckExtensions;

namespace Smart_Saver
{
    class GoalClass
    {
        public struct Goal
        {
            public string name;
            public DateTime date;
            public decimal amount;
        }

        public static Goal ParseGoal()
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
                Logger.Log(message: e.ToString());
            }
            return newGoal;
        }

        private static readonly string goalDBFilePath = "..\\..\\..\\GoalDB.csv";

    }
}
