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
            this.label1.Location = new System.Drawing.Point(424, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Savings Deposit Representation";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(257, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Expense total:";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // TotalExpense_TextBox
            // 
            this.TotalExpense_TextBox.Location = new System.Drawing.Point(549, 128);
            this.TotalExpense_TextBox.Name = "TotalExpense_TextBox";
            this.TotalExpense_TextBox.Size = new System.Drawing.Size(270, 27);
            this.TotalExpense_TextBox.TabIndex = 2;
            this.TotalExpense_TextBox.TextChanged += new System.EventHandler(this.TotalExpense_TextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(257, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Income total: ";
            // 
            // TotalIncome_TextBox
            // 
            this.TotalIncome_TextBox.Location = new System.Drawing.Point(547, 169);
            this.TotalIncome_TextBox.Name = "TotalIncome_TextBox";
            this.TotalIncome_TextBox.Size = new System.Drawing.Size(270, 27);
            this.TotalIncome_TextBox.TabIndex = 2;
            this.TotalIncome_TextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(257, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(254, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Time left to reach goal (in days):";
            // 
            // TimeToDestination_richTextBox
            // 
            this.TimeToDestination_richTextBox.Location = new System.Drawing.Point(549, 279);
            this.TimeToDestination_richTextBox.Name = "TimeToDestination_richTextBox";
            this.TimeToDestination_richTextBox.Size = new System.Drawing.Size(271, 27);
            this.TimeToDestination_richTextBox.TabIndex = 7;
            this.TimeToDestination_richTextBox.Text = "";
            // 
            // balanceField
            // 
            this.balanceField.Location = new System.Drawing.Point(547, 207);
            this.balanceField.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.balanceField.Name = "balanceField";
            this.balanceField.Size = new System.Drawing.Size(271, 27);
            this.balanceField.TabIndex = 9;
            this.balanceField.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(257, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Balance";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // amountNeeded
            // 
            this.amountNeeded.Location = new System.Drawing.Point(549, 243);
            this.amountNeeded.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.amountNeeded.Name = "amountNeeded";
            this.amountNeeded.Size = new System.Drawing.Size(270, 28);
            this.amountNeeded.TabIndex = 11;
            this.amountNeeded.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(257, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(208, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Amount needed to reach goal";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(360, 348);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 32);
            this.button1.TabIndex = 13;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(549, 348);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 32);
            this.button2.TabIndex = 14;
            this.button2.Text = "See in chart";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // SavingsDepositRepresentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 439);
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