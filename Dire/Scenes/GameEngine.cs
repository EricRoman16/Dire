using Dire.Scenes.Intro;
using Dire.Scenes;
using System.Threading;
using System;
using Dire.Map.Locations;
using Dire.Items.Consumables;

namespace Dire
{
    //                                   [This really needs to be optimized to not worry about future additions]
    public class GameEngine
    {
        #region Variables
        NavigationController NC = new NavigationController();
        #endregion

        #region Threads
        //Thread GameLoop;
        Thread NavController;
        //static Thread MusicPlayer = new Thread(AudioPlayer.PlayMusic) { Name = "MusicPlayer" };
        #endregion




        public GameEngine(bool skipMainMenu = false, bool skipIntro = false)
        {
            //setup
            NavController = new Thread(NC.threadStart) { Name = "NavController Thread" };


            if (!skipMainMenu)
            {
                //Run Main menu sequence
                Console.WriteLine("Running Main menu sequence!");
                Console.ReadKey(true);
                Console.Clear();
                MainMenu.DrawMainMenu();
                NavController.Start();
            }
            if (!skipIntro)
            {
                //Run Intro sequence
                Console.WriteLine("Running intro sequence!");
                Console.ReadKey(true);
                Player PLAYER = Intro.IntroSequence();
            }
            //Initializing Main thread - starting game [Not using thread here yet]
            MainGameLoop();
        }
        
        
        public void MainGameLoop()
        {
            // need to make player
            //Player PLAYER = Intro.IntroSequence();
            //need to generate map as it will be randomly generator

            //need to figure out if


            //Console.WriteLine(@"⫠⫟⫞⫤⫥⫧⫪⫨⫫⫭⫬⫩⫦⫣|¦‖");
            //Console.WriteLine(@"— ⊢⊥⊤⊣⋀⋁▷◁▶◀▲▼");
            
            

            
            
            
            
            
        }

        



    }
}
