using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Smart_Saver
{
    public partial class Category_Show : Form
    {
        public Category_Show()
        {
            InitializeComponent();
            categories.Items.AddRange(ExpenseClass.ExpenseCategories.ToArray());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ExpenseClass.GetCategoryExpenseAmount(categories.Text).ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            var c = new MainForm();
            c.Show();
        }

        private void Category_Show_Load(object sender, EventArgs e)
        {

        }
    }
}
