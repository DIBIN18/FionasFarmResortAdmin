
namespace Admin_Login
{
    partial class EditDepartmentPosition
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDeparments = new System.Windows.Forms.DataGridView();
            this.dgvPositions = new System.Windows.Forms.DataGridView();
            this.btnSavePosition = new System.Windows.Forms.Button();
            this.btnSaveDepartment = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeparments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPositions)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(65)))), ((int)(((byte)(0)))));
            this.pictureBox1.Location = new System.Drawing.Point(-1, -3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(830, 54);
            this.pictureBox1.TabIndex = 55;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(65)))), ((int)(((byte)(0)))));
            this.label7.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(11, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(673, 33);
            this.label7.TabIndex = 57;
            this.label7.Text = "Fiona\'s Farm and Resort - Edit Position/Department";
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(65)))), ((int)(((byte)(0)))));
            this.Logo.Image = global::Admin_Login.Properties.Resources.FionasFarmAndResort_Log;
            this.Logo.Location = new System.Drawing.Point(773, -3);
            this.Logo.Margin = new System.Windows.Forms.Padding(2);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(43, 54);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo.TabIndex = 58;
            this.Logo.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(381, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 22);
            this.label2.TabIndex = 60;
            this.label2.Text = "Position";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 22);
            this.label1.TabIndex = 59;
            this.label1.Text = "Department";
            // 
            // dgvDeparments
            // 
            this.dgvDeparments.AllowUserToAddRows = false;
            this.dgvDeparments.AllowUserToDeleteRows = false;
            this.dgvDeparments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDeparments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeparments.Location = new System.Drawing.Point(38, 107);
            this.dgvDeparments.Name = "dgvDeparments";
            this.dgvDeparments.Size = new System.Drawing.Size(341, 278);
            this.dgvDeparments.TabIndex = 61;
            // 
            // dgvPositions
            // 
            this.dgvPositions.AllowUserToAddRows = false;
            this.dgvPositions.AllowUserToDeleteRows = false;
            this.dgvPositions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPositions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPositions.Location = new System.Drawing.Point(385, 107);
            this.dgvPositions.Name = "dgvPositions";
            this.dgvPositions.Size = new System.Drawing.Size(411, 278);
            this.dgvPositions.TabIndex = 62;
            // 
            // btnSavePosition
            // 
            this.btnSavePosition.BackColor = System.Drawing.Color.Green;
            this.btnSavePosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePosition.ForeColor = System.Drawing.Color.White;
            this.btnSavePosition.Location = new System.Drawing.Point(488, 391);
            this.btnSavePosition.Name = "btnSavePosition";
            this.btnSavePosition.Size = new System.Drawing.Size(212, 34);
            this.btnSavePosition.TabIndex = 64;
            this.btnSavePosition.Text = "Save Position Changes";
            this.btnSavePosition.UseVisualStyleBackColor = false;
            this.btnSavePosition.Click += new System.EventHandler(this.btnSavePosition_Click);
            // 
            // btnSaveDepartment
            // 
            this.btnSaveDepartment.BackColor = System.Drawing.Color.Green;
            this.btnSaveDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveDepartment.ForeColor = System.Drawing.Color.White;
            this.btnSaveDepartment.Location = new System.Drawing.Point(99, 391);
            this.btnSaveDepartment.Name = "btnSaveDepartment";
            this.btnSaveDepartment.Size = new System.Drawing.Size(233, 34);
            this.btnSaveDepartment.TabIndex = 63;
            this.btnSaveDepartment.Text = "Save Department Changes";
            this.btnSaveDepartment.UseVisualStyleBackColor = false;
            this.btnSaveDepartment.Click += new System.EventHandler(this.btnSaveDepartment_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Green;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(315, 456);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(164, 34);
            this.btnClose.TabIndex = 65;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // EditDepartmentPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 502);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSavePosition);
            this.Controls.Add(this.btnSaveDepartment);
            this.Controls.Add(this.dgvPositions);
            this.Controls.Add(this.dgvDeparments);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditDepartmentPosition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditDepartmentPosition";
            this.Load += new System.EventHandler(this.EditDepartmentPosition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeparments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPositions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDeparments;
        private System.Windows.Forms.DataGridView dgvPositions;
        private System.Windows.Forms.Button btnSavePosition;
        private System.Windows.Forms.Button btnSaveDepartment;
        private System.Windows.Forms.Button btnClose;
    }
}