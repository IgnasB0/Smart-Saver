using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Smart_Saver.Backend;

namespace Smart_Saver.Frontend
{
    public partial class MainForm : Form
    {
        private readonly IHttpClientFactory _clientFactory;
        private async Task<string> GetSingleDecimalValueAsync(string requestUrl)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("456\n654\n456\n654\n456");
                //Console.WriteLine((await response.Content.ReadAsStringAsync()));
                string result = await response.Content.ReadAsStringAsync();
                return result;
            }
            else
            {
                Console.WriteLine("123\n321\n123\n321\n123");
                throw new AggregateException("Unable to parse value");
            }
        }
        private async Task DisplayExpenseValueAsync()
        {
            try
            {
                Console.WriteLine(await GetSingleDecimalValueAsync("https://localhost:44317/frontend/get-monthly-expenses"));
                expensesLabel.Text = string.Format("{0}", await GetSingleDecimalValueAsync("https://localhost:44317/frontend/get-monthly-expenses")); //usage of localhost :/
            }
            catch (AggregateException e)
            {
                expensesLabel.Text = string.Format("Unable to fetch expenses data");
                Logger.Instance().Log(e.ToString());
            }
        }
        private async Task DisplayIncomeValueAsync()
        {
            try
            {
                incomeLabel.Text = string.Format("{0}", await GetSingleDecimalValueAsync("https://localhost:44317/frontend/get-monthly-income")); //Use appsettings file, app config
            }                                                                                                                               //Use configuration manager
            catch (AggregateException e)
            {
                incomeLabel.Text = string.Format("Unable to fetch income data");
                Logger.Instance().Log(e.ToString());
            }
        }
        private async Task DisplayBalanceValueAsync()
        {
            try
            {
                balanceLabel.Text = string.Format("{0}", await GetSingleDecimalValueAsync("https://localhost:44317/frontend/get-monthly-balance"));
            }
            catch (AggregateException e)
            {
                balanceLabel.Text = string.Format("Unable to fetch balance data");
                Logger.Instance().Log(e.ToString());
            }
        }
        public MainForm()
        {
            InitializeComponent();
            userInfo(Usertextarea);

            /*
            expensesLabel.Text = string.Format("{0}", FrontendController.Instance().GetMonthlyExpenses());
            incomeLabel.Text = string.Format("{0}", FrontendController.Instance().GetMonthlyIncome());
            balanceLabel.Text = string.Format("{0}", FrontendController.Instance().GetMonthlyBalance());
            */

            //WebApi needs to be running if requests are performed

            expensesLabel.Text = string.Format("Loading...");
            incomeLabel.Text = string.Format("Loading...");
            balanceLabel.Text = string.Format("Loading...");

            DisplayIncomeValueAsync();
            DisplayExpenseValueAsync();
            DisplayBalanceValueAsync();
           
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Load_MenuToolStripMenuItem();
        }

        private void Load_MenuToolStripMenuItem()
        {
            foreach(String items in Get_Items_For_Menu())
            {
                ToolStripMenuItem item = new ToolStripMenuItem(items);
                toolStripDropDownButton1.DropDownItems.Add(item);
                item.Click += new EventHandler(Item_Click);
            }
            foreach (String items in Get_Items_For_Expense())
            {
                ToolStripMenuItem item = new ToolStripMenuItem(items);
                toolStripDropDownButton2.DropDownItems.Add(item);
                item.Click += new EventHandler(Item_Click);
            }
            foreach (String items in Get_Items_For_Settings())
            {
                ToolStripMenuItem item = new ToolStripMenuItem(items);
                item.Click += new EventHandler(Item_Click);
            }

        }
        public void userInfo(TextBox Usertextarea)
        {
            try
            {
                Usertextarea.AppendText(FrontendController.Instance().userInfo());
            }
            catch (Exception e)
            {
                Logger.Instance().Log(e.ToString());
            }
        }

        public List<String> Get_Items_For_Menu()
        {
            List<String> menu_item = new List<String>();
            menu_item.Add("Add Income");

            return menu_item;
        }
        public List<String> Get_Items_For_Expense()
        {
            List<String> menu_item = new List<String>();
            menu_item.Add("Add Expense");
            return menu_item;
        }
        public List<String> Get_Items_For_Settings()
        {
            List<String> menu_item = new List<String>();
            menu_item.Add("Edit Profile");
            menu_item.Add("Log out");

            return menu_item;
        }

        private void Item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item.Text == "Add Income")
            {
                this.Hide();
                var m = new IncomeInput();
                m.Show();     
            }
            else if (item.Text == "Add Expense")
            {
                this.Hide();
                var m = new CategoriesLoad();
                m.Show();

            }
            else if (item.Text == "Log out")
            {
                //go to login window
            }
            else
            {
                //go to profile window
            }

        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var m = new Category_Show();
            m.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var m = new SavingsDepositRepresentation();
            m.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void incomeLabel_Click(object sender, EventArgs e)
        {

        }

        private void balanceLabel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Chart _chart = new Chart();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
