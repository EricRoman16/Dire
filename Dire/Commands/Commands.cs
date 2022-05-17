using System;
using System.Collections.Generic;
using System.Linq;

namespace Dire
{
    public static class Commands
    {
        public static void CommandEnter(string command, string extraInfo = null)
        {
            switch (Program.CURRENTGAMESTATE)
            {
                case GameStates.MainMenu:
                    MainMenuCommands(command);
                    break;
                case GameStates.IntroSequence:
                    IntroSequenceCommands(command);
                    break;
                case GameStates.MainGame:
                    MainGameCommands(command, extraInfo);
                    break;
            }
        }

        public static void MainMenuCommands(string command)
        {
            switch (command.ToLower())
            {
                case "new game":
                    Console.Clear();
                    Program.CURRENTGAMESTATE = GameStates.MainGame;
                    ScreenRenderer.Entered = false;
                    ScreenRenderer.EXIT = true;
                    break;
                case "load": // Nothing Right Now
                    break;
                case "music": // Nothing Right Now
                    break;
                case "yes":
                    ScreenRenderer.EXIT = true;
                    break;
                case "no":
                    break;
                default:
                    Console.SetCursorPosition(5, 5);
                    Console.WriteLine(command.ToLower());
                    break;
            }
        }
        public static void IntroSequenceCommands(string command)
        {
            switch (command.ToLower())
            {
                case "start":
                    break;
                case "options":
                    break;
                case "exit":
                    break;
            }
        }
        public static void MainGameCommands(string command, string extraInfo)
        {
            switch (command.ToLower())
            {
                case "look":
                    switch (extraInfo.ToLower())
                    {
                        case "at":
                            break;
                        case "around":
                            break;
                        case "north":
                            break;
                        case "east":
                            break;
                        case "south":
                            break;
                        case "west":
                            break;
                    }
                    //"At", "Around", "North", "East", "South", "West"
                    break;
                case "move":
                    break;
                case "inventory":
                    break;
                case "equipped":
                    break;
                case "options":
                    break;
            }
        }
    }
}
