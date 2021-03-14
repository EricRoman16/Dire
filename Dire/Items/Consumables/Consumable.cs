using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dire.Items.Consumables
{
    public class Consumable : Item
    {
        public virtual int Consume()
        {
            return 0;
        }
    }
}
