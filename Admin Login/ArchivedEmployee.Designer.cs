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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.fFRUsersDataSet13 = new Admin_Login.FFRUsersDataSet13();
            this.archiveEmployeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.archiveEmployeeTableAdapter = new Admin_Login.FFRUsersDataSet13TableAdapters.ArchiveEmployeeTableAdapter();
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
            this.positionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jobStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fFRUsersDataSet13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.archiveEmployeeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.positionDataGridViewTextBoxColumn,
            this.departmentDataGridViewTextBoxColumn,
            this.jobStatusDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.archiveEmployeeBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(4, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1232, 735);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "Restore";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // fFRUsersDataSet13
            // 
            this.fFRUsersDataSet13.DataSetName = "FFRUsersDataSet13";
            this.fFRUsersDataSet13.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // archiveEmployeeBindingSource
            // 
            this.archiveEmployeeBindingSource.DataMember = "ArchiveEmployee";
            this.archiveEmployeeBindingSource.DataSource = this.fFRUsersDataSet13;
            // 
            // archiveEmployeeTableAdapter
            // 
            this.archiveEmployeeTableAdapter.ClearBeforeFill = true;
            // 
            // employeeIDDataGridViewTextBoxColumn
            // 
            this.employeeIDDataGridViewTextBoxColumn.DataPropertyName = "EmployeeID";
            this.employeeIDDataGridViewTextBoxColumn.HeaderText = "EmployeeID";
            this.employeeIDDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.employeeIDDataGridViewTextBoxColumn.Name = "employeeIDDataGridViewTextBoxColumn";
            this.employeeIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeIDDataGridViewTextBoxColumn.Width = 150;
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.HeaderText = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            this.firstNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.firstNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            this.lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            this.lastNameDataGridViewTextBoxColumn.HeaderText = "LastName";
            this.lastNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            this.lastNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // middleNameDataGridViewTextBoxColumn
            // 
            this.middleNameDataGridViewTextBoxColumn.DataPropertyName = "MiddleName";
            this.middleNameDataGridViewTextBoxColumn.HeaderText = "MiddleName";
            this.middleNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.middleNameDataGridViewTextBoxColumn.Name = "middleNameDataGridViewTextBoxColumn";
            this.middleNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.middleNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Address";
            this.addressDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            this.addressDataGridViewTextBoxColumn.Width = 150;
            // 
            // sSSIDDataGridViewTextBoxColumn
            // 
            this.sSSIDDataGridViewTextBoxColumn.DataPropertyName = "SSS_ID";
            this.sSSIDDataGridViewTextBoxColumn.HeaderText = "SSS_ID";
            this.sSSIDDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.sSSIDDataGridViewTextBoxColumn.Name = "sSSIDDataGridViewTextBoxColumn";
            this.sSSIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.sSSIDDataGridViewTextBoxColumn.Width = 150;
            // 
            // pAGIBIGNODataGridViewTextBoxColumn
            // 
            this.pAGIBIGNODataGridViewTextBoxColumn.DataPropertyName = "PAGIBIG_NO";
            this.pAGIBIGNODataGridViewTextBoxColumn.HeaderText = "PAGIBIG_NO";
            this.pAGIBIGNODataGridViewTextBoxColumn.MinimumWidth = 8;
            this.pAGIBIGNODataGridViewTextBoxColumn.Name = "pAGIBIGNODataGridViewTextBoxColumn";
            this.pAGIBIGNODataGridViewTextBoxColumn.ReadOnly = true;
            this.pAGIBIGNODataGridViewTextBoxColumn.Width = 150;
            // 
            // pHILHEALTHNODataGridViewTextBoxColumn
            // 
            this.pHILHEALTHNODataGridViewTextBoxColumn.DataPropertyName = "PHILHEALTH_NO";
            this.pHILHEALTHNODataGridViewTextBoxColumn.HeaderText = "PHILHEALTH_NO";
            this.pHILHEALTHNODataGridViewTextBoxColumn.MinimumWidth = 8;
            this.pHILHEALTHNODataGridViewTextBoxColumn.Name = "pHILHEALTHNODataGridViewTextBoxColumn";
            this.pHILHEALTHNODataGridViewTextBoxColumn.ReadOnly = true;
            this.pHILHEALTHNODataGridViewTextBoxColumn.Width = 150;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            this.emailDataGridViewTextBoxColumn.Width = 150;
            // 
            // employeeMaritalStatusDataGridViewTextBoxColumn
            // 
            this.employeeMaritalStatusDataGridViewTextBoxColumn.DataPropertyName = "EmployeeMaritalStatus";
            this.employeeMaritalStatusDataGridViewTextBoxColumn.HeaderText = "EmployeeMaritalStatus";
            this.employeeMaritalStatusDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.employeeMaritalStatusDataGridViewTextBoxColumn.Name = "employeeMaritalStatusDataGridViewTextBoxColumn";
            this.employeeMaritalStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeMaritalStatusDataGridViewTextBoxColumn.Width = 150;
            // 
            // contactNumberDataGridViewTextBoxColumn
            // 
            this.contactNumberDataGridViewTextBoxColumn.DataPropertyName = "ContactNumber";
            this.contactNumberDataGridViewTextBoxColumn.HeaderText = "ContactNumber";
            this.contactNumberDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.contactNumberDataGridViewTextBoxColumn.Name = "contactNumberDataGridViewTextBoxColumn";
            this.contactNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.contactNumberDataGridViewTextBoxColumn.Width = 150;
            // 
            // dateHiredDataGridViewTextBoxColumn
            // 
            this.dateHiredDataGridViewTextBoxColumn.DataPropertyName = "DateHired";
            this.dateHiredDataGridViewTextBoxColumn.HeaderText = "DateHired";
            this.dateHiredDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.dateHiredDataGridViewTextBoxColumn.Name = "dateHiredDataGridViewTextBoxColumn";
            this.dateHiredDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateHiredDataGridViewTextBoxColumn.Width = 150;
            // 
            // genderDataGridViewTextBoxColumn
            // 
            this.genderDataGridViewTextBoxColumn.DataPropertyName = "Gender";
            this.genderDataGridViewTextBoxColumn.HeaderText = "Gender";
            this.genderDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.genderDataGridViewTextBoxColumn.Name = "genderDataGridViewTextBoxColumn";
            this.genderDataGridViewTextBoxColumn.ReadOnly = true;
            this.genderDataGridViewTextBoxColumn.Width = 150;
            // 
            // birthDateDataGridViewTextBoxColumn
            // 
            this.birthDateDataGridViewTextBoxColumn.DataPropertyName = "BirthDate";
            this.birthDateDataGridViewTextBoxColumn.HeaderText = "BirthDate";
            this.birthDateDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.birthDateDataGridViewTextBoxColumn.Name = "birthDateDataGridViewTextBoxColumn";
            this.birthDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.birthDateDataGridViewTextBoxColumn.Width = 150;
            // 
            // positionDataGridViewTextBoxColumn
            // 
            this.positionDataGridViewTextBoxColumn.DataPropertyName = "Position";
            this.positionDataGridViewTextBoxColumn.HeaderText = "Position";
            this.positionDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.positionDataGridViewTextBoxColumn.Name = "positionDataGridViewTextBoxColumn";
            this.positionDataGridViewTextBoxColumn.ReadOnly = true;
            this.positionDataGridViewTextBoxColumn.Width = 150;
            // 
            // departmentDataGridViewTextBoxColumn
            // 
            this.departmentDataGridViewTextBoxColumn.DataPropertyName = "Department";
            this.departmentDataGridViewTextBoxColumn.HeaderText = "Department";
            this.departmentDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.departmentDataGridViewTextBoxColumn.Name = "departmentDataGridViewTextBoxColumn";
            this.departmentDataGridViewTextBoxColumn.ReadOnly = true;
            this.departmentDataGridViewTextBoxColumn.Width = 150;
            // 
            // jobStatusDataGridViewTextBoxColumn
            // 
            this.jobStatusDataGridViewTextBoxColumn.DataPropertyName = "JobStatus";
            this.jobStatusDataGridViewTextBoxColumn.HeaderText = "JobStatus";
            this.jobStatusDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.jobStatusDataGridViewTextBoxColumn.Name = "jobStatusDataGridViewTextBoxColumn";
            this.jobStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.jobStatusDataGridViewTextBoxColumn.Width = 150;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1088, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 44);
            this.button2.TabIndex = 2;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ArchivedEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 798);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ArchivedEmployee";
            this.Text = "ArchivedEmployee";
            this.Load += new System.EventHandler(this.ArchivedEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fFRUsersDataSet13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.archiveEmployeeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private FFRUsersDataSet13 fFRUsersDataSet13;
        private System.Windows.Forms.BindingSource archiveEmployeeBindingSource;
        private FFRUsersDataSet13TableAdapters.ArchiveEmployeeTableAdapter archiveEmployeeTableAdapter;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jobStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button2;
    }
}