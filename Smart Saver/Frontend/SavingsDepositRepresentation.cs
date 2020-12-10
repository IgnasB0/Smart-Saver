using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Smart_Saver.Backend;

namespace Smart_Saver.Frontend
{
    public partial class SavingsDepositRepresentation : Form
    {
        public async Task<decimal> GetSingleDecimalValueAsync(string requestUrl)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string requestResult = await response.Content.ReadAsStringAsync();
                decimal result = decimal.Parse(requestResult);
                return result;
            }
            else
            {
                throw new AggregateException("Unable to parse value");
            }
        }
        public async Task<int> GetSingleIntegerValueAsync(string requestUrl)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string requestResult = await response.Content.ReadAsStringAsync();
                int result = int.Parse(requestResult);
                return result;
            }
            else
            {
                throw new AggregateException("Unable to parse value");
            }
        }
        public async Task FormLoad()
        {
            /*
            TotalExpense_TextBox.AppendText(string.Format("{0}", FrontendController.Instance().GetMonthlyExpenses()));
            TotalIncome_TextBox.AppendText(string.Format("{0}", FrontendController.Instance().GetMonthlyIncome()));
            balanceField.AppendText(string.Format("{0}", FrontendController.Instance().GetMonthlyBalance()) + '\n');
            
            if (FrontendController.Instance().GetAmountToReachGoal() >= 0)
                amountNeeded.AppendText(string.Format("{0}", FrontendController.Instance().GetAmountToReachGoal()));
            else
                amountNeeded.AppendText(string.Format("{0}", 0));

            TimeToDestination_richTextBox.AppendText(string.Format("{0}", FrontendController.Instance().TimeLeftUntilGoal()));

            if (FrontendController.Instance().GetMonthlyBalance() >= FrontendController.Instance().GetGoalAmount())
                System.Windows.Forms.MessageBox.Show("Goal Reached"); TotalExpense_TextBox.AppendText(string.Format("{0}", FrontendController.Instance().GetMonthlyExpenses()));
            TotalIncome_TextBox.AppendText(string.Format("{0}", FrontendController.Instance().GetMonthlyIncome()));
            balanceField.AppendText(string.Format("{0}", FrontendController.Instance().GetMonthlyBalance()) + '\n');

            if (FrontendController.Instance().GetAmountToReachGoal() >= 0)
                amountNeeded.AppendText(string.Format("{0}", FrontendController.Instance().GetAmountToReachGoal()));
            else
                amountNeeded.AppendText(string.Format("{0}", 0));

            TimeToDestination_richTextBox.AppendText(string.Format("{0}", FrontendController.Instance().TimeLeftUntilGoal()));

            if (FrontendController.Instance().GetMonthlyBalance() >= FrontendController.Instance().GetGoalAmount())
                System.Windows.Forms.MessageBox.Show("Goal Reached");
            */
            TotalExpense_TextBox.AppendText(string.Format("Loading..."));
            TotalIncome_TextBox.AppendText(string.Format("Loading..."));
            balanceField.AppendText(string.Format("Loading..."));
            amountNeeded.AppendText(string.Format("Loading..."));
            TimeToDestination_richTextBox.AppendText(string.Format("Loading..."));

            decimal monthlyExpenses = await GetSingleDecimalValueAsync("https://localhost:44317/frontend/get-monthly-expenses");
            decimal monthlyIncome = await GetSingleDecimalValueAsync("https://localhost:44317/frontend/get-monthly-income");
            decimal monthlyBalance = await GetSingleDecimalValueAsync("https://localhost:44317/frontend/get-monthly-balance");
            decimal amountToReachGoal = await GetSingleDecimalValueAsync("https://localhost:44317/frontend/get-amount-to-reach-goal");
            decimal goalAmount = await GetSingleDecimalValueAsync("https://localhost:44317/frontend/get-goal-amount");
            int timeLeftUntilGoal = await GetSingleIntegerValueAsync("https://localhost:44317/frontend/time-left-until-goal");

            TotalExpense_TextBox.Clear();
            TotalIncome_TextBox.Clear();
            balanceField.Clear();
            amountNeeded.Clear();
            TimeToDestination_richTextBox.Clear();

            TotalExpense_TextBox.AppendText(string.Format("{0}", monthlyExpenses));
            TotalIncome_TextBox.AppendText(string.Format("{0}", monthlyIncome));
            balanceField.AppendText(string.Format("{0}", monthlyBalance) + '\n');

            if (amountToReachGoal >= 0)
                amountNeeded.AppendText(string.Format("{0}", amountToReachGoal));
            else
                amountNeeded.AppendText(string.Format("{0}", 0));

            TimeToDestination_richTextBox.AppendText(string.Format("{0}", timeLeftUntilGoal));

            if (monthlyBalance >= goalAmount)
                System.Windows.Forms.MessageBox.Show("Goal Reached"); TotalExpense_TextBox.AppendText(string.Format("{0}", monthlyExpenses));
            TotalIncome_TextBox.AppendText(string.Format("{0}", monthlyIncome));
            balanceField.AppendText(string.Format("{0}", monthlyBalance) + '\n');

            if (amountToReachGoal >= 0)
                amountNeeded.AppendText(string.Format("{0}", amountToReachGoal));
            else
                amountNeeded.AppendText(string.Format("{0}", 0));

            TimeToDestination_richTextBox.AppendText(string.Format("{0}", timeLeftUntilGoal));

            if (monthlyBalance >= goalAmount)
                System.Windows.Forms.MessageBox.Show("Goal Reached");
        }

        public SavingsDepositRepresentation()
        {
            //List<ExpenseClass.Expense> expenses = ExpenseClass.Instance().ParseExpenses();

            InitializeComponent();
            FormLoad();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SavingsDepositRepresentation_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            var m = new MainForm();
            m.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}