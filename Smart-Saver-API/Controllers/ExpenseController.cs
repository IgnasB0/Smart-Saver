using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Smart_Saver_API.Data_Structures;
using MonthCheckExtensions;
using System.IO;

namespace Smart_Saver_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpenseController : ControllerBase
    {
        /*
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         * Instance Configuration
         * --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
         */
        private ExpenseController() { }
        private static ExpenseController _instance = null; //Singleton pattern

        public static ExpenseController Instance() //Lazy Load initiation
        {
            if (_instance == null)
            {
                _instance = new ExpenseController();
            }
            return _instance;
        }

        /*--------------------------------------------------------------------------------------------------
         * Initialisation
         * -----------------------------------------------------------------------------------------------*/

        private readonly ILogger<WeatherForecastController> _logger;

        public ExpenseController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /*--------------------------------------------------------------------------------------------------
         * Methods
         * -----------------------------------------------------------------------------------------------*/

        [HttpGet]
        [Route("parse-expenses")]
        public IEnumerable<Expense> ParseExpenses()
        {
            List<Expense> expenses = new List<Expense>();
            try
            {

                List<string> items = new List<string>();
                items = System.IO.File.ReadAllLines(expenseDBFilePath).ToList();

                foreach (string item in items)
                {
                    String[] elements = item.Split(',');

                    String expenseName = elements[0];
                    Decimal expenseAmount = Decimal.Parse(elements[1]);
                    DateTime expenseDate = DateTime.Parse(elements[2]);
                    String category = elements[3];

                    Expense newExpense = new Expense();
                    newExpense.Name = expenseName;
                    newExpense.Amount = expenseAmount;
                    newExpense.Date = expenseDate;
                    newExpense.Category = category;
                    expenses.Add(newExpense);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString()); //Where?
            }

            return expenses;
        }

        [HttpGet]
        [Route("monthly-expenses")]
        public decimal MonthlyExpenses()
        {
            var expenses = ParseExpenses(); // Generics

            decimal expenseTotal = 0;

            foreach (Expense oneExpense in expenses)
            {
                if (oneExpense.Date.CheckIfCurrentMonth())
                {
                    expenseTotal += oneExpense.Amount;

                }
            }

            return expenseTotal;
        }

        [HttpGet]
        [Route("get-monthly-expenses")]
        public IEnumerable<TraceableExpense> GetMonthlyExpenses()
        {
            List<Expense> expenses = (List<Expense>)ParseExpenses();
            List<TraceableExpense> tExpenses = new List<TraceableExpense>();
            foreach (Expense expense in expenses)
            {
                TraceableExpense tExpense = new TraceableExpense()
                {
                    Amount = expense.Amount,
                    Year = expense.Date.Year,
                    Month = expense.Date.Month,
                    DateID = (expense.Date.Year * 100) + expense.Date.Month
                };
                tExpenses.Add(tExpense);
            }
            var traceableExpenses = from expense in tExpenses
                                    group expense.Amount by expense.DateID into expenseGroup
                                    select new TraceableExpense
                                    {
                                        DateID = expenseGroup.Key,
                                        Amount = expenseGroup.Sum(),
                                        Month = expenseGroup.Key % 100,
                                        Year = expenseGroup.Key / 100
                                    };
            return traceableExpenses.ToList<TraceableExpense>();
        }

        [HttpGet]
        [Route("get-cathegory-expense-amount")]
        public decimal GetCategoryExpenseAmount(string neededCategory)
        {
            try
            {
                List<string> items = new List<string>();
                List<Expense> expenses = new List<Expense>();

                //Gather information from database
                items = System.IO.File.ReadAllLines(expenseDBFilePath).ToList();
                foreach (string item in items)
                {
                    String[] elements = item.Split(',');

                    String expenseName = elements[0];
                    Decimal expenseAmount = Decimal.Parse(elements[1]);
                    DateTime expenseDate = DateTime.Parse(elements[2]);
                    String expenseCategory = elements[3];

                    Expense newExpense = new Expense();
                    newExpense.Name = expenseName;
                    newExpense.Amount = expenseAmount;
                    newExpense.Date = expenseDate;
                    newExpense.Category = expenseCategory;
                    expenses.Add(newExpense);
                }

                //Group expenses by categories
                var categories = from expense in expenses
                                 group expense.Amount by expense.Category into categoryGroup //<-----------------------------------LINQ
                                 select new { Name = categoryGroup.Key, Amount = categoryGroup.Sum() };

                //Check if category exists in the DB, then parse the amount of expense
                foreach (var category in categories)
                {
                    if (category.Name == neededCategory)
                    {
                        return category.Amount;
                    }
                }
                //If category wasn;t found throw exception
                throw new Exception("Specified category was not found in the database.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return -1;
            }
        }

        [HttpGet]
        [Route("get-total-expense-amount")]
        public decimal GetTotalExpenseAmount()
        {
            List<string> items = new List<string>();
            items = System.IO.File.ReadAllLines(expenseDBFilePath).ToList();
            Decimal totalAmount = 0;
            foreach (string item in items)
            {
                String[] elements = item.Split(',');
                Decimal expenseAmount = Decimal.Parse(elements[1]);
                totalAmount += expenseAmount;
            }
            return totalAmount;
        }

        [Route("add-expense")]
        [HttpPost]
        public void AddExpense(Expense expenseToAdd)
        {
            try
            {
                //Generate entry string
                string expenseToAddString = $"{expenseToAdd.Name},{expenseToAdd.Amount},{expenseToAdd.Date},{expenseToAdd.Category}";
                //Add new expense
                using (StreamWriter expenseDBFileWriter = new StreamWriter(expenseDBFilePath, true))
                {
                    expenseDBFileWriter.WriteLine(expenseToAddString);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }
        }

        [HttpPost]
        public void AddExpense(string expenseName, decimal expenseAmount, DateTime expenseDate, string expenseCategory)
        {
            try
            {
                //Generate entry string
                string expenseToAddString = $"{expenseName},{expenseAmount},{expenseDate},{expenseCategory}";
                //Add new expense
                using (StreamWriter expenseDBFileWriter = new StreamWriter(expenseDBFilePath, true))
                {
                    expenseDBFileWriter.WriteLine(expenseToAddString);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }
        }

        [HttpDelete]
        [Route("remove-expense-category")]
        public void RemoveExpenseCategory(string neededCategory)
        {
            try
            {
                //Find all items of specified category in DB adn clear them
                List<string> items = new List<string>();
                items = System.IO.File.ReadAllLines(expenseDBFilePath).ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    string[] elements = items[i].Split(',');
                    if (elements[3] == neededCategory)
                    {
                        items.RemoveAt(i);
                        i--;
                    }
                }
                //Else proceed with adding the data
                System.IO.File.WriteAllLines(expenseDBFilePath, items);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }
        }

        [HttpDelete]
        [Route("clear-expense-db")]
        public void ClearExpenseDB()
        {
            try
            {
                System.IO.File.Delete(expenseDBFilePath);
                System.IO.File.Create(expenseDBFilePath);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }
        }


        /*--------------------------------------------------------------------------------------------------
         * Variables
         * -----------------------------------------------------------------------------------------------*/

        private string expenseDBFilePath = DBPathConfig.Instance().ExpenseDBPath;
    }
}
