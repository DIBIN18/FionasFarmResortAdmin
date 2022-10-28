namespace Admin_Login
{
    partial class Payroll
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.dtpI_To = new System.Windows.Forms.DateTimePicker();
            this.dtpI_From = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtGrossPay = new System.Windows.Forms.TextBox();
            this.txtSpHolidayPay = new System.Windows.Forms.TextBox();
            this.txtRHolidayPay = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtOvertimePay = new System.Windows.Forms.TextBox();
            this.txtRegularPay = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSpecialHoliday = new System.Windows.Forms.TextBox();
            this.txtRegularHoliday = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtOvertimeMins = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRegularHours = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTotalDeduction = new System.Windows.Forms.TextBox();
            this.txtOtherDeductions = new System.Windows.Forms.TextBox();
            this.txtPagIbig = new System.Windows.Forms.TextBox();
            this.txtPhilHealth = new System.Windows.Forms.TextBox();
            this.txtSSS = new System.Windows.Forms.TextBox();
            this.txtTardinessMins = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtNetPay = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label20 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.txtUnderTimeMin = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtTaxAmount = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.cbSSS = new System.Windows.Forms.CheckBox();
            this.cbPAGIBIG = new System.Windows.Forms.CheckBox();
            this.cbPHILHEALTH = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.dtpI_To);
            this.groupBox1.Controls.Add(this.dtpI_From);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(17, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(631, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payroll Covered Date";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(304, 34);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(16, 22);
            this.label22.TabIndex = 13;
            this.label22.Text = "-";
            // 
            // dtpI_To
            // 
            this.dtpI_To.CalendarFont = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpI_To.CustomFormat = "MMMM dd, yyyy";
            this.dtpI_To.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpI_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpI_To.Location = new System.Drawing.Point(326, 33);
            this.dtpI_To.Name = "dtpI_To";
            this.dtpI_To.Size = new System.Drawing.Size(299, 30);
            this.dtpI_To.TabIndex = 1;
            this.dtpI_To.ValueChanged += new System.EventHandler(this.dtpI_To_ValueChanged);
            // 
            // dtpI_From
            // 
            this.dtpI_From.CalendarFont = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpI_From.CustomFormat = "MMMM dd, yyyy";
            this.dtpI_From.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpI_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpI_From.Location = new System.Drawing.Point(-5, 34);
            this.dtpI_From.Name = "dtpI_From";
            this.dtpI_From.Size = new System.Drawing.Size(303, 30);
            this.dtpI_From.TabIndex = 0;
            this.dtpI_From.ValueChanged += new System.EventHandler(this.dtpI_From_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Employee ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Employee Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Department:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 22);
            this.label4.TabIndex = 4;
            this.label4.Text = "Position:";
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Enabled = false;
            this.txtEmployeeID.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeID.Location = new System.Drawing.Point(184, 105);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Size = new System.Drawing.Size(321, 30);
            this.txtEmployeeID.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtGrossPay);
            this.groupBox2.Controls.Add(this.txtSpHolidayPay);
            this.groupBox2.Controls.Add(this.txtRHolidayPay);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtOvertimePay);
            this.groupBox2.Controls.Add(this.txtRegularPay);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtSpecialHoliday);
            this.groupBox2.Controls.Add(this.txtRegularHoliday);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtOvertimeMins);
            this.groupBox2.Controls.Add(this.txtRegularHours);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(17, 248);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(396, 358);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Earnings";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(37, 321);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 22);
            this.label13.TabIndex = 21;
            this.label13.Text = "Gross Pay:";
            // 
            // txtGrossPay
            // 
            this.txtGrossPay.Enabled = false;
            this.txtGrossPay.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrossPay.Location = new System.Drawing.Point(205, 319);
            this.txtGrossPay.Name = "txtGrossPay";
            this.txtGrossPay.Size = new System.Drawing.Size(156, 30);
            this.txtGrossPay.TabIndex = 20;
            // 
            // txtSpHolidayPay
            // 
            this.txtSpHolidayPay.Enabled = false;
            this.txtSpHolidayPay.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpHolidayPay.Location = new System.Drawing.Point(205, 283);
            this.txtSpHolidayPay.Name = "txtSpHolidayPay";
            this.txtSpHolidayPay.Size = new System.Drawing.Size(156, 30);
            this.txtSpHolidayPay.TabIndex = 19;
            // 
            // txtRHolidayPay
            // 
            this.txtRHolidayPay.Enabled = false;
            this.txtRHolidayPay.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRHolidayPay.Location = new System.Drawing.Point(204, 211);
            this.txtRHolidayPay.Name = "txtRHolidayPay";
            this.txtRHolidayPay.Size = new System.Drawing.Size(156, 30);
            this.txtRHolidayPay.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(37, 285);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(150, 22);
            this.label12.TabIndex = 16;
            this.label12.Text = "Sp.Holiday Pay:";
            // 
            // txtOvertimePay
            // 
            this.txtOvertimePay.Enabled = false;
            this.txtOvertimePay.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOvertimePay.Location = new System.Drawing.Point(204, 139);
            this.txtOvertimePay.Name = "txtOvertimePay";
            this.txtOvertimePay.Size = new System.Drawing.Size(156, 30);
            this.txtOvertimePay.TabIndex = 17;
            // 
            // txtRegularPay
            // 
            this.txtRegularPay.Enabled = false;
            this.txtRegularPay.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegularPay.Location = new System.Drawing.Point(205, 69);
            this.txtRegularPay.Name = "txtRegularPay";
            this.txtRegularPay.Size = new System.Drawing.Size(156, 30);
            this.txtRegularPay.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(36, 214);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(140, 22);
            this.label11.TabIndex = 15;
            this.label11.Text = "R.Holiday Pay:";
            // 
            // txtSpecialHoliday
            // 
            this.txtSpecialHoliday.Enabled = false;
            this.txtSpecialHoliday.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpecialHoliday.Location = new System.Drawing.Point(204, 247);
            this.txtSpecialHoliday.Name = "txtSpecialHoliday";
            this.txtSpecialHoliday.Size = new System.Drawing.Size(156, 30);
            this.txtSpecialHoliday.TabIndex = 15;
            // 
            // txtRegularHoliday
            // 
            this.txtRegularHoliday.Enabled = false;
            this.txtRegularHoliday.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegularHoliday.Location = new System.Drawing.Point(205, 175);
            this.txtRegularHoliday.Name = "txtRegularHoliday";
            this.txtRegularHoliday.Size = new System.Drawing.Size(156, 30);
            this.txtRegularHoliday.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(36, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(142, 22);
            this.label10.TabIndex = 14;
            this.label10.Text = "Overtime Pay:";
            // 
            // txtOvertimeMins
            // 
            this.txtOvertimeMins.Enabled = false;
            this.txtOvertimeMins.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOvertimeMins.Location = new System.Drawing.Point(204, 103);
            this.txtOvertimeMins.Name = "txtOvertimeMins";
            this.txtOvertimeMins.Size = new System.Drawing.Size(156, 30);
            this.txtOvertimeMins.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(36, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 22);
            this.label8.TabIndex = 12;
            this.label8.Text = "Special Holiday:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(37, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 22);
            this.label9.TabIndex = 13;
            this.label9.Text = "Regular Pay:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(37, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 22);
            this.label7.TabIndex = 11;
            this.label7.Text = "Regular Holiday:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(36, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 22);
            this.label6.TabIndex = 10;
            this.label6.Text = "Overtime Mins.:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 22);
            this.label5.TabIndex = 9;
            this.label5.Text = "Regular Hours:";
            // 
            // txtRegularHours
            // 
            this.txtRegularHours.Enabled = false;
            this.txtRegularHours.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegularHours.Location = new System.Drawing.Point(205, 33);
            this.txtRegularHours.Name = "txtRegularHours";
            this.txtRegularHours.Size = new System.Drawing.Size(156, 30);
            this.txtRegularHours.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTaxAmount);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.txtUnderTimeMin);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.txtTotalDeduction);
            this.groupBox3.Controls.Add(this.txtOtherDeductions);
            this.groupBox3.Controls.Add(this.txtPagIbig);
            this.groupBox3.Controls.Add(this.txtPhilHealth);
            this.groupBox3.Controls.Add(this.txtSSS);
            this.groupBox3.Controls.Add(this.txtTardinessMins);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(439, 261);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(425, 345);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Deductions";
            // 
            // txtTotalDeduction
            // 
            this.txtTotalDeduction.Enabled = false;
            this.txtTotalDeduction.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDeduction.Location = new System.Drawing.Point(195, 300);
            this.txtTotalDeduction.Name = "txtTotalDeduction";
            this.txtTotalDeduction.Size = new System.Drawing.Size(157, 30);
            this.txtTotalDeduction.TabIndex = 32;
            // 
            // txtOtherDeductions
            // 
            this.txtOtherDeductions.Enabled = false;
            this.txtOtherDeductions.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtherDeductions.Location = new System.Drawing.Point(195, 228);
            this.txtOtherDeductions.Name = "txtOtherDeductions";
            this.txtOtherDeductions.Size = new System.Drawing.Size(157, 30);
            this.txtOtherDeductions.TabIndex = 31;
            // 
            // txtPagIbig
            // 
            this.txtPagIbig.Enabled = false;
            this.txtPagIbig.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPagIbig.Location = new System.Drawing.Point(195, 193);
            this.txtPagIbig.Name = "txtPagIbig";
            this.txtPagIbig.Size = new System.Drawing.Size(157, 30);
            this.txtPagIbig.TabIndex = 30;
            // 
            // txtPhilHealth
            // 
            this.txtPhilHealth.Enabled = false;
            this.txtPhilHealth.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhilHealth.Location = new System.Drawing.Point(195, 157);
            this.txtPhilHealth.Name = "txtPhilHealth";
            this.txtPhilHealth.Size = new System.Drawing.Size(157, 30);
            this.txtPhilHealth.TabIndex = 29;
            // 
            // txtSSS
            // 
            this.txtSSS.Enabled = false;
            this.txtSSS.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSSS.Location = new System.Drawing.Point(195, 121);
            this.txtSSS.Name = "txtSSS";
            this.txtSSS.Size = new System.Drawing.Size(157, 30);
            this.txtSSS.TabIndex = 28;
            // 
            // txtTardinessMins
            // 
            this.txtTardinessMins.Enabled = false;
            this.txtTardinessMins.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTardinessMins.Location = new System.Drawing.Point(191, 39);
            this.txtTardinessMins.Name = "txtTardinessMins";
            this.txtTardinessMins.Size = new System.Drawing.Size(161, 30);
            this.txtTardinessMins.TabIndex = 22;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(14, 231);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(178, 22);
            this.label21.TabIndex = 26;
            this.label21.Text = "Other Deductions:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(14, 303);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(167, 22);
            this.label19.TabIndex = 23;
            this.label19.Text = "Total Deductions:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(14, 195);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(92, 22);
            this.label17.TabIndex = 21;
            this.label17.Text = "Pag-Ibig:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(14, 159);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(104, 22);
            this.label16.TabIndex = 20;
            this.label16.Text = "PhilHealth:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(14, 124);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 22);
            this.label15.TabIndex = 19;
            this.label15.Text = "SSS:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(10, 41);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(145, 22);
            this.label14.TabIndex = 18;
            this.label14.Text = "Tardiness Mins.:";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Enabled = false;
            this.txtEmployeeName.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeName.Location = new System.Drawing.Point(184, 141);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(321, 30);
            this.txtEmployeeName.TabIndex = 13;
            // 
            // txtDepartment
            // 
            this.txtDepartment.Enabled = false;
            this.txtDepartment.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepartment.Location = new System.Drawing.Point(184, 176);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(321, 30);
            this.txtDepartment.TabIndex = 14;
            // 
            // txtPosition
            // 
            this.txtPosition.Enabled = false;
            this.txtPosition.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPosition.Location = new System.Drawing.Point(184, 212);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(321, 30);
            this.txtPosition.TabIndex = 15;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(23, 632);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(88, 22);
            this.label23.TabIndex = 33;
            this.label23.Text = "Net Pay:";
            // 
            // txtNetPay
            // 
            this.txtNetPay.Enabled = false;
            this.txtNetPay.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNetPay.Location = new System.Drawing.Point(184, 630);
            this.txtNetPay.Name = "txtNetPay";
            this.txtNetPay.Size = new System.Drawing.Size(255, 30);
            this.txtNetPay.TabIndex = 33;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::Admin_Login.Properties.Resources.Back_Icon;
            this.pictureBox3.Location = new System.Drawing.Point(835, 626);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(29, 31);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 58;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Tag = "btn_Back";
            this.pictureBox3.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.label20.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(780, 630);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(55, 24);
            this.label20.TabIndex = 57;
            this.label20.Tag = "btn_Back";
            this.label20.Text = "Back";
            this.label20.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = global::Admin_Login.Properties.Resources.RoundedRectangle_Shape;
            this.pictureBox4.Location = new System.Drawing.Point(767, 623);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(108, 37);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 56;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Tag = "btn_Back";
            this.pictureBox4.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // txtUnderTimeMin
            // 
            this.txtUnderTimeMin.Enabled = false;
            this.txtUnderTimeMin.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnderTimeMin.Location = new System.Drawing.Point(193, 78);
            this.txtUnderTimeMin.Name = "txtUnderTimeMin";
            this.txtUnderTimeMin.Size = new System.Drawing.Size(159, 30);
            this.txtUnderTimeMin.TabIndex = 34;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(12, 80);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(159, 22);
            this.label25.TabIndex = 33;
            this.label25.Text = "UnderTime Mins.:";
            // 
            // txtTaxAmount
            // 
            this.txtTaxAmount.Enabled = false;
            this.txtTaxAmount.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaxAmount.Location = new System.Drawing.Point(195, 264);
            this.txtTaxAmount.Name = "txtTaxAmount";
            this.txtTaxAmount.Size = new System.Drawing.Size(157, 30);
            this.txtTaxAmount.TabIndex = 38;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(14, 267);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(45, 22);
            this.label26.TabIndex = 37;
            this.label26.Text = "Tax:";
            // 
            // cbSSS
            // 
            this.cbSSS.AutoSize = true;
            this.cbSSS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSSS.Location = new System.Drawing.Point(569, 231);
            this.cbSSS.Name = "cbSSS";
            this.cbSSS.Size = new System.Drawing.Size(61, 24);
            this.cbSSS.TabIndex = 59;
            this.cbSSS.Text = "SSS";
            this.cbSSS.UseVisualStyleBackColor = true;
            this.cbSSS.CheckedChanged += new System.EventHandler(this.cbSSS_CheckedChanged);
            // 
            // cbPAGIBIG
            // 
            this.cbPAGIBIG.AutoSize = true;
            this.cbPAGIBIG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPAGIBIG.Location = new System.Drawing.Point(640, 231);
            this.cbPAGIBIG.Name = "cbPAGIBIG";
            this.cbPAGIBIG.Size = new System.Drawing.Size(96, 24);
            this.cbPAGIBIG.TabIndex = 60;
            this.cbPAGIBIG.Text = "PAGIBIG";
            this.cbPAGIBIG.UseVisualStyleBackColor = true;
            this.cbPAGIBIG.CheckedChanged += new System.EventHandler(this.cbPAGIBIG_CheckedChanged);
            // 
            // cbPHILHEALTH
            // 
            this.cbPHILHEALTH.AutoSize = true;
            this.cbPHILHEALTH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPHILHEALTH.Location = new System.Drawing.Point(736, 231);
            this.cbPHILHEALTH.Name = "cbPHILHEALTH";
            this.cbPHILHEALTH.Size = new System.Drawing.Size(128, 24);
            this.cbPHILHEALTH.TabIndex = 61;
            this.cbPHILHEALTH.Text = "PHILHEALTH";
            this.cbPHILHEALTH.UseVisualStyleBackColor = true;
            this.cbPHILHEALTH.CheckedChanged += new System.EventHandler(this.cbPHILHEALTH_CheckedChanged);
            // 
            // Payroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(886, 682);
            this.Controls.Add(this.cbPHILHEALTH);
            this.Controls.Add(this.cbPAGIBIG);
            this.Controls.Add(this.cbSSS);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.txtNetPay);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtEmployeeID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Payroll";
            this.Load += new System.EventHandler(this.Payroll_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpI_To;
        private System.Windows.Forms.DateTimePicker dtpI_From;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.PictureBox pictureBox4;
        public System.Windows.Forms.TextBox txtEmployeeID;
        public System.Windows.Forms.TextBox txtRegularHours;
        public System.Windows.Forms.TextBox txtEmployeeName;
        public System.Windows.Forms.TextBox txtDepartment;
        public System.Windows.Forms.TextBox txtPosition;
        public System.Windows.Forms.TextBox txtGrossPay;
        public System.Windows.Forms.TextBox txtSpHolidayPay;
        public System.Windows.Forms.TextBox txtRHolidayPay;
        public System.Windows.Forms.TextBox txtOvertimePay;
        public System.Windows.Forms.TextBox txtRegularPay;
        public System.Windows.Forms.TextBox txtSpecialHoliday;
        public System.Windows.Forms.TextBox txtRegularHoliday;
        public System.Windows.Forms.TextBox txtOvertimeMins;
        public System.Windows.Forms.TextBox txtTotalDeduction;
        public System.Windows.Forms.TextBox txtOtherDeductions;
        public System.Windows.Forms.TextBox txtPagIbig;
        public System.Windows.Forms.TextBox txtPhilHealth;
        public System.Windows.Forms.TextBox txtSSS;
        public System.Windows.Forms.TextBox txtTardinessMins;
        public System.Windows.Forms.TextBox txtNetPay;
        public System.Windows.Forms.TextBox txtUnderTimeMin;
        private System.Windows.Forms.Label label25;
        public System.Windows.Forms.TextBox txtTaxAmount;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.CheckBox cbSSS;
        private System.Windows.Forms.CheckBox cbPAGIBIG;
        private System.Windows.Forms.CheckBox cbPHILHEALTH;
    }
}