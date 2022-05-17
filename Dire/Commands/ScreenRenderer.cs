using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dire
{
    /// <summary>
    /// The ScreenRenderer will create a "render/frame" and then draw it to the screen
    /// </summary>
    public static class ScreenRenderer
    {

        #region Variables
        static int StartLeft = 5;
        static int StartTop = 10;
        static int Longest;
        static int MainSelected = 0;
        static int SecondSelected = 0;
        public static bool Entered = false;
        public static bool EXIT = false;
        public static bool Showing = true;

        public static string[][] DefaultSelections = new string[5][]
        {
            new string[] { "Look", "At", "Around", "North", "East", "South", "West"},
            new string[] { "Move", "Towards", "North", "East", "South", "West"},
            new string[] { "Inventory", "Use", "Equip", "Craft", "Drop" } ,
            new string[] { "Equipped", "Remove", "Stats" } ,
            new string[] { "Options", "Difficulty", "Save", "Load", "Music", "Docs", "Exit" }
        };
        public static string[][] MainMenuSelections = new string[3][]
        {
            new string[] { "Start", "New Game", "Load"},
            new string[] { "Options", "Music"},
            new string[] { "Exit", "Yes", "No"} ,
        };
        static string[,] CurrentRender; // What is needed to write to the screen
        static string[,] PastRender;// What has been writen to the screen - Here it should be empty

        #endregion

        

        public static void StartRender(bool reset = false, string[][] options = null)
        {
            

            FillArray(options);
            
            

            DrawRender();
            Finish();
        }
        /// <summary>
        /// Final steps that need to be done
        /// </summary>
        private static void Finish()
        {
            // Sets past render to current render
            for (int i = 0; i < CurrentRender.GetLength(0); i++)
            {
                for (int j = 0; j < CurrentRender.GetLength(1); j++)
                    PastRender[i, j] = CurrentRender[i, j];
            }
            // Clears CurrentRender
            for (int i = 0; i < CurrentRender.GetLength(0); i++)
            {
                for (int j = 0; j < CurrentRender.GetLength(1); j++)
                    CurrentRender[i, j] = null;
            }
        }

        private static void FillArray(string[][] array)
        {
            
        }


        /// <summary>
        /// Draws the rendered frame onto the screen
        /// </summary>
        private static void DrawRender()
        {
            int length0 = CurrentRender.GetLength(0);
            int length1 = CurrentRender.GetLength(1);
            Console.CursorVisible = false;
            Console.SetCursorPosition(StartLeft, StartTop);
            for (int i = 0; i < length0; i++)
            {
                for (int j = 0; j < length1; j++)
                {
                    Console.SetCursorPosition(StartLeft + j, StartTop + i);
                    string x = " ";
                    if (CurrentRender[i, j] != null && CurrentRender[i, j] != PastRender[i, j]) // checks if the space is not null or same as previous frame
                    {
                        x = (CurrentRender[i, j]);
                    }
                    Console.Write("\x1b[38;2;" + 192 + ";" + 192 + ";" + 192 + "m" + x); // prints character with normal color
                }
                Console.SetCursorPosition(StartLeft, StartTop + i + 1);
            }
            

        }
                
        

        

        /*
         * Comments:
         *
         *
         */

    }
}
