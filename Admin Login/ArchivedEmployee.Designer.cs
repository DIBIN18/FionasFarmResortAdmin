namespace Admin_Login
{
    partial class ArchivedEmployee
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
            this.components = new System.ComponentModel.Container();
            this.dgvArchive = new System.Windows.Forms.DataGridView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.TB_SearchArchive = new System.Windows.Forms.TextBox();
            this.fFRUsersDataSet17 = new Admin_Login.FFRUsersDataSet17();
            this.archiveBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.archiveTableAdapter = new Admin_Login.FFRUsersDataSet17TableAdapters.ArchiveTableAdapter();
            this.employeeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.middleNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sSSIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pAGIBIGNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pHILHEALTHNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeMaritalStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateHiredDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jobStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fFRUsersDataSet17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.archiveBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArchive
            // 
            this.dgvArchive.AllowUserToAddRows = false;
            this.dgvArchive.AllowUserToDeleteRows = false;
            this.dgvArchive.AutoGenerateColumns = false;
            this.dgvArchive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArchive.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.employeeIDDataGridViewTextBoxColumn,
            this.firstNameDataGridViewTextBoxColumn,
            this.lastNameDataGridViewTextBoxColumn,
            this.middleNameDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.sSSIDDataGridViewTextBoxColumn,
            this.pAGIBIGNODataGridViewTextBoxColumn,
            this.pHILHEALTHNODataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.employeeMaritalStatusDataGridViewTextBoxColumn,
            this.contactNumberDataGridViewTextBoxColumn,
            this.dateHiredDataGridViewTextBoxColumn,
            this.genderDataGridViewTextBoxColumn,
            this.birthDateDataGridViewTextBoxColumn,
            this.departmentDataGridViewTextBoxColumn,
            this.positionDataGridViewTextBoxColumn,
            this.jobStatusDataGridViewTextBoxColumn});
            this.dgvArchive.DataSource = this.archiveBindingSource;
            this.dgvArchive.Location = new System.Drawing.Point(16, 64);
            this.dgvArchive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvArchive.Name = "dgvArchive";
            this.dgvArchive.ReadOnly = true;
            this.dgvArchive.RowHeadersWidth = 51;
            this.dgvArchive.Size = new System.Drawing.Size(1088, 604);
            this.dgvArchive.TabIndex = 0;
            this.dgvArchive.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArchiveCellClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::Admin_Login.Properties.Resources.AddNew_Icon;
            this.pictureBox2.Location = new System.Drawing.Point(140, 15);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "btn_AddNew";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(35, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 27);
            this.label1.TabIndex = 4;
            this.label1.Tag = "btn_AddNew";
            this.label1.Text = "Search";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Admin_Login.Properties.Resources.RoundedRectangle_Shape;
            this.pictureBox1.Location = new System.Drawing.Point(11, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "btn_AddNew";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::Admin_Login.Properties.Resources.AddNew_Icon;
            this.pictureBox3.Location = new System.Drawing.Point(903, 17);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(27, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Tag = "btn_AddNew";
            this.pictureBox3.Click += new System.EventHandler(this.btnRestore);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(797, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 27);
            this.label2.TabIndex = 7;
            this.label2.Tag = "btn_AddNew";
            this.label2.Text = "Restore";
            this.label2.Click += new System.EventHandler(this.btnRestore);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = global::Admin_Login.Properties.Resources.RoundedRectangle_Shape;
            this.pictureBox4.Location = new System.Drawing.Point(773, 12);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(184, 46);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Tag = "btn_AddNew";
            this.pictureBox4.Click += new System.EventHandler(this.btnRestore);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1001, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 27);
            this.label3.TabIndex = 10;
            this.label3.Tag = "btn_AddNew";
            this.label3.Text = "Back";
            this.label3.Click += new System.EventHandler(this.btnArchiveBack);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox6.Image = global::Admin_Login.Properties.Resources.RoundedRectangle_Shape;
            this.pictureBox6.Location = new System.Drawing.Point(980, 12);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(115, 46);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 9;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Tag = "btn_AddNew";
            this.pictureBox6.Click += new System.EventHandler(this.btnArchiveBack);
            // 
            // TB_SearchArchive
            // 
            this.TB_SearchArchive.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_SearchArchive.Location = new System.Drawing.Point(201, 15);
            this.TB_SearchArchive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_SearchArchive.Name = "TB_SearchArchive";
            this.TB_SearchArchive.Size = new System.Drawing.Size(556, 34);
            this.TB_SearchArchive.TabIndex = 2;
            this.TB_SearchArchive.TextChanged += new System.EventHandler(this.tbSearchArchive);
            // 
            // fFRUsersDataSet17
            // 
            this.fFRUsersDataSet17.DataSetName = "FFRUsersDataSet17";
            this.fFRUsersDataSet17.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // archiveBindingSource
            // 
            this.archiveBindingSource.DataMember = "Archive";
            this.archiveBindingSource.DataSource = this.fFRUsersDataSet17;
            // 
            // archiveTableAdapter
            // 
            this.archiveTableAdapter.ClearBeforeFill = true;
            // 
            // employeeIDDataGridViewTextBoxColumn
            // 
            this.employeeIDDataGridViewTextBoxColumn.DataPropertyName = "EmployeeID";
            this.employeeIDDataGridViewTextBoxColumn.HeaderText = "EmployeeID";
            this.employeeIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.employeeIDDataGridViewTextBoxColumn.Name = "employeeIDDataGridViewTextBoxColumn";
            this.employeeIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.HeaderText = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            this.firstNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.firstNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            this.lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            this.lastNameDataGridViewTextBoxColumn.HeaderText = "LastName";
            this.lastNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            this.lastNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // middleNameDataGridViewTextBoxColumn
            // 
            this.middleNameDataGridViewTextBoxColumn.DataPropertyName = "MiddleName";
            this.middleNameDataGridViewTextBoxColumn.HeaderText = "MiddleName";
            this.middleNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.middleNameDataGridViewTextBoxColumn.Name = "middleNameDataGridViewTextBoxColumn";
            this.middleNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.middleNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Address";
            this.addressDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            this.addressDataGridViewTextBoxColumn.Width = 125;
            // 
            // sSSIDDataGridViewTextBoxColumn
            // 
            this.sSSIDDataGridViewTextBoxColumn.DataPropertyName = "SSS_ID";
            this.sSSIDDataGridViewTextBoxColumn.HeaderText = "SSS_ID";
            this.sSSIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sSSIDDataGridViewTextBoxColumn.Name = "sSSIDDataGridViewTextBoxColumn";
            this.sSSIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.sSSIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // pAGIBIGNODataGridViewTextBoxColumn
            // 
            this.pAGIBIGNODataGridViewTextBoxColumn.DataPropertyName = "PAGIBIG_NO";
            this.pAGIBIGNODataGridViewTextBoxColumn.HeaderText = "PAGIBIG_NO";
            this.pAGIBIGNODataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pAGIBIGNODataGridViewTextBoxColumn.Name = "pAGIBIGNODataGridViewTextBoxColumn";
            this.pAGIBIGNODataGridViewTextBoxColumn.ReadOnly = true;
            this.pAGIBIGNODataGridViewTextBoxColumn.Width = 125;
            // 
            // pHILHEALTHNODataGridViewTextBoxColumn
            // 
            this.pHILHEALTHNODataGridViewTextBoxColumn.DataPropertyName = "PHILHEALTH_NO";
            this.pHILHEALTHNODataGridViewTextBoxColumn.HeaderText = "PHILHEALTH_NO";
            this.pHILHEALTHNODataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pHILHEALTHNODataGridViewTextBoxColumn.Name = "pHILHEALTHNODataGridViewTextBoxColumn";
            this.pHILHEALTHNODataGridViewTextBoxColumn.ReadOnly = true;
            this.pHILHEALTHNODataGridViewTextBoxColumn.Width = 125;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            this.emailDataGridViewTextBoxColumn.Width = 125;
            // 
            // employeeMaritalStatusDataGridViewTextBoxColumn
            // 
            this.employeeMaritalStatusDataGridViewTextBoxColumn.DataPropertyName = "EmployeeMaritalStatus";
            this.employeeMaritalStatusDataGridViewTextBoxColumn.HeaderText = "EmployeeMaritalStatus";
            this.employeeMaritalStatusDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.employeeMaritalStatusDataGridViewTextBoxColumn.Name = "employeeMaritalStatusDataGridViewTextBoxColumn";
            this.employeeMaritalStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeMaritalStatusDataGridViewTextBoxColumn.Width = 125;
            // 
            // contactNumberDataGridViewTextBoxColumn
            // 
            this.contactNumberDataGridViewTextBoxColumn.DataPropertyName = "ContactNumber";
            this.contactNumberDataGridViewTextBoxColumn.HeaderText = "ContactNumber";
            this.contactNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.contactNumberDataGridViewTextBoxColumn.Name = "contactNumberDataGridViewTextBoxColumn";
            this.contactNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.contactNumberDataGridViewTextBoxColumn.Width = 125;
            // 
            // dateHiredDataGridViewTextBoxColumn
            // 
            this.dateHiredDataGridViewTextBoxColumn.DataPropertyName = "DateHired";
            this.dateHiredDataGridViewTextBoxColumn.HeaderText = "DateHired";
            this.dateHiredDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateHiredDataGridViewTextBoxColumn.Name = "dateHiredDataGridViewTextBoxColumn";
            this.dateHiredDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateHiredDataGridViewTextBoxColumn.Width = 125;
            // 
            // genderDataGridViewTextBoxColumn
            // 
            this.genderDataGridViewTextBoxColumn.DataPropertyName = "Gender";
            this.genderDataGridViewTextBoxColumn.HeaderText = "Gender";
            this.genderDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.genderDataGridViewTextBoxColumn.Name = "genderDataGridViewTextBoxColumn";
            this.genderDataGridViewTextBoxColumn.ReadOnly = true;
            this.genderDataGridViewTextBoxColumn.Width = 125;
            // 
            // birthDateDataGridViewTextBoxColumn
            // 
            this.birthDateDataGridViewTextBoxColumn.DataPropertyName = "BirthDate";
            this.birthDateDataGridViewTextBoxColumn.HeaderText = "BirthDate";
            this.birthDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.birthDateDataGridViewTextBoxColumn.Name = "birthDateDataGridViewTextBoxColumn";
            this.birthDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.birthDateDataGridViewTextBoxColumn.Width = 125;
            // 
            // departmentDataGridViewTextBoxColumn
            // 
            this.departmentDataGridViewTextBoxColumn.DataPropertyName = "Department";
            this.departmentDataGridViewTextBoxColumn.HeaderText = "Department";
            this.departmentDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.departmentDataGridViewTextBoxColumn.Name = "departmentDataGridViewTextBoxColumn";
            this.departmentDataGridViewTextBoxColumn.ReadOnly = true;
            this.departmentDataGridViewTextBoxColumn.Width = 125;
            // 
            // positionDataGridViewTextBoxColumn
            // 
            this.positionDataGridViewTextBoxColumn.DataPropertyName = "Position";
            this.positionDataGridViewTextBoxColumn.HeaderText = "Position";
            this.positionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.positionDataGridViewTextBoxColumn.Name = "positionDataGridViewTextBoxColumn";
            this.positionDataGridViewTextBoxColumn.ReadOnly = true;
            this.positionDataGridViewTextBoxColumn.Width = 125;
            // 
            // jobStatusDataGridViewTextBoxColumn
            // 
            this.jobStatusDataGridViewTextBoxColumn.DataPropertyName = "JobStatus";
            this.jobStatusDataGridViewTextBoxColumn.HeaderText = "JobStatus";
            this.jobStatusDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.jobStatusDataGridViewTextBoxColumn.Name = "jobStatusDataGridViewTextBoxColumn";
            this.jobStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.jobStatusDataGridViewTextBoxColumn.Width = 125;
            // 
            // ArchivedEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 683);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TB_SearchArchive);
            this.Controls.Add(this.dgvArchive);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ArchivedEmployee";
            this.Text = "ArchivedEmployee";
            this.Load += new System.EventHandler(this.ArchivedEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fFRUsersDataSet17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.archiveBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArchive;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.TextBox TB_SearchArchive;
        private FFRUsersDataSet17 fFRUsersDataSet17;
        private System.Windows.Forms.BindingSource archiveBindingSource;
        private FFRUsersDataSet17TableAdapters.ArchiveTableAdapter archiveTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn middleNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sSSIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pAGIBIGNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pHILHEALTHNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeMaritalStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateHiredDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jobStatusDataGridViewTextBoxColumn;
    }
}