using Dire.Map.Locations;
using System;
using System.Collections.Generic;

namespace Dire
{
    public class MAP
    {
        #region Variables
        public int[,] RealMap = new int[10, 10];
        private Random dice = new Random();
        List<Location> Locations = new List<Location>();
        int AvailableLocations = 2; //change this based on locations made
        int CurrentAvailableID = 0;

        #endregion

        #region Constructor
        public MAP()
        {
            MAP_GENERATOR();
        }
        #endregion

        #region Methods
        //Just does a quick fill of the entire map to 0's (Might be deleted later)
        private void QuickSetup()
        {
            for(int i = 0; i < RealMap.GetLength(0); i++)
            {
                for (int w = 0; w < RealMap.GetLength(1); w++)
                {
                    RealMap[i, w] = 0;
                    dice.Next();
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
        //Gets the text of the Location at a certain world point (Used for looking in a direction)
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
        //Gets the text for the specified world point location (used for on position)
        public string GetAtLocationText(int xPos, int yPos)
        {
            string s = GetLocationByID(RealMap[xPos, yPos]).On();
            return s;
        }
        //Gets the name of the location at the specified world point
        public string GetLocationName(int xPos, int yPos)
        {
            return GetLocationByID(RealMap[xPos, yPos]).GetName();
        }
        // Not in final form
        private void MAP_GENERATOR()
        {
            int sizeX = RealMap.GetLength(0);
            int sizeY = RealMap.GetLength(1);

            //Fills the RealMap with random numbers corresponding to Locations
            for (int i = 0; i < sizeX; i++)
            {
                for(int j = 0; j < sizeY; j++)
                {
                    int x = dice.Next(AvailableLocations);
                    RealMap[i, j] = x;
                }
            }

            //Refactoring RealMap to comply with map rules


            //This will set all object Locations!!! ~ Should do last
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    switch (RealMap[i, j])
                    {
                        case 0:

                            RealMap[i, j] = CurrentAvailableID;
                            Locations.Add(new Forest(CurrentAvailableID));
                            CurrentAvailableID++;
                            break;
                        case 1:
                            RealMap[i, j] = CurrentAvailableID;
                            Locations.Add(new House(CurrentAvailableID));
                            CurrentAvailableID++;
                            break;
                        case 2:
                            RealMap[i, j] = CurrentAvailableID;
                            Locations.Add(new Forest(CurrentAvailableID)); //change object to location
                            CurrentAvailableID++;
                            break;
                        case 3:
                            RealMap[i, j] = CurrentAvailableID;
                            Locations.Add(new Forest(CurrentAvailableID)); //change object to location
                            CurrentAvailableID++;
                            break;
                        default:
                            break;
                    }
                    
                }
            }
            
            
        }

        #endregion

        /* Notes:
         * 
         * Location Codes:
         * 0 = null
         * 1 = House ~ 2
         * 2 = Lake ~ 3
         * 3 = Plains / Field
         * 4 = Temple
         * 5 = Dungeon
         * 6 = Forest
         * 
         * 
         * ~ = how many there can be in the map
         */



    }// end of MAP
}
