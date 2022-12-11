namespace Admin_Login
{
    partial class PayRollHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPayrollRecords = new System.Windows.Forms.DataGridView();
            this.tb_Search = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.dgv_PayrollID = new System.Windows.Forms.DataGridView();
            this.btnBackEdit = new System.Windows.Forms.PictureBox();
            this.label47 = new System.Windows.Forms.Label();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tb_SearchReport = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayrollRecords)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PayrollID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBackEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPayrollRecords
            // 
            this.dgvPayrollRecords.AllowUserToAddRows = false;
            this.dgvPayrollRecords.AllowUserToOrderColumns = true;
            this.dgvPayrollRecords.AllowUserToResizeColumns = false;
            this.dgvPayrollRecords.AllowUserToResizeRows = false;
            this.dgvPayrollRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvPayrollRecords.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvPayrollRecords.BackgroundColor = System.Drawing.Color.White;
            this.dgvPayrollRecords.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPayrollRecords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPayrollRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayrollRecords.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPayrollRecords.Location = new System.Drawing.Point(10, 293);
            this.dgvPayrollRecords.MultiSelect = false;
            this.dgvPayrollRecords.Name = "dgvPayrollRecords";
            this.dgvPayrollRecords.RowHeadersVisible = false;
            this.dgvPayrollRecords.RowHeadersWidth = 51;
            this.dgvPayrollRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPayrollRecords.Size = new System.Drawing.Size(864, 380);
            this.dgvPayrollRecords.TabIndex = 6;
            // 
            // tb_Search
            // 
            this.tb_Search.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tb_Search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Search.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Search.ForeColor = System.Drawing.SystemColors.Desktop;
            this.tb_Search.Location = new System.Drawing.Point(35, 3);
            this.tb_Search.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Search.Name = "tb_Search";
            this.tb_Search.Size = new System.Drawing.Size(374, 20);
            this.tb_Search.TabIndex = 6;
            this.tb_Search.Text = " Search payroll reprot";
            this.tb_Search.Click += new System.EventHandler(this.tb_Search_Click);
            this.tb_Search.TextChanged += new System.EventHandler(this.tb_Search_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.tb_Search);
            this.panel1.Location = new System.Drawing.Point(458, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 30);
            this.panel1.TabIndex = 29;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.White;
            this.pictureBox5.Image = global::Admin_Login.Properties.Resources.Search_Icon;
            this.pictureBox5.Location = new System.Drawing.Point(6, 2);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(19, 24);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 8;
            this.pictureBox5.TabStop = false;
            // 
            // dgv_PayrollID
            // 
            this.dgv_PayrollID.AllowUserToAddRows = false;
            this.dgv_PayrollID.AllowUserToOrderColumns = true;
            this.dgv_PayrollID.AllowUserToResizeColumns = false;
            this.dgv_PayrollID.AllowUserToResizeRows = false;
            this.dgv_PayrollID.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_PayrollID.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_PayrollID.BackgroundColor = System.Drawing.Color.White;
            this.dgv_PayrollID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_PayrollID.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_PayrollID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PayrollID.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_PayrollID.Location = new System.Drawing.Point(10, 49);
            this.dgv_PayrollID.MultiSelect = false;
            this.dgv_PayrollID.Name = "dgv_PayrollID";
            this.dgv_PayrollID.RowHeadersVisible = false;
            this.dgv_PayrollID.RowHeadersWidth = 51;
            this.dgv_PayrollID.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_PayrollID.Size = new System.Drawing.Size(864, 186);
            this.dgv_PayrollID.TabIndex = 46;
            this.dgv_PayrollID.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_PayrollID_CellClick);
            // 
            // btnBackEdit
            // 
            this.btnBackEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.btnBackEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackEdit.Image = global::Admin_Login.Properties.Resources.Back_Icon;
            this.btnBackEdit.Location = new System.Drawing.Point(81, 685);
            this.btnBackEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnBackEdit.Name = "btnBackEdit";
            this.btnBackEdit.Size = new System.Drawing.Size(29, 31);
            this.btnBackEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnBackEdit.TabIndex = 156;
            this.btnBackEdit.TabStop = false;
            this.btnBackEdit.Tag = "btn_Back";
            this.btnBackEdit.Click += new System.EventHandler(this.BtnBackClick);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.label47.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.ForeColor = System.Drawing.Color.White;
            this.label47.Location = new System.Drawing.Point(28, 688);
            this.label47.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(55, 24);
            this.label47.TabIndex = 155;
            this.label47.Tag = "btn_Back";
            this.label47.Text = "Back";
            this.label47.Click += new System.EventHandler(this.BtnBackClick);
            // 
            // pictureBox12
            // 
            this.pictureBox12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox12.Image = global::Admin_Login.Properties.Resources.RoundedRectangle_Shape;
            this.pictureBox12.Location = new System.Drawing.Point(15, 681);
            this.pictureBox12.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(108, 37);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox12.TabIndex = 154;
            this.pictureBox12.TabStop = false;
            this.pictureBox12.Tag = "btn_Back";
            this.pictureBox12.Click += new System.EventHandler(this.BtnBackClick);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(65)))), ((int)(((byte)(0)))));
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = global::Admin_Login.Properties.Resources.Export_Icon;
            this.pictureBox4.Location = new System.Drawing.Point(836, 688);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(21, 34);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 159;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Tag = "btn_HolidaySettings";
            this.pictureBox4.Click += new System.EventHandler(this.btn_Export);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(65)))), ((int)(((byte)(0)))));
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(647, 691);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 24);
            this.label3.TabIndex = 158;
            this.label3.Tag = "";
            this.label3.Text = "Export This Report";
            this.label3.Click += new System.EventHandler(this.btn_Export);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::Admin_Login.Properties.Resources.RoundedRectangle_Shape_Green;
            this.pictureBox3.Location = new System.Drawing.Point(635, 682);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(240, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 157;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Tag = "btn_HolidaySettings";
            this.pictureBox3.Click += new System.EventHandler(this.btn_Export);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 23);
            this.label1.TabIndex = 160;
            this.label1.Text = "Select Payroll Report";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 23);
            this.label2.TabIndex = 161;
            this.label2.Text = "Report";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.tb_SearchReport);
            this.panel2.Location = new System.Drawing.Point(458, 258);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(416, 30);
            this.panel2.TabIndex = 162;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::Admin_Login.Properties.Resources.Search_Icon;
            this.pictureBox1.Location = new System.Drawing.Point(6, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(19, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // tb_SearchReport
            // 
            this.tb_SearchReport.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tb_SearchReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_SearchReport.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_SearchReport.ForeColor = System.Drawing.SystemColors.Desktop;
            this.tb_SearchReport.Location = new System.Drawing.Point(35, 3);
            this.tb_SearchReport.Margin = new System.Windows.Forms.Padding(2);
            this.tb_SearchReport.Name = "tb_SearchReport";
            this.tb_SearchReport.Size = new System.Drawing.Size(374, 20);
            this.tb_SearchReport.TabIndex = 6;
            this.tb_SearchReport.Text = " Search report";
            this.tb_SearchReport.Click += new System.EventHandler(this.tb_SearchReport_Click);
            this.tb_SearchReport.TextChanged += new System.EventHandler(this.tb_SearchReport_TextChanged);
            // 
            // PayRollHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(886, 734);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnBackEdit);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.pictureBox12);
            this.Controls.Add(this.dgv_PayrollID);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvPayrollRecords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PayRollHistory";
            this.Load += new System.EventHandler(this.PayRollHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayrollRecords)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PayrollID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBackEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvPayrollRecords;
        private System.Windows.Forms.TextBox tb_Search;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox5;
        public System.Windows.Forms.DataGridView dgv_PayrollID;
        private System.Windows.Forms.PictureBox btnBackEdit;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tb_SearchReport;
    }
}