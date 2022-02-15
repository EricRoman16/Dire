using Dire.Map.Locations;
using System;
using System.Collections.Generic;

namespace Dire
{
    public class MAP
    {
        public Location[,] RealMap = new Location[10, 10];

        public void callingFunctions(string s)
        {
            foreach(Location loc in RealMap)
            {
                //loc.createPositions();
            }
            
        }


        public static void MAP_GENERATOR(int sizeX, int sizeY)
        {
            //creating the temporary map to generate onto
            int[,] tmpMap = new int[sizeX,sizeY];
            //using a for loop to set all numbers to 0
            for(int i = 0; i < sizeX; i++)
            {
                for(int j = 0; j < sizeY; j++)
                {
                    tmpMap[i, j] = 0;
                }
            }

            //need to create an algorithm to make the map
        }


    }// end of MAP
}
