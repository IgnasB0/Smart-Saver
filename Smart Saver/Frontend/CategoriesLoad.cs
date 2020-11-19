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
        private void PanelLoad(int i, int top, int down,int z)
        {
            
            Label label = new Label();
            {
                label.Name = string.Format("{0}", i);
                label.Text = string.Format(CategoriesClass.Instance().ByCategory(z));
                label.Location = new System.Drawing.Point(top+30, down - 30);
                label.Size = new System.Drawing.Size(150, 25);
                this.Controls.Add(label);
            }
            Button button = new Button();
            {
                button.Name = string.Format(CategoriesClass.Instance().ByCategory(z));
                button.Text = string.Format("Add");
                button.Location = new System.Drawing.Point(top, down);
                button.Size = new System.Drawing.Size(150, 35);
                button.Click += btn_msg;
                this.Controls.Add(button);
            }
            
        }

        private void btn_msg(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string s = (sender as Button).Name;
            this.Close();
            var m = new InputExpense(s);
            m.Show();
        }

        private void CategoriesLoad_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
            this.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            Label label = new Label();
            {
                label.Name = string.Format("{0}", "Title");
                label.Text = string.Format("{0}","Expenses By Category");
                label.Location = new System.Drawing.Point(100, 10);
                label.Size = new System.Drawing.Size(700, 50);
                label.Font = new Font("Arial", 20, FontStyle.Bold);
                this.Controls.Add(label);
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
                        PanelLoad(i, top, down, z);
                        top = top + 150;
                        z++;
                    }
                    else if (c % 3 != 0 && z == c - 1)
                    {

                        PanelLoad(i, top, down, z);
                        top = top + 150;
                        z++;
                        down = down - 120;
                    }

                    else if (c % 3 == 0)
                    {
                        PanelLoad(i, top, down, z);
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
                button.Click += button1_Click;
                this.Controls.Add(button);
            }
            top = top + 150;
            Button button1 = new Button();
            {
                button1.Name = string.Format("Category");
                button1.Text = string.Format("Add Category");
                button1.Location = new System.Drawing.Point(top, down);
                button1.Size = new System.Drawing.Size(150, 35);
                button1.Click += button2_Click;
                this.Controls.Add(button1);
            }
            
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
    }
}
