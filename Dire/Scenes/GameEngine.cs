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

        public MAP Map = new MAP();
        public Player PLAYER;

        public bool EXIT = false;
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

            //AreaWriter.WriteContext(Map, PLAYER.Pos[0], PLAYER.Pos[1]);

            Console.WriteLine(Map.GetLocationName(3, 3));

            while (EXIT)
            {
                ScreenRenderer.StartRender();
                Console.ReadKey();
            }


            Console.ReadKey();
            
        }




        /// <summary>
        /// Runs an intro sequence for the game to initilize a player
        /// </summary>
        private void IntroLoop()
        {
            Program.CURRENTGAMESTATE = GameStates.IntroSequence;
            PLAYER = Intro.IntroSequence();
        }
        /// <summary>
        /// Runs the main menu loop
        /// </summary>
        private void MainMenuLoop()
        {
            Program.CURRENTGAMESTATE = GameStates.MainMenu;
            Console.Clear();
            //insert tick here?
            
        }

    }
}
