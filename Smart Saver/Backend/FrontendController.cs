﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;
using Smart_Saver.Frontend;

namespace Smart_Saver.Backend
{
    class FrontendController
    {
        /*
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         * Instance Configuration
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         */
        private FrontendController() { }
        private static FrontendController _instance = null; //Singleton pattern

        public static FrontendController Instance() //Lazy Load initiation
        {
            if (_instance == null)
            {
                _instance = new FrontendController();
            }
            return _instance;
        }

        /*-----------------------------------------------------------------------------------------
         * Main Form
         ------------------------------------------------------------------------------------------*/

        public string userInfo()
        {
            using (var reader = new StreamReader(userDBFilePath))
            {
                List<string> listA = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    listA.Add(values[0]);
                    listA.Add(values[1]);
                    listA.Add(values[2]);
                }
                return (listA[1] + " " + listA[2]);
            }
        }
        /*-----------------------------------------------------------------------------------------
         * Savings Deposit Representation
         ------------------------------------------------------------------------------------------*/

        public decimal GetMonthlyExpenses()
        {
            return ExpenseClass.Instance().MonthlyExpenses();
        }
        public decimal GetMonthlyIncome()
        {
            return IncomeClass.Instance().MonthlyIncome();
        }
        public decimal GetMonthlyBalance()
        {
            return (IncomeClass.Instance().MonthlyIncome() - ExpenseClass.Instance().MonthlyExpenses());
        }
        public decimal GetGoalAmount()
        {
            return GoalClass.Instance().ParseGoal().amount;
        }
        public decimal GetAmountToReachGoal()
        {
            return (GetGoalAmount() - GetMonthlyBalance());
        }
        public int TimeLeftUntilGoal()
        {
            return (GoalClass.Instance().GetMonthCountUntilGoalIsReached());
        }

        /*-----------------------------------------------------------------------------------------
         * CategoriesLoad
         ------------------------------------------------------------------------------------------*/

        private readonly string userDBFilePath = DBPathConfig.Instance().UserDBPath;
    }
}
