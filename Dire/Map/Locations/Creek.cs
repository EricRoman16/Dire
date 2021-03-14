using Dire.Items.Consumables;
using Dire.Items.Weapons;
using System;
using System.Collections.Generic;

namespace Dire.Map.Locations
{
    public class Creek : Locations
    {
        private static new string lookedDirectAt = "A tiny creak that stretches a fair amount. The water must be so refreshing. ";
        private static new string lookedBrieflyAt = "A tiny creak ";
        private new string at = "You are at a creek";

        private static Random dice = new Random();
        private Item[] potentialItems = new Item[] { new Apple(), new Stick(), new Sword()};
        private new List<Item> items = new List<Item>();

        public Creek()
        {
            SetItems();
        }
        private void SetItems()
        {
            foreach (Item i in potentialItems)
            {
                int x = dice.Next(0, 2);
                if (x == 1)
                    items.Add(i);
            }
        }
        public override string LookedDirectAt() { return lookedDirectAt; }
        public override string LookedBreiflyAt() { return lookedBrieflyAt; }
        public override string On() { return at; }
        public override List<Item> Items() { return items; }
        public override string ToString() { return "Creek"; }
    }
}
