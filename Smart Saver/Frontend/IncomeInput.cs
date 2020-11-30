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
        private EventAddClass eventAddClass;
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
            eventAddClass = new EventAddClass();                    
            eventAddClass.incomeReached += IncomeAdded;                          //Custom event 
            eventAddClass.Add(Amount_Income.Value, IncomeDate.Value);
        }

        public void IncomeAdded(object sender, IncomeAddEventArgs e)
        {
            IncomeClass.Instance().AddIncome(e.Amount, e.Date);
            MessageBox.Show("Income was added successfully");
        }
        private void IncomeInput_Load(object sender, EventArgs e)
        {

        }
    }
}
