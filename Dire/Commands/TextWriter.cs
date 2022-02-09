using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Dire
{
    public static class TextWriter
    {
        private enum TextMode { Bad, Good, Selected, Normal };
        private static TextMode CurrentTextMode = TextMode.Normal;
        private static bool Special = false; // dont worry about this it's just used here

        public static void WriteLine(string input)
        {
            for (int i = 0; i < input.Length; ++i)
            {
                if (input[i].ToString().Equals("*")) // Red color uses "*"
                {
                    if (CurrentTextMode == TextMode.Bad)
                        CurrentTextMode = TextMode.Normal;
                    else
                        CurrentTextMode = TextMode.Bad;
                    goto End;
                }
                if (input[i].ToString().Equals("^")) // Green color uses "^"
                {
                    if (CurrentTextMode == TextMode.Good)
                        CurrentTextMode = TextMode.Normal;
                    else
                        CurrentTextMode = TextMode.Good;
                    goto End;
                }
                if (input[i].ToString().Equals("|")) // Dark Gray color uses "|"
                {
                    if (CurrentTextMode == TextMode.Selected)
                        CurrentTextMode = TextMode.Normal;
                    else
                        CurrentTextMode = TextMode.Selected;
                    goto End;
                }

                switch (CurrentTextMode)
                {
                    case TextMode.Normal:
                        Console.Write("\x1b[38;2;" + 127 + ";" + 127 + ";" + 127 + "m" + $"{input[i]}");
                        break;
                    case TextMode.Bad:
                        Console.Write("\x1b[38;2;" + 255 + ";" + 0 + ";" + 0 + "m" + $"{input[i]}");
                        break;
                    case TextMode.Good:
                        Console.Write("\x1b[38;2;" + 0 + ";" + 255 + ";" + 0 + "m" + $"{input[i]}");
                        break;
                    case TextMode.Selected:
                        Console.Write("\x1b[38;2;" + 50 + ";" + 50 + ";" + 50 + "m" + $"{input[i]}");
                        break;
                    default:
                        break;
                }
                Thread.Sleep(20);

                if (input[i].ToString().Equals(".") || input[i].ToString().Equals("!") || input[i].ToString().Equals("?"))
                {
                    Thread.Sleep(400);
                }
                else if (input[i].ToString().Equals(",")) // smaller pause after commas
                {
                    Thread.Sleep(200);
                }
            End:;
            }
            CurrentTextMode = TextMode.Normal;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }


        public static void WriteLines(string input)
        {
            for (int i = 0; i < input.Length; ++i)
            {                
                //Pauses after sentences
                if (input[i].ToString().Equals(".") || input[i].ToString().Equals("!") || input[i].ToString().Equals("?"))
                {
                    Console.Write("\x1b[38;2;" + 127 + ";" + 127 + ";" + 127 + "m" + $"{input[i]}");
                    Thread.Sleep(400);
                }
                else if (input[i].ToString().Equals(",")) // smaller pause after commas
                {
                    Console.Write("\x1b[38;2;" + 127 + ";" + 127 + ";" + 127 + "m" + $"{input[i]}");
                    Thread.Sleep(200);
                }
                else if (input[i].ToString().Equals("*")) // Red color uses "*"
                {
                    if (!Special)
                        Console.Write("\x1b[38;2;" + 255 + ";" + 0 + ";" + 0 + "m" + $"{input[i]}");
                    if (Special)
                        Console.ResetColor();
                    Special = !Special;
                }
                else if (input[i].ToString().Equals("^")) // Green color uses "^"
                {
                    if (!Special)
                        Console.Write("\x1b[38;2;" + 0 + ";" + 255 + ";" + 0 + "m" + $"{input[i]}");
                    if (Special)
                        Console.ResetColor();
                    Special = !Special;
                }
                else if (input[i].ToString().Equals("|")) // Dark Gray color uses "|"
                {
                    if (!Special)
                        Console.Write("\x1b[38;2;" + 127 + ";" + 127 + ";" + 127 + "m" + $"{input[i]}");
                    if (Special)
                        Console.ResetColor();
                    Special = !Special;
                }
                else // Very small delay to make it look typed
                {
                    //Console.Write(input[i]);
                    Console.Write("\x1b[38;2;" + 127 + ";" + 127 + ";" + 127 + "m" + $"{input[i]}");
                    Thread.Sleep(20);
                }
            }
            Console.WriteLine();
        }
    /*
     The reason this isnt working is because it's not setting console color
    so only one character will get the color because "special" isnt being used correctly
     
     */
    }
}
