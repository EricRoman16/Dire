using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Dire
{
    public static class TextWriter
    {
        public static bool Special = false;
        public static void WriteLine(string input)
        {
            for (int i = 0; i < input.Length; ++i)
            {                
                if (input[i].ToString().Equals(".") || input[i].ToString().Equals("!") || input[i].ToString().Equals("?"))
                {
                    Console.Write(input[i]);
                    Thread.Sleep(400);
                }
                else if (input[i].ToString().Equals(","))
                {
                    Console.Write(input[i]);
                    Thread.Sleep(200);
                }
                else if (input[i].ToString().Equals("*"))
                {
                    if (!Special)
                        Console.ForegroundColor = ConsoleColor.Red;
                    if (Special)
                        Console.ResetColor();
                    Special = !Special;
                }
                else if (input[i].ToString().Equals("^"))
                {
                    if (!Special)
                        Console.ForegroundColor = ConsoleColor.Green;
                    if (Special)
                        Console.ResetColor();
                    Special = !Special;
                }
                else if (input[i].ToString().Equals("|"))
                {
                    if (!Special)
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (Special)
                        Console.ResetColor();
                    Special = !Special;
                }
                else
                {
                    Console.Write(input[i]);
                    Thread.Sleep(20);
                }
            }
            Console.WriteLine();
        }
    }
}
