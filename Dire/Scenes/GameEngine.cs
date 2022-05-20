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
        //ScreenRenderer NC = new ScreenRenderer();

        public MAP Map = new MAP();
        public Player PLAYER;
        #endregion



        public GameEngine(bool skipMainMenu = false, bool skipIntro = false)
        {



            if (!skipMainMenu)
                MainMenuLoop();
            if (!skipIntro)
                IntroLoop();
            
            MainGameLoop();
        }


        public void MainGameLoop()
        {
            Program.CURRENTGAMESTATE = GameStates.MainGame;


            if(PLAYER == null) PLAYER = new Player(" ", 10, new int[] { 5, 5 }, Player.PlayerStates.Exploring);

            AreaWriter.WriteContext(Map, PLAYER.Pos[0], PLAYER.Pos[1]);

            //NC.StartRender(true);

            //need to set up function to display location
            //need to set up function to display action/status
            //need to set up function to display current place text (main game text)
            //need to set up function to display nav controller 

            while (true)
            {
                ScreenRenderer.StartRender();
                Console.ReadKey();
            }
            
            
            
            Console.ReadKey();
            
        }

        private void IntroLoop()
        {
            //Run Intro sequence
            Console.WriteLine("Running intro sequence!");
            Console.ReadKey(true);
            Program.CURRENTGAMESTATE = GameStates.IntroSequence;
            PLAYER = Intro.IntroSequence();
        }

        private void MainMenuLoop()
        {
            //Run Main menu sequence
            //Console.WriteLine("Running Main menu sequence!");
            //Console.ReadKey(true);
            Console.Clear();
            Program.CURRENTGAMESTATE = GameStates.MainMenu;
            MainMenu.DrawMainMenu();
            //NC.StartRender();
        }

    }
}
