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
    public partial class IncomeInput : Form
    {
        private async Task AddIncomeAsync(decimal amount, DateTime date)
        {
            string requestString = $"{amount},{date}";
            HttpContent content = new StringContent(JsonSerializer.Serialize(requestString), UTF8Encoding.UTF8, "application/json");
            String requestUrl = $"{ConfigurationManager.AppSettings.Get("localhost")}/incomes";
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                message.Content = content;
                var response = await client.SendAsync(message);
                string responseMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseMessage);
            }
        }
        private EventAddClass eventAddClass;
        public IncomeInput()
        {
            InitializeComponent();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            var m = new MainForm();
            m.Show();
        }

        private void AddIncomeBtn_Click(object sender, EventArgs e)
        {
            eventAddClass = new EventAddClass();                    
            eventAddClass.incomeReached += IncomeAdded;                          //Custom event 
            eventAddClass.Add(Amount_Income.Value, IncomeDate.Value);
        }

        public void IncomeAdded(object sender, IncomeAddEventArgs e)
        {
            AddIncomeAsync(e.Amount, e.Date); // <-- POST
            MessageBox.Show("Income was added successfully");
        }
        private void IncomeInput_Load(object sender, EventArgs e)
        {

        }
    }
}
