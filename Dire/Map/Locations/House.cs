using Dire.Items.Consumables;
using Dire.Items.Weapons;
using System;
using System.Collections.Generic;

namespace Dire.Map.Locations
{
    public class House : Location
    {
        //public int ID;
        private readonly new string Name = "House"; 
        private readonly new string LookedDirectAt = "A house stands tall and surprisingly pristine"; // Must not have "." or a space at the end
        private readonly new string LookedBrieflyAt = "A house"; // No punctuation or spaces at the end!
        private readonly new string At = "You are at a house.";// Basically a normal sentence

        private Random dice = new Random();
        private Item[] potentialItems = new Item[] { new Apple(), new Stick(), new Sword() };
        


        public House(int id):base(id)
        {
            base.Name = Name;
            base.LookedBrieflyAt = LookedBrieflyAt;
            base.LookedDirectAt = LookedDirectAt;
            base.At = At;
            base.Items = SetItems();
        }
        private List<Item> SetItems()
        {
            List<Item> temp = new List<Item>();
            foreach(Item i in potentialItems)
            {
                int x = dice.Next(0, 2);
                if (x < 2) // Change probability here
                    temp.Add(i);
            }
            return temp;
        }
        public override string ToString() { return "House"; }
    }
}
