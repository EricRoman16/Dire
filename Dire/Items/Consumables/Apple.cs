using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dire.Items.Consumables
{
    public class Apple : Consumable
    {
        int addedHealth = 5;
        public override int Consume()
        {
            return addedHealth;
        }
        public override string ToString()
        {
            return "Apple";
        }
    }
}
