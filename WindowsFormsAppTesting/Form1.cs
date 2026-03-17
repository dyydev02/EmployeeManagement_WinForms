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
        private readonly string _connectionString = "Server=DSK065\\LOCAL;Database=EmployeeDb;Trusted_Connection=True;TrustServerCertificate=True";
        private readonly string _loadDataQuery = "select e.Id, e.EmployeeName, e.DayOfBirth, e.DepartmentId, p.DepartmentName, e.Status from Employees e join Departments p on e.DepartmentId = p.Id";
        private string _currentView = "Employees";
        public Form1()
        {
            InitializeComponent();
        }
        // Insert new employee into database
        private void CreateEmployee(string name, DateTime dob, int departmentId, string status)
        {
            var query = "INSERT INTO Employees (EmployeeName, DayOfBirth, DepartmentId, Status) VALUES (@name, @dob, @deptId, @status)";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 200).Value = name ?? string.Empty;
                cmd.Parameters.Add("@DayOfBirth", SqlDbType.Date).Value = dob.Date;
                cmd.Parameters.Add("@dob", SqlDbType.Date).Value = dob.Date;
                cmd.Parameters.Add("@deptId", SqlDbType.Int).Value = departmentId;
                cmd.Parameters.Add("@status", SqlDbType.NVarChar, 50).Value = status ?? string.Empty;

                conn.Open();
            }
        } 
        // Delete employee by id
        private bool DeleteEmployee(int id)
        {
            var query = "DELETE FROM Employees WHERE Id = @id";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                conn.Open();
               return cmd.ExecuteNonQuery() >0;
            }
        }
        // Update employee by id
        private bool UpdateEmployee(int id, string name, DateTime dob, int departmentId, string status)
        {
            var query = "UPDATE Employees SET EmployeeName = @name, DayOfBirth = @dob, DepartmentId = @deptId, Status = @status WHERE Id = @id";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 200).Value = name ?? string.Empty;
                cmd.Parameters.Add("@dob", SqlDbType.Date).Value = dob.Date;
                cmd.Parameters.Add("@deptId", SqlDbType.Int).Value = departmentId;
                cmd.Parameters.Add("@status", SqlDbType.NVarChar, 50).Value = status ?? string.Empty;
                conn.Open();
                return cmd.ExecuteNonQuery() > 0; // returns true if at least one row was updated
            }
        }
        // Execute query and return DataTable
        private DataTable ExecuteQuery(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException("Query is null or empty", nameof(query));

            var dt = new DataTable();
            using (var connection = new SqlConnection(_connectionString))
            using (var adapter = new SqlDataAdapter(query, connection))
            {
                adapter.Fill(dt);
            }

            return dt;
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

        // Generic binder for ComboBox/ListBox (any ListControl)
        public void BindListControl(ListControl control, string displayMember, string valueMember, string query)
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));

            try
            {
                var dt = ExecuteQuery(query);
                control.DataSource = null;
                control.DisplayMember = displayMember;
                control.ValueMember = valueMember;
                control.DataSource = dt;
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
                txtDepartmentId.Text = row.Cells["Id"].Value?.ToString();

                    // Departments query exposes column "Id".
                    // Use the existing "Id" column to set the selected value.
                    var deptVal = row.Cells["Id"].Value;
                    if (deptVal != null && ListDepartmentName.DataSource != null)
                    {
                        try { ListDepartmentName.SelectedValue = deptVal; } catch { /* ignore if not present */ }
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
            // Create new employee from input fields
            var name = txtEmployeeName.Text?.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Employee name is required.");
                return;
            }

            DateTime dob;
            if(dtpDayOfBirth.Value > DateTime.Now)
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

            var idCell = dataGridView1.CurrentRow.Cells["Id"];
            var nameCell = dataGridView1.CurrentRow.Cells["EmployeeName"];
            if (idCell == null || idCell.Value == null)
            {
                MessageBox.Show("Selected row has no Id.");
                return;
            }

            int id;
            if (!int.TryParse(idCell.Value.ToString(), out id))
            {
                MessageBox.Show("Invalid Id value."); 
                return;
            }

            var nameText = nameCell?.Value?.ToString() ?? string.Empty;
            var confirm = MessageBox.Show($"Delete employee Id={id}, Name={nameText}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                DeleteEmployee(id);
                // refresh grid
                LoadData(_loadDataQuery);
                MessageBox.Show("Employee deleted.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting employee: {ex.Message}");
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            //validate 
            var idCell = dataGridView1.CurrentRow?.Cells["Id"];
            if (idCell == null || idCell.Value == null)
            {
                MessageBox.Show("Selected row has no Id.");
                return;
            }
            int id;
            try
            {
                id = Convert.ToInt32(idCell.Value);
            }
            catch
            {
                MessageBox.Show("Invalid Id.");
                return;
            }
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
                UpdateEmployee(id,name, dob, departmentId, status);
                // reload grid
                LoadData(_loadDataQuery);
                MessageBox.Show("Employee updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating employee: {ex.Message}");
            }

        }

        

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
            // disable employee inputs
            txtEmployeeName.Enabled = false;
            dtpDayOfBirth.Enabled = false;
            ListDepartmentName.Enabled = true;
            ListStatus.Enabled = false;
            btn_Create.Enabled = false;
            btn_Update.Enabled = false;
            btn_Delete.Enabled = false;
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
