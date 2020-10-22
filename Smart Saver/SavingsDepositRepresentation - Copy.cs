using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Smart_Saver
{
    public partial class SavingsDepositRepresentation : Form
    {
        struct Goal
        {
            public string name;
            public DateTime date;
            public decimal amount;

            public Goal(string goalName, DateTime goalDate, decimal goalAmount)
            {
                name = goalName;
                date = goalDate;
                amount = goalAmount;
            }
        }
        
        public SavingsDepositRepresentation()
        {
            List<DBmanager.Expense> expenses = DBmanager.ParseExpenses();
            List<DBmanager.Income> income = DBmanager.ParseIncomes();
            InitializeComponent();
            decimal balance = 0;

            const decimal goal = 2.01m; //test data

            Goal newGoal = new Goal("test goal", new DateTime(2020, 9, 30, 7, 47, 0), 2.01m);

            decimal incomeTotal = 0;

            decimal expenseTotal = 0;

            foreach (DBmanager.Expense oneExpense in expenses)
            {
                expenseTotal = CheckMonth(oneExpense.expenseDate,oneExpense.amount,expenseTotal);  
            }

            foreach (DBmanager.Income oneIncome in income)
            {
                incomeTotal = CheckMonth(oneIncome.date, oneIncome.amount, incomeTotal);
            }

            TotalExpense_TextBox.AppendText(string.Format("{0}", expenseTotal));
            TotalIncome_TextBox.AppendText(string.Format("{0}", incomeTotal));

            balance = incomeTotal - expenseTotal;

            balanceField.AppendText(string.Format("{0}", balance) + '\n');

            decimal amountToReachGoal = goal - balance;

            if (amountToReachGoal >= 0)
                amountNeeded.AppendText(string.Format("{0}", amountToReachGoal));
            else
                amountNeeded.AppendText(string.Format("{0}", 0));

            DateTime dateTimeNow = DateTime.Now;

            TimeSpan timeLeft = newGoal.date.Subtract(dateTimeNow);

            TimeToDestination_richTextBox.AppendText(string.Format("{0}", timeLeft.Days));

            if (balance >= goal)
                System.Windows.Forms.MessageBox.Show("Goal Reached");
        }
        private decimal CheckMonth(DateTime date,decimal amount,decimal Total)
        {
            
            DateTime thisDay = Convert.ToDateTime(DateTime.Now);
            int monthdt = date.Month;
            int monththis = thisDay.Month;
            if (monthdt == monththis)
            {
                return Total += amount;
            }
            else
            {
                return Total;
            }
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

        private void TotalExpense_TextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}