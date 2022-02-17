using Dire.Map.Locations;
using System;
using System.Collections.Generic;

namespace Dire
{
    public class MAP
    {
        // This will be an object that holds a map inside of it


        public Location[,] RealMap = new Location[10, 10];

        public void callingFunctions(string s)
        {
            foreach(Location loc in RealMap)
            {
                //loc.createPositions();
                
            }
            
        }

        
        public string getLocationText(string direction, int xPos, int yPos)
        {
            string s = "";
            switch (direction)
            {
                case "North":
                    try
                    {
                        s = RealMap[xPos, yPos - 1].LookedDirectAt();
                    }
                    catch (Exception)
                    {
                        s = "Nothing is over there.";
                    }
                    break;
                case "East":
                    try
                    {
                        s = RealMap[xPos + 1, yPos].LookedDirectAt();
                    }
                    catch (Exception)
                    {
                        s = "Nothing is over there.";
                    }
                    break;
                case "South":
                    try
                    {
                        s = RealMap[xPos, yPos + 1].LookedDirectAt();
                    }
                    catch (Exception)
                    {
                        s = "Nothing is over there.";
                    }
                    break;
                case "West":
                    try
                    {
                        s = RealMap[xPos - 1, yPos].LookedDirectAt();
                    }
                    catch (Exception)
                    {
                        s = "Nothing is over there.";
                    }
                    break;
                case "Brief":
                    break;
            }
            if (direction.ToLower() != "brief")
                s += $"to the {direction}.";
            return s;
        }
        public string getBriefLocationText(int xPos, int yPos) // Might need to redo this to make it more reader friendly
        {
            string s = "";
            s += $"{RealMap[xPos, yPos - 1].LookedBreiflyAt()} to the North.";
            s += $"{RealMap[xPos + 1, yPos].LookedBreiflyAt()} to the East.";
            s += $"{RealMap[xPos, yPos + 1].LookedBreiflyAt()} to the South.";
            s += $"{RealMap[xPos - 1, yPos].LookedBreiflyAt()} to the West.";
            return s;
        }
        public string getAtLocationText(int xPos, int yPos)
        {
            string s = RealMap[xPos, yPos].On();
            return s;
        }
        

        // Not in final form
        public void MAP_GENERATOR(Location[,] map)
        {
            //creating the temporary map to generate onto
            int sizeX = map.GetLength(0);
            int sizeY = map.GetLength(1);
            int[,] tmpMap = new int[sizeX,sizeY];
            Random dice = new Random();
            //using a for loop to set all numbers to 0
            for (int i = 0; i < sizeX; i++)
            {
                for(int j = 0; j < sizeY; j++)
                {
                    int x = dice.Next(4);
                    x = 0; //remove this to not make everything a house
                    tmpMap[i, j] = x;
                }
            }
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    switch (tmpMap[i, j])
                    {
                        case 0:
                            map[i, j] = new House();
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        default:
                            break;
                    }
                    
                }
            }
            
            
        }


    }// end of MAP
}
