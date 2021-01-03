using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestingUpdate.lib
{
    class QuestingModifier
    {
        public void InitModifier()
        {
            ModifyTitanium();
        }

        private RecipeCategory tempcategory;
        private RecipeCategory FindCategories(string categoryname)
        {
            tempcategory = null;
            foreach (Recipe recipe in GameResources.Instance.Recipes)
            {
                foreach (RecipeCategory category in recipe.Categories)
                {
                    if (category != null && categoryname != null)
                    {
                        if (category.name == categoryname)
                        {
                            tempcategory = category;
                        }
                    }
                }
            }
            return tempcategory;
        }

        private void ModifyTitanium()
        {
            var cobalt = GameResources.Instance.Items.FirstOrDefault(s => s.name == "CobaltIngot");
            var output = GameResources.Instance.Items.FirstOrDefault(s => s.name == "SteelIngot");
            GameResources.Instance.Recipes.FirstOrDefault(s => s.name == "TitaniumIngotRecipe").Inputs = new InventoryItemData[] { new InventoryItemData { Item = cobalt, Amount = 2 }, new InventoryItemData { Item = output, Amount = 2 } };
            GameResources.Instance.Recipes.FirstOrDefault(s => s.name == "TitaniumIngotRecipe").Categories = new RecipeCategory[] { FindCategories("ForgeTier3") };
            using (StreamWriter writer = new StreamWriter(QuestingMod.path, true))
            {
                writer.WriteLine("[Questing Update | Recipes]: Titanium Recipe Modified");
                writer.Dispose();
            }
        }
    }
}
