using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Smart_Saver.Backend;

namespace Smart_Saver.Frontend
{
    public partial class SavingsDepositRepresentation : Form
    {

        public SavingsDepositRepresentation()
        {
            List<ExpenseClass.Expense> expenses = ExpenseClass.Instance().ParseExpenses();

            InitializeComponent();

   

            TotalExpense_TextBox.AppendText(string.Format("{0}", FrontendController.Instance().GetMonthlyExpenses()));
            TotalIncome_TextBox.AppendText(string.Format("{0}", FrontendController.Instance().GetMonthlyIncome()));
            balanceField.AppendText(string.Format("{0}", FrontendController.Instance().GetMonthlyBalance()) + '\n');

            if (FrontendController.Instance().GetAmountToReachGoal() >= 0)
                amountNeeded.AppendText(string.Format("{0}", FrontendController.Instance().GetAmountToReachGoal()));
            else
                amountNeeded.AppendText(string.Format("{0}", 0));

            TimeToDestination_richTextBox.AppendText(string.Format("{0}", FrontendController.Instance().TimeLeftUntilGoal()));

            if (FrontendController.Instance().GetMonthlyBalance() >= FrontendController.Instance().GetGoalAmount())
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

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}