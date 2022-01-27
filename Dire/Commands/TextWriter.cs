using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Dire
{
    public static class TextWriter
    {
        private static bool Special = false; // dont worry about this it's just used here
        public static void WriteLine(string input)
        {
            for (int i = 0; i < input.Length; ++i)
            {                
                //Pauses after sentences
                if (input[i].ToString().Equals(".") || input[i].ToString().Equals("!") || input[i].ToString().Equals("?"))
                {
                    Console.Write(input[i]);
                    Thread.Sleep(400);
                }
                else if (input[i].ToString().Equals(",")) // smaller pause after commas
                {
                    Console.Write(input[i]);
                    Thread.Sleep(200);
                }
                else if (input[i].ToString().Equals("*")) // Red color uses "*"
                {
                    if (!Special)
                        Console.ForegroundColor = ConsoleColor.Red;
                    if (Special)
                        Console.ResetColor();
                    Special = !Special;
                }
                else if (input[i].ToString().Equals("^")) // Green color uses "^"
                {
                    if (!Special)
                        Console.ForegroundColor = ConsoleColor.Green;
                    if (Special)
                        Console.ResetColor();
                    Special = !Special;
                }
                else if (input[i].ToString().Equals("|")) // Dark Gray color uses "|"
                {
                    if (!Special)
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (Special)
                        Console.ResetColor();
                    Special = !Special;
                }
                else // Very small delay to make it look typed
                {
                    Console.Write(input[i]);
                    Thread.Sleep(20);
                }
            }
            Console.WriteLine();
        }
    }
}
