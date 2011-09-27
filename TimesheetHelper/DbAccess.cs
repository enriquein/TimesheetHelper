using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Data.SQLite;

namespace TimesheetHelper
{
    public class DbAccess
    {
        private static string _connectionString = "Data Source =filename; Version =3;";

        public static void SaveEvent(EventInfo eventInfo)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                var query = @"  insert into EventInfo(WindowTitle, EventDate, EventType)
                                values (@title, @date, @type);"; 
                conn.Open();

                conn.Execute(query, new { title = eventInfo.WindowTitle, date = eventInfo.EventDate, type = eventInfo.EventType });
            }
        }
    }
}
