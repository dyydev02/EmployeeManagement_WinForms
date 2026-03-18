using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WindowsFormsAppTesting;

namespace WindowsFormsAppTesting
{
    public partial class Form1 : Form
    {
        // reuse connection string in one place
        private readonly string _connectionString =
     ConfigurationManager.ConnectionStrings["EmployeeDb"].ConnectionString;
        private string _currentView = "Employees";

        // data layer
        private readonly DataAccess _dataAccess;
        private readonly EmployeeRepository _employeeRepo;
        private readonly DepartmentRepository _departmentRepo;
        public Form1()
        {
            InitializeComponent();
            _dataAccess = new DataAccess(_connectionString);
            _employeeRepo = new EmployeeRepository(_dataAccess);
            _departmentRepo = new DepartmentRepository(_dataAccess);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];

            try
            {
                if (_currentView == "Employees")
                {
                    txtEmployeeName.Text = row.Cells["EmployeeName"].Value?.ToString();

                    dtpDayOfBirth.Value = row.Cells["DayOfBirth"].Value != null
                        ? Convert.ToDateTime(row.Cells["DayOfBirth"].Value)
                        : DateTime.Now;

                    txtDepartmentId.Text = row.Cells["DepartmentId"].Value?.ToString();
                    if (row.Cells["DepartmentId"].Value != null && ListDepartmentName.DataSource != null && !string.IsNullOrWhiteSpace(ListDepartmentName.ValueMember))
                    {
                        try { ListDepartmentName.SelectedValue = row.Cells["DepartmentId"].Value; } catch { }
                    }

                    if (row.Cells["Status"].Value != null && ListStatus.DataSource != null && !string.IsNullOrWhiteSpace(ListStatus.ValueMember))
                    {
                        try { ListStatus.SelectedValue = row.Cells["Status"].Value; } catch { }
                    }
                }
                else if (_currentView == "Departments")
                {
                    txtEmployeeName.Text = "";
                    dtpDayOfBirth.Text = "";
                    // clear status selection safely
                    try { ListStatus.SelectedIndex = -1; } catch { ListStatus.DataSource = null; }
                    txtDepartmentId.Text = row.Cells["Id"].Value?.ToString();

                    // Departments query exposes column "Id".
                    // Use the existing "Id" column to set the selected value.
                    //int id = 0;
                    //try
                    //{
                    //    if (row.Cells["Id"].Value != null)
                    //        id = Convert.ToInt32(row.Cells["Id"].Value);
                    //}
                    //catch
                    //{
                    //    MessageBox.Show("Invalid department id in grid.");
                    //    return;
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];

            // department view (case-insensitive)
            if (string.Equals(_currentView, "Departments", StringComparison.OrdinalIgnoreCase))
            {
                var idObj = row.Cells["Id"].Value;
                var nameObj = row.Cells["DepartmentName"].Value;
                if (idObj == null) return;

                int deptId;
                try { deptId = Convert.ToInt32(idObj); }
                catch { return; }

                var deptName = nameObj?.ToString() ?? string.Empty;
              
            
                using (var dlg = new DepartmentDetail(deptId, deptName, _departmentRepo))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        // refresh departments grid and lookup
                        LoadDepartmentsGrid();
                        LoadDepartment();
                    }
                }
                return;
            }
            else if (string.Equals(_currentView, "Employees", StringComparison.OrdinalIgnoreCase))
            {
                // open employee modal with CRUD actions
                var idObj = row.Cells["Id"].Value;
                if (idObj == null) return;

                int empId;
                try { empId = Convert.ToInt32(idObj); }
                catch { return; }

                var name = row.Cells["EmployeeName"].Value?.ToString() ?? string.Empty;
                DateTime dob = DateTime.MinValue;
                try { if (row.Cells["DayOfBirth"].Value != null) dob = Convert.ToDateTime(row.Cells["DayOfBirth"].Value); } catch { }
                int deptId = 0;
                try { if (row.Cells["DepartmentId"].Value != null) deptId = Convert.ToInt32(row.Cells["DepartmentId"].Value); } catch { }
                var status = row.Cells["Status"].Value?.ToString() ?? string.Empty;

                using (var dlg = new EmployeeDetail(empId, name, dob, deptId, status, _employeeRepo, _departmentRepo))
                {
                    var res = dlg.ShowDialog(this);
                    if (res == DialogResult.OK)
                    {
                        // refresh grid after possible changes
                        LoadEmployees();
                    }
                }
            }
        }
        // Insert new employee into database (calls repository)
        private void CreateEmployee(string name, DateTime dob, int departmentId, string status)
        {
            _employeeRepo.Create(name, dob, departmentId, status);
        }
        // Department CRUD wrappers to mirror employee methods
        private void CreateDepartment(string name)
        {
            _departmentRepo.Create(name);
        }

        private bool UpdateDepartment(int id, string name)
        {
            return _departmentRepo.Update(id, name);
        }

        private bool DeleteDepartment(int id)
        {
            return _departmentRepo.Delete(id);
        }
        // Delete employee by id (repository)
        private bool DeleteEmployee(int id)
        {
            return _employeeRepo.Delete(id);
        }
        // Update employee by id (repository)
        private bool UpdateEmployee(int id, string name, DateTime dob, int departmentId, string status)
        {
            return _employeeRepo.Update(id, name, dob, departmentId, status);
        }
        // Execute query and return DataTable
        private DataTable ExecuteQuery(string query)
        {
            return _dataAccess.Query(query);
        }
       
        public void LoadEmployees()
        {
            try
            {
                var dt = _employeeRepo.GetAll();

                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dt;

                if (dataGridView1.Columns.Contains("DayOfBirth"))
                    dataGridView1.Columns["DayOfBirth"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        // Generic data for ComboBox
        public void BindListControl(ListControl control, string displayMember, string valueMember, DataTable dt)
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));

            control.DataSource = dt;
            control.DisplayMember = displayMember;
            control.ValueMember = valueMember;
        }

        public void LoadStatus()
        {
            // build a DataTable of distinct Status values so we can set DisplayMember/ValueMember
            var dtAll = _employeeRepo.GetAll();
            var dtStatus = new DataTable();
            dtStatus.Columns.Add("Status", typeof(string));

            if (dtAll != null)
            {
                var seen = new HashSet<string>();
                foreach (System.Data.DataRow r in dtAll.Rows)
                {
                    var s = r["Status"]?.ToString();
                    if (!string.IsNullOrEmpty(s) && seen.Add(s))
                        dtStatus.Rows.Add(s);
                }
            }

            ListStatus.DataSource = null;
            ListStatus.DataSource = dtStatus;
            ListStatus.DisplayMember = "Status";
            ListStatus.ValueMember = "Status";
        }

        public void LoadDepartment()
        {
            var dt = _departmentRepo.GetAll();
            ListDepartmentName.DataSource = null;
            ListDepartmentName.DataSource = dt;
            ListDepartmentName.DisplayMember = "DepartmentName";
            ListDepartmentName.ValueMember = "Id";
        }

        private void LoadDepartmentsGrid()
        {
            try
            {
                var dt = _departmentRepo.GetAll();
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading departments: {ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load lookup lists first so SelectedValue can be applied later
            LoadDepartment(); // Load departments
            LoadStatus();    // Load statuses
            LoadEmployees(); // Load employees
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            // show dialog to create new employee or department based on current view
            if (string.Equals(_currentView, "Employees", StringComparison.OrdinalIgnoreCase))
            {
                using (var dlg = new EmployeeDetail(0, null, DateTime.MinValue, 0, null, _employeeRepo, _departmentRepo))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                       LoadEmployees();
                        LoadDepartment();
                        LoadStatus();
                    }
                }
                return;
            }

            if (string.Equals(_currentView, "Departments", StringComparison.OrdinalIgnoreCase))
            {
                using (var dlg = new DepartmentDetail(0, null, _departmentRepo))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadDepartmentsGrid();
                        LoadDepartment();
                    }
                }
                return;
            }

            }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListDepartmentName.SelectedValue != null)
            {
                txtDepartmentId.Text = ListDepartmentName.SelectedValue.ToString();
            }
        }

        private void ListStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            // delete selected row in DataGridView
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("No row selected.");
                return;
            }

            try
            {
                if (_currentView == "Employees")
                {
                    var idCell = dataGridView1.CurrentRow.Cells["Id"];
                    var nameCell = dataGridView1.CurrentRow.Cells["EmployeeName"];

                    if (idCell == null || idCell.Value == null)
                    {
                        MessageBox.Show("Selected row has no Id.");
                        return;
                    }

                    var id = Convert.ToInt32(idCell.Value);
                    var nameText = nameCell?.Value?.ToString() ?? string.Empty;
                    var confirm = MessageBox.Show($"Delete employee Id={id}, Name={nameText}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm != DialogResult.Yes)
                        return;

                    var deleteResult = DeleteEmployee(id);
                    if (deleteResult)
                    {
                      LoadEmployees();
                        MessageBox.Show("Employee deleted.");
                    }
                    else
                    {
                        MessageBox.Show("No employee was deleted.");
                    }
                }
                else if (_currentView == "Departments")
                {
                    var idCell = dataGridView1.CurrentRow.Cells["Id"];
                    var nameCell = dataGridView1.CurrentRow.Cells["DepartmentName"];

                    if (idCell == null || idCell.Value == null)
                    {
                        MessageBox.Show("Selected row has no Id.");
                        return;
                    }

                    var id = Convert.ToInt32(idCell.Value);
                    var nameText = nameCell?.Value?.ToString() ?? string.Empty;

                    // prevent deleting a department that still has employees
                    var employees = _employeeRepo.GetByDepartmentId(id);
                    if (employees != null && employees.Rows.Count > 0)
                    {
                        MessageBox.Show($"Cannot delete department '{nameText}' (Id={id}) because it contains {employees.Rows.Count} employee(s). Remove or reassign employees first.");
                        return;
                    }

                    var confirm = MessageBox.Show($"Delete department Id={id}, Name={nameText}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm != DialogResult.Yes)
                        return;

                    var deleteDeptResult = DeleteDepartment(id);
                    if (deleteDeptResult)
                    {
                        LoadDepartmentsGrid();
                        LoadDepartment();
                        MessageBox.Show("Department deleted.");
                    }
                    else
                    {
                        MessageBox.Show("No department was deleted.");
                    }
                }
                else
                {
                    MessageBox.Show("Unknown view.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting: {ex.Message}");
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            // validate selected row id
            var idCell = dataGridView1.CurrentRow?.Cells["Id"];
            if (idCell == null || idCell.Value == null)
            {
                MessageBox.Show("Selected row has no Id.");
                return;
            }

            int id;
            try { id = Convert.ToInt32(idCell.Value); }
            catch
            {
                MessageBox.Show("Invalid Id.");
                return;
            }

            try
            {
                if (_currentView == "Employees")
                {
                    // Employee-specific validation
                    var name = txtEmployeeName.Text?.Trim();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        MessageBox.Show("Employee name is required.");
                        return;
                    }

                    DateTime dob;
                    if (dtpDayOfBirth.Value > DateTime.Now)
                    {
                        MessageBox.Show("Day of birth cannot be in the future.");
                        return;
                    }
                    else
                    {
                        dob = dtpDayOfBirth.Value.Date;
                    }

                    int departmentId = 0;
                    if (ListDepartmentName.SelectedValue != null)
                    {
                        try { departmentId = Convert.ToInt32(ListDepartmentName.SelectedValue); }
                        catch
                        {
                            MessageBox.Show("Invalid department id.");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a department.");
                        return;
                    }

                    var status = ListStatus?.SelectedValue?.ToString() ?? "Active";

                    var result = UpdateEmployee(id, name, dob, departmentId, status);

                    // perform update
                    if (result)
                    {
                        LoadEmployees();
                        MessageBox.Show("Employee updated.");
                    }
                    else
                    {
                        MessageBox.Show("No employee was updated.");
                    }
                }
                else if (_currentView == "Departments")
                {
                    // Department-specific validation - use ListDepartmentName.Text
                    var deptName = ListDepartmentName.Text?.Trim();

                    if (string.IsNullOrWhiteSpace(deptName))
                    {
                        MessageBox.Show("Department name is required.");
                        return;
                    }

                    var updateDeptResult = UpdateDepartment(id, deptName);
                    if (updateDeptResult)
                    {
                        LoadDepartmentsGrid();
                        LoadDepartment();
                        MessageBox.Show("Department updated.");
                    }
                    else
                    {
                        MessageBox.Show("No department was updated.");
                    }
                }
                else
                {
                    MessageBox.Show("Unknown view.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating: {ex.Message}");
            }
        }
        // validate 
        

        private void ShowEmployeesView()
        {
            // enable employee input controls
            txtEmployeeName.Enabled = true;
            dtpDayOfBirth.Enabled = true;
            ListDepartmentName.Enabled = true;
            ListStatus.Enabled = true;
            btn_Create.Enabled = true;
            txtDepartmentId.Enabled = true;
            // reload lookups and main grid
            LoadDepartment();
            LoadStatus();
            LoadEmployees();
        }

        private void ShowDepartmentsView()
        {
            // enable department inputs (use txtDepartmentName for department name)
            txtEmployeeName.Enabled = false;
            dtpDayOfBirth.Enabled = false;
            ListDepartmentName.Enabled = true;
            ListStatus.Enabled = false;
            btn_Create.Enabled = true;
            txtDepartmentId.Enabled = true;

            // show departments only
            LoadDepartmentsGrid();
        }

        private void emploToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _currentView = "Employees";
            ShowEmployeesView();
        }

        private void departmentManagementToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            _currentView = "Departments";
            ShowDepartmentsView();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Only operate when currently showing Departments view
            if (!string.Equals(_currentView, "Departments", StringComparison.OrdinalIgnoreCase))
            {
                // ignore click in Employees view
                return;
            }

            // require a single selected row (or at least a current row)
            DataGridViewRow row = null;
            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count == 1)
                row = dataGridView1.SelectedRows[0];
            else if (dataGridView1.CurrentRow != null)
                row = dataGridView1.CurrentRow;

            if (row == null)
            {
                MessageBox.Show("Please select one department row.");
                return;
            }

            var idObj = row.Cells["Id"].Value;
            var nameObj = row.Cells["DepartmentName"].Value;
            if (idObj == null)
            {
                MessageBox.Show("Selected department has no Id.");
                return;
            }

            int deptId;
            try { deptId = Convert.ToInt32(idObj); }
            catch
            {
                MessageBox.Show("Invalid department id.");
                return;
            }

            var deptName = nameObj?.ToString() ?? string.Empty;
            var employees = _employeeRepo.GetByDepartmentId(deptId);

            using (var dlg = new DepartmentDetailForm(deptId, deptName, employees))
            {
                dlg.ShowDialog(this);
            }
            
        }
    }
}
