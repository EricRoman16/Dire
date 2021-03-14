using Dire.Items.Consumables;
using Dire.Items.Weapons;
using System;
using System.Collections.Generic;

namespace Dire.Map.Locations
{
    public class Field : Locations
    {
        private static new string lookedDirectAt = "Large plain field stretches before you. Reminds you of the good days when you could run forever. ";//maybe add an age if()
        private static new string lookedBrieflyAt = "A Large plain field ";
        private new string at = "You are in a field";

        private static Random dice = new Random();
        private Item[] potentialItems = new Item[] { new Apple(), new Stick(), new Sword() };
        private new List<Item> items = new List<Item>();

        public Field()
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
        public override string ToString() { return "Field"; }
    }
}
