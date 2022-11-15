namespace Admin_Login
{
    partial class Loan
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
            this.label14 = new System.Windows.Forms.Label();
            this.tbAddOtherDeduction = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.scrollNum = new System.Windows.Forms.NumericUpDown();
            this.cbLoanType = new System.Windows.Forms.ComboBox();
            this.lblLoanType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scrollNum)).BeginInit();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(66, 190);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 22);
            this.label14.TabIndex = 84;
            this.label14.Text = "Deduction:";
            // 
            // tbAddOtherDeduction
            // 
            this.tbAddOtherDeduction.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddOtherDeduction.Location = new System.Drawing.Point(345, 150);
            this.tbAddOtherDeduction.Name = "tbAddOtherDeduction";
            this.tbAddOtherDeduction.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbAddOtherDeduction.Size = new System.Drawing.Size(135, 30);
            this.tbAddOtherDeduction.TabIndex = 58;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(345, 186);
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(135, 30);
            this.textBox1.TabIndex = 83;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(67, 259);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(266, 22);
            this.label7.TabIndex = 40;
            this.label7.Text = "Payment Iteration (Months):";
            // 
            // scrollNum
            // 
            this.scrollNum.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scrollNum.Location = new System.Drawing.Point(345, 256);
            this.scrollNum.Name = "scrollNum";
            this.scrollNum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.scrollNum.Size = new System.Drawing.Size(133, 31);
            this.scrollNum.TabIndex = 82;
            // 
            // cbLoanType
            // 
            this.cbLoanType.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLoanType.FormattingEnabled = true;
            this.cbLoanType.Items.AddRange(new object[] {
            "COPANY loan",
            "SSS loan",
            "PAGIBIG loan",
            "OTHER"});
            this.cbLoanType.Location = new System.Drawing.Point(345, 222);
            this.cbLoanType.Name = "cbLoanType";
            this.cbLoanType.Size = new System.Drawing.Size(135, 29);
            this.cbLoanType.TabIndex = 66;
            // 
            // lblLoanType
            // 
            this.lblLoanType.AutoSize = true;
            this.lblLoanType.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoanType.Location = new System.Drawing.Point(66, 225);
            this.lblLoanType.Name = "lblLoanType";
            this.lblLoanType.Size = new System.Drawing.Size(160, 22);
            this.lblLoanType.TabIndex = 67;
            this.lblLoanType.Text = "Deduction type:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(496, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 23);
            this.label1.TabIndex = 85;
            this.label1.Text = "Back";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 22);
            this.label2.TabIndex = 86;
            this.label2.Text = "Remaing:";
            // 
            // Loan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(565, 385);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tbAddOtherDeduction);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblLoanType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbLoanType);
            this.Controls.Add(this.scrollNum);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Loan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Loan";
            this.Load += new System.EventHandler(this.Loan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scrollNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbAddOtherDeduction;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown scrollNum;
        private System.Windows.Forms.ComboBox cbLoanType;
        private System.Windows.Forms.Label lblLoanType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}