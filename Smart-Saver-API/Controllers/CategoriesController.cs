using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Smart_Saver_API.Data_Structures;
using Smart_Saver_API.Models;

namespace Smart_Saver_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger; //Do we need a logger?
        private CategoriesController() { }
        private static CategoriesController _instance = null; //Singleton pattern

        public static CategoriesController Instance() //Lazy Load initiation
        {
            if (_instance == null)
            {
                _instance = new CategoriesController();
            }
            return _instance;
        }

        public CategoriesController(ILogger<CategoriesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("parse-categories")]
        public List<string> parseCategories()
        {
            List<CategoriesDB> ExpenseCategories = new List<CategoriesDB>();
            List<string> expenses = new List<string>();
            try
            {
                using (var context = new Data.Smart_Saver_APIContext())
                {
                    ExpenseCategories = context.CategoriesDB.ToList();
                }

                foreach (var _expense in ExpenseCategories)
                {
                    expenses.Add(_expense.categoryName);
                }
            }
            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
            }

            return expenses;
        }

     
        [HttpGet]
        [Route("categories-count")]
        public int getCategoriesCount()
        {
            return parseCategories().Count;
        }
        [HttpPost]
        public void AddCategory([FromBody] string category)
        {
            try
            {
                CategoriesDB _category = new CategoriesDB();
                string categoryToAddString = category;
                string[] elements = categoryToAddString.Split(',');
                foreach (string it in elements)
                {
                    string _categoryName = elements[0];
                    _category.categoryName = _categoryName;

                }
                using (var context = new Data.Smart_Saver_APIContext())
                {

                    context.CategoriesDB.Add(_category);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }
        }

        [HttpGet]
        [Route("get-one-category")]
        public string ByCategory(int index)
        {
            List<string> category = CategoriesController.Instance().parseCategories();
            int z = 0;
            foreach (var category1 in category)
            {
                if (z == index)
                {
                    return category1;
                }
                z++;

            }
            return null;
        }
        [HttpGet]
        [Route("get-categoryDB")]
        public string getCategory(int index)
        {

            List<CategoriesDB> ExpenseCategories = new List<CategoriesDB>();
            using (var context = new Data.Smart_Saver_APIContext())
            {
                ExpenseCategories = context.CategoriesDB.ToList();
            }
            foreach (var category1 in ExpenseCategories)
            {
                if (category1.categoryId == index)
                {
                    return category1.categoryName;
                }

            }
            return null;
        }

        [HttpGet]
        [Route("get-id")]
        public int getId (string categoryname)
        {
            List<CategoriesDB> ExpenseCategories = new List<CategoriesDB>();
            int z = 1;
            using (var context = new Data.Smart_Saver_APIContext())
            {
                ExpenseCategories = context.CategoriesDB.ToList();
            }
            foreach (var category1 in ExpenseCategories)
            {
                if (category1.categoryName == categoryname)
                {
                    return category1.categoryId;
                }
                z++;
  
            }
            return -1;
        }

        // public readonly string CategoriesDBFilePath = DBPathConfig.Instance().CategoriesDBPath;
    }
}
