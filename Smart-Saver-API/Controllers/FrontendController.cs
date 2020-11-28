using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Smart_Saver_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FrontendController : ControllerBase
    {
        /*
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         * Instance Configuration
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         */
        public FrontendController() { }
        private static FrontendController _instance = null; //Singleton pattern

        public static FrontendController Instance() //Lazy Load initiation
        {
            if (_instance == null)
            {
                _instance = new FrontendController();
            }
            return _instance;
        }

        /*private readonly ILogger<WeatherForecastController> _logger; //Needs to be fixed. Public constructor.

        public FrontendController(ILogger<WeatherForecastController> logger) //Add logger
        {
            _logger = logger;
        }*/
        [HttpGet]
        [Route("test")]
        public string Index()
        {
            return ConfigHelper.Instance().Configuration["AppSettings:ServerAddress"];
        }

        /*-----------------------------------------------------------------------------------------
         * Main Form
         ------------------------------------------------------------------------------------------*/
        [HttpGet]
        [Route("user-info")]
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

        [HttpGet]
        [Route("get-monthly-expenses")]
        public decimal GetMonthlyExpenses()
        {
            return ExpenseController.Instance().MonthlyExpenses();
        }
        [HttpGet]
        [Route("get-monthly-income")]
        public decimal GetMonthlyIncome()
        {
            return IncomeController.Instance().MonthlyIncome();
        }
        [HttpGet]
        [Route("get-monthly-balance")]
        public decimal GetMonthlyBalance()
        {
            return (IncomeController.Instance().MonthlyIncome() - ExpenseController.Instance().MonthlyExpenses());
        }
        [HttpGet]
        [Route("get-goal-amount")]
        public decimal GetGoalAmount()
        {
            List<Data_Structures.Goal> returningValue = (List<Data_Structures.Goal>)GoalController.Instance().ParseGoal();
            return returningValue[0].Amount;
        }
        [HttpGet]
        [Route("get-amount-to-reach-goal")]
        public decimal GetAmountToReachGoal()
        {
            return (GetGoalAmount() - GetMonthlyBalance());
        }
        [HttpGet]
        [Route("time-left-until-goal")]
        public int TimeLeftUntilGoal()
        {
            return (GoalController.Instance().GetMonthCountUntilGoalIsReached());
        }

        /*-----------------------------------------------------------------------------------------
         * CategoriesLoad
         ------------------------------------------------------------------------------------------*/

        private readonly string userDBFilePath = DBPathConfig.Instance().UserDBPath;
    }
}
