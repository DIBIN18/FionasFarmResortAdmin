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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.dgv_DailyPayrollReport = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp_To = new System.Windows.Forms.DateTimePicker();
            this.dtp_From = new System.Windows.Forms.DateTimePicker();
            this.tb_Search = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.cbSSS = new System.Windows.Forms.CheckBox();
            this.cbPAGIBIG = new System.Windows.Forms.CheckBox();
            this.cbPHILHEALTH = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DailyPayrollReport)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pictureBox4);
            this.panel3.Controls.Add(this.cbPHILHEALTH);
            this.panel3.Controls.Add(this.cbPAGIBIG);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.cbSSS);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.dgv_DailyPayrollReport);
            this.panel3.Location = new System.Drawing.Point(12, 105);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1155, 801);
            this.panel3.TabIndex = 30;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(65)))), ((int)(((byte)(0)))));
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = global::Admin_Login.Properties.Resources.Export_Icon;
            this.pictureBox4.Location = new System.Drawing.Point(113, 746);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(28, 42);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 41;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Tag = "btn_HolidaySettings";
            this.pictureBox4.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(192, 739);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(189, 50);
            this.button2.TabIndex = 7;
            this.button2.Text = "Generate Payslip";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(65)))), ((int)(((byte)(0)))));
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(19, 751);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 29);
            this.label3.TabIndex = 40;
            this.label3.Tag = "";
            this.label3.Text = "Export";
            this.label3.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::Admin_Login.Properties.Resources.RoundedRectangle_Shape_Green;
            this.pictureBox3.Location = new System.Drawing.Point(10, 743);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(144, 46);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 39;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Tag = "btn_HolidaySettings";
            this.pictureBox3.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // dgv_DailyPayrollReport
            // 
            this.dgv_DailyPayrollReport.AllowUserToOrderColumns = true;
            this.dgv_DailyPayrollReport.AllowUserToResizeColumns = false;
            this.dgv_DailyPayrollReport.AllowUserToResizeRows = false;
            this.dgv_DailyPayrollReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_DailyPayrollReport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_DailyPayrollReport.BackgroundColor = System.Drawing.Color.White;
            this.dgv_DailyPayrollReport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_DailyPayrollReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_DailyPayrollReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DailyPayrollReport.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_DailyPayrollReport.Location = new System.Drawing.Point(4, 4);
            this.dgv_DailyPayrollReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_DailyPayrollReport.MultiSelect = false;
            this.dgv_DailyPayrollReport.Name = "dgv_DailyPayrollReport";
            this.dgv_DailyPayrollReport.RowHeadersVisible = false;
            this.dgv_DailyPayrollReport.RowHeadersWidth = 51;
            this.dgv_DailyPayrollReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_DailyPayrollReport.Size = new System.Drawing.Size(1145, 726);
            this.dgv_DailyPayrollReport.TabIndex = 5;
            this.dgv_DailyPayrollReport.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDailyPayrollReport_CellDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(388, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 27);
            this.label4.TabIndex = 36;
            this.label4.Text = "To:";
            // 
            // dtp_To
            // 
            this.dtp_To.CustomFormat = "MMMM dd, yyyy";
            this.dtp_To.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_To.Location = new System.Drawing.Point(437, 34);
            this.dtp_To.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtp_To.MaxDate = new System.DateTime(2022, 10, 31, 0, 0, 0, 0);
            this.dtp_To.Name = "dtp_To";
            this.dtp_To.Size = new System.Drawing.Size(297, 36);
            this.dtp_To.TabIndex = 37;
            // 
            // dtp_From
            // 
            this.dtp_From.CustomFormat = "MMMM dd, yyyy";
            this.dtp_From.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_From.Location = new System.Drawing.Point(85, 34);
            this.dtp_From.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtp_From.Name = "dtp_From";
            this.dtp_From.Size = new System.Drawing.Size(297, 36);
            this.dtp_From.TabIndex = 31;
            this.dtp_From.ValueChanged += new System.EventHandler(this.Dt_From_ValueChanged);
            // 
            // tb_Search
            // 
            this.tb_Search.BackColor = System.Drawing.Color.White;
            this.tb_Search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Search.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Search.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.tb_Search.Location = new System.Drawing.Point(47, 4);
            this.tb_Search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_Search.Name = "tb_Search";
            this.tb_Search.Size = new System.Drawing.Size(344, 29);
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
            this.panel1.Location = new System.Drawing.Point(764, 47);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 36);
            this.panel1.TabIndex = 28;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.White;
            this.pictureBox5.Image = global::Admin_Login.Properties.Resources.Search_Icon;
            this.pictureBox5.Location = new System.Drawing.Point(8, 3);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(25, 29);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 8;
            this.pictureBox5.TabStop = false;
            // 
            // cbSSS
            // 
            this.cbSSS.AutoSize = true;
            this.cbSSS.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSSS.Location = new System.Drawing.Point(714, 749);
            this.cbSSS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbSSS.Name = "cbSSS";
            this.cbSSS.Size = new System.Drawing.Size(67, 31);
            this.cbSSS.TabIndex = 37;
            this.cbSSS.Text = "SSS";
            this.cbSSS.UseVisualStyleBackColor = true;
            this.cbSSS.CheckedChanged += new System.EventHandler(this.cbSSS_CheckedChanged);
            // 
            // cbPAGIBIG
            // 
            this.cbPAGIBIG.AutoSize = true;
            this.cbPAGIBIG.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPAGIBIG.Location = new System.Drawing.Point(819, 749);
            this.cbPAGIBIG.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbPAGIBIG.Name = "cbPAGIBIG";
            this.cbPAGIBIG.Size = new System.Drawing.Size(130, 31);
            this.cbPAGIBIG.TabIndex = 38;
            this.cbPAGIBIG.Text = "PAGIBIG";
            this.cbPAGIBIG.UseVisualStyleBackColor = true;
            this.cbPAGIBIG.CheckedChanged += new System.EventHandler(this.cbPAGIBIG_CheckedChanged);
            // 
            // cbPHILHEALTH
            // 
            this.cbPHILHEALTH.AutoSize = true;
            this.cbPHILHEALTH.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPHILHEALTH.Location = new System.Drawing.Point(974, 749);
            this.cbPHILHEALTH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbPHILHEALTH.Name = "cbPHILHEALTH";
            this.cbPHILHEALTH.Size = new System.Drawing.Size(164, 31);
            this.cbPHILHEALTH.TabIndex = 39;
            this.cbPHILHEALTH.Text = "PHILHEALTH";
            this.cbPHILHEALTH.UseVisualStyleBackColor = true;
            this.cbPHILHEALTH.CheckedChanged += new System.EventHandler(this.cbPHILHEALTH_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 27);
            this.label6.TabIndex = 40;
            this.label6.Text = "From:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.dtp_To);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtp_From);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(746, 88);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payroll covered date";
            // 
            // PayrollReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1179, 917);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PayrollReport";
            this.Tag = "btn_HolidaySettings";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DailyPayrollReport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox tb_Search;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.DataGridView dgv_DailyPayrollReport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_To;
        private System.Windows.Forms.CheckBox cbSSS;
        private System.Windows.Forms.CheckBox cbPAGIBIG;
        private System.Windows.Forms.CheckBox cbPHILHEALTH;
        public System.Windows.Forms.DateTimePicker dtp_From;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}