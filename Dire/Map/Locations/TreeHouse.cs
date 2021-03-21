using System;
using Dire.Items.Consumables;
using Dire.Items.Weapons;
using System.Collections.Generic;

namespace Dire.Map.Locations
{
    public class TreeHouse : Locations
    {
        private new string lookedDirectAt = "You see an old abandoned treehouse. Feeling a sense of nostalgia, you wonder when was the last time you had entered.";
        private new string lookedBrieflyAt = "A dark and spooky treehouse ";
        private new string at = "You are in a treehouse";

        private static Random dice = new Random();
        private Item[] potentialItems = new Item[] { new Apple(), new Stick(), new Sword() };
        private new List<Item> items = new List<Item>();

        public TreeHouse()
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
        public override string ToString() { return "Treehouse"; }
    }
}
