using System;

namespace Dire
{
    public class Item
    {
        

        public void Use()
        {
            Console.WriteLine("-Used from Item class-");
        }
        public override string ToString()
        {
            return "none";
        }
    }
}