
namespace Admin_Login
{
    partial class AddLeave
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
            this.dgvAddLeave = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtxtReason = new System.Windows.Forms.RichTextBox();
            this.btnAddLeave = new System.Windows.Forms.Button();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddLeave)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAddLeave
            // 
            this.dgvAddLeave.AllowUserToAddRows = false;
            this.dgvAddLeave.AllowUserToDeleteRows = false;
            this.dgvAddLeave.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAddLeave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddLeave.Location = new System.Drawing.Point(26, 74);
            this.dgvAddLeave.Name = "dgvAddLeave";
            this.dgvAddLeave.ReadOnly = true;
            this.dgvAddLeave.Size = new System.Drawing.Size(381, 426);
            this.dgvAddLeave.TabIndex = 0;
            this.dgvAddLeave.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAddLeave_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(436, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(436, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "End Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(436, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Reason:";
            // 
            // rtxtReason
            // 
            this.rtxtReason.Location = new System.Drawing.Point(434, 197);
            this.rtxtReason.Name = "rtxtReason";
            this.rtxtReason.Size = new System.Drawing.Size(401, 256);
            this.rtxtReason.TabIndex = 4;
            this.rtxtReason.Text = "";
            // 
            // btnAddLeave
            // 
            this.btnAddLeave.Location = new System.Drawing.Point(540, 477);
            this.btnAddLeave.Name = "btnAddLeave";
            this.btnAddLeave.Size = new System.Drawing.Size(75, 23);
            this.btnAddLeave.TabIndex = 5;
            this.btnAddLeave.Text = "Add";
            this.btnAddLeave.UseVisualStyleBackColor = true;
            this.btnAddLeave.Click += new System.EventHandler(this.btnAddLeave_Click);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "mm-dd-yyyy";
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(496, 88);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(110, 24);
            this.dtpStartDate.TabIndex = 31;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "mm-dd-yyyy";
            this.dtpEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(496, 123);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(110, 24);
            this.dtpEndDate.TabIndex = 32;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(675, 477);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 33;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // AddLeave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 531);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.btnAddLeave);
            this.Controls.Add(this.rtxtReason);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAddLeave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddLeave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddLeave";
            this.Load += new System.EventHandler(this.AddLeave_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddLeave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtxtReason;
        private System.Windows.Forms.Button btnAddLeave;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.DataGridView dgvAddLeave;
    }
}