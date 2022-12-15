namespace Admin_Login
{
    partial class OvertimeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OvertimeList));
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.tb_Search = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_Date = new System.Windows.Forms.DateTimePicker();
            this.pbCancel = new System.Windows.Forms.PictureBox();
            this.lblCancel = new System.Windows.Forms.Label();
            this.pbOvalCancel = new System.Windows.Forms.PictureBox();
            this.pbCurrent = new System.Windows.Forms.PictureBox();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.pbOvalCurrent = new System.Windows.Forms.PictureBox();
            this.pbHistory = new System.Windows.Forms.PictureBox();
            this.lblHistory = new System.Windows.Forms.Label();
            this.pbOvalHistory = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOvalCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOvalCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOvalHistory)).BeginInit();
            this.SuspendLayout();
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
            this.dgvEmployees.Location = new System.Drawing.Point(9, 52);
            this.dgvEmployees.MultiSelect = false;
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.ReadOnly = true;
            this.dgvEmployees.RowHeadersVisible = false;
            this.dgvEmployees.RowHeadersWidth = 51;
            this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.Size = new System.Drawing.Size(866, 631);
            this.dgvEmployees.TabIndex = 144;
            this.dgvEmployees.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployees_CellClick);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::Admin_Login.Properties.Resources.Back_Icon;
            this.pictureBox3.Location = new System.Drawing.Point(836, 11);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(29, 31);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 148;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Tag = "btn_Back";
            this.pictureBox3.Click += new System.EventHandler(this.back_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(781, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 24);
            this.label2.TabIndex = 147;
            this.label2.Tag = "btn_Back";
            this.label2.Text = "Back";
            this.label2.Click += new System.EventHandler(this.back_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = global::Admin_Login.Properties.Resources.RoundedRectangle_Shape;
            this.pictureBox4.Location = new System.Drawing.Point(768, 8);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(108, 37);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 146;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Tag = "btn_Back";
            this.pictureBox4.Click += new System.EventHandler(this.back_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.tb_Search);
            this.panel1.Location = new System.Drawing.Point(296, 8);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 37);
            this.panel1.TabIndex = 145;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.White;
            this.pictureBox5.Image = global::Admin_Login.Properties.Resources.Search_Icon;
            this.pictureBox5.Location = new System.Drawing.Point(16, 2);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(19, 28);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 8;
            this.pictureBox5.TabStop = false;
            // 
            // tb_Search
            // 
            this.tb_Search.BackColor = System.Drawing.Color.White;
            this.tb_Search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Search.ForeColor = System.Drawing.SystemColors.Desktop;
            this.tb_Search.Location = new System.Drawing.Point(39, 7);
            this.tb_Search.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Search.Name = "tb_Search";
            this.tb_Search.Size = new System.Drawing.Size(253, 21);
            this.tb_Search.TabIndex = 6;
            this.tb_Search.Text = " Search";
            this.tb_Search.Click += new System.EventHandler(this.tb_Search_Click);
            this.tb_Search.TextChanged += new System.EventHandler(this.tb_Search_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 26);
            this.label1.TabIndex = 149;
            this.label1.Tag = "btnAddAttendance";
            this.label1.Text = "Date:";
            // 
            // dtp_Date
            // 
            this.dtp_Date.CustomFormat = "MMMM dd, yyyy";
            this.dtp_Date.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Date.Location = new System.Drawing.Point(82, 12);
            this.dtp_Date.Margin = new System.Windows.Forms.Padding(2);
            this.dtp_Date.Name = "dtp_Date";
            this.dtp_Date.Size = new System.Drawing.Size(210, 30);
            this.dtp_Date.TabIndex = 150;
            this.dtp_Date.ValueChanged += new System.EventHandler(this.dtp_Date_ValueChanged);
            // 
            // pbCancel
            // 
            this.pbCancel.BackColor = System.Drawing.Color.Maroon;
            this.pbCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbCancel.Image = ((System.Drawing.Image)(resources.GetObject("pbCancel.Image")));
            this.pbCancel.Location = new System.Drawing.Point(718, 13);
            this.pbCancel.Margin = new System.Windows.Forms.Padding(2);
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.Size = new System.Drawing.Size(28, 28);
            this.pbCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCancel.TabIndex = 153;
            this.pbCancel.TabStop = false;
            this.pbCancel.Tag = "btn_Back";
            this.pbCancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // lblCancel
            // 
            this.lblCancel.AutoSize = true;
            this.lblCancel.BackColor = System.Drawing.Color.Maroon;
            this.lblCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancel.ForeColor = System.Drawing.Color.White;
            this.lblCancel.Location = new System.Drawing.Point(629, 15);
            this.lblCancel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(87, 24);
            this.lblCancel.TabIndex = 152;
            this.lblCancel.Tag = "btn_Back";
            this.lblCancel.Text = "Remove";
            this.lblCancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // pbOvalCancel
            // 
            this.pbOvalCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbOvalCancel.Image = global::Admin_Login.Properties.Resources.RoundedRectangle_Shape_Red;
            this.pbOvalCancel.Location = new System.Drawing.Point(608, 8);
            this.pbOvalCancel.Margin = new System.Windows.Forms.Padding(2);
            this.pbOvalCancel.Name = "pbOvalCancel";
            this.pbOvalCancel.Size = new System.Drawing.Size(154, 37);
            this.pbOvalCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOvalCancel.TabIndex = 151;
            this.pbOvalCancel.TabStop = false;
            this.pbOvalCancel.Tag = "btn_Back";
            this.pbOvalCancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // pbCurrent
            // 
            this.pbCurrent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(192)))), ((int)(((byte)(222)))));
            this.pbCurrent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbCurrent.Image = ((System.Drawing.Image)(resources.GetObject("pbCurrent.Image")));
            this.pbCurrent.Location = new System.Drawing.Point(826, 697);
            this.pbCurrent.Margin = new System.Windows.Forms.Padding(2);
            this.pbCurrent.Name = "pbCurrent";
            this.pbCurrent.Size = new System.Drawing.Size(29, 31);
            this.pbCurrent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCurrent.TabIndex = 159;
            this.pbCurrent.TabStop = false;
            this.pbCurrent.Tag = "btn_Back";
            this.pbCurrent.Visible = false;
            this.pbCurrent.Click += new System.EventHandler(this.ViewCurrentClick);
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(192)))), ((int)(((byte)(222)))));
            this.lblCurrent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrent.ForeColor = System.Drawing.Color.White;
            this.lblCurrent.Location = new System.Drawing.Point(687, 699);
            this.lblCurrent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(131, 24);
            this.lblCurrent.TabIndex = 158;
            this.lblCurrent.Tag = "btn_Back";
            this.lblCurrent.Text = "View Current";
            this.lblCurrent.Visible = false;
            this.lblCurrent.Click += new System.EventHandler(this.ViewCurrentClick);
            // 
            // pbOvalCurrent
            // 
            this.pbOvalCurrent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbOvalCurrent.Image = global::Admin_Login.Properties.Resources.RoundedRectangle_Shape_Light_Blue;
            this.pbOvalCurrent.Location = new System.Drawing.Point(665, 694);
            this.pbOvalCurrent.Margin = new System.Windows.Forms.Padding(2);
            this.pbOvalCurrent.Name = "pbOvalCurrent";
            this.pbOvalCurrent.Size = new System.Drawing.Size(211, 37);
            this.pbOvalCurrent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOvalCurrent.TabIndex = 157;
            this.pbOvalCurrent.TabStop = false;
            this.pbOvalCurrent.Tag = "btn_Back";
            this.pbOvalCurrent.Visible = false;
            this.pbOvalCurrent.Click += new System.EventHandler(this.ViewCurrentClick);
            // 
            // pbHistory
            // 
            this.pbHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pbHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbHistory.Image = ((System.Drawing.Image)(resources.GetObject("pbHistory.Image")));
            this.pbHistory.Location = new System.Drawing.Point(829, 696);
            this.pbHistory.Margin = new System.Windows.Forms.Padding(2);
            this.pbHistory.Name = "pbHistory";
            this.pbHistory.Size = new System.Drawing.Size(29, 31);
            this.pbHistory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbHistory.TabIndex = 156;
            this.pbHistory.TabStop = false;
            this.pbHistory.Tag = "btn_Back";
            this.pbHistory.Click += new System.EventHandler(this.ViewHistoryClick);
            // 
            // lblHistory
            // 
            this.lblHistory.AutoSize = true;
            this.lblHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistory.ForeColor = System.Drawing.Color.White;
            this.lblHistory.Location = new System.Drawing.Point(687, 699);
            this.lblHistory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(126, 24);
            this.lblHistory.TabIndex = 155;
            this.lblHistory.Tag = "btn_Back";
            this.lblHistory.Text = "View History";
            this.lblHistory.Click += new System.EventHandler(this.ViewHistoryClick);
            // 
            // pbOvalHistory
            // 
            this.pbOvalHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbOvalHistory.Image = global::Admin_Login.Properties.Resources.RoundedRectangle_Shape_Orange;
            this.pbOvalHistory.Location = new System.Drawing.Point(665, 694);
            this.pbOvalHistory.Margin = new System.Windows.Forms.Padding(2);
            this.pbOvalHistory.Name = "pbOvalHistory";
            this.pbOvalHistory.Size = new System.Drawing.Size(211, 37);
            this.pbOvalHistory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOvalHistory.TabIndex = 154;
            this.pbOvalHistory.TabStop = false;
            this.pbOvalHistory.Tag = "btn_Back";
            this.pbOvalHistory.Click += new System.EventHandler(this.ViewHistoryClick);
            // 
            // OvertimeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 747);
            this.Controls.Add(this.pbCurrent);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.pbOvalCurrent);
            this.Controls.Add(this.pbHistory);
            this.Controls.Add(this.lblHistory);
            this.Controls.Add(this.pbOvalHistory);
            this.Controls.Add(this.pbCancel);
            this.Controls.Add(this.lblCancel);
            this.Controls.Add(this.pbOvalCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp_Date);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvEmployees);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "OvertimeList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OvertimeList";
            this.Load += new System.EventHandler(this.OvertimeList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOvalCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOvalCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOvalHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TextBox tb_Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_Date;
        private System.Windows.Forms.PictureBox pbCancel;
        private System.Windows.Forms.Label lblCancel;
        private System.Windows.Forms.PictureBox pbOvalCancel;
        private System.Windows.Forms.PictureBox pbCurrent;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.PictureBox pbOvalCurrent;
        private System.Windows.Forms.PictureBox pbHistory;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.PictureBox pbOvalHistory;
    }
}