namespace Admin_Login
{
    partial class AttendanceRecord
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvAttendanceRecord = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.tb_Search = new System.Windows.Forms.TextBox();
            this.dtp_Date = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.AddAttendance = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceRecord)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgvAttendanceRecord);
            this.panel3.Location = new System.Drawing.Point(12, 63);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1155, 843);
            this.panel3.TabIndex = 25;
            // 
            // dgvAttendanceRecord
            // 
            this.dgvAttendanceRecord.AllowUserToAddRows = false;
            this.dgvAttendanceRecord.AllowUserToDeleteRows = false;
            this.dgvAttendanceRecord.AllowUserToResizeColumns = false;
            this.dgvAttendanceRecord.AllowUserToResizeRows = false;
            this.dgvAttendanceRecord.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvAttendanceRecord.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvAttendanceRecord.BackgroundColor = System.Drawing.Color.White;
            this.dgvAttendanceRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendanceRecord.Location = new System.Drawing.Point(4, 1);
            this.dgvAttendanceRecord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvAttendanceRecord.Name = "dgvAttendanceRecord";
            this.dgvAttendanceRecord.ReadOnly = true;
            this.dgvAttendanceRecord.RowHeadersVisible = false;
            this.dgvAttendanceRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttendanceRecord.Size = new System.Drawing.Size(1147, 834);
            this.dgvAttendanceRecord.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.tb_Search);
            this.panel1.Location = new System.Drawing.Point(709, 9);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(458, 45);
            this.panel1.TabIndex = 20;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.White;
            this.pictureBox5.Image = global::Admin_Login.Properties.Resources.Search_Icon;
            this.pictureBox5.Location = new System.Drawing.Point(9, 5);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(25, 34);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 8;
            this.pictureBox5.TabStop = false;
            // 
            // tb_Search
            // 
            this.tb_Search.BackColor = System.Drawing.Color.White;
            this.tb_Search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Search.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Search.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.tb_Search.Location = new System.Drawing.Point(48, 7);
            this.tb_Search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_Search.Name = "tb_Search";
            this.tb_Search.Size = new System.Drawing.Size(345, 23);
            this.tb_Search.TabIndex = 6;
            this.tb_Search.Text = " Search";
            this.tb_Search.Enter += new System.EventHandler(this.Tb_Search_Enter);
            this.tb_Search.Leave += new System.EventHandler(this.Tb_Search_Leave);
            // 
            // dtp_Date
            // 
            this.dtp_Date.CustomFormat = "MMMM dd, yyyy";
            this.dtp_Date.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Date.Location = new System.Drawing.Point(407, 14);
            this.dtp_Date.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtp_Date.Name = "dtp_Date";
            this.dtp_Date.Size = new System.Drawing.Size(297, 30);
            this.dtp_Date.TabIndex = 26;
            this.dtp_Date.ValueChanged += new System.EventHandler(this.dtp_Date_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(313, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 26);
            this.label1.TabIndex = 5;
            this.label1.Tag = "btnAddAttendance";
            this.label1.Text = "Date:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(101)))), ((int)(((byte)(168)))));
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::Admin_Login.Properties.Resources.LateToday_Icon1;
            this.pictureBox2.Location = new System.Drawing.Point(212, 12);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 39);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "btnAddAttendance";
            this.pictureBox2.Click += new System.EventHandler(this.btn_addAttendance);
            // 
            // AddAttendance
            // 
            this.AddAttendance.AutoSize = true;
            this.AddAttendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(101)))), ((int)(((byte)(168)))));
            this.AddAttendance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddAttendance.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddAttendance.ForeColor = System.Drawing.Color.White;
            this.AddAttendance.Location = new System.Drawing.Point(35, 17);
            this.AddAttendance.Name = "AddAttendance";
            this.AddAttendance.Size = new System.Drawing.Size(96, 24);
            this.AddAttendance.TabIndex = 33;
            this.AddAttendance.Tag = "btnAddAttendance";
            this.AddAttendance.Text = "Add/Edit ";
            this.AddAttendance.Click += new System.EventHandler(this.btn_addAttendance);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Admin_Login.Properties.Resources.RoundedRectangle_Shape_Blue;
            this.pictureBox1.Location = new System.Drawing.Point(9, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(259, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "btnAddAttendance";
            this.pictureBox1.Click += new System.EventHandler(this.btn_addAttendance);
            // 
            // AttendanceRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1179, 917);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.AddAttendance);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp_Date);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AttendanceRecord";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AttendanceRecord_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceRecord)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TextBox tb_Search;
        private System.Windows.Forms.DateTimePicker dtp_Date;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAttendanceRecord;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label AddAttendance;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}