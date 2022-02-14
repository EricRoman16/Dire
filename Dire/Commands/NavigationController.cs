﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dire
{
    public class NavigationController
    {
        enum Arrays { Selections, Look, Move, Inventory, Equipped, Options, Exit};

        #region Variables
        const int STARTLEFT = 20;
        const int STARTTOP = 10;
        int Longest = 11;
        int MainSelected = 0;
        int SecondSelected = 0;
        bool Entered = false;
        
        // The Total option choices
        string[] Selections = new string[5] { "Look", "Move", "Inventory", "Equipped", "Options"};
        // What is needed to write to the screen
        string[,] Write;
        // What has been writen to the screen - Here it should be empty
        string[,] PastWrite;
        //These will be the individual Arrays/Options for each selection
        Dictionary<int, string[]> SubSelections = new Dictionary<int, string[]>()
        {
            { 0 , new string[6] { "At", "Around", "North", "East", "South", "West"}                 },
            { 1 , new string[5] { "Towards", "North", "East", "South", "West"}                      },
            { 2 , new string[4] { "Use", "Equip", "Craft", "Drop" }                                 },
            { 3 , new string[2] { "Remove", "Stats" }                                               },
            { 4 , new string[6] { "Difficulty", "Save", "Load", "Music", "Documentation", "Exit" }  }
        };

        #endregion





        public void Begin()
        {
            Setup();
            FillArray();
            Draw();
            ReadKeyPresses();

            //Ends where the user would type
            Console.SetCursorPosition(STARTLEFT, STARTTOP + Selections.Length);
        }

        

        void Setup()
        {
            Write = new string[12, Longest * 2];
            PastWrite = new string[12, Longest * 2];

            for(int i = 0; i < Write.GetLength(0); i++)
            {
                for (int j = 0; j < Write.GetLength(1); j++)
                    PastWrite[i, j] = Write[i, j];
            }
        }

        /// <summary>
        /// Fills the write array for what will be writen to the screen
        /// </summary>
        void FillArray()
        {
            int x = (Entered) ? Write.GetLength(0) : Selections.GetLength(0);
            int length1 = Write.GetLength(1);
            for (int i = 0; i < x; i++)
            {
                
                for (int j = 0; j < length1; j++)
                {
                    try
                    {
                        Write[i, j] = Selections[i].Substring(j, 1);
                    }
                    catch
                    {
                        Write[i, j] = " ";
                        if (i == MainSelected && j == Longest - 1) Write[i, j] = (Entered) ? ">" : "<";
                    }

                }
            }


            //this is for when entered
            if (Entered)
            {
                int length = SubSelections[MainSelected].GetLength(0);
                for (int i = 0; i < length; i++)
                {
                    var w = SubSelections[MainSelected].GetValue(i);
                    for (int j = 0; j < w.ToString().Length; j++)
                    {
                        Write[MainSelected + i, Longest + j] = w.ToString().Substring(j, 1);
                    }
                }
                for (float i = 2; i != 0; i--){
                    Write[MainSelected + SecondSelected, Longest * 2 - 1] = "<";
                }
            }
        }

        /// <summary>
        /// Draws everything in the write array
        /// </summary>
        void Draw()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(STARTLEFT, STARTTOP);
            int length0 = Write.GetLength(0);
            int length1 = Write.GetLength(1);
            for (int i = 0; i < length0; i++)
            {
                for (int j = 0; j < length1; j++)
                {
                    if(Write[i,j] != PastWrite[i, j])
                    {
                        Console.Write(Write[i, j]);
                    }
                }
                Console.SetCursorPosition(STARTLEFT, STARTTOP + i + 1);
            }

        }
        
        void Enter()
        {
            switch (MainSelected)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        }

        void Exit()
        {

        }
        
        
        
        
        
        public void ReadKeyPresses()
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
                        if (!Entered) MainSelected--; else SecondSelected--;
                        Begin();
                        break;
                    case ConsoleKey.DownArrow: // this will go down in the list of options [Need to make bounds for selected]
                        if (!Entered) MainSelected++; else SecondSelected++;
                        Begin();
                        break;
                    case ConsoleKey.Enter: // see right arrow
                        Entered = !Entered;
                        Begin();
                        break;
                    case ConsoleKey.Escape: // see left arrow
                        break;
                    default:
                        break;
                }
            }
        }

        /*
         Comments:

            for (int k = 0; k < odds.GetLength(0); k++)
                for (int l = 0; l < odds.GetLength(1); l++)
                    var val = odds[k, l];
            
         
         
         MAYBE SOMETHING TO DO WITH FOR EACH LOOPS AND ALSO LOOKING IF THE WRITE[I,J] IS NULL BEFORE DOING
         ANYTHING AND ONLY SETTING THE CURSOR POSITION THEN WRITING (THOUGHTS ON TRYING TO MAKE IT FASTER)
         
         
         
         
         */

    }
}
