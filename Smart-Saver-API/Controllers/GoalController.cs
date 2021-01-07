using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Smart_Saver_API.Data_Structures;
using Smart_Saver_API.Models;
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
        public IEnumerable<GoalDB> ParseGoal() //Do not use this for several goals
        {
            List<GoalDB> newGoal = new List<GoalDB>();
            try
            {
                using (var context = new Data.Smart_Saver_APIContext())
                {
                    newGoal = context.GoalDB.ToList();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(message: e.ToString());
            }
            return newGoal;
        }

        [HttpGet]
        [Route("ParseOneUserGoal")]
        public IEnumerable<GoalDB> ParseOneUserGoal(String username, String password) //Do not use this for several goals
        {
            LoginController loginC = new LoginController();

            int userId = loginC.UserId(username, password);

            List<GoalDB> newGoal = new List<GoalDB>();
            try
            {
                using (var context = new Data.Smart_Saver_APIContext())
                {
                    newGoal = context.GoalDB.ToList();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(message: e.ToString());
            }

            List<GoalDB> oneUserGoals = new List<GoalDB>();

            foreach (GoalDB oneGoal in newGoal)
            {
                if(oneGoal.userId == userId)
                {
                    oneUserGoals.Add(oneGoal);
                }
            }    

            return oneUserGoals;
        }


        [HttpGet]
        [Route("Get-Month-Count-Until-Goal-Is-Reached")]
        public int GetMonthCountUntilGoalIsReached() 
        {
            try
            {
                int monthCount;
                List<Balance> balances = (List<Balance>)ChartController.Instance().ChartRepresenation();
                decimal averageBalance = 0;
                decimal currentSum = 0;

                currentSum = balances.Sum(x => x.Amount);       //Su LINQ

                averageBalance = currentSum / balances.Count;
                //Goal goal = (Goal)ParseGoal();
                var goal = ParseGoal();
                var goals = from _goal in goal
                            select (int)Math.Round((_goal.goalAmount - currentSum) / averageBalance);

                monthCount = goals.Single();
                return monthCount;
                
            }
            catch (Exception e)
            {
                _logger.LogError(message: e.ToString());        
                return -1;
            }
        }

        [HttpGet]
        [Route("Get-Month-Count-Until-Goal-Is-Reached-one-user")]
        public int GetMonthCountUntilGoalIsReachedOneUser(String username, String password)
        {
            try
            {
                int monthCount;
                List<Balance> balances = (List<Balance>)ChartController.Instance().ChartRepresenation();
                decimal averageBalance = 0;
                decimal currentSum = 0;

                currentSum = balances.Sum(x => x.Amount);       //Su LINQ

                averageBalance = currentSum / balances.Count;
                //Goal goal = (Goal)ParseGoal();
                var goal = ParseOneUserGoal(username, password);
                var goals = from _goal in goal
                            select (int)Math.Round((_goal.goalAmount - currentSum) / averageBalance);

                monthCount = goals.Single();
                return monthCount;

            }
            catch (Exception e)
            {
                _logger.LogError(message: e.ToString());
                return -1;
            }
        }

        // https://localhost:44317/goal 
        [HttpPost]
        public void addGoal([FromBody] string goaltoAdd)
        {
            try
            {

                GoalDB _goal = new GoalDB();
                string goalToAddString = goaltoAdd;
                string[] elements = goalToAddString.Split(',');
                foreach (string it in elements)
                {
                    string _goalName = elements[0];
                    decimal _goalAmount = decimal.Parse(elements[1]);
                    DateTime _goalDate = DateTime.Parse(elements[2]);
                    int _userid = Int32.Parse(FrontendController.Instance().userId());

                    _goal.goalName = _goalName;
                    _goal.goalAmount = _goalAmount;
                    _goal.goalDate = _goalDate;
                    _goal.userId = _userid;
                }
                using (var context = new Data.Smart_Saver_APIContext())
                {

                    context.GoalDB.Add(_goal);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }
        }
        /*--------------------------------------------------------------------------------------------------
         * Variables
         * -----------------------------------------------------------------------------------------------*/

        // private string goalDBFilePath = DBPathConfig.Instance().GoalDBPath;
    }
}
