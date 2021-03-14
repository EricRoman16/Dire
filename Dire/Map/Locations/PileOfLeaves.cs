using Dire.Items.Consumables;
using Dire.Items.Weapons;
using System;
using System.Collections.Generic;

namespace Dire.Map.Locations
{
    public class PileOfLeaves : Locations
    {
        private new string lookedDirectAt = "A high stack of leaves which begs the questions, who stacked them and why? ";
        private new string lookedBrieflyAt = "A pile of leaves ";
        private new string at = "you are at a pile of leaves";

        private static Random dice = new Random();
        private Item[] potentialItems = new Item[] { new Apple(), new Stick(), new Sword() };
        private new List<Item> items = new List<Item>();

        public PileOfLeaves()
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
        public override string ToString() { return "Pile of leaves"; }
    }
}
