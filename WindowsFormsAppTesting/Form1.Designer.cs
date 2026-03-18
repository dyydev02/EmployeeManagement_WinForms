namespace WindowsFormsAppTesting
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_Create = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.emploToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departmentManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.EmployeeName = new System.Windows.Forms.Label();
            this.DayOfBirth = new System.Windows.Forms.Label();
            this.DepartmentId = new System.Windows.Forms.Label();
            this.txtDepartmentId = new System.Windows.Forms.TextBox();
            this.DepartmentName = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.ListDepartmentName = new System.Windows.Forms.ComboBox();
            this.ListStatus = new System.Windows.Forms.ComboBox();
            this.dtpDayOfBirth = new System.Windows.Forms.DateTimePicker();
            this.btn_show = new System.Windows.Forms.Button();
            this.Information = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.Information.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(887, 253);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btn_Create
            // 
            this.btn_Create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Create.BackColor = System.Drawing.Color.Lime;
            this.btn_Create.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Create.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Create.Location = new System.Drawing.Point(818, 27);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(81, 26);
            this.btn_Create.TabIndex = 1;
            this.btn_Create.Text = "Create";
            this.btn_Create.UseVisualStyleBackColor = false;
            this.btn_Create.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(12, 172);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(887, 253);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emploToolStripMenuItem,
            this.departmentManagementToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(911, 29);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // emploToolStripMenuItem
            // 
            this.emploToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emploToolStripMenuItem.Name = "emploToolStripMenuItem";
            this.emploToolStripMenuItem.Size = new System.Drawing.Size(214, 25);
            this.emploToolStripMenuItem.Text = "Employees_Management";
            this.emploToolStripMenuItem.Click += new System.EventHandler(this.emploToolStripMenuItem_Click);
            // 
            // departmentManagementToolStripMenuItem
            // 
            this.departmentManagementToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departmentManagementToolStripMenuItem.Name = "departmentManagementToolStripMenuItem";
            this.departmentManagementToolStripMenuItem.Size = new System.Drawing.Size(223, 25);
            this.departmentManagementToolStripMenuItem.Text = "Department_Management";
            this.departmentManagementToolStripMenuItem.Click += new System.EventHandler(this.departmentManagementToolStripMenuItem_Click_1);
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(35, 48);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(112, 20);
            this.txtEmployeeName.TabIndex = 5;
            this.txtEmployeeName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // EmployeeName
            // 
            this.EmployeeName.AutoSize = true;
            this.EmployeeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmployeeName.Location = new System.Drawing.Point(32, 21);
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.Size = new System.Drawing.Size(106, 16);
            this.EmployeeName.TabIndex = 6;
            this.EmployeeName.Text = "EmployeeName";
            // 
            // DayOfBirth
            // 
            this.DayOfBirth.AutoSize = true;
            this.DayOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DayOfBirth.Location = new System.Drawing.Point(175, 21);
            this.DayOfBirth.Name = "DayOfBirth";
            this.DayOfBirth.Size = new System.Drawing.Size(71, 16);
            this.DayOfBirth.TabIndex = 7;
            this.DayOfBirth.Text = "DayOfBirth";
            // 
            // DepartmentId
            // 
            this.DepartmentId.AutoSize = true;
            this.DepartmentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepartmentId.Location = new System.Drawing.Point(175, 85);
            this.DepartmentId.Name = "DepartmentId";
            this.DepartmentId.Size = new System.Drawing.Size(88, 16);
            this.DepartmentId.TabIndex = 9;
            this.DepartmentId.Text = "DepartmentId";
            // 
            // txtDepartmentId
            // 
            this.txtDepartmentId.Location = new System.Drawing.Point(178, 113);
            this.txtDepartmentId.Name = "txtDepartmentId";
            this.txtDepartmentId.ReadOnly = true;
            this.txtDepartmentId.Size = new System.Drawing.Size(100, 20);
            this.txtDepartmentId.TabIndex = 10;
            // 
            // DepartmentName
            // 
            this.DepartmentName.AutoSize = true;
            this.DepartmentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepartmentName.Location = new System.Drawing.Point(407, 21);
            this.DepartmentName.Name = "DepartmentName";
            this.DepartmentName.Size = new System.Drawing.Size(114, 16);
            this.DepartmentName.TabIndex = 11;
            this.DepartmentName.Text = "DepartmentName";
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.Location = new System.Drawing.Point(31, 86);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(44, 16);
            this.Status.TabIndex = 15;
            this.Status.Text = "Status";
            // 
            // ListDepartmentName
            // 
            this.ListDepartmentName.FormattingEnabled = true;
            this.ListDepartmentName.Location = new System.Drawing.Point(410, 44);
            this.ListDepartmentName.Name = "ListDepartmentName";
            this.ListDepartmentName.Size = new System.Drawing.Size(121, 21);
            this.ListDepartmentName.TabIndex = 17;
            this.ListDepartmentName.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ListStatus
            // 
            this.ListStatus.FormattingEnabled = true;
            this.ListStatus.Items.AddRange(new object[] {
            "Active",
            "On Leave",
            "Resigned"});
            this.ListStatus.Location = new System.Drawing.Point(34, 112);
            this.ListStatus.Name = "ListStatus";
            this.ListStatus.Size = new System.Drawing.Size(121, 21);
            this.ListStatus.TabIndex = 18;
            this.ListStatus.SelectedIndexChanged += new System.EventHandler(this.ListStatus_SelectedIndexChanged);
            // 
            // dtpDayOfBirth
            // 
            this.dtpDayOfBirth.CalendarFont = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDayOfBirth.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDayOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDayOfBirth.Location = new System.Drawing.Point(178, 44);
            this.dtpDayOfBirth.Name = "dtpDayOfBirth";
            this.dtpDayOfBirth.Size = new System.Drawing.Size(200, 22);
            this.dtpDayOfBirth.TabIndex = 19;
            this.dtpDayOfBirth.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // btn_show
            // 
            this.btn_show.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_show.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_show.Location = new System.Drawing.Point(723, 29);
            this.btn_show.Name = "btn_show";
            this.btn_show.Size = new System.Drawing.Size(75, 23);
            this.btn_show.TabIndex = 20;
            this.btn_show.Text = "Show Employee";
            this.btn_show.UseVisualStyleBackColor = true;
            this.btn_show.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Information
            // 
            this.Information.Controls.Add(this.dtpDayOfBirth);
            this.Information.Controls.Add(this.Status);
            this.Information.Controls.Add(this.ListDepartmentName);
            this.Information.Controls.Add(this.ListStatus);
            this.Information.Controls.Add(this.DepartmentName);
            this.Information.Controls.Add(this.txtDepartmentId);
            this.Information.Controls.Add(this.DepartmentId);
            this.Information.Controls.Add(this.DayOfBirth);
            this.Information.Controls.Add(this.EmployeeName);
            this.Information.Controls.Add(this.txtEmployeeName);
            this.Information.Location = new System.Drawing.Point(12, 27);
            this.Information.Name = "Information";
            this.Information.Size = new System.Drawing.Size(552, 139);
            this.Information.TabIndex = 21;
            this.Information.TabStop = false;
            this.Information.Text = "Information";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 450);
            this.Controls.Add(this.Information);
            this.Controls.Add(this.btn_show);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_Create);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Information.ResumeLayout(false);
            this.Information.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label EmployeeName;
        private System.Windows.Forms.Label DayOfBirth;
        private System.Windows.Forms.Label DepartmentId;
        private System.Windows.Forms.TextBox txtDepartmentId;
        private System.Windows.Forms.Label DepartmentName;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.ComboBox ListDepartmentName;
        private System.Windows.Forms.ComboBox ListStatus;
        private System.Windows.Forms.DateTimePicker dtpDayOfBirth;
        private System.Windows.Forms.ToolStripMenuItem emploToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departmentManagementToolStripMenuItem;
        private System.Windows.Forms.Button btn_show;
        private System.Windows.Forms.GroupBox Information;
    }
}

