namespace WindowsFormsAppTesting
{
    partial class DepartmentDetail
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
            this.label_DepartmentId = new System.Windows.Forms.Label();
            this.label_DepartmentName = new System.Windows.Forms.Label();
            this.cbListDepartment = new System.Windows.Forms.ComboBox();
            this.txtDepartmentId = new System.Windows.Forms.TextBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_DepartmentId
            // 
            this.label_DepartmentId.AutoSize = true;
            this.label_DepartmentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DepartmentId.Location = new System.Drawing.Point(2, 21);
            this.label_DepartmentId.Name = "label_DepartmentId";
            this.label_DepartmentId.Size = new System.Drawing.Size(93, 16);
            this.label_DepartmentId.TabIndex = 0;
            this.label_DepartmentId.Text = "Department ID";
            this.label_DepartmentId.Click += new System.EventHandler(this.label1_Click);
            // 
            // label_DepartmentName
            // 
            this.label_DepartmentName.AutoSize = true;
            this.label_DepartmentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DepartmentName.Location = new System.Drawing.Point(2, 69);
            this.label_DepartmentName.Name = "label_DepartmentName";
            this.label_DepartmentName.Size = new System.Drawing.Size(117, 16);
            this.label_DepartmentName.TabIndex = 1;
            this.label_DepartmentName.Text = "Department Name";
            // 
            // cbListDepartment
            // 
            this.cbListDepartment.FormattingEnabled = true;
            this.cbListDepartment.Location = new System.Drawing.Point(142, 68);
            this.cbListDepartment.Name = "cbListDepartment";
            this.cbListDepartment.Size = new System.Drawing.Size(121, 21);
            this.cbListDepartment.TabIndex = 2;
            // 
            // txtDepartmentId
            // 
            this.txtDepartmentId.Location = new System.Drawing.Point(142, 20);
            this.txtDepartmentId.Name = "txtDepartmentId";
            this.txtDepartmentId.Size = new System.Drawing.Size(121, 20);
            this.txtDepartmentId.TabIndex = 3;
            // 
            // btn_clear
            // 
            this.btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.Location = new System.Drawing.Point(202, 144);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 4;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Save.Location = new System.Drawing.Point(295, 144);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 5;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click_1);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.Red;
            this.btn_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.ForeColor = System.Drawing.Color.White;
            this.btn_Delete.Location = new System.Drawing.Point(391, 144);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(75, 23);
            this.btn_Delete.TabIndex = 6;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDepartmentId);
            this.groupBox1.Controls.Add(this.cbListDepartment);
            this.groupBox1.Controls.Add(this.label_DepartmentName);
            this.groupBox1.Controls.Add(this.label_DepartmentId);
            this.groupBox1.Location = new System.Drawing.Point(14, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 106);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // DepartmentDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 179);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_clear);
            this.Name = "DepartmentDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DepartmentDetail";
            this.Load += new System.EventHandler(this.DepartmentDetail_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_DepartmentId;
        private System.Windows.Forms.Label label_DepartmentName;
        private System.Windows.Forms.ComboBox cbListDepartment;
        private System.Windows.Forms.TextBox txtDepartmentId;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}