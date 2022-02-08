using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dire
{
    class NavigationController
    {
        static string[] options = new string[5] { "Look", "Move", "Inventory", "Equiped", "Exit"};
        static int selected = 0;
        
        public static void draw()
        {
            Console.WriteLine();
            string write = "";
            for(int i = 0; i < options.Length; i++)
            {
                write += options[i];
                if (selected == i) write += " <";
                write += "\n";
            }
            TextWriter.WriteLine(write);
        }
        public static void ReadKeyPresses()
        {
            while (true)
            {
                Console.WriteLine("press down arrow keys!");
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.H)
                    return;//watch
                else
                    Console.WriteLine(key + " is not a command.");
            }
        }
    }
}
