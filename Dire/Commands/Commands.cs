using System;
using System.Collections.Generic;
using System.Linq;

namespace Dire
{
    public static class Commands
    {
        #region Basic Commands
        //Gets brief descriptions of places around the player
        public static void Look(int[] p)
        {
            TextWriter.WriteLine(MAP.GetBriefs(p));
        }
        //Gets descriptions of places in a description specified by the player
        public static void Look(string direction, Player p)
        {
            switch (direction)
            {
                case "forward":
                    TextWriter.WriteLine(MAP.FrontDescription(p.Pos));
                    break;
                case "backward":
                    TextWriter.WriteLine(MAP.BackDescription(p.Pos));
                    break;
                case "right":
                    TextWriter.WriteLine(MAP.RightDescription(p.Pos));
                    break;
                case "left":
                    TextWriter.WriteLine(MAP.LeftDescription(p.Pos));
                    break;
                case "around":
                    DisplayItemsOnGround(p);
                    break;
                default:
                    TextWriter.WriteLine("That's not a valid \"look\" command. Please try again.");
                    break;
            }
        }
        //Moves in the direction specified by the player
        public static void Move(String direction, Player p)
        {
            switch(direction)
            {
                case "forward":
                    try { int i = MAP.world[p.Pos[0] - 1, p.Pos[1]]; p.Pos[0] -= 1; TextWriter.WriteLine("|You went forward.|"); }
                    catch { TextWriter.WriteLine("|You couldn't move forward.|"); }
                    break;
                case "back":
                    try { int i = MAP.world[p.Pos[0] + 1,p.Pos[1]]; p.Pos[0] += 1; TextWriter.WriteLine("|You went back.|"); }
                    catch { TextWriter.WriteLine("|You couldn't move backward.|"); }
                    break;
                case "right":
                    try { int i = MAP.world[p.Pos[0], p.Pos[1] + 1]; p.Pos[1] += 1; TextWriter.WriteLine("|You went right.|"); }
                    catch { TextWriter.WriteLine("|You couldn't move right.|"); }
                    break;
                case "left":
                    try { int i = MAP.world[p.Pos[0], p.Pos[1] - 1]; p.Pos[1] -= 1; TextWriter.WriteLine("|You went left.|"); }
                    catch { TextWriter.WriteLine("|You couldn't move left.|"); }
                    break;
                default:
                    TextWriter.WriteLine("|That's not a valid \"move\" command. Please try again.|");
                    break;
            }
        }
        #endregion
        
        #region Item Handling
        //Picks up an item that is found by the player
        public static bool PickupItem(string s, Player p)
        {
            List<Item> items = MAP.GetItems(p.Pos);
            foreach (Item item in items)
            {
                if (item.ToString().ToLower().Equals(s.ToLower()))
                    p.Inventory.Add(item);
                else
                    return false;
            }
            return true;
        }
        //Shows items on the ground
        public static void DisplayItemsOnGround(Player p)
        {
            List<Item> items = MAP.GetItems(p.Pos);
            int i = 0;
            foreach (Item item in items)
            {
                TextWriter.WriteLine("Item " + i + ":\t\t" + item);
                i++;
            }
        }
        #endregion

        #region Display_Player_Stuff
        //I mean just read the method descriptions
        public static void DisplayEquippedInventory(Player player)
        {
            Console.WriteLine();
            TextWriter.WriteLine(player.Name + "'s Equipment:");
            TextWriter.WriteLine("Weapon 1:\t\t"   + player.Equipment["Weapon 1"]);
            TextWriter.WriteLine("Weapon 2:\t\t"   + player.Equipment["Weapon 2"]);
            TextWriter.WriteLine("Helm:\t\t"     + player.Equipment["Helm"]);
            TextWriter.WriteLine("Chestplate:\t" + player.Equipment["Chest"]);
            TextWriter.WriteLine("Bracer:\t\t"   + player.Equipment["Arms"]);
            TextWriter.WriteLine("Leggings:\t"   + player.Equipment["Legs"]);
            TextWriter.WriteLine("Boots:\t\t"    + player.Equipment["Boots"]);
        }
        public static void DisplayItemInventory(Player player)
        {
            Console.WriteLine();
            TextWriter.WriteLine(player.Name + "'s Backpack:");
            int i = 0;
            foreach (Item item in player.Inventory)
            {
                TextWriter.WriteLine("Item " + i + ":\t\t" + item);
                i++;
            }
        }
        public static void DisplayStats(Player p)
        {
            TextWriter.WriteLine(p.Name + "'s Status");
            foreach(KeyValuePair<string, int> n in p.Stats)
            {
                if(n.Key.Length > 5)
                    TextWriter.WriteLine(n.Key + " :\t" + n.Value);
                else
                    TextWriter.WriteLine(n.Key + " :\t\t" + n.Value);
            }
        }
        #endregion

        #region Help
        public static void DisplaySettings()
        {
            TextWriter.WriteLine("hi");
        }// Not done
        public static void help()
        {
            TextWriter.WriteLine("help:\t\t|Displays a list of all commands.|" +
                "\nlook:\t\t|Displays a brief description of what is at every side of the player.|" +
                "\nmove:\t\t|Moves the player in any direction provided [Example \"move forward\"].|" +
                "\nequipped:\t|Displays what is equiped in the inventory slots.|" +
                "\nexit:\t\t|Closes the game.|");
        }// Not done
        #endregion

    }
}
