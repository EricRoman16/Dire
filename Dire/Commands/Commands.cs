using System;
using System.Collections.Generic;
using System.Linq;

namespace Dire
{
    public static class Commands
    {
        static ConsoleKeyInfo InputKey;
        public static void GetInput()
        {
            InputKey = Console.ReadKey();

            if(InputKey.Key == ConsoleKey.Enter)
            {
                //might need to add something here because you might have another menu when pressing enter
                //will need to get the selection numbers to pass to the functions
                switch (Program.CURRENTGAMESTATE)
                {
                    case GameStates.MainMenu:
                        //MainMenuCommands(command);
                        break;
                    case GameStates.IntroSequence:
                        //IntroSequenceCommands(command);
                        break;
                    case GameStates.MainGame:
                        //MainGameCommands(command, extraInfo);
                        break;
                }
                return;
            }

            switch (InputKey.Key)
            {
                case ConsoleKey.UpArrow:
                    //Make selections go up
                    break;
                case ConsoleKey.DownArrow:
                    //Make selections go down
                    break;
                default:
                    break;
            }
        }

        public static void MainMenuCommands(string command)
        {
            switch (command.ToLower())
            {
                case "new game":
                    
                    break;
                case "load": // Nothing Right Now
                    break;
                case "music": // Nothing Right Now
                    break;
                case "yes":
                    
                    break;
                case "no":
                    break;
                default:
                    //Console.SetCursorPosition(5, 5);
                    //Console.WriteLine(command.ToLower());
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
