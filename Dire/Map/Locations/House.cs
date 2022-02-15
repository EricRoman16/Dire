using Dire.Items.Consumables;
using Dire.Items.Weapons;
using System;
using System.Collections.Generic;

namespace Dire.Map.Locations
{
    public class House : Location
    {
        private static new string lookedDirectAt = "A house stands tall and surprisingly pristine. You wonder what it's doing here. "; // add color as i think imma randomize stuff
        private static new string lookedBrieflyAt = "A house ";
        private new string at = "You are in a house";

        private Random dice = new Random();
        private Item[] potentialItems = new Item[] { new Apple(), new Stick(), new Sword() };
        public new List<Item> items = new List<Item>();

        public House()
        {
            SetItems();
        }
        private void SetItems()
        {
            foreach(Item i in potentialItems)
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
        public override string ToString() { return "House"; }
    }
}
