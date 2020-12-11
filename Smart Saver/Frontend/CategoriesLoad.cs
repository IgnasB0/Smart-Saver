using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Smart_Saver.Backend;

namespace Smart_Saver.Frontend
{
    public partial class CategoriesLoad : Form
    {
        private async Task<int> GetCategoriesCountAsync()
        {
            string requestUri = $"{ConfigurationManager.AppSettings.Get("localhost")}/categories/categories-count";
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string resultString = await response.Content.ReadAsStringAsync();
                int result = Int32.Parse(resultString);
                return result;
            }
            else
            {
                throw new AggregateException("Unable to parse value");
            }
        }
        private async Task<string> GetCategoryNameAsync(int index)
        {
            string requestUri = $"{ConfigurationManager.AppSettings.Get("localhost")}/categories/get-one-category?index={index}";
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                return result;
            }
            else
            {
                throw new AggregateException("Unable to parse value");
            }
        }
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
        public async Task PanelLoadAsync(int i, int top, int down, int z, Form form, EventHandler btn_msg)
        {
            string categoryName;
            try
            {
                categoryName = await GetCategoryNameAsync(z);
            }
            catch (AggregateException e)
            {
                categoryName = "error";
                Logger.Instance().Log($"Unable to get web service response: {e.ToString()}");
            }

            Label label = new Label();
            {
                label.Name = string.Format("{0}", i);
                label.Text = string.Format(categoryName); //<----GET
                label.Location = new System.Drawing.Point(top + 30, down - 30);
                label.Size = new System.Drawing.Size(150, 25);
                form.Controls.Add(label);
            }
            Button button = new Button();
            {
                button.Name = string.Format(categoryName); //<------GET
                button.Text = string.Format("Add");
                button.Location = new System.Drawing.Point(top, down);
                button.Size = new System.Drawing.Size(150, 35);
                button.Click += btn_msg;
                form.Controls.Add(button);
            }

        }
        public async Task load(Form form, EventHandler btn_msg, EventHandler btn_msg_Back, EventHandler btn_AddCategory) //Nieko baisaus, kad cia asynchrounous?
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
            var c = await GetCategoriesCountAsync(); //<----GET
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
                        await PanelLoadAsync(i, top, down, z, form, btn_msg); //Ar gerai taip ar geriau kitaip??
                        top = top + 150;
                        z++;
                    }
                    else if (c % 3 != 0 && z == c - 1)
                    {

                        await PanelLoadAsync(i, top, down, z, form, btn_msg);
                        top = top + 150;
                        z++;
                        down = down - 120;
                    }

                    else if (c % 3 == 0)
                    {
                        await PanelLoadAsync(i, top, down, z, form, btn_msg);
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
