namespace WindowsFormsAppTesting
{
    partial class EmployeeDetail
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
            this.label_EmployeeName = new System.Windows.Forms.Label();
            this.txtEmplyeeName = new System.Windows.Forms.TextBox();
            this.label_DayOfBirth = new System.Windows.Forms.Label();
            this.dtpDayOfBirth = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cbListDepartment = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_EmployeeName
            // 
            this.label_EmployeeName.AutoSize = true;
            this.label_EmployeeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_EmployeeName.Location = new System.Drawing.Point(25, 38);
            this.label_EmployeeName.Name = "label_EmployeeName";
            this.label_EmployeeName.Size = new System.Drawing.Size(109, 16);
            this.label_EmployeeName.TabIndex = 0;
            this.label_EmployeeName.Text = "Employee Name";
            this.label_EmployeeName.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtEmplyeeName
            // 
            this.txtEmplyeeName.Location = new System.Drawing.Point(135, 38);
            this.txtEmplyeeName.Name = "txtEmplyeeName";
            this.txtEmplyeeName.Size = new System.Drawing.Size(200, 20);
            this.txtEmplyeeName.TabIndex = 1;
            // 
            // label_DayOfBirth
            // 
            this.label_DayOfBirth.AutoSize = true;
            this.label_DayOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DayOfBirth.Location = new System.Drawing.Point(25, 80);
            this.label_DayOfBirth.Name = "label_DayOfBirth";
            this.label_DayOfBirth.Size = new System.Drawing.Size(77, 16);
            this.label_DayOfBirth.TabIndex = 2;
            this.label_DayOfBirth.Text = "Day Of Birth";
            this.label_DayOfBirth.Click += new System.EventHandler(this.label_DayOfBirth_Click);
            // 
            // dtpDayOfBirth
            // 
            this.dtpDayOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDayOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDayOfBirth.Location = new System.Drawing.Point(135, 74);
            this.dtpDayOfBirth.Name = "dtpDayOfBirth";
            this.dtpDayOfBirth.Size = new System.Drawing.Size(200, 22);
            this.dtpDayOfBirth.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Department";
            // 
            // cbListDepartment
            // 
            this.cbListDepartment.FormattingEnabled = true;
            this.cbListDepartment.Location = new System.Drawing.Point(135, 110);
            this.cbListDepartment.Name = "cbListDepartment";
            this.cbListDepartment.Size = new System.Drawing.Size(121, 21);
            this.cbListDepartment.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Status";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(135, 150);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(121, 21);
            this.cbStatus.TabIndex = 7;
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Save.Location = new System.Drawing.Point(401, 218);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 8;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Delete.Location = new System.Drawing.Point(497, 218);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(75, 23);
            this.btn_Delete.TabIndex = 9;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Clear.Location = new System.Drawing.Point(299, 218);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear.TabIndex = 10;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbStatus);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbListDepartment);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpDayOfBirth);
            this.groupBox1.Controls.Add(this.label_DayOfBirth);
            this.groupBox1.Controls.Add(this.txtEmplyeeName);
            this.groupBox1.Controls.Add(this.label_EmployeeName);
            this.groupBox1.Location = new System.Drawing.Point(16, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 182);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // EmployeeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 263);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EmployeeDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmployeeDetail";
            this.Load += new System.EventHandler(this.EmployeeDetail_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_EmployeeName;
        private System.Windows.Forms.TextBox txtEmplyeeName;
        private System.Windows.Forms.Label label_DayOfBirth;
        private System.Windows.Forms.DateTimePicker dtpDayOfBirth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbListDepartment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}