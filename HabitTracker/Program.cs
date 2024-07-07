using HabitTracker.Assets;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Text;

namespace HabitTracker;
class Program
{
    internal static string connectionString = @"Data Source=HabitTracker.db";

    static void Main(string[] args)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();

            tableCmd.CommandText =
                @"CREATE TABLE IF NOT EXISTS drinking_water (ID INTEGER PRIMARY KEY AUTOINCREMENT, Date TEXT, Quantity INTEGER)";

            tableCmd.ExecuteNonQuery();

            connection.Close();
        }

        GetUserInput();
    }

    internal static void GetUserInput()
    {

        Console.Clear();
        bool closeApp = false;
        while (closeApp == false)
        {
            AsciiArt.PrintAscii();
            Console.WriteLine("\n\nMAIN MENU");
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("\nType 0 to close the application");
            Console.WriteLine("Type 1 to view all record");
            Console.WriteLine("Type 2 to insert record");
            Console.WriteLine("Type 3 to delete record");
            Console.WriteLine("Type 4 to update record");
            Console.WriteLine("----------------------------------------\n");

            string commandInput = Console.ReadLine();

            switch (commandInput)
            {
                case "0":
                    Console.WriteLine("\nGood bye!\n");
                    closeApp = true;
                    break;
                case "1":
                    Display.GetAllRecords();
                    break;
                case "2":
                    Create.InsertRecord();
                    break;
                case "3":
                    Delete.DeleteRecord();
                    break;
                case "4":
                    Update.UpdateRecord();
                    break;
                default:
                    Console.WriteLine("\nInvalid Command. Please type a number from 0 to 4");
                    break;
            }
        }
    }


}