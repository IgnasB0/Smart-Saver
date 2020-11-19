using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Smart_Saver.Backend;


namespace Smart_Saver.Frontend
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            FrontendController.Instance().userInfo(Usertextarea);

            expensesLabel.Text = string.Format("{0}", FrontendController.Instance().GetMonthlyExpenses());
            incomeLabel.Text = string.Format("{0}", FrontendController.Instance().GetMonthlyIncome());
            balanceLabel.Text = string.Format("{0}", FrontendController.Instance().GetMonthlyBalance());
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Load_MenuToolStripMenuItem();
        }

        private void Load_MenuToolStripMenuItem()
        {
            foreach(String items in FrontendController.Instance().Get_Items_For_Menu())
            {
                ToolStripMenuItem item = new ToolStripMenuItem(items);
                toolStripDropDownButton1.DropDownItems.Add(item);
                item.Click += new EventHandler(Item_Click);
            }
            foreach (String items in FrontendController.Instance().Get_Items_For_Expense())
            {
                ToolStripMenuItem item = new ToolStripMenuItem(items);
                toolStripDropDownButton2.DropDownItems.Add(item);
                item.Click += new EventHandler(Item_Click);
            }
            foreach (String items in FrontendController.Instance().Get_Items_For_Settings())
            {
                ToolStripMenuItem item = new ToolStripMenuItem(items);
                item.Click += new EventHandler(Item_Click);
            }

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
