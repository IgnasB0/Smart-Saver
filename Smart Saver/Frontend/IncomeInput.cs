using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Smart_Saver.Backend;

namespace Smart_Saver.Frontend
{
    public partial class IncomeInput : Form
    {
        public IncomeInput()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            var m = new MainForm();
            m.Show();
        }

        private void AddIncomeBtn_Click(object sender, EventArgs e)
        {
            IncomeClass.Instance().AddIncome(Amount_Income.Value, IncomeDate.Value);
            MessageBox.Show("Income was added successfully");
        }

        private void IncomeInput_Load(object sender, EventArgs e)
        {

        }
    }
}
