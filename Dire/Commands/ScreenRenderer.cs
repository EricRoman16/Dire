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
        public static int firstSelected = 0;
        public static int secondSelected = 0;
        public static int thirdSelected = 0;
        static int Entered = 0;
        static string[,] CurrentRender = new string[29, 119];  // What is needed to write to the screen
        static string[,] PastRender = new string[29, 119];     // What has been writen to the screen - Here it should be empty

        //temp variables 
        static MAP TempMap;
        static Player TempPlayer;
        static int count = 0;
        #endregion

        
        /// <summary>
        /// Begins a new render that takes information from multiple sources based on GameState
        /// and then prints to the screen
        /// </summary>
        public static void StartRender(MAP map, Player player)
        {
            TempMap = map;
            TempPlayer = player;
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
            
            switch (Program.CURRENTGAMESTATE)
            {
                case GameStates.MainMenu:
                    break;
                case GameStates.MainGame:
                    FillMainGame();
                    break;
            }
        }

        private static void FillMainGame()
        {
            // need to get location info (name for top left)
            string location = TempMap.GetLocationName(TempPlayer.Pos[0], TempPlayer.Pos[1]);
            // need to get character status (player status for top right)
            Player.PlayerStates status = TempPlayer.PlayerStatus;
            // need to get the world description at player pos in world
            string locationText = TempMap.GetAtLocationText(TempPlayer.Pos[0], TempPlayer.Pos[1]);
            // need to get the options list for the selections at the bottom

            //need to use a for loop to put the characters in the currentRender array
            for(int i = 0; i < location.Length; i++) // Displays Player location in top left
            {
                CurrentRender[0, i] = location.Substring(i, 1);
            }
            for (int i = 0; i < locationText.Length; i++) // Displays location text
            {
                CurrentRender[3, i + 5] = locationText.Substring(i, 1);
            }
            for(int i = 0; i < status.ToString().Length; i++) // Displays player status in top right
            {
                CurrentRender[0, 119 - status.ToString().Length + i] = status.ToString().Substring(i, 1);
            }
            addOptions();
            CurrentRender[19, 0] = count.ToString();
            count++;
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
        
        private static void addOptions()
        {
            int longest = 0;
            switch (Program.CURRENTGAMESTATE)
            {
                case GameStates.MainMenu:
                    break;
                case GameStates.MainGame:
                    //writes the main selections
                    for(int i = 0; i < DefaultSelections.GetLength(0); i++)
                    {
                        for(int j =0; j < DefaultSelections[i][0].Length; j++)
                        {
                            CurrentRender[i + 10, j] = DefaultSelections[i][0].Substring(j, 1);
                        }
                        if (DefaultSelections[i][0].Length > longest) longest = DefaultSelections[i][0].Length;
                    }

                    if(Entered == 0)
                    {
                        CurrentRender[firstSelected + 10, longest + 1] = "<";
                    }
                    if(Entered == 1)
                    {
                        CurrentRender[firstSelected + 10, longest + 1] = ">";
                        CurrentRender[firstSelected + 10, longest * 2] = "<";
                    }




                    break;
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
                {
                    CurrentRender[i, j] = " ";
                    CurrentRender[i, j] = null;
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
