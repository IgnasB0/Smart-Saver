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


namespace Smart_Saver
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            userinfo();

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
            ChartRepresentation();
        }

        private void ChartRepresentation()
        {
            var c = WriteBalance();
            string fullpath = DBmanager.Index;
            string fullpath2 = DBmanager.OUTPUT;
            //Read HTML from file
            var content = File.ReadAllText(fullpath);
            string _write = "var data = google.visualization.arrayToDataTable([";

            _write += "['Date', 'Balance'],";
            int i = 0;
            foreach (var cat in c)
            {
                foreach (var categ in c)
                {
                    if (categ.monthAndYear == cat.monthAndYear && categ.Type == "Expense" && cat.Type == "Income")
                    {
                        i++;
                        i++;
                        if (i - 1 == c.Count() - 1)
                        {
                            _write += "['" + categ.monthAndYear + "'," + (cat.amount - categ.amount) + "]]);";
                        }
                        else
                        {
                            _write += "['" + categ.monthAndYear + "'," + (cat.amount - categ.amount) + "],";
                        }
                    }
                }
            }
            content = content.Replace("var data = google.visualization.arrayToDataTable([]);", _write);
            File.WriteAllText(fullpath2, content);
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/c" + "\"" + fullpath2 + "\"";
            System.Diagnostics.Process.Start(startInfo);
        }

        public IEnumerable<Result> WriteBalance()
        {
            List<DBmanager.Income> incomes = DBmanager.ParseIncomes();
            List<DBmanager.Expense> expenses = DBmanager.ParseExpenses();
            var _expenses = from expense in expenses
                        orderby expense.expenseDate ascending
                        group expense.amount by new
                        {
                            Year = expense.expenseDate.Year,
                            Month = expense.expenseDate.Month                 // LINQ using
                        } into g
                        select new Result
                        {
                            monthAndYear = g.Key.Year + "-" + g.Key.Month,
                            amount = g.Sum(),
                            Type = "Expense"
                        };

            var _incomes = from income in incomes
                         orderby income.date ascending
                         group income.amount by new
                         {
                             Year = income.date.Year,
                             Month = income.date.Month
                         } into g
                         select new Result
                         {
                             monthAndYear = g.Key.Year + "-" + g.Key.Month,
                             amount = g.Sum(),
                             Type = "Income"
                         };

            var o = _expenses.Concat(_incomes).ToList();
            return o;
        }
    }
}
