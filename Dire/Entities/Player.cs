using System;
using System.Collections.Generic;

namespace Dire
{
    public class Player
    {
        //--------------------------------------------------Position-----------------------------------------------
        public int[] Pos = new int[2] { 2, 2 };

        //---------------------------------------------------Stats-------------------------------------------------
        public Dictionary<string, int> Stats = new Dictionary<string, int>();
        public enum PlayerStates { Hidden, Seen, Conversation, Exploring, Fighting, Dead};

        public PlayerStates playerStatus = PlayerStates.Exploring;
        public string name = "Test";
        public int age = 0;

        public List<Item> Inventory = new List<Item>();
        // weapon 1, helm, armor, arms, legs, boots,
        public List<Item> Equiped = new List<Item>();

        public Player(string n, int a)
        {
            name = n;
            age = a;
            Setup();
        }
        public Player()
        {
            Setup();
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
        private void Setup()
        {
            Stats.Add("Level", 0);
            Stats.Add("MaxHealth", 0);
            Stats.Add("Health", 1);
            Stats.Add("Strength", 0);
            Stats.Add("Detection", 0);
            Stats.Add("Sneak", 0);
            Stats.Add("Armor", 0);

            for (int i = 0; i < 6; i++)
                Equiped.Add(new Item());
        }
    }
}
