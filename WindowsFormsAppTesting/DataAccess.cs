using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace WindowsFormsAppTesting
{
    internal class DataAccess
    {
        private readonly string _connectionString;

        public DataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable Query(string sql, params SqlParameter[] parameters)
        {
            if (string.IsNullOrWhiteSpace(sql))
                throw new ArgumentException("sql is null or empty", nameof(sql));

            var dt = new DataTable();
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                adapter.Fill(dt);
            }

            return dt;
        }

        public int Execute(string sql, params SqlParameter[] parameters)
        {
            if (string.IsNullOrWhiteSpace(sql))
                throw new ArgumentException("sql is null or empty", nameof(sql));

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Build a parameterized SELECT statement from components.

        public (string Sql, SqlParameter[] Parameters) BuildSelectAdvanced(
            string fromClause,
            IEnumerable<string> columns = null,
            List<Filter> filters = null,
            string orderBy = null,
            int? top = null)
        {
            if (string.IsNullOrWhiteSpace(fromClause))
                throw new ArgumentException("fromClause is null or empty", nameof(fromClause));

            var cols = (columns != null && columns.Any())
                ? string.Join(", ", columns)
                : "*";

            var sql = new System.Text.StringBuilder();

            sql.Append(top.HasValue
                ? $"SELECT TOP({top.Value}) {cols} FROM {fromClause}"
                : $"SELECT {cols} FROM {fromClause}");

            var parameters = new List<SqlParameter>();

            // WHERE
            if (filters != null && filters.Count > 0)
            {
                sql.Append(" WHERE ");
                var parts = new List<string>();

                int i = 0;
                foreach (var f in filters)
                {
                    string paramName = "@p" + i;

                    switch (f.Operator.ToUpper())
                    {
                        case "IS NULL":
                        case "IS NOT NULL":
                            parts.Add($"{f.Column} {f.Operator}");
                            break;

                        case "IN":
                            var values = (IEnumerable<object>)f.Value;
                            var inParams = new List<string>();

                            foreach (var val in values)
                            {
                                var pName = "@p" + i++;
                                inParams.Add(pName);
                                parameters.Add(new SqlParameter(pName, val));
                            }

                            parts.Add($"{f.Column} IN ({string.Join(", ", inParams)})");
                            i--; // tránh tăng dư
                            break;

                        case "BETWEEN":
                            var range = (object[])f.Value;
                            var p1 = "@p" + i++;
                            var p2 = "@p" + i;

                            parameters.Add(new SqlParameter(p1, range[0]));
                            parameters.Add(new SqlParameter(p2, range[1]));

                            parts.Add($"{f.Column} BETWEEN {p1} AND {p2}");
                            break;

                        default:
                            parts.Add($"{f.Column} {f.Operator} {paramName}");
                            parameters.Add(new SqlParameter(paramName, f.Value));
                            break;
                    }

                    i++;
                }

               for (int j = 0; j < parts.Count; j++)
{
    if (j == 0)
    {
        sql.Append(parts[j]);
    }
    else
    {
        var logic = filters[j].Logic?.ToUpper() == "OR" ? "OR" : "AND";
        sql.Append($" {logic} {parts[j]}");
    }
}
            }

            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                sql.Append(" ORDER BY ");
                sql.Append(orderBy);
            }

            return (sql.ToString(), parameters.ToArray());
        }

        // Convenience overload to run a SELECT built from components.
        public DataTable Query(
                  string fromClause,
                  IEnumerable<string> columns = null,
                  List<Filter> filters = null,
                  string orderBy = null,
                  int? top = null)
        {
            var built = BuildSelectAdvanced(fromClause, columns, filters, orderBy, top);
            return Query(built.Sql, built.Parameters);
        }


    }
}
