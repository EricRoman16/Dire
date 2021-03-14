using Dire.Map.Locations;
using System;
using System.Collections.Generic;

namespace Dire
{
    public static class MAP
    {
        // Locations array for the instances of locations
        public static Locations[,] realWorld = new Locations[5, 5];
        // Referance array [ change this to change map ]
        public static int[,] world = new int[5, 5]
        {
            { 1, 1, 2, 2, 1},
            { 0, 1, 3, 2, 2},
            { 2, 5, 1, 4, 1},
            { 4, 2, 0, 2, 2},
            { 0, 1, 0, 2, 1}
        };

        // Gets the brief descriptions of all directions
        public static string GetBriefs(int[] p)
        {
            string write = "You see ";
            try { write += realWorld[p[0] - 1, p[1]].LookedBreiflyAt(); }
            catch { write += "void "; }
            write += "in front of you. ";

            try { write += realWorld[p[0], p[1] + 1].LookedBreiflyAt(); }
            catch { write += "void "; }
            write += "to your right.\n";

            try { write += realWorld[p[0] + 1, p[1]].LookedBreiflyAt(); }
            catch { write += "void "; }
            write += "behind you. ";

            try { write += realWorld[p[0], p[1] - 1].LookedBreiflyAt(); }
            catch { write += "void "; }
            write += "at your left. ";

            return write;
        }

        // Gets the directional descriptions
        public static string FrontDescription(int[] p) { return realWorld[p[0] - 1, p[1]].LookedDirectAt(); }
        public static string BackDescription(int[] p) { return realWorld[p[0] + 1, p[1]].LookedDirectAt(); }
        public static string RightDescription(int[] p) { return realWorld[p[0], p[1] + 1].LookedDirectAt(); }
        public static string LeftDescription(int[] p) { return realWorld[p[0], p[1] - 1].LookedDirectAt(); }

        // Gets the items at the location
        public static List<Item> GetItems(int[] p) { return realWorld[p[0], p[1]].Items(); }

        public static Locations SetPlot(int i)
        {
            switch (i)
            {
                case 0:
                    return new Field();
                case 1:
                    return new Forest();
                case 2:
                    return new Creek();
                case 3:
                    return new TreeHouse();
                case 4:
                    return new House();
                case 5:
                    return new PileOfLeaves();
                default:
                    break;
            }
            return new Locations();
        }
        // Fills the "realWorld" map with instances of locations
        public static void FillMap()
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    realWorld[x, y] = SetPlot(world[x, y]);
                }
            }
        }
    }// end of MAP
}
