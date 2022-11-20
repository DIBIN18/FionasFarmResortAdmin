namespace Admin_Login
{
    partial class EmployeeList
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Search = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.ArchiveLabel = new System.Windows.Forms.Label();
            this.dgv_EmployeeList = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.ArchivePictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.ArchivePictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmployeeList)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArchivePictureBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArchivePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(101)))), ((int)(((byte)(168)))));
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 23);
            this.label1.TabIndex = 1;
            this.label1.Tag = "btn_AddNew";
            this.label1.Text = "Add new";
            this.label1.Click += new System.EventHandler(this.btnAddEmployee);
            // 
            // tb_Search
            // 
            this.tb_Search.BackColor = System.Drawing.Color.White;
            this.tb_Search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Search.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Search.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.tb_Search.Location = new System.Drawing.Point(30, 6);
            this.tb_Search.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_Search.Name = "tb_Search";
            this.tb_Search.Size = new System.Drawing.Size(373, 23);
            this.tb_Search.TabIndex = 6;
            this.tb_Search.Text = " Search";
            this.tb_Search.TextChanged += new System.EventHandler(this.tb_Search_TextChanged);
            this.tb_Search.Enter += new System.EventHandler(this.Tb_Search_Enter);
            this.tb_Search.Leave += new System.EventHandler(this.Tb_Search_Leave);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tb_Search);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Location = new System.Drawing.Point(469, 9);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 37);
            this.panel1.TabIndex = 7;
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
            // ArchiveLabel
            // 
            this.ArchiveLabel.AutoSize = true;
            this.ArchiveLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(124)))), ((int)(((byte)(2)))));
            this.ArchiveLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ArchiveLabel.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArchiveLabel.ForeColor = System.Drawing.Color.White;
            this.ArchiveLabel.Location = new System.Drawing.Point(164, 15);
            this.ArchiveLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ArchiveLabel.Name = "ArchiveLabel";
            this.ArchiveLabel.Size = new System.Drawing.Size(81, 23);
            this.ArchiveLabel.TabIndex = 11;
            this.ArchiveLabel.Tag = "btn_Archive";
            this.ArchiveLabel.Text = "Archive";
            this.ArchiveLabel.Click += new System.EventHandler(this.btnArchive);
            // 
            // dgv_EmployeeList
            // 
            this.dgv_EmployeeList.AllowUserToAddRows = false;
            this.dgv_EmployeeList.AllowUserToDeleteRows = false;
            this.dgv_EmployeeList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_EmployeeList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_EmployeeList.BackgroundColor = System.Drawing.Color.White;
            this.dgv_EmployeeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_EmployeeList.Location = new System.Drawing.Point(3, 3);
            this.dgv_EmployeeList.MultiSelect = false;
            this.dgv_EmployeeList.Name = "dgv_EmployeeList";
            this.dgv_EmployeeList.ReadOnly = true;
            this.dgv_EmployeeList.RowHeadersVisible = false;
            this.dgv_EmployeeList.RowHeadersWidth = 51;
            this.dgv_EmployeeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_EmployeeList.Size = new System.Drawing.Size(860, 678);
            this.dgv_EmployeeList.TabIndex = 5;
            this.dgv_EmployeeList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCellClick);
            this.dgv_EmployeeList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_EmployeeList_CellContentClick);
            this.dgv_EmployeeList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_EmployeeList_CellDoubleClick);
            this.dgv_EmployeeList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEmployeeList_CellMouseDoubleClick);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgv_EmployeeList);
            this.panel3.Location = new System.Drawing.Point(9, 50);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(867, 685);
            this.panel3.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(192)))), ((int)(((byte)(222)))));
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(297, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 23);
            this.label2.TabIndex = 22;
            this.label2.Tag = "btn_ArchivedList";
            this.label2.Text = "Archived List";
            this.label2.Click += new System.EventHandler(this.btn_ArchivedList_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(192)))), ((int)(((byte)(222)))));
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::Admin_Login.Properties.Resources.ArchivedList_Icon;
            this.pictureBox3.Location = new System.Drawing.Point(424, 13);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(22, 28);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 23;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Tag = "btn_ArchivedList";
            this.pictureBox3.Click += new System.EventHandler(this.btn_ArchivedList_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = global::Admin_Login.Properties.Resources.RoundedRectangle_Shape_Light_Blue;
            this.pictureBox4.Location = new System.Drawing.Point(286, 9);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(178, 37);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 21;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Tag = "btn_ArchivedList";
            this.pictureBox4.Click += new System.EventHandler(this.btn_ArchivedList_Click);
            // 
            // ArchivePictureBoxLogo
            // 
            this.ArchivePictureBoxLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(124)))), ((int)(((byte)(2)))));
            this.ArchivePictureBoxLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ArchivePictureBoxLogo.Image = global::Admin_Login.Properties.Resources.Archive_Icon;
            this.ArchivePictureBoxLogo.Location = new System.Drawing.Point(249, 15);
            this.ArchivePictureBoxLogo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ArchivePictureBoxLogo.Name = "ArchivePictureBoxLogo";
            this.ArchivePictureBoxLogo.Size = new System.Drawing.Size(20, 26);
            this.ArchivePictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ArchivePictureBoxLogo.TabIndex = 12;
            this.ArchivePictureBoxLogo.TabStop = false;
            this.ArchivePictureBoxLogo.Tag = "btn_Archive";
            this.ArchivePictureBoxLogo.Click += new System.EventHandler(this.btnArchive);
            // 
            // ArchivePictureBox
            // 
            this.ArchivePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ArchivePictureBox.Image = global::Admin_Login.Properties.Resources.RoundedRectangle_Shape_Orange;
            this.ArchivePictureBox.Location = new System.Drawing.Point(152, 9);
            this.ArchivePictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ArchivePictureBox.Name = "ArchivePictureBox";
            this.ArchivePictureBox.Size = new System.Drawing.Size(130, 37);
            this.ArchivePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ArchivePictureBox.TabIndex = 10;
            this.ArchivePictureBox.TabStop = false;
            this.ArchivePictureBox.Tag = "btn_Archive";
            this.ArchivePictureBox.Click += new System.EventHandler(this.btnArchive);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(101)))), ((int)(((byte)(168)))));
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::Admin_Login.Properties.Resources.AddNew_Icon;
            this.pictureBox2.Location = new System.Drawing.Point(113, 15);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "btn_AddNew";
            this.pictureBox2.Click += new System.EventHandler(this.btnAddEmployee);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Admin_Login.Properties.Resources.RoundedRectangle_Shape_Blue;
            this.pictureBox1.Location = new System.Drawing.Point(9, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "btn_AddNew";
            this.pictureBox1.Click += new System.EventHandler(this.btnAddEmployee);
            // 
            // EmployeeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 745);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.ArchivePictureBoxLogo);
            this.Controls.Add(this.ArchiveLabel);
            this.Controls.Add(this.ArchivePictureBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "EmployeeList";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.EmployeeList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmployeeList)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArchivePictureBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArchivePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox tb_Search;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox ArchivePictureBoxLogo;
        private System.Windows.Forms.Label ArchiveLabel;
        private System.Windows.Forms.PictureBox ArchivePictureBox;
        public System.Windows.Forms.DataGridView dgv_EmployeeList;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}