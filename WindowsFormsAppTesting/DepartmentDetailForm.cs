using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsAppTesting
{
    internal partial class DepartmentDetailForm : Form
    {
        public DepartmentDetailForm()
        {
            InitializeComponent();
        }

        public DepartmentDetailForm(int departmentId, string departmentName, DataTable employees)
            : this()
        {
            this.Text = $"Department details - {departmentName}";
            lblHeader.Text = $"Department: {departmentName} (Id={departmentId})";
            dgvEmployees.DataSource = employees;

            try
            {
                if (dgvEmployees.Columns.Contains("DepartmentId"))
                    dgvEmployees.Columns["DepartmentId"].Visible = false;
                if (dgvEmployees.Columns.Contains("DepartmentName"))
                    dgvEmployees.Columns["DepartmentName"].Visible = false;
                if (dgvEmployees.Columns.Contains("DayOfBirth"))
                    dgvEmployees.Columns["DayOfBirth"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            catch (Exception ex)
            { 
                throw new Exception( departmentName + " - Load employee list failed: " + ex.Message, ex);
            }
        }
        private void DepartmentDetailForm_Load(object sender, EventArgs e)
        {

        }
    }
}
