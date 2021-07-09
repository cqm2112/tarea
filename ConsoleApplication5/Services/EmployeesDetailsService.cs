using ConsoleApplication5.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5.Services
{
    class EmployeesDetailsService
    {
        public static void Insert(EmployeeDetails details)
        {
            var props = details.GetType().GetProperties().Where(u => u.Name != "Id");
            var args = String.Join(",", Enumerable.Repeat("?", props.Count()).ToArray());
            var query = $"INSERT INTO employeesDetails ({String.Join(",", props.Select(u => u.Name).ToArray())}) VALUES ({args})";
            using (var ctx = DbContext.GetInstance())
            using (var command = new SQLiteCommand(query, ctx))
            {
                foreach (var prop in props)
                {
                    command.Parameters.Add(new SQLiteParameter(prop.Name, prop.GetValue(details, null)));
                }
                command.ExecuteNonQuery();
            }
        }

        public static int GetIncentives(int employeeCardId)
        {
            var query = $"SELECT * FROM EmployeesDetails WHERE EmployeeCardId = {employeeCardId} AND ActionType = 'I'";
            return FromRawSql(query).Sum(u => u.Value);
        }

        public static int GetDiscounts(int employeeCardId)
        {
            var query = $"SELECT * FROM EmployeesDetails WHERE EmployeeCardId = {employeeCardId} AND ActionType = 'D'";
            return FromRawSql(query).Sum(u => u.Value);
        }

        private static IEnumerable<EmployeeDetails> FromRawSql(string sql)
        {
            var result = new List<EmployeeDetails>();
            using (var ctx = DbContext.GetInstance())
            using (var command = new SQLiteCommand(sql, ctx))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var employeeDetails = new EmployeeDetails
                    {
                        Id = Convert.ToInt32(reader["id"].ToString()),
                        EmployeeCardId = Convert.ToInt32(reader["EmployeeCardId"].ToString()),
                        ActionType = reader["ActionType"].ToString(),
                        Concept = reader["Concept"].ToString(),
                        Value = Convert.ToInt32(reader["Value"].ToString()),
                    };
                    result.Add(employeeDetails);
                }
            }
            return result;
        }
    }
}
