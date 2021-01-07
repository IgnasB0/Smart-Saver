using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonthCheckExtensions;
using Smart_Saver_API.Data_Structures;
using Smart_Saver_API.Models;

namespace Smart_Saver_API.Controllers
{
    [ApiController]
    [Route("recurringincomes")]
    //https://localhost:44317/recurringincomes
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
        [Route("ParseOneUserIncomes")]
        public IEnumerable<ReccuringIncomeDB> ParseOneUserIncomes(String username, String password)
        {
            LoginController loginC = new LoginController();

            int userId = loginC.UserId(username, password);

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

             List<ReccuringIncomeDB> oneUserIncome = new List<ReccuringIncomeDB>();

            foreach(var oneIncome in income)
            {
                if(oneIncome.userId == userId)
                {
                    oneUserIncome.Add(oneIncome);
                }
            }

                return oneUserIncome;
        }

        [HttpGet]
        [Route("monthly-recurring-incomes")]
        public decimal MonthlyIncome()
        {
            var income = ParseIncomes();

            decimal incomeTotal = 0;

            foreach (ReccuringIncomeDB i in income)
            {
                if (i.reccuringincomeDateUntil >= DateTime.Now && i.reccuringincomeDateFrom <= DateTime.Now )
                {
                    incomeTotal += i.reccuringincomeAmount;
                }
                
            }

            return incomeTotal;
        }

        [HttpGet]
        [Route("OneUserMonthlyIncome")]
        public decimal OneUserMonthlyIncome(String username, String password)
        {
            var income = ParseOneUserIncomes(username, password);

            decimal incomeTotal = 0;

            foreach (ReccuringIncomeDB i in income)
            {
                if (i.reccuringincomeDateUntil >= DateTime.Now && i.reccuringincomeDateFrom <= DateTime.Now)
                {
                    incomeTotal += i.reccuringincomeAmount;
                }

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
        [HttpPost]
        public void AddExpenseWeb([FromBody] string recurringincomeadd)
        {
            try
            {

                ReccuringIncomeDB _recurringincome = new ReccuringIncomeDB();
                string reccuringIncomeToAddString = recurringincomeadd;
                string[] elements = reccuringIncomeToAddString.Split(',');
                foreach (string it in elements)
                {
                    decimal _reccuringIncomeAmount = decimal.Parse(elements[0]);
                    DateTime _reccuringDateFrom = DateTime.Parse(elements[1]);
                    DateTime _reccuringDateUntil = DateTime.Parse(elements[2]);
                    int _userid = Int32.Parse(FrontendController.Instance().userId());

                    _recurringincome.reccuringincomeAmount = _reccuringIncomeAmount;
                    _recurringincome.reccuringincomeDateFrom = _reccuringDateFrom;
                    _recurringincome.reccuringincomeDateUntil = _reccuringDateUntil;
                    _recurringincome.userId = _userid;
                }
                using (var context = new Data.Smart_Saver_APIContext())
                {

                    context.ReccuringIncomeDB.Add(_recurringincome);
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
