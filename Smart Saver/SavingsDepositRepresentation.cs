using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Smart_Saver
{
    public partial class SavingsDepositRepresentation : Form
    {

        public SavingsDepositRepresentation()
        {
            List<DBmanager.Expense> expenses = DBmanager.ParseExpenses();

            InitializeComponent();

   
            DBmanager.Goal goal = DBmanager.ParseGoal();


            decimal monthlyExpenses = DBmanager.MonthlyExpenses();

            TotalExpense_TextBox.AppendText(string.Format("{0}", monthlyExpenses));

            decimal monthlyIncome = DBmanager.MonthlyIncome();

            TotalIncome_TextBox.AppendText(string.Format("{0}", monthlyIncome));

            decimal balance = monthlyIncome - monthlyExpenses;

            balanceField.AppendText(string.Format("{0}", balance) + '\n');

            decimal amountToReachGoal = goal.amount - balance;

            if (amountToReachGoal >= 0)
                amountNeeded.AppendText(string.Format("{0}", amountToReachGoal));
            else
                amountNeeded.AppendText(string.Format("{0}", 0));

            DateTime dateTimeNow = DateTime.Now;

            TimeSpan timeLeft = goal.date.Subtract(dateTimeNow);

            TimeToDestination_richTextBox.AppendText(string.Format("{0}", timeLeft.Days));

            if (balance >= goal.amount)
                System.Windows.Forms.MessageBox.Show("Goal Reached");
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
    }
}