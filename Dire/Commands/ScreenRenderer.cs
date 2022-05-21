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
        static string[,] CurrentRender = new string[29, 119];  // What is needed to write to the screen
        static string[,] PastRender = new string[29, 119];     // What has been writen to the screen - Here it should be empty

        #endregion

        
        /// <summary>
        /// Begins a new render that takes information from multiple sources based on GameState
        /// and then prints to the screen
        /// </summary>
        public static void StartRender()
        {
            FillArray();
            if(Showing)
                DrawRender();
            Finish();
        }


        /// <summary>
        /// Grabs all the information that will be in the frame and organizes it into an array that will be displayed
        /// </summary>
        private static void FillArray()
        {
            // need to get location info (name for top left)
            // need to get character status (player status for top right)
            // need to get the world description at player pos in world
            // need to get the options list for the selections at the bottom

            switch (Program.CURRENTGAMESTATE)
            {
                case GameStates.MainMenu:
                    break;
                case GameStates.MainGame:
                    break;
            }
        }


        /// <summary>
        /// Draws the rendered frame onto the screen
        /// </summary>
        private static void DrawRender()
        {
            int length0 = CurrentRender.GetLength(0);
            int length1 = CurrentRender.GetLength(1);
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < length0; i++)
            {
                for (int j = 0; j < length1; j++)
                {
                    Console.SetCursorPosition(j, i);
                    string x = ""; //problem around here - i think i fixed it?
                    if (CurrentRender[i, j] != null && CurrentRender[i, j] != PastRender[i, j]) // checks if the space is not null or same as previous frame
                    {
                        x = (CurrentRender[i, j]);
                    }
                    Console.Write("\x1b[38;2;" + 192 + ";" + 192 + ";" + 192 + "m" + x); // prints character with normal color
                }
                Console.SetCursorPosition(0, i + 1);
            }
            

        }
                
        
        /// <summary>
        /// Final steps that need to be done
        /// </summary>
        private static void Finish()
        {
            // Sets past render to current render
            PastRender = new string[CurrentRender.GetLength(0), CurrentRender.GetLength(1)];
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

        

        /*
         * Comments:
         *
         *
         */

    }
}
