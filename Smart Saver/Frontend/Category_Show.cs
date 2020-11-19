using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Smart_Saver.Backend;

namespace Smart_Saver.Frontend
{
    public partial class Category_Show : Form
    {
        public Category_Show()
        {
            InitializeComponent();
            List<CategoriesClass.Category> ExpenseCategories = CategoriesClass.Instance().parseCategories();
            foreach (var _category in ExpenseCategories)
            {
                categories.Items.Add(_category.category);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ExpenseClass.Instance().GetCategoryExpenseAmount(categories.Text).ToString());
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
