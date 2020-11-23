using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Smart_Saver.Backend;

namespace Smart_Saver.Frontend
{
    public partial class CategoriesLoad : Form
    {
        public CategoriesLoad()
        {
            InitializeComponent();
            
        }
  
        private void CategoriesLoad_Load(object sender, EventArgs e)
        {
            //Async api request
            CategoriesClass.Instance().load(this, btn_msg, button1_Click, button2_Click);
        }
        public void btn_msg(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string s = (sender as Button).Name;
            this.Close();
            var m = new InputExpense(s);
            m.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            var m = new MainForm();
            m.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            var m = new Categories();
            m.Show();
        }
    }
}
