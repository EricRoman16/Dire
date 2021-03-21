using System;
using System.Collections.Generic;

namespace Dire
{
    public class Player
    {
        public enum PlayerStates { Hidden, Seen, Conversation, Exploring, Fighting, Dead};

        public PlayerStates PlayerStatus { get; set; }
        public string Name { get; set; }
        public int[] Pos { get; set; }
        public int Age { get; set; }

        public List<Item> Inventory { get; set; }
        public Dictionary<string, int> Stats { get; set; }
        public Dictionary<string, Item> Equipment = new Dictionary<string, Item>()
        {
            {"Weapon 1", null },
            {"Weapon 2", null },
            {"Helm"    , null },
            {"Chest"   , null },
            {"Arms"    , null },
            {"Legs"    , null },
            {"Boots"   , null }
        };
        
        public Player(string name, int age, int[] pos, PlayerStates playerstatus)
        {
            Name = name;
            Age = age;
            Pos = pos;
            PlayerStatus = playerstatus;
        }

        public bool TrySneak()
        {
            UpdateStats();
            if (Stats["Sneak"] < Stats["Detection"])
            {
                Random dice = new Random();
                bool x = (dice.Next(1, 100) / 100 <= Stats["Sneak"] / (Stats["Sneak"] + Stats["Detection"])) ? true : false;
                return x;
            }
            return true;
        }
        public int Attack()
        {
            int dmg = Stats["Strength"];
            //dmg += (Equiped[0] != null) ? Equiped[0].Damage : 0; // might break
            return dmg;
        }

        private void UpdateStats()
        {

        }

        public bool TypeSetup(string type)
        {
            switch (type.Trim().ToLower())
            {
                case "thief":
                    Stats["MaxHealth"] = 10;
                    Stats["Health"] = 10;
                    Stats["Strength"] = 5;
                    Stats["Detection"] = 20;
                    Stats["Stealth"] = 15;
                    Stats["Armor"] = 10;
                    return true;

                case "warrior":
                    Stats["MaxHealth"] = 12;
                    Stats["Health"] = 12;
                    Stats["Strength"] = 12;
                    Stats["Detection"] = 10;
                    Stats["Stealth"] = 5;
                    Stats["Armor"] = 15;
                    return true;

                case "brute":
                    Stats["MaxHealth"] = 20;
                    Stats["Health"] = 20;
                    Stats["Strength"] = 5;
                    Stats["Detection"] = 5;
                    Stats["Stealth"] = 5;
                    Stats["Armor"] = 15;
                    return true;

                default:
                    TextWriter.WriteLine("|That doesn't seem to be an option, please try again.|");
                    break;
            }
            return false;
        }
    }
}
