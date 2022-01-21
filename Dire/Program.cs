using System;
using System.Threading;

namespace Dire
{
    public enum GameStates { Start, Setup, Running, Fight }
    public class Program
    { 
        // Main Game variables
        public static string version = "0.0.0 Pre-Alpha";
        public static GameStates CURRENTGAMESTATE;

        // Main method that the program runs first
        public static void Main(string[] args)
        {
            //RunDire();
            Testing.LinkedListTest();
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
 *  
 * > sneak behind troll
 * 
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
