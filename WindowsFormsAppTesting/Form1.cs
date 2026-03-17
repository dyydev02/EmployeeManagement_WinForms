using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Xml.Linq;

namespace WindowsFormsAppTesting
{
    public partial class Form1 : Form
    {
        // reuse connection string in one place
        private readonly string _connectionString = "Server=.\\SQLEXPRESS;Database=EmployeeManagement;Trusted_Connection=True;TrustServerCertificate=True";
        private readonly string _loadDataQuery = "select e.Id, e.EmployeeName, e.DayOfBirth, e.DepartmentId, p.DepartmentName, e.Status from Employees e join Departments p on e.DepartmentId = p.Id";
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
            // ensure row clicks populate the form the same way as content clicks
            dataGridView1_CellContentClick(sender, e);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // when double-clicking a department row, show its details including employees
            if (e.RowIndex < 0) return;
            if (_currentView != "Departments") return;

            var row = dataGridView1.Rows[e.RowIndex];
            var idObj = row.Cells["Id"].Value;
            var nameObj = row.Cells["DepartmentName"].Value;
            if (idObj == null) return;

            int deptId;
            try { deptId = Convert.ToInt32(idObj); }
            catch { return; }

            var deptName = nameObj?.ToString() ?? string.Empty;
            var employees = _employeeRepo.GetByDepartmentId(deptId);

            using (var dlg = new DepartmentDetailForm(deptId, deptName, employees))
            {
                dlg.ShowDialog(this);
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

        // Bind result to DataGridView
        public void LoadData(string query)
        {
            try
            {
                var dataTable = ExecuteQuery(query);
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dataTable;
                //dataGridView1.Columns["DayOfBirth"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        // Generic data for ComboBox
        public void BindListControl(ListControl control, string displayMember, string valueMember, string query)
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));

            try
            {
                var dt = ExecuteQuery(query);
                control.DataSource = dt;
                control.DisplayMember = displayMember;
                control.ValueMember = valueMember;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error binding list control: {ex.Message}");
            }
        }

        public void LoadStatus()
        {
            var query = "SELECT DISTINCT Status FROM Employees";
            BindListControl(ListStatus, "Status", "Status", query);
        }
        public void LoadDepartment()
        {
            var query = "SELECT Id, DepartmentName FROM Departments";
            BindListControl(ListDepartmentName, "DepartmentName", "Id", query);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load lookup lists first so SelectedValue can be applied later
            LoadDepartment();
            LoadStatus();
            LoadData(_loadDataQuery);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

                    if (row.Cells["DepartmentId"].Value != null)
                        ListDepartmentName.SelectedValue = row.Cells["DepartmentId"].Value;

                    if (row.Cells["Status"].Value != null)
                        ListStatus.SelectedValue = row.Cells["Status"].Value;
                }
                else if (_currentView == "Departments")
                {
                    txtEmployeeName.Text = "";
                    dtpDayOfBirth.Text = "";
                    ListStatus.SelectedValue = "";
                    txtDepartmentId.Text = row.Cells["Id"].Value?.ToString();

                    // Departments query exposes column "Id".
                    // Use the existing "Id" column to set the selected value.
                    var deptVal = row.Cells["Id"].Value;
                    if (deptVal != null && ListDepartmentName.DataSource != null)
                    {
                        ListDepartmentName.SelectedValue = deptVal;
                        
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_currentView == "Employees")
            {
                // Create new employee from input fields
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

                // selected Departmnetname convert to DepartmentId
                int departmentId = 0;
                try
                {
                    if (ListDepartmentName.SelectedValue != null)
                        departmentId = Convert.ToInt32(ListDepartmentName.SelectedValue);
                    else
                    {
                        MessageBox.Show("Please select a department.");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid department id.");
                    return;
                }

                var status = ListStatus?.SelectedValue?.ToString() ?? string.Empty;

                try
                {
                    CreateEmployee(name, dob, departmentId, status);

                    // reload grid
                    LoadData(_loadDataQuery);
                    MessageBox.Show("Employee created.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating employee: {ex.Message}");
                }
            }
            else if (_currentView == "Departments")
            {
                var name = ListDepartmentName.Text?.Trim();
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Department name is required.");
                    return;
                }

                    try
                    {
                        CreateDepartment(name);
                        // reload grid
                        LoadData("SELECT Id, DepartmentName FROM Departments");
                        LoadDepartment();
                        MessageBox.Show("Department created.");
                    }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating department: {ex.Message}");
                }
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

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void PALLETNO_Click(object sender, EventArgs e)
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
                        LoadData(_loadDataQuery);
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
                        LoadData("SELECT Id, DepartmentName FROM Departments");
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
                        LoadData(_loadDataQuery);
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
                        LoadData("SELECT Id, DepartmentName FROM Departments");
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
            btn_Update.Enabled = true;
            btn_Delete.Enabled = true;
            txtDepartmentId.Enabled = true;

            // reload lookups and main grid
            LoadDepartment();
            LoadStatus();
            LoadData(_loadDataQuery);
        }

        private void ShowDepartmentsView()
        {
            // enable department inputs (use txtDepartmentName for department name)
            txtEmployeeName.Enabled = false;
            dtpDayOfBirth.Enabled = false;
            ListDepartmentName.Enabled = true;
            ListStatus.Enabled = false;
            btn_Create.Enabled = true;
            btn_Update.Enabled = true;
            btn_Delete.Enabled = true;
            txtDepartmentId.Enabled = true;

            // show departments only
            LoadData("SELECT Id, DepartmentName FROM Departments");
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
    }
}
