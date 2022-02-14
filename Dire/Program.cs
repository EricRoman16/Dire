using System;
using System.Threading;
using System.Runtime.InteropServices;
using Dire.Scenes;

namespace Dire
{
    public enum GameStates { Start, Setup, Running, Fight }
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
        public static string version = "0.0.0 Pre-Alpha";
        public static GameStates CURRENTGAMESTATE;

        // Main method that the program runs first
        public static void Main(string[] args)
        {
            var handle = GetStdHandle(-11);
            int mode;
            GetConsoleMode(handle, out mode);
            SetConsoleMode(handle, mode | 0x4);

            //Console.Write("\x1b[48;5;" + i + "m*");
            //Console.Write("\x1b[38;2;" + i + ";" + i + ";" + i + "m h");

            //MainMenu.DrawMainMenu();

            NavigationController NAVCTRL = new NavigationController();




            //RunDire();

        }

        // Main function that sets up and runs the games threads
        public static void RunDire()
        {
            Settings.Setup();
            //MusicPlayer.Start(); //[Add the right sounds and music] :)
            GameLoop.Start();
        }
        
        // Game threads for doing things simultaniously 
        static Thread GameLoop    = new Thread(GameLoops.MainLoop   ) { Name = "GameLoop"    };
        //static Thread MusicPlayer = new Thread(AudioPlayer.PlayMusic) { Name = "MusicPlayer" };
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
