using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsAppTesting
{
    public partial class EmployeeDetail : Form
    {
        private readonly int _employeeId;
        private readonly EmployeeRepository _employeeRepo;
        private readonly DepartmentRepository _departmentRepo;
     


        internal EmployeeDetail(int employeeId, string name, DateTime dob, int departmentId, string status,
           EmployeeRepository employeeRepo, DepartmentRepository departmentRepo)
        {
            _employeeId = employeeId;
            _employeeRepo = employeeRepo ;
            _departmentRepo = departmentRepo;

            InitializeComponent();

            // populate fields
            txtEmplyeeName.Text = name ?? string.Empty;
            dtpDayOfBirth.Value = dob == DateTime.MinValue ? DateTime.Now.Date : dob.Date;
            LoadDepartments(departmentId);
            LoadStatus(status);
            //txtName.Text = name ?? string.Empty;
            //dtpDob.Value = dob == DateTime.MinValue ? DateTime.Now.Date : dob.Date;
            //LoadDepartments(departmentId);
            //LoadStatus(status);
        }
        public EmployeeDetail()
        {
            InitializeComponent();
        }

        private void LoadDepartments(int selectedId)
        {
            try
            {
                var dt = _departmentRepo.GetAll();
                cbListDepartment.DataSource = dt;
                cbListDepartment.DisplayMember = "DepartmentName";
                cbListDepartment.ValueMember = "Id";
                if (dt != null && dt.Rows.Count > 0)
                {
                    try { cbListDepartment.SelectedValue = selectedId; } catch { /* ignore */ }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading departments: {ex.Message}");
            }
        }

        private void LoadStatus(string status)
        {
            cbStatus.Items.Clear();
            cbStatus.Items.AddRange(new object[] { "Active", "On Leave", "Resigned" });
            if (!string.IsNullOrWhiteSpace(status))
            {
                try { cbStatus.SelectedItem = status; } catch { }
            }
            else cbStatus.SelectedIndex = 0;
        }


        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void EmployeeDetail_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label_DayOfBirth_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            var name = txtEmplyeeName.Text?.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Employee name is required.");
                return;
            }

            if (dtpDayOfBirth.Value > DateTime.Now)
            {
                MessageBox.Show("Day of birth cannot be in the future.");
                return;
            }

            int deptId = 0;
            if (cbListDepartment.SelectedValue != null)
            {
                try { deptId = Convert.ToInt32(cbListDepartment.SelectedValue); }
                catch { MessageBox.Show("Invalid department id."); return; }
            }
            else
            {
                MessageBox.Show("Please select a department.");
                return;
            }

            var status = cbStatus.SelectedItem?.ToString() ?? string.Empty;

            try
            {
                var isNew = _employeeId <= 0;
                if (isNew)
                {
                    var created = _employeeRepo.Create(name, dtpDayOfBirth.Value.Date, deptId, status);
                    if (created)
                    {
                        MessageBox.Show("Employee created.");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Create failed.");
                    }
                }
                else
                {
                    var updated = _employeeRepo.Update(_employeeId, name, dtpDayOfBirth.Value.Date, deptId, status);
                    if (updated)
                    {
                        MessageBox.Show("Employee updated.");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No employee was updated.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving employee: {ex.Message}");
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show($"Delete employee Id={_employeeId}, Name={txtEmplyeeName.Text}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                var deleted = _employeeRepo.Delete(_employeeId);
                if (deleted)
                {
                    MessageBox.Show("Employee deleted.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No employee was deleted.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting employee: {ex.Message}");
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txtEmplyeeName.Text = string.Empty;
            dtpDayOfBirth.Value = DateTime.Now.Date;
            cbListDepartment.SelectedIndex = 0;
            cbStatus.SelectedIndex = 0;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
