
namespace Admin_Login
{
    partial class AddSingleSchedule
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
            this.dtpSchedOut = new System.Windows.Forms.DateTimePicker();
            this.dtpScheduleIn = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lbl_EmployeeName = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_UpdateEdit = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.btnBackEdit = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.btnAddMode = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_UpdateEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBackEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpSchedOut
            // 
            this.dtpSchedOut.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSchedOut.CustomFormat = "hh-mm";
            this.dtpSchedOut.Enabled = false;
            this.dtpSchedOut.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSchedOut.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpSchedOut.Location = new System.Drawing.Point(625, 214);
            this.dtpSchedOut.Margin = new System.Windows.Forms.Padding(2);
            this.dtpSchedOut.Name = "dtpSchedOut";
            this.dtpSchedOut.Size = new System.Drawing.Size(213, 27);
            this.dtpSchedOut.TabIndex = 77;
            this.dtpSchedOut.Value = new System.DateTime(2022, 11, 22, 17, 0, 0, 0);
            // 
            // dtpScheduleIn
            // 
            this.dtpScheduleIn.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpScheduleIn.CustomFormat = "hh-mm";
            this.dtpScheduleIn.Enabled = false;
            this.dtpScheduleIn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpScheduleIn.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpScheduleIn.Location = new System.Drawing.Point(624, 174);
            this.dtpScheduleIn.Margin = new System.Windows.Forms.Padding(2);
            this.dtpScheduleIn.Name = "dtpScheduleIn";
            this.dtpScheduleIn.Size = new System.Drawing.Size(214, 27);
            this.dtpScheduleIn.TabIndex = 76;
            this.dtpScheduleIn.Value = new System.DateTime(2022, 11, 22, 8, 0, 0, 0);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(491, 219);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(121, 21);
            this.label18.TabIndex = 75;
            this.label18.Text = "Schedule Out:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(491, 179);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(105, 21);
            this.label17.TabIndex = 74;
            this.label17.Text = "Schedule In:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(491, 127);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 21);
            this.label12.TabIndex = 80;
            this.label12.Text = "Date :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.dtpDate);
            this.panel1.Controls.Add(this.lbl_EmployeeName);
            this.panel1.Controls.Add(this.label57);
            this.panel1.Controls.Add(this.label33);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.dtpSchedOut);
            this.panel1.Controls.Add(this.btn_UpdateEdit);
            this.panel1.Controls.Add(this.dtpScheduleIn);
            this.panel1.Controls.Add(this.label31);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.pictureBox10);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.btnBackEdit);
            this.panel1.Controls.Add(this.label47);
            this.panel1.Controls.Add(this.pictureBox12);
            this.panel1.Controls.Add(this.label49);
            this.panel1.Controls.Add(this.dgvEmployees);
            this.panel1.Location = new System.Drawing.Point(11, 52);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(865, 684);
            this.panel1.TabIndex = 150;
            // 
            // dtpDate
            // 
            this.dtpDate.CalendarFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.CustomFormat = "MMMM dd, yyyy";
            this.dtpDate.Enabled = false;
            this.dtpDate.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(624, 127);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(214, 30);
            this.dtpDate.TabIndex = 155;
            // 
            // lbl_EmployeeName
            // 
            this.lbl_EmployeeName.AutoSize = true;
            this.lbl_EmployeeName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_EmployeeName.Location = new System.Drawing.Point(621, 84);
            this.lbl_EmployeeName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_EmployeeName.Name = "lbl_EmployeeName";
            this.lbl_EmployeeName.Size = new System.Drawing.Size(163, 21);
            this.lbl_EmployeeName.TabIndex = 153;
            this.lbl_EmployeeName.Text = "Select an Employee";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.Location = new System.Drawing.Point(491, 84);
            this.label57.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(90, 21);
            this.label57.TabIndex = 152;
            this.label57.Text = "Employee:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(491, 40);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(202, 23);
            this.label33.TabIndex = 151;
            this.label33.Text = "Add Single Schedule";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(101)))), ((int)(((byte)(168)))));
            this.label31.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.White;
            this.label31.Location = new System.Drawing.Point(548, 595);
            this.label31.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(48, 24);
            this.label31.TabIndex = 149;
            this.label31.Tag = "btn_Add";
            this.label31.Text = "Add";
            this.label31.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.label47.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.ForeColor = System.Drawing.Color.White;
            this.label47.Location = new System.Drawing.Point(711, 595);
            this.label47.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(55, 24);
            this.label47.TabIndex = 146;
            this.label47.Tag = "btn_Back";
            this.label47.Text = "Back";
            this.label47.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(10, 11);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(165, 23);
            this.label49.TabIndex = 144;
            this.label49.Text = "Select Employee";
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AllowUserToAddRows = false;
            this.dgvEmployees.AllowUserToDeleteRows = false;
            this.dgvEmployees.AllowUserToResizeColumns = false;
            this.dgvEmployees.AllowUserToResizeRows = false;
            this.dgvEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployees.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Location = new System.Drawing.Point(13, 40);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.ReadOnly = true;
            this.dgvEmployees.RowHeadersVisible = false;
            this.dgvEmployees.RowHeadersWidth = 51;
            this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.Size = new System.Drawing.Size(454, 626);
            this.dgvEmployees.TabIndex = 143;
            this.dgvEmployees.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployees_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(101)))), ((int)(((byte)(168)))));
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(25, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 24);
            this.label3.TabIndex = 148;
            this.label3.Tag = "btnViewOtList";
            this.label3.Text = "View Single Schedules";
            this.label3.Click += new System.EventHandler(this.view_single_schedlist);
            // 
            // btn_UpdateEdit
            // 
            this.btn_UpdateEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(101)))), ((int)(((byte)(168)))));
            this.btn_UpdateEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_UpdateEdit.Image = global::Admin_Login.Properties.Resources.Export_Icon;
            this.btn_UpdateEdit.Location = new System.Drawing.Point(624, 592);
            this.btn_UpdateEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_UpdateEdit.Name = "btn_UpdateEdit";
            this.btn_UpdateEdit.Size = new System.Drawing.Size(20, 31);
            this.btn_UpdateEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_UpdateEdit.TabIndex = 150;
            this.btn_UpdateEdit.TabStop = false;
            this.btn_UpdateEdit.Tag = "btn_Add";
            this.btn_UpdateEdit.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pictureBox10
            // 
            this.pictureBox10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox10.Image = global::Admin_Login.Properties.Resources.RoundedRectangle_Shape_Blue;
            this.pictureBox10.Location = new System.Drawing.Point(536, 588);
            this.pictureBox10.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(123, 37);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 148;
            this.pictureBox10.TabStop = false;
            this.pictureBox10.Tag = "btn_Add";
            this.pictureBox10.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnBackEdit
            // 
            this.btnBackEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.btnBackEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackEdit.Image = global::Admin_Login.Properties.Resources.Back_Icon;
            this.btnBackEdit.Location = new System.Drawing.Point(764, 592);
            this.btnBackEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnBackEdit.Name = "btnBackEdit";
            this.btnBackEdit.Size = new System.Drawing.Size(29, 31);
            this.btnBackEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnBackEdit.TabIndex = 147;
            this.btnBackEdit.TabStop = false;
            this.btnBackEdit.Tag = "btn_Back";
            this.btnBackEdit.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pictureBox12
            // 
            this.pictureBox12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox12.Image = global::Admin_Login.Properties.Resources.RoundedRectangle_Shape;
            this.pictureBox12.Location = new System.Drawing.Point(698, 588);
            this.pictureBox12.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(108, 37);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox12.TabIndex = 145;
            this.pictureBox12.TabStop = false;
            this.pictureBox12.Tag = "btn_Back";
            this.pictureBox12.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAddMode
            // 
            this.btnAddMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(101)))), ((int)(((byte)(168)))));
            this.btnAddMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddMode.Image = global::Admin_Login.Properties.Resources.AdvancedDay_Offs_Icon;
            this.btnAddMode.Location = new System.Drawing.Point(272, 14);
            this.btnAddMode.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddMode.Name = "btnAddMode";
            this.btnAddMode.Size = new System.Drawing.Size(20, 31);
            this.btnAddMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAddMode.TabIndex = 149;
            this.btnAddMode.TabStop = false;
            this.btnAddMode.Tag = "btnViewOtList";
            this.btnAddMode.Click += new System.EventHandler(this.view_single_schedlist);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = global::Admin_Login.Properties.Resources.RoundedRectangle_Shape_Blue;
            this.pictureBox4.Location = new System.Drawing.Point(12, 11);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(306, 37);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 147;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Tag = "btnViewOtList";
            this.pictureBox4.Click += new System.EventHandler(this.view_single_schedlist);
            // 
            // AddSingleSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 747);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAddMode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddSingleSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddSingleSchedule";
            this.Load += new System.EventHandler(this.AddSingleSchedule_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_UpdateEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBackEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DateTimePicker dtpSchedOut;
        public System.Windows.Forms.DateTimePicker dtpScheduleIn;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lbl_EmployeeName;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.PictureBox btn_UpdateEdit;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox btnBackEdit;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.PictureBox btnAddMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}