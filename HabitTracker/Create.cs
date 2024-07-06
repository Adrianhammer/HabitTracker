using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker
{
    internal class Create
    {
        public static void InsertRecord()
        {
            string date = GetDateInput();

            int quantity = GetNumberInput();

            using (var connection = new SqliteConnection(Program.connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = $"INSERT INTO drinking_water(date, quantity) VALUES('{date}', {quantity})";

                tableCmd.ExecuteNonQuery();
                connection.Close();

            }
        }

        private static string GetDateInput()
        {
            Console.WriteLine("\n\nPlease insert the date: (Format: dd-mm-yy). Type 0 to return to main menu.");

            string dateInput = Console.ReadLine();

            //Return user to main menu
            if (dateInput == "0") Program.GetUserInput();

            return dateInput;
        }

        private static int GetNumberInput()
        {
            Console.WriteLine("\n\nPlease insert number of glasses or other measure of your choice (no decimals allowed)\n\n");

            //The user writes the number of glasses. Casts the user input, String, to an Integer
            int numberInput = Convert.ToInt32(Console.ReadLine());


            return numberInput;
        }
    }
}
