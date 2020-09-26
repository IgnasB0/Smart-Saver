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
        struct Expense
        {
            public decimal amount;
            public DateTime date;

            public Expense(decimal expenseAmount, DateTime expenseDate)
            {
                amount = expenseAmount;
                date = expenseDate;
            }
        }
        struct Income
        {
            public decimal amount;
            public DateTime date;

            public Income(decimal incomeAmount, DateTime incomeDate)
            {
                amount = incomeAmount;
                date = incomeDate;
            }
        }

        public SavingsDepositRepresentation()
        {
            InitializeComponent();
            decimal balance = 0;

            List<Expense> expenseList = new List<Expense>();

            Expense newExpense = new Expense(1.12m, new DateTime(2020, 9, 26, 7, 47, 0));
            expenseList.Add(newExpense);

            newExpense = new Expense(2.31m, new DateTime(2020, 9, 26, 7, 47, 0));
            expenseList.Add(newExpense);

            List<Income> incomeList = new List<Income>();

            Income newIncome = new Income(5.11m, new DateTime(2020, 9, 26, 7, 47, 0));
            incomeList.Add(newIncome);

            const decimal goal = 2.01m; //test data

            decimal incomeTotal = 0;

            foreach (Income income in incomeList)
            {
                incomeTotal += income.amount;
            }
            TotalIncome_TextBox.AppendText( string.Format("{0}", incomeTotal) );

            decimal expenseTotal = 0;

            foreach (Expense expense in expenseList)
            {
                expenseTotal += expense.amount;
            }
            TotalExpense_TextBox.AppendText(string.Format("{0}", expenseTotal) );

            balance = incomeTotal - expenseTotal;

            balanceField.AppendText( string.Format("{0}", balance) + '\n');

            decimal amountToReachGoal = goal - balance;

            if (amountToReachGoal >= 0)
                amountNeeded.AppendText(string.Format("{0}", amountToReachGoal) + '\n');
            else
                amountNeeded.AppendText(string.Format("{0}", 0) + '\n');

            if (balance >= goal)
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
    }
}
