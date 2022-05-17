using System;
using System.Collections.Generic;

namespace Dire
{
    class ReadInput
    {
        /*void ReadKeyPresses(string[][] array)
        {
            Console.WriteLine();
            //Console.WriteLine("press down arrow keys!");
            while (!EXIT)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.LeftArrow: // this will close secondary options 
                        Entered = false;
                        SecondSelected = 0;
                        StartRender();
                        break;
                    case ConsoleKey.RightArrow: // this will open up secondary options
                        Entered = true;
                        StartRender();
                        break;
                    case ConsoleKey.UpArrow: // this will go up in the list of options
                        if (!Entered && MainSelected > 0) MainSelected--; else if (Entered && SecondSelected > 0) SecondSelected--;
                        StartRender();
                        break;
                    case ConsoleKey.DownArrow: // this will go down in the list of options [Need to make bounds for selected]
                        int tmp = array[MainSelected].Length;
                        if (!Entered && MainSelected < array.GetLength(0) - 1) MainSelected++; else if (Entered && SecondSelected < tmp - 2) SecondSelected++;
                        StartRender();
                        break;
                    case ConsoleKey.Enter: // see right arrow
                        if (Entered) Enter();
                        StartRender();
                        break;
                    case ConsoleKey.Escape: // see left arrow
                        Entered = false;
                        SecondSelected = 0;
                        StartRender();
                        break;
                    case ConsoleKey.Y: // This hides/shows the options
                        Showing = !Showing;
                        MainSelected = 0;
                        SecondSelected = 0;
                        Entered = false;
                        StartRender();
                        break;
                    case ConsoleKey.W: // This auto switches to normal options
                        MainSelected = 0;
                        SecondSelected = 0;
                        Entered = false;
                        StartRender();
                        break;
                    default:
                        break;
                }
            }

        }
        void Enter()
        {
            //Console.SetCursorPosition(5, 5);
            //Console.WriteLine(MainMenuSelections[MainSelected][SecondSelected]);
            if (Program.CURRENTGAMESTATE == GameStates.MainGame)
                Commands.CommandEnter(MainMenuSelections[MainSelected][0], MainMenuSelections[MainSelected][SecondSelected + 1]);
            if (Program.CURRENTGAMESTATE == GameStates.MainMenu)
                Commands.CommandEnter(MainMenuSelections[MainSelected][SecondSelected + 1]);

            // Will send X to the commands class to get processed
        }*/
    }
}
