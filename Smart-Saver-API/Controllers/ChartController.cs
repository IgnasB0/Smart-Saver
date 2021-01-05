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
        [Route("kazkas")]
        // https://localhost:44317/chart/kazkas
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
                               amount = g.Sum(),
                               Type = "Income"
                           };

            var o = incomes.Concat(expenses);
            var results = from p in o
                          orderby p.monthAndYear ascending
                          select new Result
                          {
                              monthAndYear = p.monthAndYear,
                              amount = p.amount,
                              Type = p.Type
                          };
            if (expenses.Count() == incomes.Count())
            {

                return CalculateEqual(results).ToList();
                //foreach (var c in m)
                //{
                //    Debug.WriteLine("asdsad" + c.Amount + " sdas" + c.monthAndYear);
                //}

            }
            //else if (incomes.Count() > expenses.Count())
            //{
            //   // return (CalculateIncomeMore(expenses, incomes));
            //}
            //else
            //{
            //    //return ( CalculateExpenseMore(expenses, incomes));
            //}
            else
            {
                return CalculateEqual(results).ToList();
            }
        }
        private IEnumerable<Balance> CalculateEqual(IEnumerable<Result> both)
        {
            string _write = "";
            bool sign = false;
            var array = both.ToArray();
            List<Balance> tBalances = new List<Balance>();

           for (int i = 0; i < array.Count() ;i++)
            {
                if(i != array.Count()-1)
                {
                    if(array[i].monthAndYear == array[i + 1].monthAndYear)
                    {
                        _write += "['" + array[i].monthAndYear + "'," + (array[i].amount - array[i + 1].amount) + "s1]]);";
                        sign = true;
                        Balance tBalance = new Balance()
                        {
                            Amount = (array[i].amount - array[i + 1].amount),
                            monthAndYear = array[i].monthAndYear
                        };
                        tBalances.Add(tBalance);

                    }
                    else if (array[i].Type == "Expense" && sign == false)
                    {
                        _write += "['" + array[i].monthAndYear + "'," + (-array[i].amount) + "s2]]);";
                        Balance tBalance = new Balance()
                        {
                            Amount = (-array[i].amount),
                            monthAndYear = array[i].monthAndYear
                        };
                        tBalances.Add(tBalance);
                    }
                    else if (array[i].Type == "Income")
                    {
                        _write += "['" + array[i].monthAndYear + "'," + array[i].amount + "s3]]);";
                        Balance tBalance = new Balance()
                        {
                            Amount = (array[i].amount),
                            monthAndYear = array[i].monthAndYear
                        };
                        tBalances.Add(tBalance);
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
                        _write += "['" + array[i].monthAndYear + "'," + (-array[i].amount) + "s2]]);";
                        Balance tBalance = new Balance()
                        {
                            Amount = (-array[i].amount),
                            monthAndYear = array[i].monthAndYear
                        };
                        tBalances.Add(tBalance);
                    }
                    else if (array[i].Type == "Income")
                    {
                        _write += "['" + array[i].monthAndYear + "'," + array[i].amount + "s3]]);";
                        Balance tBalance = new Balance()
                        {
                            Amount = (array[i].amount),
                            monthAndYear = array[i].monthAndYear
                        };
                        tBalances.Add(tBalance);
                    }
                    else
                    {
                        sign = false;
                    }
                }
                
                
            }
            return tBalances;
        }
        //private string CalculateEqual(IEnumerable<Result> expenses, IEnumerable<Result> incomes)
        //{
        //    int i = 1;
        //    string _write = "";
        //    bool sign = false;
        //    string monthandy = "";
        //    foreach (var _incomes in incomes)
        //    {
        //        foreach (var _expenses in expenses)
        //        {
        //                if(_expenses.monthAndYear == _incomes.monthAndYear)
        //                     {
        //                _write += "['" + _expenses.monthAndYear + "'," + (_incomes.amount - _expenses.amount) + "ss]]);";
        //                monthandy = _incomes.monthAndYear;
        //                     }
        //            else if(_expenses.monthAndYear != monthandy)
        //            {
        //                _write += "['" + _expenses.monthAndYear + "'," + _expenses.amount + "s2]]);";
        //            }


        //        }
        //        if (_incomes.monthAndYear != monthandy)
        //        {
        //            _write += "['" + _incomes.monthAndYear + "'," + _incomes.amount + "s3]]);";
        //        }

        //    }
        //    return _write;
        //}

        private string CalculateExpenseMore(IEnumerable<Result> expenses, IEnumerable<Result> incomes)
        {
            int i = 1;
            bool sign = true;
            string _write = "";
            foreach (var _expense in expenses)
            {
                foreach (var _incomes in incomes)
                {
                    if (_incomes.monthAndYear == _expense.monthAndYear && _expense.Type == "Expense" && _incomes.Type == "Income")
                    {
                       _write += "['" + _incomes.monthAndYear + "'," + (_incomes.amount - _expense.amount) + "],";
                        break;
                    }
                    else
                    {
                        sign = false;
                    }
                }

            }
            return _write;
        }

        private string CalculateIncomeMore(IEnumerable<Result> expenses, IEnumerable<Result> incomes)
        {
            int i = 1;
            bool sign = true;
            string _write = "";
            foreach (var _incomes in incomes)
            {
                foreach (var _expenses in expenses)
                {
                    if (_expenses.monthAndYear == _incomes.monthAndYear && _expenses.Type == "Expense" && _incomes.Type == "Income")
                    {

                            _write += "['" + _expenses.monthAndYear + "'," + (_incomes.amount - _expenses.amount) + "]";
                        i++;
                        sign = true;
                        break;
                    }
                    else
                    {
                        sign = false;
                    }
                }
                if (sign == false && i != incomes.Count())
                {
                    sign = true;
                    i++;
                }

            }
            return _write;
        }

        private string CalculateExpenseMore(IEnumerable<Result> expenses, IEnumerable<Result> incomes, string _write)
        {
            int i = 1;
            bool sign = true;
            foreach (var _expense in expenses)
            {
                foreach (var _incomes in incomes)
                {
                    if (_incomes.monthAndYear == _expense.monthAndYear && _expense.Type == "Expense" && _incomes.Type == "Income")
                    {
                        if (i == expenses.Count())
                        {
                            _write += "['" + _incomes.monthAndYear + "'," + (_incomes.amount - _expense.amount) + "]]);";
                        }
                        else
                        {
                            _write += "['" + _incomes.monthAndYear + "'," + (_incomes.amount - _expense.amount) + "],";
                        }
                        i++;
                        sign = true;
                        break;
                    }
                    else
                    {
                        sign = false;
                    }
                }
                if (sign == false && i != expenses.Count())
                {
                    _write += "['" + _expense.monthAndYear + "'," + (-_expense.amount) + "],";
                    sign = true;
                    i++;
                }
                else if (i == expenses.Count() && sign == false)
                {
                    _write += "['" + _expense.monthAndYear + "'," + (-_expense.amount) + "]]);";
                }
            }
            return _write;
        }

        private string CalculateIncomeMore(IEnumerable<Result> expenses, IEnumerable<Result> incomes, string _write)
        {
            int i = 1;
            bool sign = true;
            foreach (var _incomes in incomes)
            {
                foreach (var _expenses in expenses)
                {
                    if (_expenses.monthAndYear == _incomes.monthAndYear && _expenses.Type == "Expense" && _incomes.Type == "Income")
                    {
                        if (i == incomes.Count())
                        {
                            _write += "['" + _expenses.monthAndYear + "'," + (_incomes.amount - _expenses.amount) + "]]);";
                        }
                        else
                        {
                            _write += "['" + _expenses.monthAndYear + "'," + (_incomes.amount - _expenses.amount) + "],";
                        }
                        i++;
                        sign = true;
                        break;
                    }
                    else
                    {
                        sign = false;
                    }
                }
                if (sign == false && i != incomes.Count())
                {
                    _write += "['" + _incomes.monthAndYear + "'," + (_incomes.amount - 0) + "],";
                    sign = true;
                    i++;
                }
                else if (i == incomes.Count() && sign == false)
                {
                    _write += "['" + _incomes.monthAndYear + "'," + (_incomes.amount - 0) + "]]);";
                }
            }
            return _write;
        }
       


       

       



    }
}
