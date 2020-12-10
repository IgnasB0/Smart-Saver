using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Smart_Saver.Backend;

namespace Smart_Saver.Frontend
{
    public partial class Category_Show : Form
    {
        private async Task<List<string>> GetListOfStringsValueAsync(string requestUrl)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string requestResult = await response.Content.ReadAsStringAsync(); //JSON List value
                List <string> result = JsonConvert.DeserializeObject<List<string>>(requestResult);
                return result;
            }
            else
            {
                throw new AggregateException("Unable to parse value");
            }
        }
        private async Task<string> GetStringValueAsync(string requestUrl)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync(); //JSON List value
                return result;
            }
            else
            {
                throw new AggregateException("Unable to parse value");
            }
        }
        public async Task LoadCategories()
        {
            try
            {
                List<string> ExpenseCategories = await GetListOfStringsValueAsync("https://localhost:44317/categories/parse-categories");
                foreach (var _category in ExpenseCategories)
                {
                    categories.Items.Add(_category);
                }
            }
            catch (AggregateException e)
            {
                categories.Items.Add("Unable to fetch categories' data");
                Logger.Instance().Log(e.ToString());
            }
        }
        public async Task<string> GetCategoryExpenseAmountAsync(string neededCategory)
        {
            string requestUrl = "https://localhost:44317/expenses/get-category-expense-amount?neededCategory=" + neededCategory;
            return await GetStringValueAsync(requestUrl);
        }
        public Category_Show()
        {
            InitializeComponent();
            //List<CategoriesClass.Category> ExpenseCategories = CategoriesClass.Instance().parseCategories();
            LoadCategories();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(await GetCategoryExpenseAmountAsync(categories.Text));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            var c = new MainForm();
            c.Show();
        }

        private void Category_Show_Load(object sender, EventArgs e)
        {

        }
    }
}
