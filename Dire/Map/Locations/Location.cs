using System.Collections.Generic;

namespace Dire.Map.Locations
{
    public class Location
    {
        private string lookedDirectAt = "Location class - lookedDirectAt"; // for if the character looks directly at
        private string lookedBrieflyAt = "Location class - lookedBrieflyAt"; // if the player looks around for brief desc.
        private string at = "You are in an empty space."; // text for when you're at the location
        private List<Item> items; // items at this location
        private List<Location> SpecialLocations; // items at this location

        public virtual string LookedDirectAt() { return lookedDirectAt; }
        public virtual string LookedBreiflyAt() { return lookedBrieflyAt; }
        public virtual string On() { return at; }
        public virtual List<Item> Items() { return items; }
    }
}
