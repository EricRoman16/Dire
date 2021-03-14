using System;

namespace Dire
{
    class Settings
    {
        public static bool NavigationSettingText = true;


        public static void Setup()
        {
            GameStates CURRENTGAMESTATE = GameStates.Start;
            Console.Title = "Dire - Eric Roman  Version: " + Program.version;
            MAP.FillMap();
            Console.Clear();
        }
        public static Player NewCharacter(Player p)
        {
            p = GetPlayerInfo(p);
            SetType(p);
            Console.Clear();
            return p;
        }
        public static Player SetType(Player p)
        {
            while (true)
            {
                TextWriter.WriteLine("Please choose one of these: ");
                TypeDisplayer.DisplayThief();
                TypeDisplayer.DisplayWarrior();
                TypeDisplayer.DisplayBrute();
                Console.Write("> ");
                string i = Console.ReadLine();
                bool x = p.TypeSetup(i);
                if (x)
                    break;
                Console.Clear();
            }
            return p;
        }
        public static Player GetPlayerInfo(Player p)
        {
            TextWriter.WriteLine("What is your characters name?");
            Console.Write("> ");
            string n = Console.ReadLine();
            Console.Clear();
            int a = 0;
            while (a == 0)
            {
                TextWriter.WriteLine("What is their age?");
                Console.Write("> ");
                try { a = Convert.ToInt16(Console.ReadLine()); }
                catch { Console.Clear(); TextWriter.WriteLine("That's not a number, please try again."); }
            }
            p = new Player(n.Trim(), a);
            Console.Clear();
            return p;
        }
        public static void SaveGame(Player p)
        {
            //p.GetSaveData();
            //
            FileReader.Write("\n||Second test||");
        }
    }
}
