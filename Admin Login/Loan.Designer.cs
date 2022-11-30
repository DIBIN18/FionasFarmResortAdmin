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
            this.gbaddDeduction = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.lbStart = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbAddOtherDeduction = new System.Windows.Forms.TextBox();
            this.tbScrollNum = new System.Windows.Forms.NumericUpDown();
            this.lblIteration = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.gbaddDeduction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbScrollNum)).BeginInit();
            this.SuspendLayout();
            // 
            // gbaddDeduction
            // 
            this.gbaddDeduction.Controls.Add(this.label2);
            this.gbaddDeduction.Controls.Add(this.btnAdd);
            this.gbaddDeduction.Controls.Add(this.label14);
            this.gbaddDeduction.Controls.Add(this.dtStart);
            this.gbaddDeduction.Controls.Add(this.lbStart);
            this.gbaddDeduction.Controls.Add(this.label7);
            this.gbaddDeduction.Controls.Add(this.tbAddOtherDeduction);
            this.gbaddDeduction.Controls.Add(this.tbScrollNum);
            this.gbaddDeduction.Controls.Add(this.lblIteration);
            this.gbaddDeduction.Controls.Add(this.tbDescription);
            this.gbaddDeduction.Location = new System.Drawing.Point(12, 12);
            this.gbaddDeduction.Name = "gbaddDeduction";
            this.gbaddDeduction.Size = new System.Drawing.Size(430, 361);
            this.gbaddDeduction.TabIndex = 86;
            this.gbaddDeduction.TabStop = false;
            this.gbaddDeduction.Text = "Add Deduction";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(362, 330);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 22);
            this.label2.TabIndex = 91;
            this.label2.Tag = "";
            this.label2.Text = "Back";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(14, 330);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(51, 22);
            this.btnAdd.TabIndex = 90;
            this.btnAdd.Tag = "";
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(8, 166);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(111, 22);
            this.label14.TabIndex = 89;
            this.label14.Text = "Description";
            // 
            // dtStart
            // 
            this.dtStart.CustomFormat = "MMMM dd, yyyy";
            this.dtStart.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStart.Location = new System.Drawing.Point(194, 112);
            this.dtStart.Margin = new System.Windows.Forms.Padding(2);
            this.dtStart.Name = "dtStart";
            this.dtStart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtStart.Size = new System.Drawing.Size(219, 30);
            this.dtStart.TabIndex = 86;
            // 
            // lbStart
            // 
            this.lbStart.AutoSize = true;
            this.lbStart.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStart.Location = new System.Drawing.Point(8, 118);
            this.lbStart.Name = "lbStart";
            this.lbStart.Size = new System.Drawing.Size(82, 22);
            this.lbStart.TabIndex = 88;
            this.lbStart.Text = "Start at:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 22);
            this.label7.TabIndex = 42;
            this.label7.Text = "Total Amount";
            // 
            // tbAddOtherDeduction
            // 
            this.tbAddOtherDeduction.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddOtherDeduction.Location = new System.Drawing.Point(278, 16);
            this.tbAddOtherDeduction.Name = "tbAddOtherDeduction";
            this.tbAddOtherDeduction.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbAddOtherDeduction.Size = new System.Drawing.Size(135, 30);
            this.tbAddOtherDeduction.TabIndex = 83;
            // 
            // tbScrollNum
            // 
            this.tbScrollNum.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbScrollNum.Location = new System.Drawing.Point(278, 67);
            this.tbScrollNum.Name = "tbScrollNum";
            this.tbScrollNum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbScrollNum.Size = new System.Drawing.Size(135, 31);
            this.tbScrollNum.TabIndex = 85;
            // 
            // lblIteration
            // 
            this.lblIteration.AutoSize = true;
            this.lblIteration.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIteration.Location = new System.Drawing.Point(8, 70);
            this.lblIteration.Name = "lblIteration";
            this.lblIteration.Size = new System.Drawing.Size(266, 22);
            this.lblIteration.TabIndex = 84;
            this.lblIteration.Text = "Payment Iteration (Months):";
            // 
            // tbDescription
            // 
            this.tbDescription.BackColor = System.Drawing.Color.White;
            this.tbDescription.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescription.Location = new System.Drawing.Point(12, 206);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(401, 115);
            this.tbDescription.TabIndex = 42;
            // 
            // Loan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(456, 385);
            this.Controls.Add(this.gbaddDeduction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Loan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Loan";
            this.Load += new System.EventHandler(this.Loan_Load);
            this.gbaddDeduction.ResumeLayout(false);
            this.gbaddDeduction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbScrollNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbaddDeduction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label btnAdd;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.Label lbStart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbAddOtherDeduction;
        private System.Windows.Forms.NumericUpDown tbScrollNum;
        private System.Windows.Forms.Label lblIteration;
        private System.Windows.Forms.TextBox tbDescription;
    }
}