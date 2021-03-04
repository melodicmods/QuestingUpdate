using QuestingUpdate.lib.scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestingUpdate.lib.data
{
    class ExportHandler
    {
        public static readonly Dictionary<Item, GUID> questingItems = new Dictionary<Item, GUID>();
        public static readonly Dictionary<Recipe, GUID> questingRecipes = new Dictionary<Recipe, GUID>();
        public static readonly Dictionary<Modifier, string> questingModifiers = new Dictionary<Modifier, string>();
        public static readonly Dictionary<Category, GUID> questingCategories = new Dictionary<Category, GUID>();
        public static readonly Dictionary<Deposit, string> questingDeposits = new Dictionary<Deposit, string>();
        public static readonly Dictionary<Module, GUID> questingModules = new Dictionary<Module, GUID>();
        public static readonly Dictionary<Station, GUID> questingStations = new Dictionary<Station, GUID>();
        public ExportHandler()
        {
            Export();
            QuestLog.Log("[Export Handler]: Export Complete");
        }
        private void Export()
        {
            foreach (Item item in ImportHandler.imports.items)
            {
                questingItems[item] = GUID.Parse(item.guid);
            }

            foreach (Recipe item in ImportHandler.imports.recipes)
            {
                questingRecipes[item] = GUID.Parse(item.itemID);
            }

            foreach (Modifier item in ImportHandler.imports.modifiers)
            {
                questingModifiers[item] = item.modification_type;
            }

            foreach (Category item in ImportHandler.imports.categories)
            {
                questingCategories[item] = GUID.Parse(item.guid);
            }

            foreach (Deposit item in ImportHandler.imports.deposits)
            {
                questingDeposits[item] = item.replaced_item;
            }

            foreach (Module item in ImportHandler.imports.modules)
            {
                questingModules[item] = GUID.Parse(item.guid);
            }

            foreach (Station item in ImportHandler.imports.stations)
            {
                questingStations[item] = GUID.Parse(item.guid);
            }
        }
    }
}
