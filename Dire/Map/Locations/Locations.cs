using System.Collections.Generic;

namespace Dire.Map.Locations
{
    public class Locations
    {
        public string lookedDirectAt = "Locations class - lookedDirectAt";
        public string lookedBrieflyAt = "Locations class - lookedBrieflyAt";
        public string at = "locations thing";
        public List<Item> items;
        public virtual string LookedDirectAt() { return lookedDirectAt; }
        public virtual string LookedBreiflyAt() { return lookedBrieflyAt; }
        public virtual string On() { return at; }
        public virtual List<Item> Items() { return items; }
    }
}
