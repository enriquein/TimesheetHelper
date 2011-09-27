using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Data.SQLite;

namespace TimesheetHelper.Data
{
    public class DbAccess
    {
        private static string _connectionString = @"Data Source=db\helper.sq3; Version=3;";

        public static void SaveEvent(EventInfo eventInfo)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                var query = @"  insert into EventInfo(WindowTitle, EventType)
                                values (@title, @type);"; 
                conn.Open();

                conn.Execute(query, new { title = eventInfo.WindowTitle, type = eventInfo.EventType }, null, null, null);
            }
        }
    }
}
