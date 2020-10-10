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

namespace Smart_Saver
{

    public partial class InputExpense : Form
    {
        public InputExpense()
        {
            InitializeComponent();
            category.Items.Add("Transportation");
            category.Items.Add("Food");
            category.Items.Add("Health");
            category.Items.Add("Entertainment");
            category.Items.Add("Taxes");
            category.Items.Add("Household items");
            category.Items.Add("Outfit");
            category.Items.Add("investments");

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
            rasytiifaila(category.Text,expenseAmount.Value,expenseName.Text, date.Value);

        }

        private void rasytiifaila(string text1, decimal value1, string text2, DateTime value2)
        {
            List<string> lines = new List<string>();
            lines.Add(text1);
            lines.Add(Convert.ToString(value1));
            lines.Add(text2);
            lines.Add(Convert.ToString(value2));

            using (StreamWriter outputFile = new StreamWriter("..\\..\\..\\output.txt", true))
            {
                foreach (string line in lines)
                {
                    outputFile.WriteLine(line);
                }
                   
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
            var m = new MainForm();
            m.Show();
            this.Close();
        }
    }
}
