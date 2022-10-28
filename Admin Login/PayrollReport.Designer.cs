namespace Admin_Login
{
    partial class PayrollReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.dgvDailyPayrollReport = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp_To = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_From = new System.Windows.Forms.DateTimePicker();
            this.lbl_Holiday = new System.Windows.Forms.Label();
            this.tb_Search = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lbl_SortBy = new System.Windows.Forms.Label();
            this.cb_SortBy = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_Period = new System.Windows.Forms.Label();
            this.cbSSS = new System.Windows.Forms.CheckBox();
            this.cbPAGIBIG = new System.Windows.Forms.CheckBox();
            this.cbPHILHEALTH = new System.Windows.Forms.CheckBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailyPayrollReport)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pictureBox4);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.dgvDailyPayrollReport);
            this.panel3.Location = new System.Drawing.Point(16, 152);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(827, 426);
            this.panel3.TabIndex = 30;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = global::Admin_Login.Properties.Resources.Export_Icon;
            this.pictureBox4.Location = new System.Drawing.Point(92, 354);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(21, 34);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 41;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Tag = "btn_HolidaySettings";
            this.pictureBox4.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(145, 348);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 41);
            this.button2.TabIndex = 7;
            this.button2.Text = "Generate Payslip";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(22, 358);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 24);
            this.label3.TabIndex = 40;
            this.label3.Tag = "";
            this.label3.Text = "Export";
            this.label3.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::Admin_Login.Properties.Resources.RoundedRectangle_Shape;
            this.pictureBox3.Location = new System.Drawing.Point(15, 352);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(108, 37);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 39;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Tag = "btn_HolidaySettings";
            this.pictureBox3.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // dgvDailyPayrollReport
            // 
            this.dgvDailyPayrollReport.AllowUserToOrderColumns = true;
            this.dgvDailyPayrollReport.AllowUserToResizeColumns = false;
            this.dgvDailyPayrollReport.AllowUserToResizeRows = false;
            this.dgvDailyPayrollReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDailyPayrollReport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDailyPayrollReport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDailyPayrollReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDailyPayrollReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDailyPayrollReport.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDailyPayrollReport.Location = new System.Drawing.Point(3, 3);
            this.dgvDailyPayrollReport.Name = "dgvDailyPayrollReport";
            this.dgvDailyPayrollReport.RowHeadersWidth = 51;
            this.dgvDailyPayrollReport.Size = new System.Drawing.Size(819, 331);
            this.dgvDailyPayrollReport.TabIndex = 5;
            this.dgvDailyPayrollReport.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDailyPayrollReport_CellDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(476, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 26);
            this.label4.TabIndex = 36;
            this.label4.Text = "-";
            // 
            // dtp_To
            // 
            this.dtp_To.CustomFormat = "MMMM dd, yyyy";
            this.dtp_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_To.Location = new System.Drawing.Point(497, 20);
            this.dtp_To.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtp_To.Name = "dtp_To";
            this.dtp_To.Size = new System.Drawing.Size(224, 28);
            this.dtp_To.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 26);
            this.label1.TabIndex = 27;
            this.label1.Text = "Payroll covered date:";
            // 
            // dtp_From
            // 
            this.dtp_From.CustomFormat = "MMMM dd, yyyy";
            this.dtp_From.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_From.Location = new System.Drawing.Point(250, 20);
            this.dtp_From.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtp_From.Name = "dtp_From";
            this.dtp_From.Size = new System.Drawing.Size(224, 28);
            this.dtp_From.TabIndex = 31;
            this.dtp_From.ValueChanged += new System.EventHandler(this.Dt_From_ValueChanged);
            // 
            // lbl_Holiday
            // 
            this.lbl_Holiday.AutoSize = true;
            this.lbl_Holiday.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.lbl_Holiday.Location = new System.Drawing.Point(110, 63);
            this.lbl_Holiday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Holiday.Name = "lbl_Holiday";
            this.lbl_Holiday.Size = new System.Drawing.Size(0, 24);
            this.lbl_Holiday.TabIndex = 35;
            // 
            // tb_Search
            // 
            this.tb_Search.BackColor = System.Drawing.Color.White;
            this.tb_Search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Search.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.tb_Search.Location = new System.Drawing.Point(36, 6);
            this.tb_Search.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_Search.Name = "tb_Search";
            this.tb_Search.Size = new System.Drawing.Size(259, 21);
            this.tb_Search.TabIndex = 6;
            this.tb_Search.Text = " Search";
            this.tb_Search.TextChanged += new System.EventHandler(this.tb_Search_TextChanged);
            this.tb_Search.Enter += new System.EventHandler(this.Tb_Search_Enter);
            this.tb_Search.Leave += new System.EventHandler(this.Tb_Search_Leave);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.tb_Search);
            this.panel1.Location = new System.Drawing.Point(314, 53);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 37);
            this.panel1.TabIndex = 28;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.White;
            this.pictureBox5.Image = global::Admin_Login.Properties.Resources.Search_Icon;
            this.pictureBox5.Location = new System.Drawing.Point(7, 4);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(19, 28);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 8;
            this.pictureBox5.TabStop = false;
            // 
            // lbl_SortBy
            // 
            this.lbl_SortBy.AutoSize = true;
            this.lbl_SortBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SortBy.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbl_SortBy.Location = new System.Drawing.Point(9, 6);
            this.lbl_SortBy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_SortBy.Name = "lbl_SortBy";
            this.lbl_SortBy.Size = new System.Drawing.Size(73, 24);
            this.lbl_SortBy.TabIndex = 11;
            this.lbl_SortBy.Text = "Sort by:";
            // 
            // cb_SortBy
            // 
            this.cb_SortBy.AccessibleDescription = "";
            this.cb_SortBy.AccessibleName = "";
            this.cb_SortBy.BackColor = System.Drawing.Color.White;
            this.cb_SortBy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_SortBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_SortBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_SortBy.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.cb_SortBy.Items.AddRange(new object[] {
            "Default",
            "Name",
            "Gross Pay",
            "Deductions",
            "Net Pay"});
            this.cb_SortBy.Location = new System.Drawing.Point(84, 3);
            this.cb_SortBy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cb_SortBy.Name = "cb_SortBy";
            this.cb_SortBy.Size = new System.Drawing.Size(132, 30);
            this.cb_SortBy.TabIndex = 10;
            this.cb_SortBy.Text = "Default";
            this.cb_SortBy.Click += new System.EventHandler(this.Cb_SortBy_Click);
            this.cb_SortBy.Enter += new System.EventHandler(this.Cb_SortBy_Enter);
            this.cb_SortBy.Leave += new System.EventHandler(this.Cb_SortBy_Leave);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cb_SortBy);
            this.panel2.Controls.Add(this.lbl_SortBy);
            this.panel2.Location = new System.Drawing.Point(630, 53);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(219, 37);
            this.panel2.TabIndex = 29;
            // 
            // lbl_Period
            // 
            this.lbl_Period.AutoSize = true;
            this.lbl_Period.Location = new System.Drawing.Point(574, 117);
            this.lbl_Period.Name = "lbl_Period";
            this.lbl_Period.Size = new System.Drawing.Size(0, 13);
            this.lbl_Period.TabIndex = 36;
            // 
            // cbSSS
            // 
            this.cbSSS.AutoSize = true;
            this.cbSSS.Location = new System.Drawing.Point(20, 130);
            this.cbSSS.Name = "cbSSS";
            this.cbSSS.Size = new System.Drawing.Size(47, 17);
            this.cbSSS.TabIndex = 37;
            this.cbSSS.Text = "SSS";
            this.cbSSS.UseVisualStyleBackColor = true;
            this.cbSSS.CheckedChanged += new System.EventHandler(this.cbSSS_CheckedChanged);
            // 
            // cbPAGIBIG
            // 
            this.cbPAGIBIG.AutoSize = true;
            this.cbPAGIBIG.Location = new System.Drawing.Point(71, 130);
            this.cbPAGIBIG.Name = "cbPAGIBIG";
            this.cbPAGIBIG.Size = new System.Drawing.Size(69, 17);
            this.cbPAGIBIG.TabIndex = 38;
            this.cbPAGIBIG.Text = "PAGIBIG";
            this.cbPAGIBIG.UseVisualStyleBackColor = true;
            this.cbPAGIBIG.CheckedChanged += new System.EventHandler(this.cbPAGIBIG_CheckedChanged);
            // 
            // cbPHILHEALTH
            // 
            this.cbPHILHEALTH.AutoSize = true;
            this.cbPHILHEALTH.Location = new System.Drawing.Point(146, 130);
            this.cbPHILHEALTH.Name = "cbPHILHEALTH";
            this.cbPHILHEALTH.Size = new System.Drawing.Size(93, 17);
            this.cbPHILHEALTH.TabIndex = 39;
            this.cbPHILHEALTH.Text = "PHILHEALTH";
            this.cbPHILHEALTH.UseVisualStyleBackColor = true;
            this.cbPHILHEALTH.CheckedChanged += new System.EventHandler(this.cbPHILHEALTH_CheckedChanged);
            // 
            // PayrollReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(854, 592);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbPHILHEALTH);
            this.Controls.Add(this.dtp_To);
            this.Controls.Add(this.cbPAGIBIG);
            this.Controls.Add(this.cbSSS);
            this.Controls.Add(this.lbl_Period);
            this.Controls.Add(this.lbl_Holiday);
            this.Controls.Add(this.dtp_From);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PayrollReport";
            this.Tag = "btn_HolidaySettings";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PayrollReport_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailyPayrollReport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_Holiday;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox tb_Search;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_SortBy;
        private System.Windows.Forms.ComboBox cb_SortBy;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.DataGridView dgvDailyPayrollReport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_From;
        private System.Windows.Forms.DateTimePicker dtp_To;
        private System.Windows.Forms.Label lbl_Period;
        private System.Windows.Forms.CheckBox cbSSS;
        private System.Windows.Forms.CheckBox cbPAGIBIG;
        private System.Windows.Forms.CheckBox cbPHILHEALTH;
    }
}