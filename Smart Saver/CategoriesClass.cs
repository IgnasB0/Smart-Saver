using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Smart_Saver
{
    public class CategoriesClass
    {
        private CategoriesClass() { }
        private static CategoriesClass _instance = null; //Singleton pattern

        public static CategoriesClass Instance() //Lazy Load initiation
        {
            if (_instance == null)
            {
                _instance = new CategoriesClass();
            }
            return _instance;
        }

        public struct Category
        {
           public string category;
        };
        public List<Category> parseCategories()
        {
            List<Category> ExpenseCategories = new List<Category>();
            try
            {
                List<string> item = new List<string>();
                item = File.ReadAllLines(CategoriesDBFilePath).ToList();

                foreach (string it in item)
                {
                    string[] elements = it.Split('\n');
                    string category = Convert.ToString(elements[0]);
                    Category _category = new Category();
                    _category.category = category;
                    ExpenseCategories.Add(_category);
                }
            }
            catch (Exception e)
            {
                Logger.Instance().Log(e.ToString());
            }
            return ExpenseCategories;
        }
        public void AddCategory(string category)
        {
            try
            {
                string CategoryToAddString = $"{category}";
                using (StreamWriter CategoriesDBFileWriter = new StreamWriter(CategoriesDBFilePath, true))
                {
                    CategoriesDBFileWriter.WriteLine(CategoryToAddString);
                }
            }
            catch (Exception e)
            {
                Logger.Instance().Log(e.ToString());
            }
        }

       public string ByCategory(int i)
        {
            List<Category> category = CategoriesClass.Instance().parseCategories();
            int z = 0;
            foreach (CategoriesClass.Category category1 in category)
            {
                if(z == i)
                {
                    return category1.category;
                }
                z++;

            }
            return null;
        }


        public readonly string CategoriesDBFilePath = "..\\..\\..\\Categories.csv";
    }
}
