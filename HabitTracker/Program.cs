using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic.FileIO;
using System;

namespace HabitTracker;
class Program
{
    static void Main(string[] args)
    {
        string connectionString = @"Data Source=HabitTracker.db";
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();

            tableCmd.CommandText =
                @"CREATE TABLE IF NOT EXISTS drinking_water (ID INTEGER PRIMARY KEY AUTOINCREMENT, Date TEXT, Quantity INTEGER)";

            tableCmd.ExecuteNonQuery();

            connection.Close();
        }
    }

    static void GetUserInput()
    {
        Console.Clear();
        bool closeApp = false;
        while (closeApp == false)
        {
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
                    break;
                //case "1":
                //    GetAllRecords();
                //    break;
                case "2":
                    InsertRecord();
                    break;
                //case "3":
                //    DeleteRecord();
                //    break;
                //case "4":
                //    UpdateRecord();
                //    break;
                //default:
                //    Console.WriteLine("\nInvalid Command. Please type a number from 0 to 4");
                //    break;
            }
        }
    }

    private static void InsertRecord()
    {
        string date = GetDateInput();

        int quantity = GetNumberInput("\n\nPlease insert number of glasses or other measure of your choice (no decimals allowed)\n\n");

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();

            tableCmd.CommandText = $"INSERT INTO drinking_water(date, quantity) VALUES('{date}', {quantity})";

        }
    }

    internal static string GetDateInput()
    {
        Console.WriteLine("\n\nPlease insert the date: (Format: dd-mm-yy). Type 0 to return to main menu.");

        string dateInput = Console.ReadLine();

        if (dateInput == "0") GetUserInput();

        return dateInput;
    }

    internal static int GetNumberInput(string message)
    {
        Console.WriteLine(message);

        int numberInput = Convert.ToInt32(Console.ReadLine);

        return numberInput;
    }
}