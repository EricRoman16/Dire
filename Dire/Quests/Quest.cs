using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dire.Quests
{
    public class Quest
    {
        public string Description { get; set; }
        
        
        public Quest(string description)
        {
            Description = description;
        }
    }
}
