using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dire.Scenes.Intro
{
    public static class Intro
    {
        public static Player IntroSequence()
        {
            Introduction();

            return new Player();
        }

        private static void Introduction()
        {
            TextWriter.WriteLine("Welcome to the world!");
            TextWriter.WriteLine("I am the narrator and I'll guide you through the character creator.");
            Console.ReadKey(true);
            //create player
            TextWriter.WriteLine("Amazing! Your lungs fill with new air and you feel the blood flow through you.");
            TextWriter.WriteLine("Now time to give you some ^items^ so you're not fighting bare.");
            Console.ReadKey(true);
            //give items
            TextWriter.WriteLine("Ta-da! You look amazing! Now go, go and fight till you... *DIE*!");
            TextWriter.WriteLine("I can't wait!");
            Console.ReadKey(true);


        }

    }
}
