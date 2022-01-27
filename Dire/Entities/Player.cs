using System;
using System.Collections.Generic;

namespace Dire
{
    public class Player
    {
        public enum PlayerStates { Hidden, Seen, Conversation, Exploring, Fighting, Dead};

        public PlayerStates PlayerStatus { get; set; }
        public string Name
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value + " :)";
            }
        }
        public int[] Pos { get; set; }
        public int Age { get; set; }

        public List<Item> Inventory { get; set; }
        public Dictionary<string, int> Stats = new Dictionary<string, int>()
        {
            {"MaxHealth" , 0 },
            {"Health"    , 0 },
            {"Strength"  , 0 },
            {"Defence"   , 0 },
            {"Perception", 0 },
            {"Stealth"   , 0 }
        };
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

        public Player() { }
        public Player(string name, int age, int[] pos, PlayerStates playerstatus)
        {
            Name = name;
            Age = age;
            Pos = pos;
            PlayerStatus = playerstatus;

            Name = "Name";
        }

        public bool TrySneak()
        {
            return false;
        }
        public int Attack()
        {
            return 1;
        }

        private void UpdateStats()
        {

        }

        public bool TypeSetup(string type)
        {
            return false;
        }
    }
}

/*
public class YourClass
{
    private readonly IDictionary<string, string> _yourDictionary = new Dictionary<string, string>();

    public string this[string key]
    {
        // returns value if exists
        get { return _yourDictionary[key]; }

        // updates if exists, adds if doesn't exist
        set { _yourDictionary[key] = value; }
    }
}
*/
/*
public string Name
{
    get
    {
        return Name;
    }
    set
    {
        Name = value + " :)";
    }
}
*/
