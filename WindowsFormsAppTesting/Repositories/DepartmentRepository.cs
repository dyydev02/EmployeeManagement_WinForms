using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Configuration;

namespace WindowsFormsAppTesting.Repositories
{
    public class DepartmentRepository
    {
        private readonly string _connectionString;

        public DepartmentRepository()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public DepartmentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable GetAll()
        {
            var dt = new DataTable();
            using (var conn = new SqlConnection(_connectionString))
            using (var da = new SqlDataAdapter("SELECT Id, DepartmentName FROM Departments", conn))
            {
                da.Fill(dt);
            }
            return dt;
        }

        // Async versions
        public Task<DataTable> GetAllAsync()
        {
            return Task.Run(() => GetAll());
        }

        public Task<int> InsertAsync(string departmentName)
        {
            return Task.Run(() => Insert(departmentName));
        }

        public Task<bool> UpdateAsync(int id, string departmentName)
        {
            return Task.Run(() => Update(id, departmentName));
        }

        public Task<bool> DeleteAsync(int id)
        {
            return Task.Run(() => Delete(id));
        }

        public int Insert(string departmentName)
        {
            var query = "INSERT INTO Departments (DepartmentName) VALUES (@name); SELECT SCOPE_IDENTITY();";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 200).Value = departmentName ?? string.Empty;
                conn.Open();
                var id = cmd.ExecuteScalar();
                if (id == null || id == DBNull.Value)
                    return 0;
                try { return Convert.ToInt32(id); }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Failed to convert inserted Id to int.", ex);
                }
            }
        }

        public bool Update(int id, string departmentName)
        {
            var query = "UPDATE Departments SET DepartmentName = @name WHERE Id = @id";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 200).Value = departmentName ?? string.Empty;
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int id)
        {
            var query = "DELETE FROM Departments WHERE Id = @id";
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
