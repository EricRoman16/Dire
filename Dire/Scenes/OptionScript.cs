using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dire.Scenes
{
    public static class OptionScript
    {
        public static Array[] stuff = new Array[] { DefaultSelections, MainMenuSelections };

        public static string[][] DefaultSelections = new string[5][]
        {
            new string[] { "Look", "At", "Around", "North", "East", "South", "West"},
            new string[] { "Move", "Towards", "North", "East", "South", "West"},
            new string[] { "Inventory", "Use", "Equip", "Craft", "Drop" } ,
            new string[] { "Equipped", "Remove", "Stats" } ,
            new string[] { "Options", "Difficulty", "Save", "Load", "Music", "Docs", "Exit" }
        };
        public static string[][] MainMenuSelections = new string[3][]
        {
            new string[] { "Start", "New Game", "Load"},
            new string[] { "Options", "Music"},
            new string[] { "Exit", "Yes", "No"} ,
        };

        public static Dictionary<int, Delegate> dico = new Dictionary<int, Delegate>();

        public static Dictionary<string, string[]> Options = new Dictionary<string, string[]>()
        {
            { "Look", new string[] { "At", "Around", "North", "East", "South", "West"} },
            { "Move", new string[] { "Towards", "North", "East", "South", "West" } },
            { "Inventory", new string[] { "Use", "Equip", "Craft", "Drop" } },
            { "Equipped", new string[] { "Remove", "Stats" } },
            { "Options", new string[] { "Difficulty", "Save", "Load", "Music", "Docs", "Exit" } }
        };

        //new delegate 
        /*
         * Gonna try to make methods that can be called from within the dictionary
         * that will do the tasks or that will reference methods in commands class <- probably better option
         */

        #region Methods

        #endregion

    }
}
