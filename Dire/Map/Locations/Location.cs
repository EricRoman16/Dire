using System.Collections.Generic;

namespace Dire.Map.Locations
{
    public class Location
    {
        public string lookedDirectAt = "Location class - lookedDirectAt";
        public string lookedBrieflyAt = "Location class - lookedBrieflyAt";
        public string at = "location thing";
        public List<Item> items;
        public virtual string LookedDirectAt() { return lookedDirectAt; }
        public virtual string LookedBreiflyAt() { return lookedBrieflyAt; }
        public virtual string On() { return at; }
        public virtual List<Item> Items() { return items; }
    }
}
