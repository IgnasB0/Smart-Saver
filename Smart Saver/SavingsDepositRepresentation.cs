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
            List<ExpenseClass.Expense> expenses = ExpenseClass.Instance().ParseExpenses();

            InitializeComponent();

   

            TotalExpense_TextBox.AppendText(string.Format("{0}", FrontendController.GetMonthlyExpenses()));
            TotalIncome_TextBox.AppendText(string.Format("{0}", FrontendController.GetMonthlyIncome()));
            balanceField.AppendText(string.Format("{0}", FrontendController.GetMonthlyBalance()) + '\n');

            if (FrontendController.GetAmountToReachGoal() >= 0)
                amountNeeded.AppendText(string.Format("{0}", FrontendController.GetAmountToReachGoal()));
            else
                amountNeeded.AppendText(string.Format("{0}", 0));

            TimeToDestination_richTextBox.AppendText(string.Format("{0}", FrontendController.TimeLeftUntilGoal().Days));

            if (FrontendController.GetMonthlyBalance() >= FrontendController.GetGoalAmount())
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