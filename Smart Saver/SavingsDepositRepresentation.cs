﻿using System;
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
<<<<<<< Updated upstream
            List<DBmanager.Expense> expenses = DBmanager.ParseExpenses();

=======
>>>>>>> Stashed changes
            InitializeComponent();

<<<<<<< Updated upstream

            List<Income> incomeList = new List<Income>();

            Income newIncome = new Income(5.10m, new DateTime(2020, 9, 26, 7, 47, 0));
            incomeList.Add(newIncome);

            const decimal goal = 2.01m; //test data
=======
            DBmanager.Goal goal = DBmanager.ParseGoal();
>>>>>>> Stashed changes


            decimal monthlyExpenses = DBmanager.MonthlyExpenses();

<<<<<<< Updated upstream
            foreach (Income income in incomeList)
            {
                incomeTotal += income.amount;
            }
            TotalIncome_TextBox.AppendText(string.Format("{0}", incomeTotal));

            decimal expenseTotal = 0;

            foreach (DBmanager.Expense oneExpense in expenses)
            {
                expenseTotal += oneExpense.amount;
            }

            TotalExpense_TextBox.AppendText(string.Format("{0}", expenseTotal));
=======
            TotalExpense_TextBox.AppendText(string.Format("{0}", monthlyExpenses));

            decimal monthlyIncome = DBmanager.MonthlyIncome();

            TotalIncome_TextBox.AppendText(string.Format("{0}", monthlyIncome));
>>>>>>> Stashed changes

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