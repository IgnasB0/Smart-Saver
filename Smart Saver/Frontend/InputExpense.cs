using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Smart_Saver.Backend;

namespace Smart_Saver.Frontend
{

    public partial class InputExpense : Form
    {
        public delegate void AddExpenseParametirezed(string expenseName, decimal expenseAmount, DateTime expenseDate, string expenseCategory);        //delegate, anonymous method initiation
        
        public InputExpense()
        {
            InitializeComponent();
        }
        public InputExpense(string Category)
        {
            InitializeComponent();
            category.Items.Add(Category);
            category.Text = Category;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(category.Text + '\n');
            richTextBox1.AppendText(string.Format("{0}", expenseAmount.Value) + '\n');
            richTextBox1.AppendText(expenseName.Text + '\n');
            richTextBox1.AppendText(string.Format("{0}", DateTime.Now));
            try
            {
                AddExpenseParametirezed addexpense = delegate (string _name, decimal _amount, DateTime date, string _category)
                {
                    MessageBox.Show(_name + " income was added successfully to " +  _category + " category");           //Anonymous method
                };                                                                                                  
                addexpense(expenseName.Text, expenseAmount.Value, DateTime.Now, category.Text);
                addexpense = new AddExpenseParametirezed(ExpenseClass.Instance().AddExpense);
                addexpense(expenseName.Text, expenseAmount.Value, DateTime.Now, category.Text);
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(ex.ToString());
            }

            //ExpenseClass.Instance().AddExpense(expenseName: expenseName.Text, expenseCategory: category.Text, expenseDate: DateTime.Now, expenseAmount: expenseAmount.Value);
            //MessageBox.Show("Expense was added successfully");

        }
        
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void InputExpense_Load(object sender, EventArgs e)
        {

        }

        private void category_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            var m = new CategoriesLoad();
            m.Show();
        }

    }
}
