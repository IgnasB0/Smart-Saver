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
            String category = CategoryName.Text;
            var m = new InputExpense(category);
            m.Show();
        }
    }
}
