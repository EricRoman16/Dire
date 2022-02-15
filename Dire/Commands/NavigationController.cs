using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dire
{
    public class NavigationController
    {
        enum Mode { Normal, MainMenu }; // Not in use currently
        Mode CurrentMode = Mode.Normal;

        #region Variables
        int StartLeft = 0;
        int StartTop = 10;
        int Longest;
        int MainSelected = 0;
        int SecondSelected = 0;
        bool Entered = false;


        string[] NormalSelections = new string[5] { "Look", "Move", "Inventory", "Equipped", "Options" };// The Total option choices
        string[,] Write; // What is needed to write to the screen
        string[,] PastWrite;// What has been writen to the screen - Here it should be empty
        Dictionary<int, string[]> NormalSubSelections = new Dictionary<int, string[]>()// These will be the individual Arrays/Options for each selection
        {
            { 0 , new string[6] { "At", "Around", "North", "East", "South", "West"}                 },
            { 1 , new string[5] { "Towards", "North", "East", "South", "West"}                      },
            { 2 , new string[4] { "Use", "Equip", "Craft", "Drop" }                                 },
            { 3 , new string[2] { "Remove", "Stats" }                                               },
            { 4 , new string[6] { "Difficulty", "Save", "Load", "Music", "Docs", "Exit" }  }
        };

        #endregion

        public NavigationController()
        {
            CurrentMode = Mode.Normal; // Might change this later
        }

        public void NormalBegin()
        {
            Setup();
            
            FillArray(Write);
            Draw(Write, PastWrite);
            ReadKeyPresses();

            //Ends where the user would type
            Console.SetCursorPosition(StartLeft, StartTop + NormalSelections.Length);
        }


        void Setup()
        {
            Longest = 0;
            foreach (string s in NormalSelections)
                Longest = (s.Length > Longest) ? s.Length : Longest;
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
        void FillArray(string[,] w)
        {
            int length0 = w.GetLength(0);
            int length1 = w.GetLength(1);
            for (int i = 0; i < length0; i++) // clears w
            {
                for (int j = 0; j < length1; j++)
                {
                    w[i, j] = null;

                }
            }

            int tmp = 0;
            foreach(string s in NormalSelections) // fills w
            {
                for(int i = 0; i < s.Length; i++)
                {
                    w[tmp, i] = s.Substring(i, 1);
                }
                tmp++;
            }
            for(int i = 0; i < length0; i++) // adds pointer
            {
                string x = (Entered) ? ">" : "<";
                w[i, Longest - 1] = (i == MainSelected) ? x : " ";
            }

            if (Entered) // this is for when entered
            {
                int length = NormalSubSelections[MainSelected].GetLength(0);
                for (int i = 0; i < length; i++) // fills subselections to w
                {
                    var l = NormalSubSelections[MainSelected].GetValue(i).ToString();
                    for (int j = 0; j < l.Length; j++)
                    {
                        Write[MainSelected + i, Longest + j + 1] = l.ToString().Substring(j, 1);
                    }
                }
                for (float i = 2; i != 0; i--) // adds second pointer
                {
                    w[MainSelected + SecondSelected, Longest * 2 + 1] = "<";
                }
            }
        }

        /// <summary>
        /// Draws everything in the write array
        /// </summary>
        void Draw(string[,] w, string[,] pw)
        {
            int length0 = w.GetLength(0);
            int length1 = w.GetLength(1);
            lock (this)
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(StartLeft, StartTop);
                for (int i = 0; i < length0; i++)
                {
                    for (int j = 0; j < length1; j++)
                    {
                        Console.SetCursorPosition(StartLeft + j, StartTop + i);
                        string x = " ";
                        if (w[i, j] != null && w[i, j] != pw[i, j])
                        {
                            x = (w[i, j]);
                        }
                        Console.Write(x);
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
                        NormalBegin();
                        break;
                    case ConsoleKey.RightArrow: // this will open up secondary options
                        Entered = true;
                        NormalBegin();
                        break;
                    case ConsoleKey.UpArrow: // this will go up in the list of options
                        if (!Entered && MainSelected > 0) MainSelected--; else if (Entered && SecondSelected > 0) SecondSelected--;
                        NormalBegin();
                        break;
                    case ConsoleKey.DownArrow: // this will go down in the list of options [Need to make bounds for selected]
                        int tmp = NormalSubSelections[MainSelected].Length;
                        if (!Entered && MainSelected < 4) MainSelected++; else if (Entered && SecondSelected < tmp - 1) SecondSelected++;
                        NormalBegin();
                        break;
                    case ConsoleKey.Enter: // see right arrow
                        if (Entered) Enter();
                        Entered = true;
                        NormalBegin();
                        break;
                    case ConsoleKey.Escape: // see left arrow
                        Entered = false;
                        SecondSelected = 0;
                        NormalBegin();
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
