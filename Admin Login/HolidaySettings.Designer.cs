namespace Admin_Login
{
    partial class HolidaySettings
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
            this.lbl_Add = new System.Windows.Forms.Label();
            this.lbl_Edit = new System.Windows.Forms.Label();
            this.lbl_Delete = new System.Windows.Forms.Label();
            this.dtp_To = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_HolidayName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_Type = new System.Windows.Forms.ComboBox();
            this.dtp_From = new System.Windows.Forms.DateTimePicker();
            this.dg_HolidaysTable = new System.Windows.Forms.DataGridView();
            this.fFRUsersDataSet3 = new Admin_Login.FFRUsersDataSet3();
            this.holidaysBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_Done = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pb_Delete = new System.Windows.Forms.PictureBox();
            this.pb_Edit = new System.Windows.Forms.PictureBox();
            this.pb_Add = new System.Windows.Forms.PictureBox();
            this.cb_HolidayName = new System.Windows.Forms.ComboBox();
            this.t_Done = new System.Windows.Forms.Timer(this.components);
            this.holidaysTableAdapter1 = new Admin_Login.FFRUsersDataSet2TableAdapters.HolidaysTableAdapter();
            this.fFRUsersDataSet13 = new Admin_Login.FFRUsersDataSet13();
            this.holidaysBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.holidaysTableAdapter = new Admin_Login.FFRUsersDataSet13TableAdapters.HolidaysTableAdapter();
            this.holidayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fromDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dg_HolidaysTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fFRUsersDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidaysBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Add)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fFRUsersDataSet13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidaysBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Add
            // 
            this.lbl_Add.AutoSize = true;
            this.lbl_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.lbl_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Add.ForeColor = System.Drawing.Color.White;
            this.lbl_Add.Location = new System.Drawing.Point(738, 51);
            this.lbl_Add.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Add.Name = "lbl_Add";
            this.lbl_Add.Size = new System.Drawing.Size(59, 26);
            this.lbl_Add.TabIndex = 9;
            this.lbl_Add.Tag = "btn_Add";
            this.lbl_Add.Text = "ADD";
            this.lbl_Add.Click += new System.EventHandler(this.Btn_Add_Click);
            // 
            // lbl_Edit
            // 
            this.lbl_Edit.AutoSize = true;
            this.lbl_Edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(132)))), ((int)(((byte)(227)))));
            this.lbl_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Edit.ForeColor = System.Drawing.Color.White;
            this.lbl_Edit.Location = new System.Drawing.Point(740, 117);
            this.lbl_Edit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Edit.Name = "lbl_Edit";
            this.lbl_Edit.Size = new System.Drawing.Size(61, 26);
            this.lbl_Edit.TabIndex = 11;
            this.lbl_Edit.Tag = "btn_Edit_HolidaySettings";
            this.lbl_Edit.Text = "EDIT";
            this.lbl_Edit.Click += new System.EventHandler(this.Btn_Edit_Click);
            // 
            // lbl_Delete
            // 
            this.lbl_Delete.AutoSize = true;
            this.lbl_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(48)))), ((int)(((byte)(49)))));
            this.lbl_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Delete.ForeColor = System.Drawing.Color.White;
            this.lbl_Delete.Location = new System.Drawing.Point(723, 184);
            this.lbl_Delete.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Delete.Name = "lbl_Delete";
            this.lbl_Delete.Size = new System.Drawing.Size(97, 26);
            this.lbl_Delete.TabIndex = 13;
            this.lbl_Delete.Tag = "btn_Delete_HolidaySettings";
            this.lbl_Delete.Text = "DELETE";
            this.lbl_Delete.Click += new System.EventHandler(this.Btn_Delete_Click);
            // 
            // dtp_To
            // 
            this.dtp_To.CustomFormat = "MMMM dd, yyyy";
            this.dtp_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_To.Location = new System.Drawing.Point(338, 96);
            this.dtp_To.Margin = new System.Windows.Forms.Padding(2);
            this.dtp_To.Name = "dtp_To";
            this.dtp_To.Size = new System.Drawing.Size(280, 28);
            this.dtp_To.TabIndex = 35;
            this.dtp_To.ValueChanged += new System.EventHandler(this.Dtp_To_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 76);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 34;
            this.label5.Text = "Period:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 17);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 20);
            this.label6.TabIndex = 38;
            this.label6.Text = "Holiday Name:";
            // 
            // tb_HolidayName
            // 
            this.tb_HolidayName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_HolidayName.Location = new System.Drawing.Point(9, 36);
            this.tb_HolidayName.Margin = new System.Windows.Forms.Padding(2);
            this.tb_HolidayName.Name = "tb_HolidayName";
            this.tb_HolidayName.Size = new System.Drawing.Size(609, 28);
            this.tb_HolidayName.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 134);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 20);
            this.label7.TabIndex = 40;
            this.label7.Text = "Type:";
            // 
            // cb_Type
            // 
            this.cb_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Type.FormattingEnabled = true;
            this.cb_Type.Items.AddRange(new object[] {
            "Regular Holiday",
            "Special Non-Working Holiday",
            "Special Working Holiday"});
            this.cb_Type.Location = new System.Drawing.Point(9, 155);
            this.cb_Type.Margin = new System.Windows.Forms.Padding(2);
            this.cb_Type.Name = "cb_Type";
            this.cb_Type.Size = new System.Drawing.Size(308, 30);
            this.cb_Type.TabIndex = 41;
            this.cb_Type.SelectedValueChanged += new System.EventHandler(this.Cb_Type_SelectedValueChanged);
            // 
            // dtp_From
            // 
            this.dtp_From.CustomFormat = "MMMM dd, yyyy";
            this.dtp_From.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_From.Location = new System.Drawing.Point(9, 96);
            this.dtp_From.Margin = new System.Windows.Forms.Padding(2);
            this.dtp_From.Name = "dtp_From";
            this.dtp_From.Size = new System.Drawing.Size(264, 28);
            this.dtp_From.TabIndex = 42;
            this.dtp_From.ValueChanged += new System.EventHandler(this.Dtp_From_ValueChanged);
            // 
            // dg_HolidaysTable
            // 
            this.dg_HolidaysTable.AllowUserToAddRows = false;
            this.dg_HolidaysTable.AllowUserToDeleteRows = false;
            this.dg_HolidaysTable.AutoGenerateColumns = false;
            this.dg_HolidaysTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_HolidaysTable.BackgroundColor = System.Drawing.Color.White;
            this.dg_HolidaysTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_HolidaysTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_HolidaysTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.holidayDataGridViewTextBoxColumn,
            this.fromDataGridViewTextBoxColumn,
            this.toDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn});
            this.dg_HolidaysTable.DataSource = this.holidaysBindingSource;
            this.dg_HolidaysTable.Location = new System.Drawing.Point(9, 202);
            this.dg_HolidaysTable.Margin = new System.Windows.Forms.Padding(2);
            this.dg_HolidaysTable.Name = "dg_HolidaysTable";
            this.dg_HolidaysTable.ReadOnly = true;
            this.dg_HolidaysTable.RowHeadersWidth = 51;
            this.dg_HolidaysTable.RowTemplate.Height = 24;
            this.dg_HolidaysTable.Size = new System.Drawing.Size(608, 380);
            this.dg_HolidaysTable.TabIndex = 43;
            this.dg_HolidaysTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dg_HolidaysTable_CellClick);
            // 
            // fFRUsersDataSet3
            // 
            this.fFRUsersDataSet3.DataSetName = "FFRUsersDataSet3";
            this.fFRUsersDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // holidaysBindingSource1
            // 
            this.holidaysBindingSource1.DataMember = "Holidays";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(296, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 26);
            this.label3.TabIndex = 44;
            this.label3.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(48)))), ((int)(((byte)(49)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(723, 538);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 26);
            this.label8.TabIndex = 46;
            this.label8.Tag = "btn_Cancel";
            this.label8.Text = "Cancel";
            this.label8.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // lbl_Done
            // 
            this.lbl_Done.AutoSize = true;
            this.lbl_Done.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.lbl_Done.Enabled = false;
            this.lbl_Done.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Done.ForeColor = System.Drawing.Color.White;
            this.lbl_Done.Location = new System.Drawing.Point(723, 405);
            this.lbl_Done.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Done.Name = "lbl_Done";
            this.lbl_Done.Size = new System.Drawing.Size(64, 26);
            this.lbl_Done.TabIndex = 48;
            this.lbl_Done.Tag = "btn_Done";
            this.lbl_Done.Text = "Done";
            this.lbl_Done.Click += new System.EventHandler(this.Btn_Done_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(132)))), ((int)(((byte)(227)))));
            this.label10.Enabled = false;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(723, 471);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 26);
            this.label10.TabIndex = 50;
            this.label10.Tag = "btn_Clear";
            this.label10.Text = "Clear";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Enabled = false;
            this.pictureBox6.Image = global::Admin_Login.Properties.Resources.Clear_Icon;
            this.pictureBox6.Location = new System.Drawing.Point(655, 454);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(175, 61);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 49;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Tag = "btn_Clear";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Enabled = false;
            this.pictureBox5.Image = global::Admin_Login.Properties.Resources.Done_Icon;
            this.pictureBox5.Location = new System.Drawing.Point(655, 388);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(175, 61);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 47;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Tag = "btn_Done";
            this.pictureBox5.Click += new System.EventHandler(this.Btn_Done_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Admin_Login.Properties.Resources.Cancel_Icon;
            this.pictureBox3.Location = new System.Drawing.Point(655, 521);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(175, 61);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 45;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Tag = "btn_Cancel";
            this.pictureBox3.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // pb_Delete
            // 
            this.pb_Delete.Image = global::Admin_Login.Properties.Resources.Delete_Icon;
            this.pb_Delete.Location = new System.Drawing.Point(655, 167);
            this.pb_Delete.Margin = new System.Windows.Forms.Padding(2);
            this.pb_Delete.Name = "pb_Delete";
            this.pb_Delete.Size = new System.Drawing.Size(175, 61);
            this.pb_Delete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Delete.TabIndex = 12;
            this.pb_Delete.TabStop = false;
            this.pb_Delete.Tag = "btn_Delete_HolidaySettings";
            this.pb_Delete.Click += new System.EventHandler(this.Btn_Delete_Click);
            // 
            // pb_Edit
            // 
            this.pb_Edit.Image = global::Admin_Login.Properties.Resources.Edit_Icon;
            this.pb_Edit.Location = new System.Drawing.Point(655, 100);
            this.pb_Edit.Margin = new System.Windows.Forms.Padding(2);
            this.pb_Edit.Name = "pb_Edit";
            this.pb_Edit.Size = new System.Drawing.Size(175, 61);
            this.pb_Edit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Edit.TabIndex = 10;
            this.pb_Edit.TabStop = false;
            this.pb_Edit.Tag = "btn_Edit_HolidaySettings";
            this.pb_Edit.Click += new System.EventHandler(this.Btn_Edit_Click);
            // 
            // pb_Add
            // 
            this.pb_Add.Image = global::Admin_Login.Properties.Resources.Add_Icon;
            this.pb_Add.Location = new System.Drawing.Point(655, 34);
            this.pb_Add.Margin = new System.Windows.Forms.Padding(2);
            this.pb_Add.Name = "pb_Add";
            this.pb_Add.Size = new System.Drawing.Size(175, 61);
            this.pb_Add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Add.TabIndex = 8;
            this.pb_Add.TabStop = false;
            this.pb_Add.Tag = "btn_Add";
            this.pb_Add.Click += new System.EventHandler(this.Btn_Add_Click);
            // 
            // cb_HolidayName
            // 
            this.cb_HolidayName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_HolidayName.FormattingEnabled = true;
            this.cb_HolidayName.Location = new System.Drawing.Point(9, 37);
            this.cb_HolidayName.Margin = new System.Windows.Forms.Padding(2);
            this.cb_HolidayName.Name = "cb_HolidayName";
            this.cb_HolidayName.Size = new System.Drawing.Size(609, 30);
            this.cb_HolidayName.TabIndex = 51;
            this.cb_HolidayName.SelectedValueChanged += new System.EventHandler(this.Cb_HolidayName_SelectedValueChanged);
            // 
            // t_Done
            // 
            this.t_Done.Tick += new System.EventHandler(this.Done_Tick);
            // 
            // holidaysTableAdapter1
            // 
            this.holidaysTableAdapter1.ClearBeforeFill = true;
            // 
            // fFRUsersDataSet13
            // 
            this.fFRUsersDataSet13.DataSetName = "FFRUsersDataSet13";
            this.fFRUsersDataSet13.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // holidaysBindingSource
            // 
            this.holidaysBindingSource.DataMember = "Holidays";
            this.holidaysBindingSource.DataSource = this.fFRUsersDataSet13;
            // 
            // holidaysTableAdapter
            // 
            this.holidaysTableAdapter.ClearBeforeFill = true;
            // 
            // holidayDataGridViewTextBoxColumn
            // 
            this.holidayDataGridViewTextBoxColumn.DataPropertyName = "Holiday_";
            this.holidayDataGridViewTextBoxColumn.HeaderText = "Holiday_";
            this.holidayDataGridViewTextBoxColumn.Name = "holidayDataGridViewTextBoxColumn";
            this.holidayDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fromDataGridViewTextBoxColumn
            // 
            this.fromDataGridViewTextBoxColumn.DataPropertyName = "From_";
            this.fromDataGridViewTextBoxColumn.HeaderText = "From_";
            this.fromDataGridViewTextBoxColumn.Name = "fromDataGridViewTextBoxColumn";
            this.fromDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // toDataGridViewTextBoxColumn
            // 
            this.toDataGridViewTextBoxColumn.DataPropertyName = "To_";
            this.toDataGridViewTextBoxColumn.HeaderText = "To_";
            this.toDataGridViewTextBoxColumn.Name = "toDataGridViewTextBoxColumn";
            this.toDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type_";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type_";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // HolidaySettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(854, 592);
            this.ControlBox = false;
            this.Controls.Add(this.cb_HolidayName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.lbl_Done);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dg_HolidaysTable);
            this.Controls.Add(this.dtp_From);
            this.Controls.Add(this.cb_Type);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_HolidayName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtp_To);
            this.Controls.Add(this.lbl_Delete);
            this.Controls.Add(this.pb_Delete);
            this.Controls.Add(this.lbl_Edit);
            this.Controls.Add(this.pb_Edit);
            this.Controls.Add(this.lbl_Add);
            this.Controls.Add(this.pb_Add);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "HolidaySettings";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HolidaySettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_HolidaysTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fFRUsersDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidaysBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Add)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fFRUsersDataSet13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidaysBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Add;
        private System.Windows.Forms.PictureBox pb_Add;
        private System.Windows.Forms.Label lbl_Edit;
        private System.Windows.Forms.PictureBox pb_Edit;
        private System.Windows.Forms.Label lbl_Delete;
        private System.Windows.Forms.PictureBox pb_Delete;
        private System.Windows.Forms.DateTimePicker dtp_To;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_HolidayName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_Type;
        private System.Windows.Forms.DateTimePicker dtp_From;
        private System.Windows.Forms.DataGridView dg_HolidaysTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lbl_Done;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.ComboBox cb_HolidayName;
        private System.Windows.Forms.Timer t_Done;
        private System.Windows.Forms.BindingSource holidaysBindingSource1;
        private FFRUsersDataSet2TableAdapters.HolidaysTableAdapter holidaysTableAdapter1;
        private FFRUsersDataSet3 fFRUsersDataSet3;
        private FFRUsersDataSet13 fFRUsersDataSet13;
        private System.Windows.Forms.BindingSource holidaysBindingSource;
        private FFRUsersDataSet13TableAdapters.HolidaysTableAdapter holidaysTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn holidayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn toDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
    }
}