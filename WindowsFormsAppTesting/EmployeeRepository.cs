using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace WindowsFormsAppTesting
{
    internal class EmployeeRepository
    {
        private readonly DataAccess _db;
        private const string LoadQuery = "select e.Id, e.EmployeeName, e.DayOfBirth, e.DepartmentId, p.DepartmentName, e.Status from Employees e join Departments p on e.DepartmentId = p.Id";

        public EmployeeRepository(DataAccess db)
        {
            _db = db;
        }

        public DataTable GetAll()
        {
            return _db.Query(LoadQuery);
        }

        public void Create(string name, DateTime dob, int departmentId, string status)
        {
            var sql = "INSERT INTO Employees (EmployeeName, DayOfBirth, DepartmentId, Status) VALUES (@name, @dob, @deptId, @status)";
            var parameters = new[]
            {
                new SqlParameter("@name", SqlDbType.NVarChar, 200) { Value = name ?? string.Empty },
                new SqlParameter("@dob", SqlDbType.Date) { Value = dob.Date },
                new SqlParameter("@deptId", SqlDbType.Int) { Value = departmentId },
                new SqlParameter("@status", SqlDbType.NVarChar, 50) { Value = status ?? string.Empty }
            };

            var rows = _db.Execute(sql, parameters);
            if (rows <= 0)
                throw new Exception("Insert failed, no rows affected.");
        }

        public bool Update(int id, string name, DateTime dob, int departmentId, string status)
        {
            var sql = "UPDATE Employees SET EmployeeName = @name, DayOfBirth = @dob, DepartmentId = @deptId, Status = @status WHERE Id = @id";
            var parameters = new[]
            {
                new SqlParameter("@id", SqlDbType.Int) { Value = id },
                new SqlParameter("@name", SqlDbType.NVarChar, 200) { Value = name ?? string.Empty },
                new SqlParameter("@dob", SqlDbType.Date) { Value = dob.Date },
                new SqlParameter("@deptId", SqlDbType.Int) { Value = departmentId },
                new SqlParameter("@status", SqlDbType.NVarChar, 50) { Value = status ?? string.Empty }
            };

            return _db.Execute(sql, parameters) > 0;
        }

        public bool Delete(int id)
        {
            var sql = "DELETE FROM Employees WHERE Id = @id";
            var parameters = new[] { new SqlParameter("@id", SqlDbType.Int) { Value = id } };
            return _db.Execute(sql, parameters) > 0;
        }
        // Get list of employees by department id
        public DataTable GetByDepartmentId(int departmentId)
        {
            var sql = LoadQuery + " WHERE e.DepartmentId = @deptId";
            var parameters = new[] { new SqlParameter("@deptId", SqlDbType.Int) { Value = departmentId } };
            return _db.Query(sql, parameters);
        }
    }
}
