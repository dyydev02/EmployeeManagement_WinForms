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
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.Label();
            this.ListDepartmentName = new System.Windows.Forms.ComboBox();
            this.ListStatus = new System.Windows.Forms.ComboBox();
            this.dtpDayOfBirth = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(887, 253);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btn_Create
            // 
            this.btn_Create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Create.BackColor = System.Drawing.Color.Lime;
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
            this.menuStrip1.Size = new System.Drawing.Size(911, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // emploToolStripMenuItem
            // 
            this.emploToolStripMenuItem.Name = "emploToolStripMenuItem";
            this.emploToolStripMenuItem.Size = new System.Drawing.Size(152, 20);
            this.emploToolStripMenuItem.Text = "Employees_Management";
            this.emploToolStripMenuItem.Click += new System.EventHandler(this.emploToolStripMenuItem_Click);
            // 
            // departmentManagementToolStripMenuItem
            // 
            this.departmentManagementToolStripMenuItem.Name = "departmentManagementToolStripMenuItem";
            this.departmentManagementToolStripMenuItem.Size = new System.Drawing.Size(158, 20);
            this.departmentManagementToolStripMenuItem.Text = "Department_Management";
            this.departmentManagementToolStripMenuItem.Click += new System.EventHandler(this.departmentManagementToolStripMenuItem_Click_1);
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(12, 50);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(112, 20);
            this.txtEmployeeName.TabIndex = 5;
            this.txtEmployeeName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // EmployeeName
            // 
            this.EmployeeName.AutoSize = true;
            this.EmployeeName.Location = new System.Drawing.Point(13, 28);
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.Size = new System.Drawing.Size(81, 13);
            this.EmployeeName.TabIndex = 6;
            this.EmployeeName.Text = "EmployeeName";
            this.EmployeeName.Click += new System.EventHandler(this.PALLETNO_Click);
            // 
            // DayOfBirth
            // 
            this.DayOfBirth.AutoSize = true;
            this.DayOfBirth.Location = new System.Drawing.Point(156, 28);
            this.DayOfBirth.Name = "DayOfBirth";
            this.DayOfBirth.Size = new System.Drawing.Size(58, 13);
            this.DayOfBirth.TabIndex = 7;
            this.DayOfBirth.Text = "DayOfBirth";
            this.DayOfBirth.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // DepartmentId
            // 
            this.DepartmentId.AutoSize = true;
            this.DepartmentId.Location = new System.Drawing.Point(156, 93);
            this.DepartmentId.Name = "DepartmentId";
            this.DepartmentId.Size = new System.Drawing.Size(71, 13);
            this.DepartmentId.TabIndex = 9;
            this.DepartmentId.Text = "DepartmentId";
            // 
            // txtDepartmentId
            // 
            this.txtDepartmentId.Location = new System.Drawing.Point(159, 111);
            this.txtDepartmentId.Name = "txtDepartmentId";
            this.txtDepartmentId.ReadOnly = true;
            this.txtDepartmentId.Size = new System.Drawing.Size(100, 20);
            this.txtDepartmentId.TabIndex = 10;
            // 
            // DepartmentName
            // 
            this.DepartmentName.AutoSize = true;
            this.DepartmentName.Location = new System.Drawing.Point(388, 28);
            this.DepartmentName.Name = "DepartmentName";
            this.DepartmentName.Size = new System.Drawing.Size(90, 13);
            this.DepartmentName.TabIndex = 11;
            this.DepartmentName.Text = "DepartmentName";
            // 
            // btn_Update
            // 
            this.btn_Update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Update.Location = new System.Drawing.Point(737, 30);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(75, 23);
            this.btn_Update.TabIndex = 13;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Delete.BackColor = System.Drawing.Color.Red;
            this.btn_Delete.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Delete.Location = new System.Drawing.Point(656, 30);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(75, 23);
            this.btn_Delete.TabIndex = 14;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(12, 93);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(37, 13);
            this.Status.TabIndex = 15;
            this.Status.Text = "Status";
            // 
            // ListDepartmentName
            // 
            this.ListDepartmentName.FormattingEnabled = true;
            this.ListDepartmentName.Location = new System.Drawing.Point(391, 51);
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
            this.ListStatus.Location = new System.Drawing.Point(16, 110);
            this.ListStatus.Name = "ListStatus";
            this.ListStatus.Size = new System.Drawing.Size(121, 21);
            this.ListStatus.TabIndex = 18;
            this.ListStatus.SelectedIndexChanged += new System.EventHandler(this.ListStatus_SelectedIndexChanged);
            // 
            // dtpDayOfBirth
            // 
            this.dtpDayOfBirth.Location = new System.Drawing.Point(159, 51);
            this.dtpDayOfBirth.Name = "dtpDayOfBirth";
            this.dtpDayOfBirth.Size = new System.Drawing.Size(200, 20);
            this.dtpDayOfBirth.TabIndex = 19;
            this.dtpDayOfBirth.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 450);
            this.Controls.Add(this.dtpDayOfBirth);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.ListDepartmentName);
            this.Controls.Add(this.ListStatus);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.DepartmentName);
            this.Controls.Add(this.txtDepartmentId);
            this.Controls.Add(this.DepartmentId);
            this.Controls.Add(this.DayOfBirth);
            this.Controls.Add(this.EmployeeName);
            this.Controls.Add(this.txtEmployeeName);
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
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.ComboBox ListDepartmentName;
        private System.Windows.Forms.ComboBox ListStatus;
        private System.Windows.Forms.DateTimePicker dtpDayOfBirth;
        private System.Windows.Forms.ToolStripMenuItem emploToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departmentManagementToolStripMenuItem;
    }
}

