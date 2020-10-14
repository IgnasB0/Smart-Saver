using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Smart_Saver
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
    }
}
