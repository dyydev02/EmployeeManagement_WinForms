using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppTesting
{
    public partial class DepartmentDetail : Form
    {
        private readonly int _departmentId;
        private readonly DepartmentRepository _departmentRepo;

        internal DepartmentDetail(int departmentId, string departmentName, DepartmentRepository departmentRepo)
        {
            _departmentId = departmentId;
            _departmentRepo = departmentRepo;
            InitializeComponent();
            // populate fields
            txtDepartmentId.Text = departmentId > 0 ? departmentId.ToString() : string.Empty;
            if (_departmentRepo != null)
            {
                LoadDepartments(departmentId);
                try { if (!string.IsNullOrWhiteSpace(departmentName)) cbListDepartment.Text = departmentName; } catch { }
            }
        }

        public DepartmentDetail()
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
                    try { cbListDepartment.SelectedValue = selectedId; } catch { }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading departments: {ex.Message}");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtDepartmentId.Text = string.Empty;
            if (cbListDepartment.Items.Count > 0) cbListDepartment.SelectedIndex = 0;
        }

        private void DepartmentDetail_Load(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click_1(object sender, EventArgs e)
        {
            var name = cbListDepartment.Text?.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Department name is required.");
                return;
            }

            try
            {
                if (_departmentId <= 0)
                {
                    _departmentRepo.Create(name);
                    MessageBox.Show("Department created.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    var updated = _departmentRepo.Update(_departmentId, name);
                    if (updated)
                    {
                        MessageBox.Show("Department updated.");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No department was updated.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving department: {ex.Message}");
            }
        }

        private void btn_Delete_Click_1(object sender, EventArgs e)
        {
            if (_departmentId <= 0)
            {
                MessageBox.Show("No department selected to delete.");
                return;
            }

            var confirm = MessageBox.Show($"Delete department Id={_departmentId}, Name={cbListDepartment.Text}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                var deleted = _departmentRepo.Delete(_departmentId);
                if (deleted)
                {
                    MessageBox.Show("Department deleted.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No department was deleted.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting department: {ex.Message}");
            }
        }
    }
}
