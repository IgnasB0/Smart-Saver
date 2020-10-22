﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace Smart_Saver
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            userinfo();

            // userinfo();

            decimal monthlyExpenses = DBmanager.MonthlyExpenses();

            expensesLabel.Text = string.Format("{0}", monthlyExpenses);

            decimal monthlyIncome = DBmanager.MonthlyIncome();

            incomeLabel.Text = string.Format("{0}", monthlyIncome);

            balanceLabel.Text = string.Format("{0}", monthlyIncome - monthlyExpenses);
        }

        private void userinfo()
        {
            using (var reader = new StreamReader("..\\..\\..\\UserDB.csv"))
            {
                List<string> listA = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    listA.Add(values[0]);
                    listA.Add(values[1]);
                    listA.Add(values[2]);

                }
                try //Exception is thrown
                {
                    Usertextarea.AppendText(listA[1] + " " + listA[2]);
                }
                catch (Exception e)
                {
                    Logger.Log(e.ToString());
                }
            }
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
                toolStripDropDownButton3.DropDownItems.Add(item);
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
                var m = new InputExpense();
                m.Show();

            }
            else if (item.Text == "Add Category")
            {
                this.Hide();
                var m = new Categories();
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

        private List<String> Get_Items_For_Menu()
        {
            List<String> menu_item = new List<String>();
            menu_item.Add("Add Income");

            return menu_item;
        }
        private List<String> Get_Items_For_Expense()
        {
            List<String> menu_item = new List<String>();
            menu_item.Add("Add Expense");
            menu_item.Add("Add Category");

            return menu_item;
        }
        private List<String> Get_Items_For_Settings()
        {
            List<String> menu_item = new List<String>();
            menu_item.Add("Edit Profile");
            menu_item.Add("Log out");

            return menu_item;
        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
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
    }
}