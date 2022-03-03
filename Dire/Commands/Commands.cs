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
                case "start":
                    break;
                case "options":
                    break;
                case "exit":
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
                case "Look":
                    break;
                case "Move":
                    break;
                case "exit":
                    break;
            }
        }
    }
}
