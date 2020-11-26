using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Smart_Saver_API.Data_Structures;

namespace Smart_Saver_API.Controllers
{
    [ApiController]
    [Route("Balance")]

    public class BalanceController : ControllerBase
    {
        /*
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         * Instance Configuration
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         */
        private BalanceController() { }
        private static BalanceController _instance = null; //Singleton pattern

        public static BalanceController Instance() //Lazy Load initiation
        {
            if (_instance == null)
            {
                _instance = new BalanceController();
            }
            return _instance;
        }

        /*--------------------------------------------------------------------------------------------------
         * Initialisation
         * -----------------------------------------------------------------------------------------------*/

        private readonly ILogger<WeatherForecastController> _logger;

        public BalanceController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /*--------------------------------------------------------------------------------------------------
        * Methods
        * -----------------------------------------------------------------------------------------------*/

        [HttpGet]
        [Route("get-monthly-balances")]
        public IEnumerable<TraceableBalance> GetMonthlyBalances() //Gets list of every year-month balances
        {
            List<TraceableIncome> tIncomes = (List<TraceableIncome>)IncomeController.Instance().GetMonthlyIncomes();
            List<TraceableExpense> tExpenses = (List<TraceableExpense>)ExpenseController.Instance().GetMonthlyExpenses();
            List<TraceableBalance> tBalances = new List<TraceableBalance>();
            for (int i = 0; i < tIncomes.Count; i++)
            {
                if (tIncomes[i].DateID == tExpenses[i].DateID)
                {
                    TraceableBalance tBalance = new TraceableBalance()
                    {
                        Amount = tIncomes[i].Amount - tExpenses[i].Amount,
                        Year = tIncomes[i].Year,
                        Month = tIncomes[i].Month,
                        DateID = tIncomes[i].DateID
                    };
                    tBalances.Add(tBalance);
                }
                else throw new Exception("Balances cannot be calculated because of missing income or expense data, or errors in parsing data");
            }
            return tBalances;
        }
    }
}
