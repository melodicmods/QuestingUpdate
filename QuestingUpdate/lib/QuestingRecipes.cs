using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace VolcQuestingUpdate.lib
{
    class QuestingRecipes
    {
        public void InitRecipes()
        {
            ModifyTitanium();
            Create1IngRecipe("CobaltIngot", "CobaltOre", "CobaltIngot", "TitaniumIngotRecipe", 2, 1, "66A6E0D5D3EA4F37A7E8C8B8494EBEAB");
            Create1IngRecipe("TinIngot", "TinOre", "TinIngot", "CopperIngotRecipe", 1, 1, "813C576F2689476C930CE875A6920541");
            Create2IngRecipeLooping(Findcategories("ForgeTier1"), "BronzeIngot", "TinIngot", "CopperIngot", "BronzeIngot", "CopperIngotRecipe", 2, 2, 1, "5834A7C544EA44B7B2F499846F65A5F7");
            Create2IngRecipe("SteelIngot", "CoalOre", "IronIngot", "SteelIngot", "AdvancedExplosivesSchematicRecipe", 2, 1, 1, "31285829C32547AFAA7566C70AC01F7B");
            Create2IngRecipe("TinOre", "CoalOre", "SulfurPowder", "TinOre", "CopperLadderWorktableRecipe", 1, 1, 1, "D00D8B60000F49F9ACE357F6475D5845");
            Create2IngRecipe("TinOre", "CoalOre", "SulfurPowder", "TinOre", "CopperLadderRecipe", 1, 1, 1, "F91D87B941924FC4AF9D3DFDA6F0DA30");

            Debug.Log("[Questing Update | Recipes]: Recipes Loaded...");
        }
        private RecipeCategory tempcategory;

        public RecipeCategory Findcategories(string categoryname)
        {
            tempcategory = null;
            foreach (Recipe recipe in GameResources.Instance.Recipes)
            {
                foreach (RecipeCategory category in recipe.Categories)
                {
                    if (category.name == categoryname)
                    {
                        tempcategory = category;
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
        }

        private void Create1IngRecipe(string recipeName, string inputName, string outputName, string baseRecipeName, int inputAmount, int outputAmount, string itemId)
        {
            // Get some items and a copper ingot worktable recipe
            var input = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName);
            var output = GameResources.Instance.Items.FirstOrDefault(s => s.name == outputName);
            var baseRecipe = GameResources.Instance.Recipes.FirstOrDefault(s => s.name == baseRecipeName);

            // Create new recipe
            var recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.name = recipeName;
            recipe.Inputs = new InventoryItemData[] { new InventoryItemData { Item = input, Amount = inputAmount } };
            recipe.Output = new InventoryItemData { Item = output, Amount = outputAmount };
            recipe.RequiredUpgrades = baseRecipe.RequiredUpgrades;

            // Copy categories from copper ingot worktable recipe, this will make it craftable in worktable as well
            recipe.Categories = baseRecipe.Categories.ToArray();

            // Recipe needs stable GUID across games to work with saves
            // This guid was generated through Visual studio, Tools, Generate GUID, dashes were removed
            var guid = GUID.Parse(itemId);

            // Not ideal, will try to make is more simple in next version
            typeof(Definition).GetField("m_assetId", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(recipe, guid);

            // Add recipe among runtime assets so game knows about them
            // All will try to make it more simple in next update
            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = recipe, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);
        }
        private void Create2IngRecipe(string recipeName, string inputName1, string inputName2, string outputName, string baseRecipeName, int inputAmount1, int inputAmount2, int outputAmount, string itemId)
        {
            // Get some items and a copper ingot worktable recipe
            var input1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName1);
            var input2 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName2);
            var output = GameResources.Instance.Items.FirstOrDefault(s => s.name == outputName);
            var baseRecipe = GameResources.Instance.Recipes.FirstOrDefault(s => s.name == baseRecipeName);

            // Create new recipe
            var recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.name = recipeName;
            recipe.Inputs = new InventoryItemData[] { new InventoryItemData { Item = input1, Amount = inputAmount1 }, new InventoryItemData { Item = input2, Amount = inputAmount2 } };
            recipe.Output = new InventoryItemData { Item = output, Amount = outputAmount };
            recipe.RequiredUpgrades = baseRecipe.RequiredUpgrades;

            // Copy categories from copper ingot worktable recipe, this will make it craftable in worktable as well
            recipe.Categories = baseRecipe.Categories.ToArray();

            // Recipe needs stable GUID across games to work with saves
            // This guid was generated through Visual studio, Tools, Generate GUID, dashes were removed
            var guid = GUID.Parse(itemId);

            // Not ideal, will try to make is more simple in next version
            typeof(Definition).GetField("m_assetId", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(recipe, guid);

            // Add recipe among runtime assets so game knows about them
            // All will try to make it more simple in next update
            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = recipe, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);
        }

        private void Create2IngRecipeLooping(RecipeCategory recipeCategory, string recipeName, string inputName1, string inputName2, string outputName, string baseRecipeName, int inputAmount1, int inputAmount2, int outputAmount, string itemId)
        {
            // Get some items and a copper ingot worktable recipe
            var input1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName1);
            var input2 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName2);
            var output = GameResources.Instance.Items.FirstOrDefault(s => s.name == outputName);
            var baseRecipe = GameResources.Instance.Recipes.FirstOrDefault(s => s.name == baseRecipeName);

            // Create new recipe
            var recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.name = recipeName;
            recipe.Inputs = new InventoryItemData[] { new InventoryItemData { Item = input1, Amount = inputAmount1 }, new InventoryItemData { Item = input2, Amount = inputAmount2 } };
            recipe.Output = new InventoryItemData { Item = output, Amount = outputAmount };
            recipe.RequiredUpgrades = baseRecipe.RequiredUpgrades;

            // Copy categories from copper ingot worktable recipe, this will make it craftable in worktable as well
            recipe.Categories = new RecipeCategory[] { recipeCategory };

            // Recipe needs stable GUID across games to work with saves
            // This guid was generated through Visual studio, Tools, Generate GUID, dashes were removed
            var guid = GUID.Parse(itemId);

            // Not ideal, will try to make is more simple in next version
            typeof(Definition).GetField("m_assetId", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(recipe, guid);

            // Add recipe among runtime assets so game knows about them
            // All will try to make it more simple in next update
            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = recipe, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);
        }
    }
}
