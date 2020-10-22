namespace Smart_Saver
{
    partial class SavingsDepositRepresentation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TotalExpense_TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TotalIncome_TextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TimeToDestination_richTextBox = new System.Windows.Forms.RichTextBox();
            this.balanceField = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.amountNeeded = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(371, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Savings Deposit Representation";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(225, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Expenses:";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // TotalExpense_TextBox
            // 
            this.TotalExpense_TextBox.Location = new System.Drawing.Point(480, 96);
            this.TotalExpense_TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TotalExpense_TextBox.Name = "TotalExpense_TextBox";
            this.TotalExpense_TextBox.Size = new System.Drawing.Size(237, 23);
            this.TotalExpense_TextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(225, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Total Income:";
            // 
            // TotalIncome_TextBox
            // 
            this.TotalIncome_TextBox.Location = new System.Drawing.Point(479, 127);
            this.TotalIncome_TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TotalIncome_TextBox.Name = "TotalIncome_TextBox";
            this.TotalIncome_TextBox.Size = new System.Drawing.Size(237, 23);
            this.TotalIncome_TextBox.TabIndex = 2;
            this.TotalIncome_TextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(225, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Time left to reach goal (in days):";
            // 
            // TimeToDestination_richTextBox
            // 
            this.TimeToDestination_richTextBox.Location = new System.Drawing.Point(480, 209);
            this.TimeToDestination_richTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TimeToDestination_richTextBox.Name = "TimeToDestination_richTextBox";
            this.TimeToDestination_richTextBox.Size = new System.Drawing.Size(238, 21);
            this.TimeToDestination_richTextBox.TabIndex = 7;
            this.TimeToDestination_richTextBox.Text = "";
            // 
            // balanceField
            // 
            this.balanceField.Location = new System.Drawing.Point(479, 155);
            this.balanceField.Name = "balanceField";
            this.balanceField.Size = new System.Drawing.Size(238, 21);
            this.balanceField.TabIndex = 9;
            this.balanceField.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(225, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Balance";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // amountNeeded
            // 
            this.amountNeeded.Location = new System.Drawing.Point(480, 182);
            this.amountNeeded.Name = "amountNeeded";
            this.amountNeeded.Size = new System.Drawing.Size(237, 22);
            this.amountNeeded.TabIndex = 11;
            this.amountNeeded.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(225, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Amount needed to reach goal";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(315, 261);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 24);
            this.button1.TabIndex = 13;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(480, 261);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 24);
            this.button2.TabIndex = 14;
            this.button2.Text = "See in chart";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // SavingsDepositRepresentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 329);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.amountNeeded);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.balanceField);
            this.Controls.Add(this.TimeToDestination_richTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TotalIncome_TextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TotalExpense_TextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SavingsDepositRepresentation";
            this.Text = "SavingsDepositRepresentation";
            this.Load += new System.EventHandler(this.SavingsDepositRepresentation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TotalExpense_TextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TotalIncome_TextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Destination_ComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox TimeToDestination_richTextBox;
        private System.Windows.Forms.Button Show_Button;
        private System.Windows.Forms.RichTextBox balanceField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox amountNeeded;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}