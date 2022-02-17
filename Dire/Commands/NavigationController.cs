using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dire
{
    public class NavigationController
    {
        private static readonly object padlock = new object();
        enum Mode { Normal, MainMenu }; // Not in use currently
        Mode CurrentMode = Mode.Normal;

        #region Variables
        int StartLeft = 0;
        int StartTop = 10;
        int Longest;
        int MainSelected = 0;
        int SecondSelected = 0;
        bool Entered = false;

        string[][] DefaultSelections = new string[5][]
        {
            new string[] { "Look", "At", "Around", "North", "East", "South", "West"},
            new string[] { "Move", "Towards", "North", "East", "South", "West"},
            new string[] { "Inventory", "Use", "Equip", "Craft", "Drop" } ,
            new string[] { "Equipped", "Remove", "Stats" } ,
            new string[] { "Options", "Difficulty", "Save", "Load", "Music", "Docs", "Exit" }
        };
        string[,] Write; // What is needed to write to the screen
        string[,] PastWrite;// What has been writen to the screen - Here it should be empty

        #endregion

        public NavigationController()
        {
            CurrentMode = Mode.Normal; // Might change this later
        }

        public void Begin(string[][] options)
        {
            Setup();
            FillArray(options);
            Draw();
            ReadKeyPresses();

            //Ends where the user would type
            //Console.SetCursorPosition(StartLeft, StartTop + NormalSelections.Length);
        }


        void Setup(string[][] array)
        {
            int length0 = array.GetLength(0);
            int length1 = array.GetLength(1);
            Longest = 0;
            for(int i = 0; i < length0; i++)
            {
                for(int j = 0; j < length1; j++)
                {
                    Longest = (array[i][j].Length > Longest) ? s.Length : Longest;
                }
            }
            Longest += 2;
            Write = new string[10, Longest * 2 + 2];
            PastWrite = new string[10, Longest * 2 + 2];

            for (int i = 0; i < Write.GetLength(0); i++)
            {
                for (int j = 0; j < Write.GetLength(1); j++)
                    PastWrite[i, j] = Write[i, j];
            }
        }

        /// <summary>
        /// Fills the write array for what will be writen to the screen
        /// </summary>
        void FillArray(string[][] array)
        {
            int Writelength0 = Write.GetLength(0);
            int Writelength1 = Write.GetLength(1);
            // clears Write
            for (int i = 0; i < Writelength0; i++) 
            {
                for (int j = 0; j < Writelength1; j++)
                {
                    Write[i, j] = null;

                }
            }

            /*int tmp = 0;
            foreach(string s in NormalSelections) // fills w
            {
                for(int i = 0; i < s.Length; i++)
                {
                    Write[tmp, i] = s.Substring(i, 1);
                }
                tmp++;
            }*/

            for(int i = 0; i < array.GetLength(0); i++)
            {
                for(int j = 0; j < array[i][0].Length; j++)
                {
                    Write[i,j] = array[i][0].Substring(j, 1);
                }
            }


            for(int i = 0; i < Writelength0; i++) // adds pointer
            {
                string x = (Entered) ? ">" : "<";
                Write[i, Longest - 1] = (i == MainSelected) ? x : " ";
            }

            if (Entered) // this is for when entered
            {
                int length = DefaultSelections[MainSelected].Length;
                for (int i = 1; i < length; i++) // fills subselections to w
                {
                    var l = DefaultSelections[MainSelected][i];
                    for (int j = 0; j < l.Length; j++)
                    {
                        Write[MainSelected + i - 1, Longest + j + 1] = l.ToString().Substring(j, 1);
                    }
                }
                for (float i = 2; i != 0; i--) // adds second pointer
                {
                    Write[MainSelected + SecondSelected, Longest * 2 + 1] = "<";
                }
            }
        }

        /// <summary>
        /// Draws everything in the write array
        /// </summary>
        void Draw()
        {
            int length0 = Write.GetLength(0);
            int length1 = Write.GetLength(1);
            lock (padlock)
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(StartLeft, StartTop);
                for (int i = 0; i < length0; i++)
                {
                    for (int j = 0; j < length1; j++)
                    {
                        Console.SetCursorPosition(StartLeft + j, StartTop + i);
                        string x = " ";
                        if (Write[i, j] != null && Write[i, j] != PastWrite[i, j])
                        {
                            x = (Write[i, j]);
                        }
                        Console.Write("\x1b[38;2;" + 192 + ";" + 192 + ";" + 192 + "m" + x);
                    }
                    Console.SetCursorPosition(StartLeft, StartTop + i + 1);
                }
            }

        }
                
        void Enter()
        {
            string x = NormalSubSelections[MainSelected].GetValue(SecondSelected).ToString();
            // Will send X to the commands class to get processed
        }

        void ReadKeyPresses()
        {
            Console.WriteLine();
            //Console.WriteLine("press down arrow keys!");
            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.LeftArrow: // this will close secondary options 
                        Entered = false;
                        SecondSelected = 0;
                        Begin(DefaultSelections);
                        break;
                    case ConsoleKey.RightArrow: // this will open up secondary options
                        Entered = true;
                        Begin(DefaultSelections);
                        break;
                    case ConsoleKey.UpArrow: // this will go up in the list of options
                        if (!Entered && MainSelected > 0) MainSelected--; else if (Entered && SecondSelected > 0) SecondSelected--;
                        Begin(DefaultSelections);
                        break;
                    case ConsoleKey.DownArrow: // this will go down in the list of options [Need to make bounds for selected]
                        int tmp = NormalSubSelections[MainSelected].Length;
                        if (!Entered && MainSelected < 4) MainSelected++; else if (Entered && SecondSelected < tmp - 1) SecondSelected++;
                        Begin(DefaultSelections);
                        break;
                    case ConsoleKey.Enter: // see right arrow
                        if (Entered) Enter();
                        Entered = true;
                        Begin(DefaultSelections);
                        break;
                    case ConsoleKey.Escape: // see left arrow
                        Entered = false;
                        SecondSelected = 0;
                        Begin(DefaultSelections);
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
            
         
         
         START THINKING ABOUT MORE OPTIONS ABOUT WHAT IT NEEDS TO TYPE 
         I.E. PASSING IN STRINGS LIKE OPTIONS
         
         
         
         
         */

    }
}
