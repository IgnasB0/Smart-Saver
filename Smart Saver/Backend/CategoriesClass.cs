using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Smart_Saver.Backend
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


        public void PanelLoad(int i, int top, int down, int z, Form form, EventHandler btn_msg)
        {

            Label label = new Label();
            {
                label.Name = string.Format("{0}", i);
                label.Text = string.Format(CategoriesClass.Instance().ByCategory(z));
                label.Location = new System.Drawing.Point(top + 30, down - 30);
                label.Size = new System.Drawing.Size(150, 25);
                form.Controls.Add(label);
            }
            Button button = new Button();
            {
                button.Name = string.Format(CategoriesClass.Instance().ByCategory(z));
                button.Text = string.Format("Add");
                button.Location = new System.Drawing.Point(top, down);
                button.Size = new System.Drawing.Size(150, 35);
                button.Click += btn_msg;
                form.Controls.Add(button);
            }

        }

        public void load(Form form, EventHandler btn_msg, EventHandler btn_msg_Back, EventHandler btn_AddCategory)
        {
            form.MinimumSize = new System.Drawing.Size(form.Width, form.Height);
            form.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            form.AutoSize = true;
            form.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Label label = new Label();
            {
                label.Name = string.Format("{0}", "Title");
                label.Text = string.Format("{0}", "Expenses By Category");
                label.Location = new System.Drawing.Point(100, 10);
                label.Size = new System.Drawing.Size(700, 50);
                label.Font = new Font("Arial", 20, FontStyle.Bold);
                form.Controls.Add(label);
            }

            var c = CategoriesClass.Instance().parseCategories().Count;
            int top = 50;
            int down = 100;
            int z = 0;
            var x = c / 3 + c % 3;
            for (int j = 0; j < x; j++)
            {
                for (int i = 0; i < 3; i++)
                {

                    if (c % 3 != 0 && z <= 3 * (c / 3))
                    {
                        PanelLoad(i, top, down, z, form, btn_msg);
                        top = top + 150;
                        z++;
                    }
                    else if (c % 3 != 0 && z == c - 1)
                    {

                        PanelLoad(i, top, down, z, form, btn_msg);
                        top = top + 150;
                        z++;
                        down = down - 120;
                    }

                    else if (c % 3 == 0)
                    {
                        PanelLoad(i, top, down, z, form, btn_msg);
                        top = top + 150;
                        z++;
                    }
                    else
                    {
                        break;
                    }

                }
                top = 50;
                down = down + 120;


            }

            Button button = new Button();
            {
                button.Name = string.Format("Back");
                button.Text = string.Format("Back");
                button.Location = new System.Drawing.Point(top, down);
                button.Size = new System.Drawing.Size(150, 35);
                button.Click += btn_msg_Back;
                form.Controls.Add(button);
            }
            top = top + 150;
            Button button1 = new Button();
            {
                button1.Name = string.Format("Category");
                button1.Text = string.Format("Add Category");
                button1.Location = new System.Drawing.Point(top, down);
                button1.Size = new System.Drawing.Size(150, 35);
                button1.Click += btn_AddCategory;
                form.Controls.Add(button1);
            }
        }


        public readonly string CategoriesDBFilePath = DBPathConfig.Instance().CategoriesDBPath;
    }
}
