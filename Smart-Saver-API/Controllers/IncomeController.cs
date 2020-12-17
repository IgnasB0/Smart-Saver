using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonthCheckExtensions;
using Smart_Saver_API.Data_Structures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Http;
using Smart_Saver_API.Models;

namespace Smart_Saver_API.Controllers
{
    [ApiController]
    [Route("incomes")]
    public class IncomeController : ControllerBase
    {

        /*
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         * Instance Configuration
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         */
        private IncomeController() { }
        private static IncomeController _instance = null; //Singleton pattern

        public static IncomeController Instance() //Lazy Load initiation
        {
            if (_instance == null)
            {
                _instance = new IncomeController();
            }
            return _instance;
        }

        /*--------------------------------------------------------------------------------------------------
         * Initialisation
         * -----------------------------------------------------------------------------------------------*/

        private readonly ILogger<IncomeController> _logger;

        public IncomeController(ILogger<IncomeController> logger)
        {
            _logger = logger;  
        }

        /*--------------------------------------------------------------------------------------------------
         * Methods
         * -----------------------------------------------------------------------------------------------*/

        [HttpGet]
        [Route("parse-incomes")]
        public IEnumerable<Smart_Saver_API.Models.IncomeDB> ParseIncomes()
        {
            List<IncomeDB> income = new List<IncomeDB>();
            try
            {
                using (var context = new Data.Smart_Saver_APIContext())
                {
                    income = context.IncomeDB.ToList();
                    
                }
            }catch (Exception e)
            {
                _logger?.LogError(e.ToString());
            }
            return income;
        }

        [HttpGet]
        [Route("get-monthly-incomes")]
        public IEnumerable<TraceableIncome> GetMonthlyIncomes()
        {
            List<IncomeDB> incomes = (List<IncomeDB>) ParseIncomes();       //IncomeClass.Instance().ParseIncomes();
            List<TraceableIncome> tIncomes = new List<TraceableIncome>();
            foreach (IncomeDB income in incomes)
            {
                TraceableIncome tIncome = new TraceableIncome()
                {
                    Amount = income.incomeAmount,
                    Year = income.incomeDate.Year,
                    Month = income.incomeDate.Month,
                    DateID = (income.incomeDate.Year * 100) + income.incomeDate.Month
                };
                tIncomes.Add(tIncome);
            }
            var traceableIncomes = from income in tIncomes
                                   group income.Amount by income.DateID into incomeGroup
                                   select new TraceableIncome
                                   {
                                       DateID = incomeGroup.Key,
                                       Amount = incomeGroup.Sum(),
                                       Month = incomeGroup.Key % 100,
                                       Year = incomeGroup.Key / 100
                                   };
            return traceableIncomes.ToList<TraceableIncome>();
        }

        [HttpGet]
        [Route("monthly-incomes")]
        public decimal MonthlyIncome()
        {
            var income =  ParseIncomes();    

            decimal incomeTotal = 0;

            foreach (Smart_Saver_API.Models.IncomeDB oneIncome in income)
            {
                if (oneIncome.incomeDate.CheckIfCurrentMonth())
                {
                    incomeTotal += oneIncome.incomeAmount;
                }
            }

            return incomeTotal + RecurringIncomeController.Instance().MonthlyIncome();
        }

        [HttpPost]
        [Route("add-income-object")] //Unusable
        public void PostNewIncome(IncomeDB income)
        {
            try
            {
                IncomeDB _income = new IncomeDB()
                {
                    incomeAmount = income.incomeAmount,
                    incomeDate = income.incomeDate,
                    userId = Int32.Parse(FrontendController.Instance().userId())
                };
                using (var context = new Data.Smart_Saver_APIContext())
                {
                    context.IncomeDB.Add(_income);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }
        }

        [HttpPost]
        [Route("add-income")] //Unusable
        public void AddIncome(decimal amount, DateTime date)
        {
            try
            {
                IncomeDB _income = new IncomeDB()
                { 
                    incomeAmount = amount,
                    incomeDate = date,
                    userId = Int32.Parse(FrontendController.Instance().userId())
            };
                using (var context = new Data.Smart_Saver_APIContext())
                {

                    context.IncomeDB.Add(_income);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }

        }

        [HttpPost]
        public void AddIncomeWeb([FromBody] string income)
        {
            try
            {
                IncomeDB _income = new IncomeDB();
                string incomeToAddString = income;
                string[] elements = incomeToAddString.Split(',');
                foreach (string it in elements)
                {
                    decimal _incomeAmount = decimal.Parse(elements[0]);
                    DateTime _incomeDate = DateTime.Parse(elements[1]);
                    int _userid = Int32.Parse(FrontendController.Instance().userId());
                    _income.incomeAmount = _incomeAmount;
                    _income.incomeDate = _incomeDate;
                    _income.userId = _userid;
                }
                using (var context = new Data.Smart_Saver_APIContext())
                {

                    context.IncomeDB.Add(_income);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }

        }

        [HttpGet]
        [Route("get-first-entry-date")]
        public DateTime GetFirstEntryDate() //Gets earliest entry date
        {
            try
            {
                DateTime earliestDate = new DateTime(9999, 12, 31);
                List<IncomeDB> income = (List<IncomeDB>)ParseIncomes();
                foreach (var _income in income)
                {
                    if (earliestDate > _income.incomeDate)
                    {
                        earliestDate = _income.incomeDate;
                    }
                }
                return earliestDate;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return new DateTime(0000, 00, 00);
            }
        }

        /*--------------------------------------------------------------------------------------------------
         * Variables
         * -----------------------------------------------------------------------------------------------*/


      //  public readonly string incomeDBFilePath = DBPathConfig.Instance().IncomeDBPath;
    }
}
