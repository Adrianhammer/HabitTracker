using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker
{
    internal class Delete
    {
        public static void DeleteRecord()
        {
            Console.WriteLine("Which record do you want to delete? Please type in the ID of the record or press 0 to return to the main menu");
            Console.WriteLine("----------------------------------------\n");

            string userInput = Console.ReadLine();

            if (!int.TryParse(userInput, out int recordID))
            {
                Console.WriteLine("Please input a number");
                DeleteRecord();
            }
            else if (userInput == "0")
            {
                Program.GetUserInput();
            }
            

            using (var connection = new SqliteConnection(Program.connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = $"DELETE FROM drinking_water WHERE ID = {userInput}";

                try
                {
                    tableCmd.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    Console.WriteLine("Something went wrong. Return to the main menu or try again");
                    Console.WriteLine(e.Message);
                    throw;
                }

                //check if ID still exists in table
                //If id still exists, something went wrong
                //If not return success message

                tableCmd.CommandText = $"SELECT EXISTS (SELECT 1 FROM drinking_water WHERE ID = {userInput})";
                var result = (long)tableCmd.ExecuteScalar();


                if (result == 0)
                {
                    Console.WriteLine("Record deleted succesfully");
                }
                else
                {
                    Console.WriteLine("Something went wrong. The record still exists");
                }

                connection.Close();
            }
        }
    }
}
