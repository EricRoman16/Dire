using System.Collections.Generic;

namespace Dire.Map.Locations
{
    public class Location
    {
        public string lookedDirectAt = "Location class - lookedDirectAt"; // for if the character looks directly at
        public string lookedBrieflyAt = "Location class - lookedBrieflyAt"; // if the player looks around for brief desc.
        public string at = "You are in an empty space."; // text for when you're at the location
        public List<Item> items; // items at this location
        public List<Location> SpecialLocations; // items at this location

        public virtual string LookedDirectAt() { return lookedDirectAt; }
        public virtual string LookedBreiflyAt() { return lookedBrieflyAt; }
        public virtual string On() { return at; }
        public virtual List<Item> Items() { return this.items; }
    }
}
