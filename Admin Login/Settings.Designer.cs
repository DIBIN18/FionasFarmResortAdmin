
namespace Admin_Login
{
    partial class Settings
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
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbBackupEvery = new System.Windows.Forms.ComboBox();
            this.btnRestoreDatabase = new System.Windows.Forms.Button();
            this.btnCreateBackup = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToResizeColumns = false;
            this.dgvUsers.AllowUserToResizeRows = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(37, 44);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.Size = new System.Drawing.Size(761, 150);
            this.dgvUsers.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Users";
            // 
            // btnAddUser
            // 
            this.btnAddUser.BackColor = System.Drawing.Color.Green;
            this.btnAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.ForeColor = System.Drawing.Color.White;
            this.btnAddUser.Location = new System.Drawing.Point(37, 200);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(183, 32);
            this.btnAddUser.TabIndex = 2;
            this.btnAddUser.Text = "Add Another User";
            this.btnAddUser.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbBackupEvery);
            this.panel1.Controls.Add(this.btnRestoreDatabase);
            this.panel1.Controls.Add(this.btnCreateBackup);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(37, 238);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(761, 275);
            this.panel1.TabIndex = 3;
            // 
            // cmbBackupEvery
            // 
            this.cmbBackupEvery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBackupEvery.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBackupEvery.FormattingEnabled = true;
            this.cmbBackupEvery.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly",
            "Annually"});
            this.cmbBackupEvery.Location = new System.Drawing.Point(259, 69);
            this.cmbBackupEvery.Name = "cmbBackupEvery";
            this.cmbBackupEvery.Size = new System.Drawing.Size(185, 28);
            this.cmbBackupEvery.TabIndex = 8;
            // 
            // btnRestoreDatabase
            // 
            this.btnRestoreDatabase.BackColor = System.Drawing.Color.Green;
            this.btnRestoreDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestoreDatabase.ForeColor = System.Drawing.Color.White;
            this.btnRestoreDatabase.Location = new System.Drawing.Point(24, 154);
            this.btnRestoreDatabase.Name = "btnRestoreDatabase";
            this.btnRestoreDatabase.Size = new System.Drawing.Size(170, 33);
            this.btnRestoreDatabase.TabIndex = 7;
            this.btnRestoreDatabase.Text = "Restore Database";
            this.btnRestoreDatabase.UseVisualStyleBackColor = false;
            this.btnRestoreDatabase.Click += new System.EventHandler(this.btnRestoreDatabase_Click);
            // 
            // btnCreateBackup
            // 
            this.btnCreateBackup.BackColor = System.Drawing.Color.Green;
            this.btnCreateBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateBackup.ForeColor = System.Drawing.Color.White;
            this.btnCreateBackup.Location = new System.Drawing.Point(25, 115);
            this.btnCreateBackup.Name = "btnCreateBackup";
            this.btnCreateBackup.Size = new System.Drawing.Size(170, 33);
            this.btnCreateBackup.TabIndex = 4;
            this.btnCreateBackup.Text = "Create Backup";
            this.btnCreateBackup.UseVisualStyleBackColor = false;
            this.btnCreateBackup.Click += new System.EventHandler(this.btnCreateBackup_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Backup Database Every:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Backup and Restore";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(834, 550);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Settings";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbBackupEvery;
        private System.Windows.Forms.Button btnRestoreDatabase;
        private System.Windows.Forms.Button btnCreateBackup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}