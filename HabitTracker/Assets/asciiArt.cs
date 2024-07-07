using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker.Assets
{
    internal class AsciiArt
    {
        public static readonly string filepath = "C:\\study\\code\\HabitTracker\\HabitTracker\\Assets\\luffy.txt";
        
        public static void PrintAscii()
        {
            Console.OutputEncoding = Encoding.UTF8;

            if (File.Exists(filepath))
            {
                try
                {
                    string[] asciiArtLines = File.ReadAllLines(filepath);
                    foreach (var line in asciiArtLines)
                    {
                        Console.WriteLine(line);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occured while reading the file:\n {ex.Message}");
                    throw; 
                }
            } 
            else
            {
                Console.WriteLine("The luffy.txt file can't be reached");
            }
        }

    }
}
