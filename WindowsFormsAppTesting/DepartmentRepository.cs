using System;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsAppTesting
{
    internal class DepartmentRepository
    {
        private readonly DataAccess _db;
        private const string LoadQuery = "SELECT Id, DepartmentName FROM Departments";

        public DepartmentRepository(DataAccess db)
        {
            _db = db;
        }

        public DataTable GetAll()
        {
            return _db.Query(LoadQuery);
        }

        public void Create(string name)
        {
            var sql = "INSERT INTO Departments (DepartmentName) VALUES (@name)";
            var parameters = new[] { new SqlParameter("@name", SqlDbType.NVarChar, 200) { Value = name ?? string.Empty } };
            var rows = _db.Execute(sql, parameters);
            if (rows <= 0)
                throw new Exception("Insert department failed, no rows affected.");
        }

        public bool Update(int id, string name)
        {
            var sql = "UPDATE Departments SET DepartmentName = @name WHERE Id = @id";
            var parameters = new[]
            {
                new SqlParameter("@id", SqlDbType.Int) { Value = id },
                new SqlParameter("@name", SqlDbType.NVarChar, 200) { Value = name ?? string.Empty }
            };
            return _db.Execute(sql, parameters) > 0;
        }

        public bool Delete(int id)
        {
            var sql = "DELETE FROM Departments WHERE Id = @id";
            var parameters = new[] { new SqlParameter("@id", SqlDbType.Int) { Value = id } };
            return _db.Execute(sql, parameters) > 0;
        }

        public DataTable GetById(int id)
        {
            var sql = LoadQuery + " WHERE Id = @id";
            var parameters = new[] { new SqlParameter("@id", SqlDbType.Int) { Value = id } };
            return _db.Query(sql, parameters);
        }

    }
}
