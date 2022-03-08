using Dire.Items.Consumables;
using Dire.Items.Weapons;
using System;
using System.Collections.Generic;

namespace Dire.Map.Locations
{
    public class House : Location
    {
        public override int ID { get; }
        private static string lookedDirectAt = "A house stands tall and surprisingly pristine"; // Must not have "." or a space at the end
        private static string lookedBrieflyAt = "A house"; // No punctuation or spaces at the end!
        private string at = "You are at a house.";// Basically a normal sentence

        private Random dice = new Random();
        private Item[] potentialItems = new Item[] { new Apple(), new Stick(), new Sword() };
        public List<Item> Items = new List<Item>();


        public House()
        {
            SetItems();
            //ID = 5;
        }
        private void SetItems()
        {
            foreach(Item i in potentialItems)
            {
                int x = dice.Next(0, 2);
                if (x == 1)
                    Items.Add(i);
            }
        }
        public override string GetLookedDirectAt() { return lookedDirectAt; }
        public override string GetLookedBreiflyAt() { return lookedBrieflyAt; }
        public override string On() { return at; }
        public override string ToString() { return "House"; }
    }
}
