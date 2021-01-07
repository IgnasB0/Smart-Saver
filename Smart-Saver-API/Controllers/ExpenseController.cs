using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Smart_Saver_API.Data_Structures;
using MonthCheckExtensions;
using System.IO;
using Smart_Saver_API.Models;
using Microsoft.AspNetCore.Cors;

namespace Smart_Saver_API.Controllers
{
    [ApiController]
    [Route("expenses")]
    [EnableCors("AllowOrigin")]
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

        private readonly ILogger<ExpenseController> _logger;

        public ExpenseController(ILogger<ExpenseController> logger)
        {
            _logger = logger;
        }

        /*--------------------------------------------------------------------------------------------------
         * Methods
         * -----------------------------------------------------------------------------------------------*/

        [HttpGet]
        [Route("parse-expenses")]
        public IEnumerable<ExpenseDB> ParseExpenses()
        {
            List<ExpenseDB> expenses = new List<ExpenseDB>();
            try
            {
                using (var context = new Data.Smart_Saver_APIContext())
                {
                    expenses = context.ExpenseDB.ToList();
                }
            }
            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
            }
            return expenses;
        }

        [HttpGet]
        [Route("ParseOneUserExpenses")]
        public IEnumerable<ExpenseDB> ParseOneUserExpenses(String username, string password)
        {
            LoginController loginC = new LoginController();

            int userId = loginC.UserId(username, password);

            List<ExpenseDB> expenses = new List<ExpenseDB>();
            try
            {
                using (var context = new Data.Smart_Saver_APIContext())
                {
                    expenses = context.ExpenseDB.ToList();
                }
            }
            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
            }

            List<ExpenseDB> userExpenses = new List<ExpenseDB>();

            foreach (ExpenseDB oneExpense in expenses)
            {
                if (oneExpense.UserId == userId)
                    userExpenses.Add(oneExpense);
            }

            return userExpenses;
        }

        [HttpGet]
        [Route("monthly-expenses")]
       [EnableCors("AllowOrigin")]
        public decimal MonthlyExpenses()
        {
            var expenses = ParseExpenses(); // Generics

            decimal expenseTotal = 0;

            foreach (ExpenseDB oneExpense in expenses)
            {
                if (oneExpense.expenseDate.CheckIfCurrentMonth())
                {
                    expenseTotal += oneExpense.expenseAmount;
                }
            }

            return expenseTotal;
        }

        [HttpGet]
        [Route("OneUserMonthlyExpenses")]
        [EnableCors("AllowOrigin")]
        public decimal OneUserMonthlyExpenses(String username, String Password)
        {
            String passwordFromDatabase = "";

            System.Collections.Generic.List<Smart_Saver_API.Models.LoginDB> logins = new System.Collections.Generic.List<Smart_Saver_API.Models.LoginDB>();

            try
            {
                using (var context = new Data.Smart_Saver_APIContext())
                {
                    logins = context.LoginDB.ToList();
                }
            }
            catch (Exception e)
            {
                //_logger?.LogError(e.ToString());
            }

            Smart_Saver_API.Models.LoginDB foundUser = new Smart_Saver_API.Models.LoginDB();

            bool userFound = false;

            foreach (Smart_Saver_API.Models.LoginDB oneUser in logins)
            {
                if (oneUser.Username == username)
                {
                    foundUser = oneUser;
                    userFound = true;
                    break;
                }
            }

            if (!userFound || foundUser.Password != Password)
                return 0;

            var expenses = ParseExpenses(); // Generics

            decimal expenseTotal = 0;

            foreach (ExpenseDB oneExpense in expenses)
            {
                if (oneExpense.expenseDate.CheckIfCurrentMonth() && oneExpense.UserId == foundUser.UserId)
                {
                    expenseTotal += oneExpense.expenseAmount;
                }
            }

            return expenseTotal;
        }

        [HttpGet]
        [Route("get-monthly-expenses")]
        public IEnumerable<TraceableExpense> GetMonthlyExpenses()
        {
            List<ExpenseDB> expenses = (List<ExpenseDB>)ParseExpenses();
            List<TraceableExpense> tExpenses = new List<TraceableExpense>();
            foreach (ExpenseDB expense in expenses)
            {
                TraceableExpense tExpense = new TraceableExpense()
                {
                    Amount = expense.expenseAmount,
                    Year = expense.expenseDate.Year,
                    Month = expense.expenseDate.Month,
                    DateID = (expense.expenseDate.Year * 100) + expense.expenseDate.Month
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
        // https://localhost:44317/expenses/get-category-expense-amount?neededCategory=Transport
        [HttpGet]
        [Route("get-category-expense-amount")]
        public decimal GetCategoryExpenseAmount(string neededCategory)
        {
            List<ExpenseDB> expenses = new List<ExpenseDB>();
            try
            {
                using (var context = new Data.Smart_Saver_APIContext())
                {
                    expenses = context.ExpenseDB.ToList();
                    var categories = from expense in expenses
                                group expense.expenseAmount by expense.expenseCategory into categoryGroup //<-----------------------------------LINQ
                                select new { Name = categoryGroup.Key, Amount = categoryGroup.Sum() };
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

            List<ExpenseDB> expenses = new List<ExpenseDB>();            
            Decimal totalAmount = 0;
            using (var context = new Data.Smart_Saver_APIContext())
                {
                    expenses = context.ExpenseDB.ToList();
                    
                    foreach (var _expenses in expenses)
                    {
                        totalAmount += _expenses.expenseAmount;
                    }

                }

            return totalAmount;

        }

        [HttpPost("add-expense-object")]
        public void AddExpense(ExpenseDB expenseToAdd)
        {
            try
            {
                ExpenseDB _expense = new ExpenseDB()
                {
                    expenseName = expenseToAdd.expenseName,
                    expenseAmount = expenseToAdd.expenseAmount,
                    expenseDate = expenseToAdd.expenseDate,
                    categoryId = CategoriesController.Instance().getId(expenseToAdd.expenseCategory),
                    expenseCategory = CategoriesController.Instance().getCategory(CategoriesController.Instance().getId(expenseToAdd.expenseCategory)),
                    UserId = Int32.Parse(FrontendController.Instance().userId())
                };
                using (var context = new Data.Smart_Saver_APIContext())
                {

                    context.ExpenseDB.Add(_expense);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
               _logger.LogError(e.ToString());
            }
        }

         [HttpPost]
        public void AddExpenseWeb([FromBody]string expenseToAdd)
        {
            try
            {

                ExpenseDB _expense = new ExpenseDB();
                string expenseToAddString = expenseToAdd;
                string[] elements = expenseToAddString.Split(',');
                foreach (string it in elements)
                {
                    string _expenseName = elements[0];
                    decimal _expenseAmount = decimal.Parse(elements[1]);
                    DateTime _expenseDate = DateTime.Parse(elements[2]);
                    String _category = elements[3];
                    int _userid = Int32.Parse(FrontendController.Instance().userId());

                    _expense.expenseName = _expenseName;
                    _expense.expenseAmount = _expenseAmount;
                    _expense.expenseDate = _expenseDate;
                    _expense.categoryId = CategoriesController.Instance().getId(_category);
                    _expense.expenseCategory = CategoriesController.Instance().getCategory(_expense.categoryId); 
                    _expense.UserId = _userid;
                }
                using (var context = new Data.Smart_Saver_APIContext())
                {

                    context.ExpenseDB.Add(_expense);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }
        }

        [HttpDelete]
        [Route("remove-expense-category")]
        public void RemoveExpenseCategory(string neededCategory)     //unusable because it can be more categories with the same name
        {

            try
            {
                using (var context = new Data.Smart_Saver_APIContext())
                {
                    var expenses = context.ExpenseDB.Where(p => p.expenseCategory == neededCategory) 
                            .FirstOrDefault();

                    if (expenses is ExpenseDB)
                    {
                        context.Remove(expenses);
                    }
                    context.SaveChanges();

                }
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
            var expenses = ParseExpenses();
            try
            {
                using (var context = new Data.Smart_Saver_APIContext())         
                {
                    context.ExpenseDB.RemoveRange(expenses);
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

        //private string expenseDBFilePath = DBPathConfig.Instance().ExpenseDBPath;
    }
}
