using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Smart_Saver
{
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string category = CategoryName.Text;
            var m = new InputExpense(category);
            m.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            var m = new MainForm();
            m.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string category = CategoryName.Text;
            if (string.IsNullOrEmpty(category)){
                MessageBox.Show("Please enter the category");
            }
            else
            {
                MessageBox.Show("Category was added successfully");
            }
           
            
        }

        private void Categories_Load(object sender, EventArgs e)
        {

        }
    }
}
