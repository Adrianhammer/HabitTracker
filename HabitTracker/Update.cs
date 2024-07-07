using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker
{
    internal class Update
    {
        public static void UpdateRecord()
        {
            Console.WriteLine("Please type the ID of the record you want to update or press 0 to return to the main menu");
            Console.WriteLine("----------------------------------------\n");

            string userInput = Console.ReadLine();
            string updateDate;
            int updateQuantity;


            if (int.TryParse(userInput, out int inputId))
            {
                Console.WriteLine("Please write the date which you want to update (Format: dd-mm-yy");
                updateDate = Console.ReadLine();

                //Dumb way of checking if user inputs a string for the date
                if (!int.TryParse(updateDate, out int parsedDate))
                {
                    Console.WriteLine("Please update the quantity of glasses");

                    if (int.TryParse(Console.ReadLine(), out updateQuantity))
                    {
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid quantity");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Please write the date in correct format");
                    return;
                }
            }
            else if (userInput == "0")
            {
                //Returns to main menu
                Program.GetUserInput();
                return;
            }
            else
            {
                Console.WriteLine("Please input the correct format");
                UpdateRecord();
                return;
            }

            using (var connection = new SqliteConnection(Program.connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = $"UPDATE drinking_water SET Date = '{updateDate}', Quantity = {updateQuantity} WHERE ID = {inputId}";

                try
                {
                    tableCmd.ExecuteNonQuery();
                    Console.WriteLine("Record updated successfully");

                }
                catch (Exception e)
                {
                    Console.WriteLine("Something went wrong. Return to the main menu or try again");
                    Console.WriteLine(e.Message);
                    throw;
                }
            }

        }
    }
}
