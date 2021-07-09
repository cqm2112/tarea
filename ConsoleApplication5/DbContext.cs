using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    public class DbContext
    {
        private const string DBName = "HHRRSystem";
        private const string SQLScript = @"..\..\Util\db.sql";

        public static void Up()
        {
            bool isDbRecentlyCreated = false;
            if (!File.Exists(Path.GetFullPath(DBName)))
            {
                isDbRecentlyCreated = true;
                SQLiteConnection.CreateFile(DBName);
            }
            using (var ctx = GetInstance())
            {
                if (isDbRecentlyCreated)
                {
                    using (var reader = new StreamReader(Path.GetFullPath(SQLScript)))
                    {
                        var query = "";
                        var line = "";
                        while ((line = reader.ReadLine()) != null)
                        {
                            query += line;
                        }

                        using (var command = new SQLiteCommand(query, ctx))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public static SQLiteConnection GetInstance()
        {
            var db = new SQLiteConnection(string.Format("Data Source={0};Version=3;", DBName));
            db.Open();
            return db;
        }
    }
}
