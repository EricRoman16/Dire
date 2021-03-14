 using System;

namespace Dire
{
    //                                   [This really needs to be optimized to not worry about future additions]
    class GameLoops
    {
        public static bool GameRunning = true;
        public static Player player;
        public static int MOVE = 0;
        public static void MainLoop()
        {
            while (GameRunning)
            {
                MakePlayer();
                while (true)
                {
                    if (player.playerStatus == Player.PlayerStates.Exploring)
                        ExplorationLoop();
                    if (player.playerStatus == Player.PlayerStates.Fighting)
                        FightLoop();
                    if (player.playerStatus == Player.PlayerStates.Conversation)
                        ConversationLoop();

                    if (player.playerStatus == Player.PlayerStates.Dead) break;
                }
                TextWriter.WriteLine(player.name + " has *died*.");
                Console.ReadLine();
                Console.Clear();
            }
        }
        //                                                 Basic Game Loops
        #region Other
        public static void ExplorationLoop()
        {
            while(player.playerStatus == Player.PlayerStates.Exploring)
            {
                Draw();
                while (true)
                {
                    //int writingOnLine = Console.CursorTop; Im going to want to replace the input with the actions [> walk forward -> You walked forward]
                    Console.Write("> ");
                    bool x = ReadInput.Decifer(Console.ReadLine().Trim().ToLower(), player);
                    if (x) break;
                }
                MOVE++;
            }
        }
        public static void FightLoop()
        {

        }
        public static void ConversationLoop()
        {
            
        }






        //                                                  Other funtions

        // Draw function that draws all context on screen
        public static void Draw()
        {
            Console.Clear();
            ShowLocation();
            ShowStatus();
            Contextualize();
        }
        // Context function that get's the location of the player
        public static void Contextualize()
        {
            Console.WriteLine();
            TextWriter.WriteLine(MAP.realWorld[player.Pos[0], player.Pos[1]].On());
            Console.WriteLine();
        }
        // Displays the name of the location in the top left corner
        public static void ShowLocation()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(MAP.realWorld[player.Pos[0], player.Pos[1]].ToString());
        }
        // Displays the players state/status in top right
        public static void ShowStatus()
        {
            Console.SetCursorPosition(20, 0);
            Console.WriteLine(player.playerStatus);
        }
        // Makes a new object of type player
        public static void MakePlayer()
        {
            //player = Settings.NewCharacter(player); // this can be commented out to remove intro
            if (player != new Player())
                player = new Player();
        }
        // breaks the entire loop and exits the game
        public static void Exit()
        {
            GameRunning = false;
            TextWriter.WriteLine("Do come back again, goodbye.");
            Console.ReadLine();
        }
        #endregion
    }
}
