using ConsoleApplication5.Models;
using ConsoleApplication5.Modules.HHRR;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace ConsoleApplication5.Services
{
    static class EmployeeService
    {

        public static Employee CaptureEmployeeCardId()
        {
            int cardId = Forms.CaptureWithParse<int>("Introduzca la cedula del empleado: ");
            return GetByCardId(cardId);
        }

        public static void ShowEmployeeData(Employee employee)
        {
            Console.WriteLine();
            Console.WriteLine("Nombre empleado:" + employee.Name);
            Console.WriteLine("Departamento empleado:" + employee.Department);
            Console.WriteLine("Cargo empleado:" + employee.Role);
            Console.WriteLine("Salario empleado:" + employee.Salary);
            Console.WriteLine();
        }

        public static Employee GetByCardId(int cardId){
            var sql = $"SELECT * FROM Employees WHERE CardId = {cardId}";
            return FromRawSql(sql).FirstOrDefault();
        }

        public static IEnumerable<Employee> GetAll()
        {
            return FromRawSql("SELECT * FROM Employees");
        }

        private static string ParseDateFromString(string dateStr)
        {
            DateTime? result = null;
            DateTime date;
            bool ok = DateTime.TryParse(dateStr, out date);
            if (ok) result = date;
            return ok ? result.Value.ToString("yyyy-MM-dd") : null;
        }

        private static short? ParseShortFromString(string dateStr)
        {
            short? result = null;
            short number;
            bool ok = Int16.TryParse(dateStr, out number);
            if (ok) result = number;
            return result;
        }

        private static IEnumerable<Employee> FromRawSql(string sql)
        {
            var result = new List<Employee>();
            using (var ctx = DbContext.GetInstance())
            using (var command = new SQLiteCommand(sql, ctx))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var employee = new Employee
                    {
                        Id = Convert.ToInt32(reader["id"].ToString()),
                        Name = reader["Name"].ToString(),
                        CardId = Convert.ToInt32(reader["CardId"].ToString()),
                        Department = reader["Department"].ToString(),
                        Role = reader["Role"].ToString(),
                        Salary = Convert.ToInt32(reader["Salary"].ToString()),
                        IsInVacation = ParseShortFromString(reader["IsInVacation"].ToString()),
                        DateVacationStart = ParseDateFromString(reader["DateVacationStart"].ToString()),
                        DateVacationEnd = ParseDateFromString(reader["DateVacationEnd"].ToString()),
                        Permission = ParseDateFromString(reader["Permission"].ToString()),
                        PerReason = reader["PerReason"].ToString()
                    };
                    result.Add(employee);
                }
            }
            return result;
        }

        public static void Insert(Employee employee)
        {
            var props = employee.GetType().GetProperties().Where(u => u.Name != "Id");
            var args = String.Join(",", Enumerable.Repeat("?", props.Count()).ToArray());
            var query = $"INSERT INTO Employees ({String.Join(",", props.Select(u => u.Name).ToArray())}) VALUES ({args})";
            using (var ctx = DbContext.GetInstance())
            using (var command = new SQLiteCommand(query, ctx))
            {
                foreach(var prop in props)
                {
                    command.Parameters.Add(new SQLiteParameter(prop.Name, prop.GetValue(employee, null)));
                }
                command.ExecuteNonQuery();
            }
        }

        public static void Update(Employee employee)
        {
            var props = employee.GetType().GetProperties().Where(u => u.Name != "Id");
            var quotableTypes = new string[] { "string", "datetime" };
            string localSqlProp(string propFullName, object val) =>
                val == null
                ? "null"
                : quotableTypes.Any(u => propFullName.ToLower().Contains(u))
                ? $"'{val}'"
                : val.ToString();
            var query = $@"UPDATE Employees
                    SET {String.Join(",", props.Select(u => $"{u.Name} = {localSqlProp(u.PropertyType.FullName, u.GetValue(employee, null))}").ToArray())}
                    WHERE Id = {employee.Id}";
            using (var ctx = DbContext.GetInstance())
            using (var command = new SQLiteCommand(query, ctx))
            {
                command.ExecuteNonQuery();
            }
        }

        public static void Delete(int id)
        {
            string query = $"DELETE FROM Employees where id = {id}";
            using (var ctx = DbContext.GetInstance())
            using (var command = new SQLiteCommand(query, ctx))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
