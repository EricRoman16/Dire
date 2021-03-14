using System;
using System.Collections.Generic;

namespace Dire
{
    class ReadInput
    {
        public static bool Decifer(String input, Player p)
        {
            Console.WriteLine();
            string[] cmd = input.Split();

            switch (cmd[0])
            {
                case "look":
                    try { Commands.Look(cmd[1], p); }
                    catch { TextWriter.WriteLine(MAP.GetBriefs(p.Pos)); }
                    break;

                case "move":
                    try { Commands.Move(cmd[1], p); }
                    catch { TextWriter.WriteLine("Please specify where to move."); }
                    return true;
                     
                case "go":
                    try { Commands.Move(cmd[1], p); }
                    catch { TextWriter.WriteLine("Please specify where to move."); }
                    return true;

                case "equipped":
                    Commands.DisplayEquippedInventory(p);
                    break;

                case "inventory":
                    Commands.DisplayItemInventory(p);
                    break;

                case "pickup":
                    bool a = false;
                    try { a = Commands.PickupItem(cmd[1], p); }
                    catch { TextWriter.WriteLine("Please specify what to pickup."); }
                    if (a) { TextWriter.WriteLine("|Collected : " + cmd[1] + "|"); return true; }
                    else try { TextWriter.WriteLine("|Could not find : " + cmd[1] + "|"); } catch { }
                    break;

                case "get":
                    bool b = false;
                    try { b = Commands.PickupItem(cmd[1], p); }
                    catch { TextWriter.WriteLine("Please specify what to get."); }
                    if (b) { TextWriter.WriteLine("|Collected : " + cmd[1] + "|"); return true; }
                    else try { TextWriter.WriteLine("|Could not find : " + cmd[1] + "|"); } catch { }
                    break;

                case "stats":
                    Commands.DisplayStats(p);
                    break;

                case "help":
                    Commands.help();
                    break;

                case "exit":
                    GameLoops.Exit();
                    return true;

                default:
                    TextWriter.WriteLine("That command doesn't work. Please try again.");
                    break;
            }
            return false;
        }
    }
}
