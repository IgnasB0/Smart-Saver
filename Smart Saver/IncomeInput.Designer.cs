namespace Smart_Saver
{
    partial class IncomeInput
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
            this.Amount_Income = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.IncomeDate = new System.Windows.Forms.DateTimePicker();
            this.AddIncomeBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.IncomeOutputField = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Amount_Income)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(454, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Income input";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(298, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Amount (per month):";
            // 
            // Amount_Income
            // 
            this.Amount_Income.DecimalPlaces = 2;
            this.Amount_Income.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.Amount_Income.Location = new System.Drawing.Point(518, 120);
            this.Amount_Income.Name = "Amount_Income";
            this.Amount_Income.Size = new System.Drawing.Size(240, 27);
            this.Amount_Income.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(298, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Date:";
            // 
            // IncomeDate
            // 
            this.IncomeDate.Location = new System.Drawing.Point(518, 193);
            this.IncomeDate.Name = "IncomeDate";
            this.IncomeDate.Size = new System.Drawing.Size(240, 27);
            this.IncomeDate.TabIndex = 4;
            // 
            // AddIncomeBtn
            // 
            this.AddIncomeBtn.Location = new System.Drawing.Point(631, 258);
            this.AddIncomeBtn.Name = "AddIncomeBtn";
            this.AddIncomeBtn.Size = new System.Drawing.Size(127, 27);
            this.AddIncomeBtn.TabIndex = 5;
            this.AddIncomeBtn.Text = "Add";
            this.AddIncomeBtn.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(298, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Your income:";
            // 
            // IncomeOutputField
            // 
            this.IncomeOutputField.Location = new System.Drawing.Point(517, 310);
            this.IncomeOutputField.Name = "IncomeOutputField";
            this.IncomeOutputField.Size = new System.Drawing.Size(241, 114);
            this.IncomeOutputField.TabIndex = 7;
            this.IncomeOutputField.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(504, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 28);
            this.button1.TabIndex = 8;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // IncomeInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 498);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.IncomeOutputField);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AddIncomeBtn);
            this.Controls.Add(this.IncomeDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Amount_Income);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "IncomeInput";
            this.Text = "IncomeInput";
            ((System.ComponentModel.ISupportInitialize)(this.Amount_Income)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Amount_Income;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker IncomeDate;
        private System.Windows.Forms.Button AddIncomeBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox IncomeOutputField;
        private System.Windows.Forms.Button button1;
    }
}