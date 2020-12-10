using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Smart_Saver.Backend;

namespace Smart_Saver.Frontend
{
    public partial class CategoriesLoad : Form
    {
        public CategoriesLoad()
        {
            InitializeComponent();
            
        }
  
        private void CategoriesLoad_Load(object sender, EventArgs e)
        {
            //Async api request
            load(this, btn_msg, button1_Click, button2_Click);
        }
        public void btn_msg(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string s = (sender as Button).Name;
            this.Close();
            var m = new InputExpense(s);
            m.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            var m = new MainForm();
            m.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            var m = new Categories();
            m.Show();
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

            //Async api load
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
    }
}
