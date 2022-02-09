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
            // this will have a previous write and a normal write
            // it will create an array and look at the previous write 
            // and only change based on the differences
            Console.Clear(); // take this off later --------------- [Look]
            Console.WriteLine();
            int startLeft = 0;
            int startTop = 0;
            string tmp;
            int longest = 0;
            foreach (string s in options)
                longest = (s.Length >= longest) ? s.Length : longest;

            // Arrays
            string[,] Write = new string[options.Length, longest];
            string[,] PastWrite = Write;
            for(int i = 0; i < options.Length; i++)
            {
                for(int j = 0; j < options[i].Length; j++)
                {
                    tmp = options[i];
                    tmp[j].ToString();
                    Write[i, j] = tmp;
                }
            }


            // I DONT KNOW WHAT IM DOING!!!!

            Console.SetCursorPosition(startLeft, startTop);
            for(int i = 0; i < Write.Length; i++)
            {
                for (int j = 0; j < Write.Length; j++)
                {
                    if (Write[i, j] != PastWrite[i, j])
                        Console.Write(Write[i, j]);
                }
            }
            Console.WriteLine(Write);
            //TextWriter.WriteLine(write);
        }

        public static void ReadKeyPresses()
        {
            Console.WriteLine("press down arrow keys!");
            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        break;
                    case ConsoleKey.RightArrow:
                        break;
                    case ConsoleKey.UpArrow:
                        Console.Clear();
                        selected--;
                        draw();
                        break;
                    case ConsoleKey.DownArrow:
                        Console.Clear();
                        selected++;
                        draw();
                        break;
                    case ConsoleKey.Enter:
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        Console.Write("\x1b[38;2;" + 255 + ";" + 0 + ";" + 0 + "m" + $"{key} is not a valid command");
                        break;
                }
            }
        }
    }
}
