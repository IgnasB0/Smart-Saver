using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private void AddIncomeBtn_Click(object sender, EventArgs e)
        {
            WriteIncome(Amount_Income.Value, IncomeDate.Value);
            MessageBox.Show("Income was added successfully");
        }

        private void WriteIncome(decimal incomeValue, DateTime incomeDate)
        {
            try
            {
                List<string> lines = new List<string>();
                lines.Add(Convert.ToString(incomeValue));
                lines.Add(",");
                DateTime date = DateTime.Parse(Convert.ToString(incomeDate));
                lines.Add(date.ToString("yyyy-MM-dd"));
                lines.Add(Environment.NewLine);
                using (StreamWriter outputFile = new StreamWriter(DBmanager.incomeFilePath, true))
                {
                    foreach (string line in lines)
                    {
                        outputFile.Write(line);
                    }

                }
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
            }
        }
    }
}
