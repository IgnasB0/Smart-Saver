using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Smart_Saver_API.Data_Structures;
using Smart_Saver_API.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Saver_API.Controllers
{
    [ApiController]
    [Route("chart")]
    public class ChartController : ControllerBase
    {
        private ChartController() { }
        private static ChartController _instance = null; //Singleton pattern

        public static ChartController Instance() //Lazy Load initiation
        {
            if (_instance == null)
            {
                _instance = new ChartController();
            }
            return _instance;
        }

        /*--------------------------------------------------------------------------------------------------
         * Initialisation
         * -----------------------------------------------------------------------------------------------*/

        private readonly ILogger<ChartController> _logger;

        public ChartController(ILogger<ChartController> logger)
        {
            _logger = logger;
        }
        //methods
        
        [HttpGet]
        [Route("show-chart")]
        public IEnumerable<Balance> ChartRepresenation()
        {
            IEnumerable <ExpenseDB> _expenses = ExpenseController.Instance().ParseExpenses();
            IEnumerable<IncomeDB> _incomes = IncomeController.Instance().ParseIncomes();
            var expenses = from expense in _expenses
                            orderby expense.expenseDate ascending
                            group expense.expenseAmount by new
                            {
                                Year = expense.expenseDate.Year,
                                Month = expense.expenseDate.Month                 // LINQ using
                            } into g
                            select new Result
                            {
                                monthAndYear = g.Key.Year + "-" + g.Key.Month,
                                Year = g.Key.Year,
                                Month = g.Key.Month,
                                amount = g.Sum(),
                                Type = "Expense"

                            };
          
            var incomes = from income in _incomes
                           orderby income.incomeDate ascending
                           group income.incomeAmount by new
                           {
                               Year = income.incomeDate.Year,
                               Month = income.incomeDate.Month
                           } into g
                           select new Result
                           {
                               monthAndYear = g.Key.Year + "-" + g.Key.Month,
                               Year = g.Key.Year,
                               Month = g.Key.Month,
                               amount = g.Sum(),
                               Type = "Income"
                           };

            var o = incomes.Concat(expenses);
            var results = from p in o
                          orderby p.monthAndYear ascending
                          select new Result
                          {
                              monthAndYear = p.monthAndYear,
                              Year = p.Year,
                              Month = p.Month,
                              amount = p.amount,
                              Type = p.Type
                          };

            var gautas = from h in CalculateEqual(results).ToList()
                         orderby h.Year, h.Month ascending
                         select h;

            return gautas.ToList();

        }

        [HttpGet]
        [Route("show-chart-for-one-user")]
        public IEnumerable<Balance> ChartRepresenationForOneUser(String username, String password)
        {
            IEnumerable<ExpenseDB> _expenses = ExpenseController.Instance().ParseOneUserExpenses(username, password);
            IEnumerable<IncomeDB> _incomes = IncomeController.Instance().parseOneUserIncomes(username, password);
            var expenses = from expense in _expenses
                           orderby expense.expenseDate ascending
                           group expense.expenseAmount by new
                           {
                               Year = expense.expenseDate.Year,
                               Month = expense.expenseDate.Month                 // LINQ using
                           } into g
                           select new Result
                           {
                               monthAndYear = g.Key.Year + "-" + g.Key.Month,
                               Year = g.Key.Year,
                               Month = g.Key.Month,
                               amount = g.Sum(),
                               Type = "Expense"

                           };

            var incomes = from income in _incomes
                          orderby income.incomeDate ascending
                          group income.incomeAmount by new
                          {
                              Year = income.incomeDate.Year,
                              Month = income.incomeDate.Month
                          } into g
                          select new Result
                          {
                              monthAndYear = g.Key.Year + "-" + g.Key.Month,
                              Year = g.Key.Year,
                              Month = g.Key.Month,
                              amount = g.Sum(),
                              Type = "Income"
                          };

            var o = incomes.Concat(expenses);
            var results = from p in o
                          orderby p.monthAndYear ascending
                          select new Result
                          {
                              monthAndYear = p.monthAndYear,
                              Year = p.Year,
                              Month = p.Month,
                              amount = p.amount,
                              Type = p.Type
                          };

            var gautas = from h in CalculateEqual(results).ToList()
                         orderby h.Year, h.Month ascending
                         select h;

            return gautas.ToList();

        }

        private IEnumerable<Balance> CalculateEqual(IEnumerable<Result> both)
        {
            bool sign = false;
            var array = both.ToArray();
            List<Balance> tBalances = new List<Balance>();

           for (int i = 0; i < array.Count() ;i++)
            {
                if(i != array.Count()-1)
                {
                    if(array[i].monthAndYear == array[i + 1].monthAndYear)
                    {
                        sign = true;
                        if(array[i].Year == DateTime.Now.Year && array[i].Month == DateTime.Now.Month)
                        {
                            Balance tBalance = new Balance()
                            {
                                Amount = (array[i].amount - array[i + 1].amount) + RecurringIncomeController.Instance().MonthlyIncome(),
                                monthAndYear = array[i].monthAndYear,
                                Year = array[i].Year,
                                Month = array[i].Month
                            };
                            tBalances.Add(tBalance);
                        }
                        else
                        {
                            Balance tBalance = new Balance()
                            {
                                Amount = (array[i].amount - array[i + 1].amount),
                                monthAndYear = array[i].monthAndYear,
                                Year = array[i].Year,
                                Month = array[i].Month
                            };
                            tBalances.Add(tBalance);
                        }
                        
                        

                    }
                    else if (array[i].Type == "Expense" && sign == false)
                    {
                        if (array[i].Year == DateTime.Now.Year && array[i].Month == DateTime.Now.Month)
                        {
                            Balance tBalance = new Balance()
                            {
                                Amount = (-array[i].amount) + RecurringIncomeController.Instance().MonthlyIncome(),
                                monthAndYear = array[i].monthAndYear,
                                Year = array[i].Year,
                                Month = array[i].Month
                            };
                            tBalances.Add(tBalance);
                        }
                        else
                        {
                            Balance tBalance = new Balance()
                            {
                                Amount = (-array[i].amount),
                                monthAndYear = array[i].monthAndYear,
                                Year = array[i].Year,
                                Month = array[i].Month
                            };
                            tBalances.Add(tBalance);
                        }
                           
                    }
                    else if (array[i].Type == "Income" && sign == false)
                    {
                        if (array[i].Year == DateTime.Now.Year && array[i].Month == DateTime.Now.Month)
                        {
                            Balance tBalance = new Balance()
                            {
                                Amount = (array[i].amount) + RecurringIncomeController.Instance().MonthlyIncome(),
                                monthAndYear = array[i].monthAndYear,
                                Year = array[i].Year,
                                Month = array[i].Month
                            };
                            tBalances.Add(tBalance);
                        }
                        else
                        {
                            Balance tBalance = new Balance()
                            {
                                Amount = (array[i].amount),
                                monthAndYear = array[i].monthAndYear,
                                Year = array[i].Year,
                                Month = array[i].Month
                            };
                            tBalances.Add(tBalance);
                        }
                           
                    }
                    else
                    {
                        sign = false;
                    }
                }
                else
                {
                    if (array[i].Type == "Expense" && sign == false)
                    {
                        if (array[i].Year == DateTime.Now.Year && array[i].Month == DateTime.Now.Month)
                        {
                            Balance tBalance = new Balance()
                            {
                                Amount = (-array[i].amount) + RecurringIncomeController.Instance().MonthlyIncome(),
                                monthAndYear = array[i].monthAndYear,
                                Year = array[i].Year,
                                Month = array[i].Month
                            };
                            tBalances.Add(tBalance);
                        }
                        else
                        {
                            Balance tBalance = new Balance()
                            {
                                Amount = (-array[i].amount),
                                monthAndYear = array[i].monthAndYear,
                                Year = array[i].Year,
                                Month = array[i].Month
                            };
                            tBalances.Add(tBalance);
                        }
                            
                    }
                    else if (array[i].Type == "Income" && sign == false)
                    {
                        if (array[i].Year == DateTime.Now.Year && array[i].Month == DateTime.Now.Month)
                        {
                            Balance tBalance = new Balance()
                            {
                                Amount = (array[i].amount) + RecurringIncomeController.Instance().MonthlyIncome(),
                                monthAndYear = array[i].monthAndYear,
                                Year = array[i].Year,
                                Month = array[i].Month
                            };
                            tBalances.Add(tBalance);
                        }
                        else
                        {
                            Balance tBalance = new Balance()
                            {
                                Amount = (array[i].amount),
                                monthAndYear = array[i].monthAndYear,
                                Year = array[i].Year,
                                Month = array[i].Month
                            };
                            tBalances.Add(tBalance);
                        }
                           
                    }
                    else
                    {
                        sign = false;
                    }
                }
                
                
            }
            return tBalances;
        }
       


    }
}
