using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Smart_Saver_API.Data_Structures;
using Smart_Saver_API.Models;

namespace Smart_Saver_API.Controllers
{
    public class RecurringIncomeController : ControllerBase
    {
        /*
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         * Instance Configuration
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         */
        private RecurringIncomeController() { }
        private static RecurringIncomeController _instance = null; //Singleton pattern

        public static RecurringIncomeController Instance() //Lazy Load initiation
        {
            if (_instance == null)
            {
                _instance = new RecurringIncomeController();
            }
            return _instance;
        }

        /*--------------------------------------------------------------------------------------------------
         * Initialisation
         * -----------------------------------------------------------------------------------------------*/

        private readonly ILogger<RecurringIncomeController> _logger;

        public RecurringIncomeController(ILogger<RecurringIncomeController> logger)
        {
            _logger = logger;
        }

        /*--------------------------------------------------------------------------------------------------
        * Methods
        * -----------------------------------------------------------------------------------------------*/

        [HttpGet]
        [Route("parse-recurring-incomes")]
        public IEnumerable<ReccuringIncomeDB> ParseIncomes()
        {

            List<ReccuringIncomeDB> income = new List<ReccuringIncomeDB>();
            try
            {
                using (var context = new Data.Smart_Saver_APIContext())
                {
                    income = context.ReccuringIncomeDB.ToList();

                }
            }
            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
            }
            return income;
        }

        [HttpGet]
        [Route("monthly-recurring-incomes")]
        public decimal MonthlyIncome()
        {
            var income = ParseIncomes();

            decimal incomeTotal = 0;

            foreach (ReccuringIncomeDB i in income)
            {
                incomeTotal += i.reccuringincomeAmount;
            }

            return incomeTotal;
        }

        [HttpGet]
        [Route("add-recurring-income")]
        public void AddIncome(decimal amount, DateTime dateFrom, DateTime dateUntil)
        {
            try
            {
                ReccuringIncomeDB _income = new ReccuringIncomeDB()
                {
                    reccuringincomeAmount = amount,
                    reccuringincomeDateFrom = dateFrom,
                    reccuringincomeDateUntil = dateUntil,
                    userId = Int32.Parse(FrontendController.Instance().userInfo())
                };
                using (var context = new Data.Smart_Saver_APIContext())
                {

                    context.ReccuringIncomeDB.Add(_income);
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

      //  public readonly string incomeDBFilePath = DBPathConfig.Instance().RecuringIncomeDBPath;
    }
}
