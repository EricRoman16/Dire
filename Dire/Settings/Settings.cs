﻿using System;

namespace Dire
{
    class Settings
    {
        public static void Setup()
        {
            Console.Title = "Dire - Eric Roman ~ Version: " + Program.version;
            //Console.SetWindowSize(100, 30);
            Console.Clear();
        }
        
    }
}
