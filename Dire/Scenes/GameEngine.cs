using Dire.Scenes.Intro;
using Dire.Scenes;
using System.Threading;
using System;

namespace Dire
{
    //                                   [This really needs to be optimized to not worry about future additions]
    public class GameEngine
    {
        #region Variables
        NavigationController NC = new NavigationController();
        public MAP Map = new MAP();
        #endregion

        #region Threads
        //Thread GameLoop;
        Thread NavController;
        //static Thread MusicPlayer = new Thread(AudioPlayer.PlayMusic) { Name = "MusicPlayer" };
        #endregion




        public GameEngine(bool skipMainMenu = false, bool skipIntro = false)
        {
            //setup
            //NavController = new Thread(NC.threadStart) { Name = "NavController Thread" };


            if (!skipMainMenu)
            {
                //Run Main menu sequence
                Console.WriteLine("Running Main menu sequence!");
                Console.ReadKey(true);
                Console.Clear();
                Program.CURRENTGAMESTATE = GameStates.MainMenu;
                MainMenu.DrawMainMenu();
                NC.threadStart();
                //NavController.Start();
            }
            if (!skipIntro)
            {
                //Run Intro sequence
                Console.WriteLine("Running intro sequence!");
                Console.ReadKey(true);
                Program.CURRENTGAMESTATE = GameStates.IntroSequence;
                Player PLAYER = Intro.IntroSequence();
            }
            
            MainGameLoop();
        }
        
        
        public void MainGameLoop()
        {
            // need to make player
            //Player PLAYER = Intro.IntroSequence();
            //need to generate map as it will be randomly generator

            Console.ReadKey();
            
            //need to set up function to display location
            //need to set up function to display action/status
            //need to set up function to display current place text (main game text)
            //need to set up function to display nav controller 

            
            
            
            
            
        }

        



    }
}
