using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dire
{
    class TypeDisplayer
    {
        public static void DisplayThief()
        {
            TextWriter.WriteLine("Thief: ");
            TextWriter.WriteLine("\tMaxHealth = 10");
            TextWriter.WriteLine("\tHealth    = 10");
            TextWriter.WriteLine("\tStrength  = 5 ");
            TextWriter.WriteLine("\tDetection = 20");
            TextWriter.WriteLine("\tSneak     = 15");
            TextWriter.WriteLine("\tArmor     = 10");
            Console.WriteLine();
        }
        public static void DisplayWarrior()
        {
            TextWriter.WriteLine("Warrior: ");
            TextWriter.WriteLine("\tMaxHealth = 12");
            TextWriter.WriteLine("\tHealth    = 12");
            TextWriter.WriteLine("\tStrength  = 12");
            TextWriter.WriteLine("\tDetection = 10");
            TextWriter.WriteLine("\tSneak     = 5 ");
            TextWriter.WriteLine("\tArmor     = 15");
            Console.WriteLine();
        }
        public static void DisplayBrute()
        {
            TextWriter.WriteLine("Brute: ");
            TextWriter.WriteLine("\tMaxHealth = 20");
            TextWriter.WriteLine("\tHealth    = 20");
            TextWriter.WriteLine("\tStrength  = 5 ");
            TextWriter.WriteLine("\tDetection = 5 ");
            TextWriter.WriteLine("\tSneak     = 5 ");
            TextWriter.WriteLine("\tArmor     = 15");
            Console.WriteLine();
        }
    }
}
