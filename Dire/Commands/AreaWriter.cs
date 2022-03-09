using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dire
{
    public static class AreaWriter
    {

        public static void WriteContext(MAP map, int xPos, int yPos)
        {
            string text = map.GetAtLocationText(xPos,yPos);
            Console.WriteLine(text);
        }

    }
}
