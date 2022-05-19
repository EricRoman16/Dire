using Dire.Map.Locations;
using System;
using System.Runtime.InteropServices;

namespace Dire
{
    public enum GameStates { MainMenu, IntroSequence, MainGame }
    public class Program
    {
        #region Dll Color stuff
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetConsoleMode(IntPtr handle, out int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int handle);
        #endregion


        // Main Game variables
        public static string version = "0.0.1 Pre-Alpha";
        public static GameStates CURRENTGAMESTATE = GameStates.MainGame;
        public static GameEngine GE;

        // Main method that the program runs first
        public static void Main(string[] args)
        {
            var handle = GetStdHandle(-11);
            int mode;
            GetConsoleMode(handle, out mode);
            SetConsoleMode(handle, mode | 0x4);

            //Console.Write("\x1b[48;5;" + i + "m*");
            //Console.Write("\x1b[38;2;" + i + ";" + i + ";" + i + "m h");
            
            
            //UITest();

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("⫠⫟⫞⫤⫥⫧⫪⫨⫫⫭⫬⫩⫦⫣|¦‖");
            Console.ReadKey();

            RunDire();

        }

        // Main function that sets up and runs the game
        public static void RunDire()
        {
            Settings.Setup();
            GE = new GameEngine(false, true);
        }
        
        public static void UITest()
        {
            // (119,29)
            Console.SetCursorPosition(4, 0);
            Console.Write("Harthden - Old Hut");
            Console.SetCursorPosition(100, 0);
            Console.Write("In Conversation");
            Console.SetCursorPosition(1, 3);
            Console.Write("\tWorld descriptions here");
            Console.SetCursorPosition(4, 10);
            Console.Write("Options start here");
        }
    }
}


// What the end product should look close to:

/*
 * Caldon - Forest                         Hidden
 * 
 *     You spy a troll a couple meters ahead, so
 * you decide to hide in a bush. The troll has 
 * his back turned towards you and is munching
 * on a cows leg
 * 
 *   actions
 * > Inventory >
 *   Options
 */

/*
 * Harthden - Old Hut                      In Conversation
 * 
 * Old Man:    Huh, been a long time since I've spoken to 
 *             anyone... other than me'self Ooohaha!
 *          
 * Starborn:   Are you alone here Old Man?
 *
 * Old Man:    Depends on your definition of alone lad.
 *  
 * > Is there anyone else here?
 * 
 */

/*
 *    ______  _________ _______  _______ 
 *   (  __  \ \__   __/(  ____ )(  ____ \
 *   | (  \  )   ) (   | (    )|| (    \/
 *   | |   ) |   | |   | (____)|| (__    
 *   | |   | |   | |   |     __)|  __)   
 *   | |   ) |   | |   | (\ (   | (      
 *   | (__/  )___) (___| ) \ \__| (____/\
 *   (______/ \_______/|/   \__/(_______/
 */
