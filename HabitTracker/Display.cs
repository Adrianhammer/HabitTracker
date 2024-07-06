using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker
{
    internal class Display
    {
        public static void GetAllRecords()
        {
            Console.WriteLine("Here is all the records from the water drinking table");
            Console.WriteLine("----------------------------------------\n");
            using (var connection = new SqliteConnection(Program.connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = $"SELECT * FROM drinking_water";

                SqliteDataReader reader = tableCmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["ID"]}, Date:{reader["Date"]}, Quantity:{reader["Quantity"]}");
                }

                connection.Close();
            }
        }
    }
}
