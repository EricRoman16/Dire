using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dire
{
    public static class AreaWriter
    {
        static int StartLeft = 5;
        static int StartTop = 4;
        static int TextBoxLength = 20;
        static int TextBoxHeight = 5;

        public static void WriteContext(MAP map, int xPos, int yPos)
        {
            ClearTextBox();
            Console.SetCursorPosition(StartLeft, StartTop);
            string text = map.GetAtLocationText(xPos,yPos);
            Console.WriteLine(FormatText(text));
            
        }

        private static string FormatText(string rawText) //gonna format the text given to be perfect to type
        {
            return rawText;
        }

        public static void ClearTextBox()// will loop through the entire text box and clear it
        {
            for(int i = 0; i < TextBoxLength; i++)
            {
                for(int j = 0; j < TextBoxHeight; j++)
                {
                    Console.SetCursorPosition(i + StartLeft, j + StartTop);
                    Console.WriteLine(" ");
                }
            }
        }

    }
}
