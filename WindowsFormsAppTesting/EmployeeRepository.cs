using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace WindowsFormsAppTesting
{
   
    internal class EmployeeRepository
    {
        private readonly DataAccess _db;

        public EmployeeRepository(DataAccess db)
        {
            _db = db;
        }

        public DataTable GetAll()
        {
            return _db.Query(
                "Employees e JOIN Departments p ON e.DepartmentId = p.Id",
                new[]
                {
                "e.Id",
                "e.EmployeeName",
                "e.DayOfBirth",
                "e.DepartmentId",
                "p.DepartmentName",
                "e.Status"
                }
            );
        }

        public bool Create(string name, DateTime dob, int deptId, string status)
        {
            var sql = "INSERT INTO Employees(EmployeeName, DayOfBirth, DepartmentId, Status) VALUES (@n,@d,@dep,@s)";
           var rows = _db.Execute(sql,
                new SqlParameter("@n", name),
                new SqlParameter("@d", dob),
                new SqlParameter("@dep", deptId),
                new SqlParameter("@s", status));
           
            return rows > 0;
        }

        public bool Delete(int id)
        {
            return _db.Execute("DELETE FROM Employees WHERE Id=@id",
                new SqlParameter("@id", id)) > 0;
        }

        public bool Update(int id, string name, DateTime dob, int deptId, string status)
        {
            return _db.Execute(
                "UPDATE Employees SET EmployeeName=@n, DayOfBirth=@d, DepartmentId=@dep, Status=@s WHERE Id=@id",
                new SqlParameter("@n", name),
                new SqlParameter("@d", dob),
                new SqlParameter("@dep", deptId),
                new SqlParameter("@s", status),
                new SqlParameter("@id", id)
            ) > 0;
        }

        public DataTable GetByDepartmentId(int deptId)
        {
           return _db.Query(
                "Employees e JOIN Departments p ON e.DepartmentId = p.Id",
                new[]
                {
                "e.Id",
                "e.EmployeeName",
                "e.DayOfBirth",
                "e.DepartmentId",
                "p.DepartmentName",
                "e.Status"
                },
                new List<Filter>
                {
                    new Filter
                    {
                        Column = "e.DepartmentId",
                        Operator = "=",
                        Value = deptId,
                    }
                }
            );
        }
    }
}
