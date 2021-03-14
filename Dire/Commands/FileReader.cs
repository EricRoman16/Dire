using System;
using System.IO;

namespace Dire
{
    //This class handles all things to do with files
    class FileReader
    {
        public const string SavedDataPath = @".\SavedData.txt";
        

        private static void Create()
        {
            
            
            
        }

        public static void Write(string dataToWrite)
        {
            try
            {
                File.AppendAllText(SavedDataPath, dataToWrite);
                Console.WriteLine("Player data saved!");
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
        }

        public static void Read()
        {
            try
            {
                string[] playerFile = File.ReadAllLines(SavedDataPath);
                Console.WriteLine("Restoring data from {0}", playerFile[1]);
            }
            catch (Exception error)
            {
                Console.WriteLine("Could not recover player data.");
                Console.WriteLine(error.Message);

            }
        }
    }
}
