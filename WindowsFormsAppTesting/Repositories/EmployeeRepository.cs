using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Configuration;
using WindowsFormsAppTesting.Models;

namespace WindowsFormsAppTesting.Repositories
{
    public class EmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        // Async versions
        public Task<DataTable> GetAllAsync()
        {
            return Task.Run(() => GetAll());
        }

        public Task<int> InsertAsync(Employee e)
        {
            return Task.Run(() => Insert(e));
        }

        public Task<bool> UpdateAsync(Employee e)
        {
            return Task.Run(() => Update(e));
        }

        public Task<bool> DeleteAsync(int id)
        {
            return Task.Run(() => Delete(id));
        }

        public EmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable GetAll()
        {
            var dt = new DataTable();
            using (var conn = new SqlConnection(_connectionString))
            using (var da = new SqlDataAdapter("select e.Id, e.EmployeeName, e.DayOfBirth, e.DepartmentId, p.DepartmentName, e.Status from Employees e join Departments p on e.DepartmentId = p.Id", conn))
            {
                da.Fill(dt);
            }
            return dt;
        }

        public int Insert(Employee e)
        {
            var query = "INSERT INTO Employees (EmployeeName, DayOfBirth, DepartmentId, Status) VALUES (@name, @dob, @deptId, @status); SELECT SCOPE_IDENTITY();";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 200).Value = e.EmployeeName ?? string.Empty;
                cmd.Parameters.Add("@dob", SqlDbType.Date).Value = e.DayOfBirth.Date;
                cmd.Parameters.Add("@deptId", SqlDbType.Int).Value = e.DepartmentId;
                cmd.Parameters.Add("@status", SqlDbType.NVarChar, 50).Value = e.Status ?? string.Empty;
                conn.Open();
                var id = cmd.ExecuteScalar();
                return Convert.ToInt32(id);
            }
        }

        public bool Update(Employee e)
        {
            var query = "UPDATE Employees SET EmployeeName = @name, DayOfBirth = @dob, DepartmentId = @deptId, Status = @status WHERE Id = @id";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = e.Id;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 200).Value = e.EmployeeName ?? string.Empty;
                cmd.Parameters.Add("@dob", SqlDbType.Date).Value = e.DayOfBirth.Date;
                cmd.Parameters.Add("@deptId", SqlDbType.Int).Value = e.DepartmentId;
                cmd.Parameters.Add("@status", SqlDbType.NVarChar, 50).Value = e.Status ?? string.Empty;
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int id)
        {
            var query = "DELETE FROM Employees WHERE Id = @id";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
