using System;
using System.Collections.Generic;
using System.Linq;

namespace Dire
{
    public static class Commands
    {
        #region Basic Commands
        public static void Look(int[] p)
        {
            string w = MAP.GetBriefs(p);
            TextWriter.WriteLine(w);
            //eventually will say brief desc about what's around
        }

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
        public static void DisplayEquippedInventory(Player player)
        {
            Console.WriteLine();
            TextWriter.WriteLine(player.name + "'s Equipment:");
            TextWriter.WriteLine("Weapon:\t\t"   + player.Equiped[0].ToString());
            TextWriter.WriteLine("Helm:\t\t"     + player.Equiped[1].ToString());
            TextWriter.WriteLine("Chestplate:\t" + player.Equiped[2].ToString());
            TextWriter.WriteLine("Bracer:\t\t"   + player.Equiped[3].ToString());
            TextWriter.WriteLine("Leggings:\t"   + player.Equiped[4].ToString());
            TextWriter.WriteLine("Boots:\t\t"    + player.Equiped[5].ToString());
        }
        public static void DisplayItemInventory(Player player)
        {
            Console.WriteLine();
            TextWriter.WriteLine(player.name + "'s Backpack:");
            int i = 0;
            foreach (Item item in player.Inventory)
            {
                TextWriter.WriteLine("Item " + i + ":\t\t" + item);
                i++;
            }
        }
        public static void DisplayStats(Player p)
        {
            TextWriter.WriteLine(p.name + "'s Status");
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
