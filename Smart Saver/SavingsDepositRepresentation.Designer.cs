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
            this.label4 = new System.Windows.Forms.Label();
            this.Destination_ComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TimeToDestination_richTextBox = new System.Windows.Forms.RichTextBox();
            this.Show_Button = new System.Windows.Forms.Button();
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
            this.label2.Location = new System.Drawing.Point(257, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total expense:";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // TotalExpense_TextBox
            // 
            this.TotalExpense_TextBox.Location = new System.Drawing.Point(547, 130);
            this.TotalExpense_TextBox.Name = "TotalExpense_TextBox";
            this.TotalExpense_TextBox.Size = new System.Drawing.Size(270, 27);
            this.TotalExpense_TextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(257, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Total income: ";
            // 
            // TotalIncome_TextBox
            // 
            this.TotalIncome_TextBox.Location = new System.Drawing.Point(547, 169);
            this.TotalIncome_TextBox.Name = "TotalIncome_TextBox";
            this.TotalIncome_TextBox.Size = new System.Drawing.Size(270, 27);
            this.TotalIncome_TextBox.TabIndex = 2;
            this.TotalIncome_TextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(257, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Choose the destination:";
            // 
            // Destination_ComboBox
            // 
            this.Destination_ComboBox.FormattingEnabled = true;
            this.Destination_ComboBox.Location = new System.Drawing.Point(547, 86);
            this.Destination_ComboBox.Name = "Destination_ComboBox";
            this.Destination_ComboBox.Size = new System.Drawing.Size(270, 28);
            this.Destination_ComboBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(257, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(284, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Left time to destination (in months):";
            // 
            // TimeToDestination_richTextBox
            // 
            this.TimeToDestination_richTextBox.Location = new System.Drawing.Point(547, 217);
            this.TimeToDestination_richTextBox.Name = "TimeToDestination_richTextBox";
            this.TimeToDestination_richTextBox.Size = new System.Drawing.Size(272, 27);
            this.TimeToDestination_richTextBox.TabIndex = 7;
            this.TimeToDestination_richTextBox.Text = "";
            // 
            // Show_Button
            // 
            this.Show_Button.Location = new System.Drawing.Point(855, 86);
            this.Show_Button.Name = "Show_Button";
            this.Show_Button.Size = new System.Drawing.Size(112, 24);
            this.Show_Button.TabIndex = 8;
            this.Show_Button.Text = "Show";
            this.Show_Button.UseVisualStyleBackColor = true;
            // 
            // SavingsDepositRepresentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 439);
            this.Controls.Add(this.Show_Button);
            this.Controls.Add(this.TimeToDestination_richTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Destination_ComboBox);
            this.Controls.Add(this.label4);
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
    }
}