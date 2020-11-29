using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Smart_Saver_API.Data_Structures;

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
        public IEnumerable<Income> ParseIncomes()
        {
            List<Income> income = new List<Income>();
            try
            {
                List<string> item = new List<string>();
                item = System.IO.File.ReadAllLines(incomeDBFilePath).ToList(); //Kodel cia reik listo, jei recurring income tik vienas??

                foreach (string it in item)
                {
                    string[] elements = it.Split(',');
                    decimal incomeAmount = decimal.Parse(elements[0]);

                    Income newIncome = new Income();
                    newIncome.Amount = incomeAmount;

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
        [Route("monthly-recurring-incomes")]
        public decimal MonthlyIncome()
        {
            var income = ParseIncomes();

            decimal incomeTotal = 0;

            foreach (Income i in income)
            {
                incomeTotal += i.Amount;
            }

            return incomeTotal;
        }

        [HttpGet]
        [Route("add-recurring-income")]
        public void AddIncome(decimal amount)
        {
            try
            {
                //Generate entry string
                string incomeToAddString = $"{amount}";
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


        /*--------------------------------------------------------------------------------------------------
        * Variables
        * -----------------------------------------------------------------------------------------------*/

        public readonly string incomeDBFilePath = DBPathConfig.Instance().RecuringIncomeDBPath;
    }
}
