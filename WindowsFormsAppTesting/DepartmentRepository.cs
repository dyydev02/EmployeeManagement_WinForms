using System;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsAppTesting
{
    internal class DepartmentRepository
    {
        private readonly DataAccess _db;

        public DepartmentRepository(DataAccess db)
        {
            _db = db;
        }

        public DataTable GetAll()
        {
            return _db.Query("Departments", new[] { "Id", "DepartmentName" });
        }

        public void Create(string name)
        {
            _db.Execute("INSERT INTO Departments(DepartmentName) VALUES(@n)",
                new SqlParameter("@n", name));
        }

        public bool Update(int id, string name)
        {
            return _db.Execute("UPDATE Departments SET DepartmentName=@n WHERE Id=@id",
                new SqlParameter("@n", name),
                new SqlParameter("@id", id)) > 0;
        }

        public bool Delete(int id)
        {
            return _db.Execute("DELETE FROM Departments WHERE Id=@id",
                new SqlParameter("@id", id)) > 0;
        }
    }
}
