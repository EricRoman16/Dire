using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dire.Items.Consumables
{
    public class Cookie : Consumable
    {
        int addedHealth = 3;
        public override int Consume()
        {
            return addedHealth;
        }
        public override string ToString()
        {
            return "Cookie";
        }
    }
}
