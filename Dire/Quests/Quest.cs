using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dire.Quests
{
    public class Quest
    {
        Dictionary<int, string> Objectives = new Dictionary<int, string>()
        {
            {0, "Kill 10 Trolls" },
            {1, "Find 2 Sticks" },
            {2, "Talk to Maria" }
        };
        public string Objective;
        
        public Quest()
        {
            
        }

        public static Quest GenerateNewQuest()
        {
            return new Quest();
        }
    }
}
