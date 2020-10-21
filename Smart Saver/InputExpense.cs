using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Saver
{

    public partial class InputExpense : Form
    {

        public InputExpense()
        {
            InitializeComponent();
            category.Items.AddRange(DBmanager.ExpenseCategories.ToArray());

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
            richTextBox1.AppendText(string.Format("{0}", date.Value) + '\n');
            WriteToFile(text1:expenseName.Text, value1:expenseAmount.Value, value2:date.Value, text2:category.Text);
            MessageBox.Show("Expense was added successfully");

        }
    

        private void WriteToFile(string text1, decimal value1, DateTime value2, string text2)
        { 
            try
            {
                List<string> lines = new List<string>();
                lines.Add(text1);
                lines.Add(",");
                lines.Add(Convert.ToString(value1));
                lines.Add(",");
                DateTime date = DateTime.Parse(Convert.ToString(value2));
                lines.Add(date.ToString("yyyy-MM-dd"));
                lines.Add(",");
                lines.Add(text2);
                lines.Add(Environment.NewLine);
                using (StreamWriter outputFile = new StreamWriter("..\\..\\..\\ExpenseDB.csv", true))
                {
                    foreach (string line in lines)
                    {
                        outputFile.Write(line);
                    }

                }
            }
            catch(Exception e)
            {
                Logger.Log(e.ToString());
            }
            
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
            var m = new MainForm();
            m.Show();
        }

    }
}
