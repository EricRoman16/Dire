using System;

namespace Dire
{
    class Settings
    {
        public static bool NavigationSettingText = true;


        public static void Setup()
        {
            Console.Title = "Dire - Eric Roman  Version: " + Program.version;
            Console.Clear();
        }
        
    }
}
