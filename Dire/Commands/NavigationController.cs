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
        enum Mode { Normal, MainMenu }; 
        Mode CurrentMode = Mode.MainMenu;

        #region Variables
        int StartLeft = 4;
        int StartTop = 12;
        int Longest;
        int MainSelected = 0;
        int SecondSelected = 0;
        bool Entered = false;

        public bool Showing = true;


        public string[][] DefaultSelections = new string[5][]
        {
            new string[] { "Look", "At", "Around", "North", "East", "South", "West"},
            new string[] { "Move", "Towards", "North", "East", "South", "West"},
            new string[] { "Inventory", "Use", "Equip", "Craft", "Drop" } ,
            new string[] { "Equipped", "Remove", "Stats" } ,
            new string[] { "Options", "Difficulty", "Save", "Load", "Music", "Docs", "Exit" }
        };
        public string[][] MainMenuSelections = new string[3][]
        {
            new string[] { "Start", "New Game", "Load"},
            new string[] { "Options", "Music"},
            new string[] { "Exit", "Yes", "No"} ,
        };
        string[,] Write; // What is needed to write to the screen
        string[,] PastWrite;// What has been writen to the screen - Here it should be empty

        #endregion

        public NavigationController()
        {
            CurrentMode = Mode.MainMenu; // Might change this later
        }

        public void threadStart()
        {
            switch (CurrentMode)
            {
                case Mode.MainMenu:
                    Begin(MainMenuSelections);
                    break;
                case Mode.Normal:
                    Begin(DefaultSelections);
                    break;
            }
        }

        public void Begin(string[][] options = null)
        {
            
            if (options == null)
            {
                switch (CurrentMode)
                {
                    case Mode.MainMenu:
                        options = MainMenuSelections;
                        break;
                    case Mode.Normal:
                        options = DefaultSelections;
                        break;
                }
            }
                
            Setup(options);
            FillArray(options);
            Draw();
            ReadKeyPresses(options);

            //Ends where the user would type
            //Console.SetCursorPosition(StartLeft, StartTop + NormalSelections.Length);
        }

        void Setup(string[][] array)
        {
            int length0 = array.GetLength(0);
            int length1;
            Longest = 0;
            for(int i = 0; i < length0; i++)
            {
                length1 = array[i].GetLength(0);
                for (int j = 0; j < length1; j++)
                {
                    Longest = (array[i][j].Length > Longest) ? array[i][j].Length : Longest;
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

            if (!Showing)
                return;

            for (int i = 0; i < array.GetLength(0); i++)
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
                int length = array[MainSelected].Length;
                for (int i = 1; i < length; i++) // fills subselections to w
                {
                    var l = array[MainSelected][i];
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
            
            // Will send X to the commands class to get processed
        }

        void ReadKeyPresses(string[][] array)
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
                        Entered = true;
                        Begin();
                        break;
                    case ConsoleKey.UpArrow: // this will go up in the list of options
                        if (!Entered && MainSelected > 0) MainSelected--; else if (Entered && SecondSelected > 0) SecondSelected--;
                        Begin();
                        break;
                    case ConsoleKey.DownArrow: // this will go down in the list of options [Need to make bounds for selected]
                        int tmp = array[MainSelected].Length;
                        if (!Entered && MainSelected < array.GetLength(0) - 1) MainSelected++; else if (Entered && SecondSelected < tmp - 2) SecondSelected++;
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
                    case ConsoleKey.Y: // This hides/shows the options
                        Showing = !Showing;
                        MainSelected = 0;
                        SecondSelected = 0;
                        Entered = false;
                        Begin();
                        break;
                    case ConsoleKey.W: // This auto switches to normal options
                        CurrentMode = Mode.Normal;
                        MainSelected = 0;
                        SecondSelected = 0;
                        Entered = false;
                        Begin();
                        break;
                    default:
                        break;
                }
            }
        }

        /*
         * Comments:
         *
         *
         */

    }
}
