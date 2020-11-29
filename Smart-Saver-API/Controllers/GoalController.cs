using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Smart_Saver_API.Data_Structures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Smart_Saver_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoalController : ControllerBase
    {
        /*
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         * Instance Configuration
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         */
        private GoalController() { }
        private static GoalController _instance = null; //Singleton pattern

        public static GoalController Instance() //Lazy Load initiation
        {
            if (_instance == null)
            {
                _instance = new GoalController();
            }
            return _instance;
        }
        /*--------------------------------------------------------------------------------------------------
         * Initialisation
         * -----------------------------------------------------------------------------------------------*/

        private readonly ILogger<GoalController> _logger;

        public GoalController(ILogger<GoalController> logger)
        {
            _logger = logger;
        }

        /*--------------------------------------------------------------------------------------------------
         * Methods
         * -----------------------------------------------------------------------------------------------*/
        [HttpGet]
        [Route("parse-goal")]
        public IEnumerable<Goal> ParseGoal() //Do not use this for several goals
        {
            //List<Goal> Goals = new Goal();
            List<Goal> newGoal = new List<Goal>();
            try
            {
                List<string> item = new List<string>();
                item = System.IO.File.ReadAllLines(goalDBFilePath).ToList();

                foreach (string it in item)
                {
                    string[] elements = it.Split(',');
                    string goalName = elements[0];
                    decimal goalAmount = decimal.Parse(elements[1]);
                    DateTime goalDate = DateTime.Parse(elements[2]);

                    Goal newgoal = new Goal();
                    newgoal.Name = goalName;
                    newgoal.Amount = goalAmount;
                    newgoal.Date = goalDate;

                    newGoal.Add(newgoal);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(message: e.ToString());
            }
            return newGoal;
        }

      
        [HttpGet]
        [Route("Get-Month-Count-Until-Goal-Is-Reached")]
        public int GetMonthCountUntilGoalIsReached() 
        {
            try
            {
                int monthCount;
                List<TraceableBalance> balances = (List< TraceableBalance>) BalanceController.Instance().GetMonthlyBalances();  
                decimal averageBalance = 0;
                decimal currentSum = 0;

                currentSum = balances.Sum(x => x.Amount);       //Su LINQ

                averageBalance = currentSum / balances.Count;
                //Goal goal = (Goal)ParseGoal();
                var goal = ParseGoal();
                var goals = from _goal in goal
                            select (int)Math.Round((_goal.Amount - currentSum) / averageBalance);

                monthCount = goals.Single();
                return monthCount;
                
            }
            catch (Exception e)
            {
                _logger.LogError(message: e.ToString());
                return -1;
            }
        }
        /*--------------------------------------------------------------------------------------------------
         * Variables
         * -----------------------------------------------------------------------------------------------*/

        private string goalDBFilePath = DBPathConfig.Instance().GoalDBPath;
    }
}
