using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Smart_Saver.Backend;

namespace Smart_Saver.Frontend
{
    public partial class Categories : Form
    {
        private async Task AddCategoryAsync(string category)
        {
            HttpContent content = new StringContent(JsonSerializer.Serialize(category), UTF8Encoding.UTF8, "application/json");
            String requestUrl = $"{ConfigurationManager.AppSettings.Get("localhost")}/categories";
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                message.Content = content;
                var response = await client.SendAsync(message);
                //string responseMessage = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(responseMessage);
            }
        }
        public Categories()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string category = CategoryName.Text;
            if (string.IsNullOrEmpty(category))
            {
                MessageBox.Show("Please enter the category");
            }
            else
            {
                MessageBox.Show("Category was added successfully");
                //CategoriesClass.Instance().AddCategory(category);
                var m = new InputExpense(category);
                m.Show();
                this.Close();
                AddCategoryAsync(category);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            var m = new CategoriesLoad();
            m.Show();
            
        }

        private void Categories_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
