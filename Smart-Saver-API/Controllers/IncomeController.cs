using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonthCheckExtensions;
using Smart_Saver_API.Data_Structures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Smart_Saver_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public IEnumerable<Income> ParseIncomes()
        {
            List<Income> income = new List<Income>();
            try
            {
                List<string> item = new List<string>();
                item = System.IO.File.ReadAllLines(incomeDBFilePath).ToList();

                foreach (string it in item)
                {
                    string[] elements = it.Split(',');
                    decimal incomeAmount = decimal.Parse(elements[0]);
                    DateTime incomeDate = DateTime.Parse(elements[1]);

                    Income newIncome = new Income();
                    newIncome.Amount = incomeAmount;
                    newIncome.Date = incomeDate;

                    income.Add(newIncome);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }
            return income;
        }

        [HttpGet]
        [Route("get-monthly-incomes")]
        public IEnumerable<TraceableIncome> GetMonthlyIncomes()
        {
            List<Income> incomes = (List<Income>) ParseIncomes();       //IncomeClass.Instance().ParseIncomes();
            List<TraceableIncome> tIncomes = new List<TraceableIncome>();
            foreach (Income income in incomes)
            {
                TraceableIncome tIncome = new TraceableIncome()
                {
                    Amount = income.Amount,
                    Year = income.Date.Year,
                    Month = income.Date.Month,
                    DateID = (income.Date.Year * 100) + income.Date.Month
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

            foreach (Income oneIncome in income)
            {
                if (oneIncome.Date.CheckIfCurrentMonth())
                {
                    incomeTotal += oneIncome.Amount;
                }
            }

            return incomeTotal + RecurringIncomeController.Instance().MonthlyIncome();
        }
        [HttpGet]
        [Route("add-income-with-parameter-object")]
        public void AddIncome(Income incomeToAdd)
        {
            try
            {
                //Generate entry string
                string incomeToAddString = $"{incomeToAdd.Amount},{incomeToAdd.Date}";
                //Add new expense
                using (StreamWriter incomeDBFileWriter = new StreamWriter(incomeDBFilePath, true))
                {
                    incomeDBFileWriter.WriteLine(incomeToAddString);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }
        }

        [HttpGet]
        [Route("add-income-with-2-parameter")]
        public void AddIncome(decimal amount, DateTime date)
        {
            try
            {
                //Generate entry string
                string incomeToAddString = $"{amount},{date}";
                //Add new expense
                using (StreamWriter incomeDBFileWriter = new StreamWriter(incomeDBFilePath, true))
                {
                    incomeDBFileWriter.WriteLine(incomeToAddString);
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
                List<string> items = new List<string>();
                items = System.IO.File.ReadAllLines(incomeDBFilePath).ToList();
                DateTime earliestDate = new DateTime(9999, 12, 31);
                foreach (string item in items)
                {
                    string[] elements = item.Split(',');
                    DateTime incomeDate = DateTime.Parse(elements[1]);
                    if (earliestDate > incomeDate)
                    {
                        earliestDate = incomeDate;
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


        public readonly string incomeDBFilePath = DBPathConfig.Instance().IncomeDBPath;
    }
}
