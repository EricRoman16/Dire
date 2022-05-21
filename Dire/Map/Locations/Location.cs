using System.Collections.Generic;

namespace Dire.Map.Locations
{
    public abstract class Location
    {
        public int ID;
        protected string Name;
        protected string LookedDirectAt = "Location class - lookedDirectlyAt"; // for if the character looks directly at
        protected string LookedBrieflyAt = "Location class - lookedBrieflyAt"; // if the player looks around for brief desc.
        protected string At = "You are in an empty space."; // text for when you're at the location
        protected List<Item> Items; // items at this location
        private List<Location> SpecialLocations; // items at this location

        public Location(int id)
        {
            ID = id;
        }
        public string GetName() { return Name; }
        public string GetLookedDirectAt() { return LookedDirectAt; }
        public string GetLookedBreiflyAt() { return LookedBrieflyAt; }
        public string On() { return At; }
        public List<Item> GetItems() { return Items; }
    }
}
