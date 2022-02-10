﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dire
{
    class NavigationController
    {
        enum Arrays { Selections, Look, Move, Inventory, Equipped, Options, Exit};

        static Arrays CurrentUsedArray = Arrays.Selections;
        // Variables
        static int startLeft = 20;
        static int startTop = 10;
        static int longest = 11; //Must always be 2 more than the largest string
        static int selected = 0;
        // Arrays ----------------------------------------------------------
        // The Total option choices
        static string[] Selections = new string[6] { "Look", "Move", "Inventory", "Equipped", "Options", "Exit"};
        // What is needed to write to the screen
        static string[,] Write = new string[Selections.Length, longest];
        // What has been writen to the screen - Here it should be empty
        static string[,] PastWrite = new string[Selections.Length, longest];
        //These will be the individual Arrays/Options for each selection
        
        public static void draw()
        {
            // Used for filling Write
            string tmp;

            // Adds each idividual character into the Write array
            for(int i = 0; i < Selections.Length; i++)
            {
                for(int j = 0; j < longest; j++)
                {
                    try
                    {
                        tmp = Selections[i].Substring(j, 1);
                    }
                    catch (Exception)
                    {
                        if (i == selected && j == Selections[i].Length + 1)
                            tmp = "<";
                        else
                            tmp = " ";
                    }
                    Write[i, j] = tmp;
                }
            }

            //Sets cursor invisable and to the start where it will start typing
            Console.CursorVisible = false;
            Console.SetCursorPosition(startLeft, startTop);
            // Goes through write and writes each character to the screen
            for(int i = 0; i < Selections.Length; i++)
            {
                Console.SetCursorPosition(startLeft, startTop+i);
                for (int j = 0; j < longest; j++)
                {
                    Console.SetCursorPosition(startLeft+j, startTop+i);
                    if (Write[i, j] != PastWrite[i, j])
                        Console.Write(Write[i, j]);

                }
            }
            //Console.CursorVisible = true;
            // Sets PastWrite to Write so you dont redraw what's already there
            for (int i = 0; i < Selections.Length; i++)
            {
                for (int j = 0; j < longest; j++)
                {
                    PastWrite[i, j] = Write[i, j];
                }
            }
            Console.SetCursorPosition(startLeft, startTop + Selections.Length);
        }

        public static void ReadKeyPresses()
        {
            Console.WriteLine();
            //Console.WriteLine("press down arrow keys!");
            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.LeftArrow: // this will close secondary options 
                        break;
                    case ConsoleKey.RightArrow: // this will open up secondary options
                        break;
                    case ConsoleKey.UpArrow: // this will go up in the list of options
                        selected--;
                        draw();
                        break;
                    case ConsoleKey.DownArrow: // this will go down in the list of options [Need to make bounds for selected]
                        selected++;
                        draw();
                        break;
                    case ConsoleKey.Enter: // see right arrow
                        break;
                    case ConsoleKey.Escape: // see left arrow
                        return;
                    default:
                        //Console.Write("\x1b[38;2;" + 255 + ";" + 0 + ";" + 0 + "m" + $"{key} is not a valid command");
                        //Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            }
        }
    }
}
