using System.Collections.Generic;

namespace Dire.Map.Locations
{
    public abstract class Location
    {
        public abstract int ID { get; }
        private string LookedDirectAt = "Location class - lookedDirectlyAt"; // for if the character looks directly at
        private string LookedBrieflyAt = "Location class - lookedBrieflyAt"; // if the player looks around for brief desc.
        private string at = "You are in an empty space."; // text for when you're at the location
        private List<Item> items; // items at this location
        private List<Location> SpecialLocations; // items at this location

        public virtual string GetLookedDirectAt() { return LookedDirectAt; }
        public virtual string GetLookedBreiflyAt() { return LookedBrieflyAt; }
        public virtual string On() { return at; }
        public virtual List<Item> Items() { return items; }
    }
}
