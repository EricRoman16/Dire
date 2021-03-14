using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dire.Scenes
{
    public static class MainMenu
    {
        public static void StartMainMenu()
        {
            DrawMainMenu();
        }

        //⫠⫟⫞⫤⫥⫧⫪⫨⫫⫭⫬⫩⫦⫣|¦‖
        //⫠⫟⫞⫤⫥⫧⫪⫨⫫⫭⫬⫩⫦⫣|¦‖
        //— ⊢⊥⊤⊣⋀⋁▷◁▶◀▲▼
        public static void DrawMainMenu()
        {
                                                                                      Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(@"__________________________________________________"); Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@"        ______  _________ _______  _______        ");
            Console.WriteLine(@"       (  __  \ \__   __/(  ____ )(  ____ \       ");
            Console.WriteLine(@"       | (  \  )   ) (   | (    )|| (    \/       ");
            Console.WriteLine(@"       | |   ) |   | |   | (____)|| (__           ");
            Console.WriteLine(@"       | |   | |   | |   |     __)|  __)          ");
            Console.WriteLine(@"       | |   ) |   | |   | (\ (   | (             ");
            Console.WriteLine(@"       | (__/  )___) (___| ) \ \__| (____/\       ");
            Console.WriteLine(@"       (______/ \_______/|/   \__/(_______/       "); Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(@"__________________________________________________"); Console.ResetColor();
            Console.WriteLine(@"                                                  ");
            TextWriter.WriteLine("                       Play                       ");
            TextWriter.WriteLine("                      Options                     ");
            TextWriter.WriteLine("                       Info                       ");
            TextWriter.WriteLine("                       Exit                       "); Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(@"__________________________________________________"); Console.ResetColor();
            Console.WriteLine(@"                                                  ");
            Console.Write(">");
            string input = Console.ReadLine(); // need to put a readinput function here
        }

        public static void DrawOptionsMenu()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("                      Options                     ");
            Console.WriteLine("==================================================");
            Console.WriteLine("                                                  ");
            Console.WriteLine("                                                  ");
            Console.WriteLine("   +——————————————————————————————————————————+   ");
            Console.WriteLine("   |                   Play                   |   ");
            Console.WriteLine("   |                  Options                 |   ");
            Console.WriteLine("   |                   Info                   |   ");
            Console.WriteLine("   |                   Exit                   |   ");
            Console.WriteLine("   +——————————————————————————————————————————+   ");
            Console.WriteLine("                                                  ");
            Console.WriteLine("==================================================");
            Console.WriteLine("                                                  ");
            Console.Write(">");
            string input = Console.ReadLine(); // need to put a readinput function here
        }

        public static void DrawInfoMenu()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("                       Info                       ");
            Console.WriteLine("==================================================");
            Console.WriteLine("                                                  ");
            Console.WriteLine("                                                  ");
            Console.WriteLine("   +——————————————————————————————————————————+   ");
            Console.WriteLine("   |                   Play                   |   ");
            Console.WriteLine("   |                  Options                 |   ");
            Console.WriteLine("   |                   Info                   |   ");
            Console.WriteLine("   |                   Exit                   |   ");
            Console.WriteLine("   +——————————————————————————————————————————+   ");
            Console.WriteLine("                                                  ");
            Console.WriteLine("==================================================");
            Console.WriteLine("                                                  ");
            Console.Write(">");
            string input = Console.ReadLine(); // need to put a readinput function here
        }
    }
}
