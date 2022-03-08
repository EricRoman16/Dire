using Dire.Map.Locations;
using System;
using System.Collections.Generic;

namespace Dire
{
    public class MAP
    {
        #region Variables
        int[,] RealMap = new int[10, 10];
        List<Location> Locations = new List<Location>();


        #endregion



        public MAP()
        {
            QuickSetup();
        }

        private void QuickSetup()
        {
            for(int i = 0; i < RealMap.GetLength(0); i++)
            {
                for (int w = 0; w < RealMap.GetLength(1); w++)
                {
                    RealMap[i, w] = 0;
                }
            }
        }

        //Goes through Locations list to find a location with the searchID (returns null if not found)
        private Location GetLocationByID(int searchID)
        {
            foreach(Location loc in Locations)
            {
                if (loc.ID == searchID)
                    return loc;
            }
            return null;
        }
        //Gets the text of the Location at a certain world point
        public string GetLocationText(string direction, int xPos, int yPos)
        {
            string s = "";
            switch (direction)
            {
                case "North":
                    try
                    {
                        s = GetLocationByID(RealMap[xPos, yPos - 1]).GetLookedDirectAt();
                    }
                    catch (Exception)
                    {
                        s = "Nothing is over there.";
                    }
                    break;
                case "East":
                    try
                    {
                        s = GetLocationByID(RealMap[xPos + 1, yPos]).GetLookedDirectAt();
                    }
                    catch (Exception)
                    {
                        s = "Nothing is over there.";
                    }
                    break;
                case "South":
                    try
                    {
                        s = GetLocationByID(RealMap[xPos, yPos + 1]).GetLookedDirectAt();
                    }
                    catch (Exception)
                    {
                        s = "Nothing is over there.";
                    }
                    break;
                case "West":
                    try
                    {
                        s = GetLocationByID(RealMap[xPos - 1, yPos]).GetLookedDirectAt();
                    }
                    catch (Exception)
                    {
                        s = "Nothing is over there.";
                    }
                    break;
                case "Brief":
                    s = GetBriefLocationText(xPos, yPos);
                    break;
            }
            if (direction.ToLower() != "brief")
                s += $"to the {direction}.";
            return s;
        }
        //Gets brief text of all locations around players location
        private string GetBriefLocationText(int xPos, int yPos)
        {
            string s = "";
            s += $"{GetLocationByID(RealMap[xPos, yPos - 1]).GetLookedBreiflyAt()} to the North.";
            s += $"{GetLocationByID(RealMap[xPos + 1, yPos]).GetLookedBreiflyAt()} to the East.";
            s += $"{GetLocationByID(RealMap[xPos, yPos + 1]).GetLookedBreiflyAt()} to the South.";
            s += $"{GetLocationByID(RealMap[xPos - 1, yPos]).GetLookedBreiflyAt()} to the West.";
            return s;
        }
        //Gets the text for the specified world point location
        public string GetAtLocationText(int xPos, int yPos)
        {
            string s = GetLocationByID(RealMap[xPos, yPos]).On();
            return s;
        }
        

        // Not in final form
        private void MAP_GENERATOR(Location[,] map)
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



        /* Notes:
         * 
         * Location Codes:
         * 0 = null
         * 1 = House
         * 2 = Lake
         * 3 = Plains / Field
         * 4 = Temple
         * 5 = Dungeon
         * 6 = Forest
         * 
         */ 



    }// end of MAP
}
