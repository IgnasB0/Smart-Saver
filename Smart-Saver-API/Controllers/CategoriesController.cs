using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Smart_Saver_API.Data_Structures;

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
            List<string> ExpenseCategories = new List<string>();
            try
            {
                List<string> item = new List<string>();
                item = System.IO.File.ReadAllLines(CategoriesDBFilePath).ToList();

                foreach (string it in item)
                {
                    string[] elements = it.Split('\n');
                    string category = Convert.ToString(elements[0]);
                    ExpenseCategories.Add(category);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }
            return ExpenseCategories;
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
                using (StreamWriter CategoriesDBFileWriter = new StreamWriter(CategoriesDBFilePath, true))
                {
                    CategoriesDBFileWriter.WriteLine(category);
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
            foreach (string category1 in category)
            {
                if (z == index)
                {
                    return category1;
                }
                z++;

            }
            return null;
        }


        public readonly string CategoriesDBFilePath = DBPathConfig.Instance().CategoriesDBPath;
    }
}
