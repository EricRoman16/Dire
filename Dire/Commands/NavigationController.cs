using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dire
{
    public class NavigationController
    {
        enum Arrays { Selections, Look, Move, Inventory, Equipped, Options, Exit };

        #region Variables
        const int STARTLEFT = 0;
        const int STARTTOP = 5;
        int Longest = 11;
        int MainSelected = 0;
        int SecondSelected = 0;
        bool Entered = false;

        // The Total option choices
        string[] NormalSelections = new string[5] { "Look", "Move", "Inventory", "Equipped", "Options" };
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
            { 4 , new string[6] { "Difficulty", "Save", "Load", "Music", "Docs", "Exit" }  }
        };

        #endregion

        public NavigationController()
        {
            Begin();
            
        }



        public void Begin()
        {
            Setup();
            FillArray();
            Draw();
            ReadKeyPresses();

            //Ends where the user would type
            Console.SetCursorPosition(STARTLEFT, STARTTOP + NormalSelections.Length);
        }



        void Setup()
        {
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
        void FillArray()
        {
            int length0 = Write.GetLength(0);
            int length1 = Write.GetLength(1);
            for (int i = 0; i < length0; i++)
            {

                for (int j = 0; j < length1; j++)
                {
                    Write[i, j] = null;

                }
            }

            int tmp = 0;
            foreach(string s in NormalSelections)
            {
                for(int i = 0; i < s.Length; i++)
                {
                    Write[tmp, i] = s.Substring(i, 1);
                }
                tmp++;
            }
            for(int i = 0; i < length0; i++)
            {
                string x = (Entered) ? ">" : "<";
                Write[i, Longest - 1] = (i == MainSelected) ? x : " ";
            }

            //this is for when entered
            if (Entered)
            {
                int length = SubSelections[MainSelected].GetLength(0);
                for (int i = 0; i < length; i++)
                {
                    var w = SubSelections[MainSelected].GetValue(i).ToString();
                    for (int j = 0; j < w.Length; j++)
                    {
                        Write[MainSelected + i, Longest + j + 1] = w.ToString().Substring(j, 1);
                    }
                }
                for (float i = 2; i != 0; i--) {
                    Write[MainSelected + SecondSelected, Longest * 2 + 1] = "<";
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
            lock (this)
            {
                for (int i = 0; i < length0; i++)
                {
                    for (int j = 0; j < length1; j++)
                    {
                        Console.SetCursorPosition(STARTLEFT + j, STARTTOP + i);
                        string x = " ";
                        if (Write[i, j] != null && Write[i, j] != PastWrite[i, j])
                        {
                            x = (Write[i, j]);
                        }
                        Console.Write(x);
                    }
                    Console.SetCursorPosition(STARTLEFT, STARTTOP + i + 1);
                }
            }

        }
                
        void Enter()
        {
            string x = SubSelections[MainSelected].GetValue(SecondSelected).ToString();
            // Will send X to the commands class to get processed
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
                        Entered = false;
                        SecondSelected = 0;
                        Begin();
                        break;
                    case ConsoleKey.RightArrow: // this will open up secondary options
                        if (Entered) Enter();
                        Entered = true;
                        Begin();
                        break;
                    case ConsoleKey.UpArrow: // this will go up in the list of options
                        if (!Entered && MainSelected > 0) MainSelected--; else if (Entered && SecondSelected > 0) SecondSelected--;
                        Begin();
                        break;
                    case ConsoleKey.DownArrow: // this will go down in the list of options [Need to make bounds for selected]
                        int tmp = SubSelections[MainSelected].Length;
                        if (!Entered && MainSelected < 4) MainSelected++; else if (Entered && SecondSelected < tmp - 1) SecondSelected++;
                        Begin();
                        break;
                    case ConsoleKey.Enter: // see right arrow
                        if (Entered) Enter();
                        Entered = true;
                        Begin();
                        break;
                    case ConsoleKey.Escape: // see left arrow
                        Entered = false;
                        SecondSelected = 0;
                        Begin();
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
