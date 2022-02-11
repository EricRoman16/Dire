using System;
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
        const int STARTLEFT = 20;
        const int STARTTOP = 10;
        static int Longest = 0; //Must always be 2 more than the largest string
        static int MainSelected = 0;
        static int SecondSelected = 0;
        static bool Entered = false;
        // Arrays ----------------------------------------------------------
        // The Total option choices
        static string[] Selections = new string[5] { "Look", "Move", "Inventory", "Equipped", "Options"};
        // What is needed to write to the screen
        static string[,] Write;
        // What has been writen to the screen - Here it should be empty
        static string[,] PastWrite;
        //These will be the individual Arrays/Options for each selection
        Dictionary<int, string[]> SubSelections = new Dictionary<int, string[]>()
        {
            { 0 , new string[6] { "At", "Around", "North", "East", "South", "West"}                 },
            { 1 , new string[5] { "Towards", "North", "East", "South", "West"}                      },
            { 2 , new string[4] { "Use", "Equip", "Craft", "Drop" }                                 },
            { 3 , new string[2] { "Remove", "Stats"}                                                },
            { 4 , new string[6] { "Difficulty", "Save", "Load", "Music", "Documentation", "Exit" }  }
        };
        

        public static void Start()
        {
            DoOnce();
            Setup();
            Fill();
            Draw();
            
            Console.SetCursorPosition(STARTLEFT, STARTTOP + Selections.Length);
        }

        static void DoOnce()
        {
            if(Longest == 0)
            {
                foreach (string s in Selections)
                    Longest = (s.Length > Longest) ? s.Length : Longest;
                Longest += 2;
            }
        }

        static void Setup()
        {
            Write = new string[Selections.Length, Longest];
            PastWrite = new string[Selections.Length, Longest];

            // Sets PastWrite to Write so you dont redraw what's already there
            for (int i = 0; i < Selections.Length; i++)
            {
                for (int j = 0; j < Longest; j++)
                {
                    PastWrite[i, j] = Write[i, j];
                }
            }
        }

        /// <summary>
        /// Fills the write array for what will be writen to the screen
        /// </summary>
        static void Fill()
        {
            // Used for filling Write
            string tmp;
            // Adds each idividual character into the Write array
            for (int i = 0; i < Write.GetLength(0); i++)
            {
                for (int j = 0; j < Write.GetLength(1); j++)
                {
                    try
                    {
                        tmp = Selections[i].Substring(j, 1);
                    }
                    catch (Exception)
                    {
                        if (i == MainSelected && j == 10) //Selections[i].Length + 1
                            tmp = (Entered) ? ">" : "<";
                        else
                            tmp = " ";
                    }
                    Write[i, j] = tmp;
                }
            }
        }
        /// <summary>
        /// Draws everything in the write array
        /// </summary>
        static void Draw()
        {
            //Sets cursor invisable and to the start where it will start typing
            Console.CursorVisible = false;
            Console.SetCursorPosition(STARTLEFT, STARTTOP);
            // Goes through write and writes each character to the screen
            for (int i = 0; i < Write.GetLength(0); i++)
            {
                Console.SetCursorPosition(STARTLEFT, STARTTOP + i);
                for (int j = 0; j < Write.GetLength(1); j++)
                {
                    Console.SetCursorPosition(STARTLEFT + j, STARTTOP + i);
                    if (Write[i, j] != PastWrite[i, j])
                        Console.Write(Write[i, j]);

                }
            }
        }
        
        static void Enter()
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

        static void Exit()
        {

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
                        if(MainSelected - 1 >= 0 && !Entered)
                            MainSelected--;
                        Start();
                        break;
                    case ConsoleKey.DownArrow: // this will go down in the list of options [Need to make bounds for selected]
                        if (MainSelected + 1 <= Selections.Length - 1 && !Entered) // this will probably need to change
                            MainSelected++;
                        Start();
                        break;
                    case ConsoleKey.Enter: // see right arrow
                        Entered = true;
                        Start();
                        break;
                    case ConsoleKey.Escape: // see left arrow
                        Entered = false;
                        Start();
                        break;
                    default:
                        //Console.Write("\x1b[38;2;" + 255 + ";" + 0 + ";" + 0 + "m" + $"{key} is not a valid command");
                        //Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            }
        }

        /*
         Comments:

            for (int k = 0; k < odds.GetLength(0); k++)
                for (int l = 0; l < odds.GetLength(1); l++)
                    var val = odds[k, l];
            
         
         
         
         
         
         
         
         */

    }
}
