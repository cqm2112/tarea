using ConsoleApplication5.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Data;

namespace ConsoleApplication5.Services
{
    class PaysService
    {
        public static void Insert(Pays pays)
        {
            var props = pays.GetType().GetProperties().Where(u => u.Name != "Id");
            var args = String.Join(",", Enumerable.Repeat("?", props.Count()).ToArray());
            var query = $"INSERT INTO pays ({String.Join(",", props.Select(u => u.Name).ToArray())}) VALUES ({args})";
            using (var ctx = DbContext.GetInstance())
            using (var command = new SQLiteCommand(query, ctx))
            {
                foreach (var prop in props)
                {
                    command.Parameters.Add(new SQLiteParameter(prop.Name, prop.GetValue(pays, null)));
                }
                command.ExecuteNonQuery();
            }
        }

        public static DataTable GetDataTable()
        {
            var dataTable = new DataTable();
            using (var ctx = DbContext.GetInstance())
            using (var command = new SQLiteCommand("SELECT * FROM Pays", ctx))
            using (var reader = command.ExecuteReader())
            {
                dataTable.Load(reader);
            }
            return dataTable;
        }
    }
}
