using System.Linq;
using System.Reflection;
using UnityEngine;
using System.IO;

namespace QuestingUpdate.lib
{
    class QuestingRecipes
    {
        public void InitRecipes()
        {
            Create1IngRecipeCategory("CobaltIngotRecipe", "CobaltOre", "CobaltIngot", "TitaniumIngotRecipe", 2, 1, "66A6E0D5D3EA4F37A7E8C8B8494EBEAB", FindCategories("RefinementTier2"));
            Create1IngRecipe("TinIngotRecipe", "TinOre", "TinIngot", "CopperIngotRecipe", 1, 1, "813C576F2689476C930CE875A6920541");
            Create2IngRecipeLooping(FindCategories("ForgeTier1"), "BronzeIngotRecipe", "TinIngot", "CopperIngot", "BronzeIngot", "CopperIngotRecipe", 2, 2, 1, "5834A7C544EA44B7B2F499846F65A5F7");
            Create2IngRecipeLooping(FindCategories("ForgeTier2"), "SteelIngotRecipe", "CoalOre", "IronIngot", "SteelIngot", "IronIngotRecipe", 2, 1, 1, "31285829C32547AFAA7566C70AC01F7B");
            Create2IngRecipe("TinOreWorktableRecipe", "CoalOre", "SulfurPowder", "TinOre", "CopperLadderWorktableRecipe", 1, 1, 1, "D00D8B60000F49F9ACE357F6475D5845");
            Create2IngRecipe("TinOreRecipe", "CoalOre", "SulfurPowder", "TinOre", "CopperLadderRecipe", 1, 1, 1, "F91D87B941924FC4AF9D3DFDA6F0DA30");

            // Bolts
            Create1IngRecipe("BronzeBoltsRecipe", "BronzeIngot", "BronzeBolts", "CopperBoltsRecipe", 1, 1, "29DC3D5941A040BABF089C8837220D56");
            Create1IngRecipe("CobaltBoltsRecipe", "CobaltIngot", "CobaltBolts", "TitaniumBoltsRecipe", 1, 1, "BF883E730A0E4571A498BD520CC41A03");
            Create1IngRecipe("SteelBoltsRecipe", "SteelIngot", "SteelBolts", "IronBoltsRecipe", 1, 1, "92339DD53B59431F8AD4AF33919286E0");
            Create1IngRecipe("TinBoltsRecipe", "TinIngot", "TinBolts", "CopperBoltsRecipe", 1, 1, "B57DC13501594BBCB8770598CC9E1493");
            Create1IngRecipe("TinBoltsWorktableRecipe", "TinIngot", "TinBolts", "CopperBoltsWorktableRecipe", 1, 1, "429FDCDF78454A9E83C6E7B529F5DE2D");

            // Plates
            Create1IngRecipe("BronzePlatesRecipe", "BronzeIngot", "BronzePlates", "CopperPlatesRecipe", 1, 1, "D418515C6B2E42649D5979E1BD2AF624");
            Create1IngRecipe("CobaltPlatesRecipe", "CobaltIngot", "CobaltPlates", "TitaniumPlatesRecipe", 1, 1, "233F48A2ABB140729F2A6FAB1FBE8942");
            Create1IngRecipe("SteelPlatesRecipe", "SteelIngot", "SteelPlates", "IronPlatesRecipe", 1, 1, "F85498173406424D97A23C86575D56EE");
            Create1IngRecipe("TinPlatesRecipe", "TinIngot", "TinPlates", "CopperPlatesRecipe", 1, 1, "07C7F4B4E6834A8F9BB3D1E2026B46FD");
            Create1IngRecipe("TinPlatesWorktableRecipe", "TinIngot", "TinPlates", "CopperPlatesWorktableRecipe", 1, 1, "8C544BCE2A2C44CDA9A073278F9A3EF2");

            // Tubes
            Create1IngRecipe("BronzeTubesRecipe", "BronzeIngot", "BronzeTubes", "CopperTubesRecipe", 1, 1, "177273172C324BC98A3E280BE760F7CD");
            Create1IngRecipe("CobaltTubesRecipe", "CobaltIngot", "CobaltTubes", "TitaniumTubesRecipe", 1, 1, "D92B11B3B83C4FAC81E26D5B2A762284");
            Create1IngRecipe("SteelTubesRecipe", "SteelIngot", "SteelTubes", "IronTubesRecipe", 1, 1, "D10ED3794F4C445BB392B7D28EC912A2");
            Create1IngRecipe("TinTubesRecipe", "TinIngot", "TinTubes", "CopperTubesRecipe", 1, 1, "8F2793C875104B889C29EF1005271171");
            Create1IngRecipe("TinTubesWorktableRecipe", "TinIngot", "TinTubes", "CopperTubesWorktableRecipe", 1, 1, "1C5868D46B4A41EC9F19869633B8D9D6");

            // Misc
            Create2IngRecipe("AlloyStationRecipe", "CopperTubes", "SulfurPowder", "AlloyForgeStation", "ProductionControlStationRecipe", 3, 1, 1, "2177E7806F3842FF9D929941930DA96F");
            Create2IngRecipe("AlloyStationWorktableRecipe", "CopperTubes", "SulfurPowder", "AlloyForgeStation", "ProductionControlStationWorktableRecipe", 3, 1, 1, "3E0CB457B5AC44928A4476652F33B18A");

            // Modules
            Create4IngRecipe("AlloyForgeTier1Recipe", "CopperPlates", "CopperBolts", "RefineryT1_Shredder", "IntelRefineryT1", "AlloyForgeTier1", "RefineryModuleSide1Recipe", 3, 3, 1, 1, 1, "1A6B5BFD59D5418A9ADD618B85F812E2");
            Create4IngRecipe("AlloyForgeTier2Recipe", "BronzePlates", "BronzeBolts", "RefineryT2_Boiler", "IntelRefineryT2", "AlloyForgeTier2", "RefineryModuleSide2Recipe", 6, 6, 2, 1, 1, "7DAAE7F9C18448E082D8719E10CBDE52");
            Create4IngRecipe("AlloyForgeTier3Recipe", "SteelPlates", "SteelBolts", "RefineryT3_Furnace", "IntelRefineryT3", "AlloyForgeTier3", "RefineryModuleSide3Recipe", 9, 9, 2, 1, 1, "48969D10B2344354967CCB4039EB0CBC");

            using (StreamWriter writer = new StreamWriter(QuestingMod.path, true))
            {
                writer.WriteLine("[Questing Update | Recipes]: Recipes Loaded...");
                writer.Dispose();
            }
            Debug.Log("[Questing Update | Recipes]: Recipes Loaded...");
        }
        private RecipeCategory tempcategory;
        public RecipeCategory FindCategories(string categoryname)
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
        private void Create1IngRecipe(string recipeName, string inputName, string outputName, string baseRecipeName, int inputAmount, int outputAmount, string itemId)
        {
            var input = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName);
            var output = GameResources.Instance.Items.FirstOrDefault(s => s.name == outputName);
            var baseRecipe = GameResources.Instance.Recipes.FirstOrDefault(s => s.name == baseRecipeName);

            var recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.name = recipeName;
            recipe.Inputs = new InventoryItemData[] { new InventoryItemData { Item = input, Amount = inputAmount } };
            recipe.Output = new InventoryItemData { Item = output, Amount = outputAmount };
            recipe.RequiredUpgrades = baseRecipe.RequiredUpgrades;

            recipe.Categories = baseRecipe.Categories.ToArray();

            var guid = GUID.Parse(itemId);

            typeof(Definition).GetField("m_assetId", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(recipe, guid);

            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = recipe, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);
            using (StreamWriter writer = new StreamWriter(QuestingMod.path, true))
            {
                writer.WriteLine("[Questing Update | Recipes]: Recipe " + recipeName + " has been Loaded");
                writer.Dispose();
            }
        }

        private void Create1IngRecipeCategory(string recipeName, string inputName, string outputName, string baseRecipeName, int inputAmount, int outputAmount, string itemId, RecipeCategory recipeCategory)
        {
            var input = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName);
            var output = GameResources.Instance.Items.FirstOrDefault(s => s.name == outputName);
            var baseRecipe = GameResources.Instance.Recipes.FirstOrDefault(s => s.name == baseRecipeName);

            var recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.name = recipeName;
            recipe.Inputs = new InventoryItemData[] { new InventoryItemData { Item = input, Amount = inputAmount } };
            recipe.Output = new InventoryItemData { Item = output, Amount = outputAmount };
            recipe.RequiredUpgrades = baseRecipe.RequiredUpgrades;

            recipe.Categories = new RecipeCategory[] { recipeCategory };

            var guid = GUID.Parse(itemId);

            typeof(Definition).GetField("m_assetId", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(recipe, guid);

            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = recipe, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);
            using (StreamWriter writer = new StreamWriter(QuestingMod.path, true))
            {
                writer.WriteLine("[Questing Update | Recipes]: Recipe " + recipeName + " has been Loaded");
                writer.Dispose();
            }
        }

        private void Create2IngRecipe(string recipeName, string inputName1, string inputName2, string outputName, string baseRecipeName, int inputAmount1, int inputAmount2, int outputAmount, string itemId)
        {
            var input1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName1);
            var input2 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName2);
            var output = GameResources.Instance.Items.FirstOrDefault(s => s.name == outputName);
            var baseRecipe = GameResources.Instance.Recipes.FirstOrDefault(s => s.name == baseRecipeName);

            var recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.name = recipeName;
            recipe.Inputs = new InventoryItemData[] { new InventoryItemData { Item = input1, Amount = inputAmount1 }, new InventoryItemData { Item = input2, Amount = inputAmount2 } };
            recipe.Output = new InventoryItemData { Item = output, Amount = outputAmount };
            recipe.RequiredUpgrades = baseRecipe.RequiredUpgrades;

            recipe.Categories = baseRecipe.Categories.ToArray();

            var guid = GUID.Parse(itemId);

            typeof(Definition).GetField("m_assetId", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(recipe, guid);

            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = recipe, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);
            using (StreamWriter writer = new StreamWriter(QuestingMod.path, true))
            {
                writer.WriteLine("[Questing Update | Recipes]: Recipe " + recipeName + " has been Loaded");
                writer.Dispose();
            }
        }

        private void Create4IngRecipe(string recipeName, string inputName1, string inputName2, string inputName3, string inputName4, string outputName, string baseRecipeName, int inputAmount1, int inputAmount2, int inputAmount3, int inputAmount4, int outputAmount, string itemId)
        {
            var input1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName1);
            var input2 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName2);
            var input3 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName3);
            var input4 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName4);
            var output = GameResources.Instance.Items.FirstOrDefault(s => s.name == outputName);
            var baseRecipe = GameResources.Instance.Recipes.FirstOrDefault(s => s.name == baseRecipeName);

            var recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.name = recipeName;
            recipe.Inputs = new InventoryItemData[] { new InventoryItemData { Item = input1, Amount = inputAmount1 }, new InventoryItemData { Item = input2, Amount = inputAmount2 }, new InventoryItemData { Item = input3, Amount = inputAmount3 }, new InventoryItemData { Item = input4, Amount = inputAmount4 } };
            recipe.Output = new InventoryItemData { Item = output, Amount = outputAmount };
            recipe.RequiredUpgrades = baseRecipe.RequiredUpgrades;

            recipe.Categories = baseRecipe.Categories.ToArray();

            var guid = GUID.Parse(itemId);

            typeof(Definition).GetField("m_assetId", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(recipe, guid);

            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = recipe, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);
            using (StreamWriter writer = new StreamWriter(QuestingMod.path, true))
            {
                writer.WriteLine("[Questing Update | Recipes]: Recipe " + recipeName + " has been Loaded");
                writer.Dispose();
            }
        }

        private void Create5IngRecipe(string recipeName, string inputName1, string inputName2, string inputName3, string inputName4, string inputName5, string outputName, string baseRecipeName, int inputAmount1, int inputAmount2, int inputAmount3, int inputAmount4, int inputAmount5, int outputAmount, string itemId)
        {
            var input1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName1);
            var input2 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName2);
            var input3 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName3);
            var input4 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName4);
            var input5 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName5);
            var output = GameResources.Instance.Items.FirstOrDefault(s => s.name == outputName);
            var baseRecipe = GameResources.Instance.Recipes.FirstOrDefault(s => s.name == baseRecipeName);

            var recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.name = recipeName;
            recipe.Inputs = new InventoryItemData[] { new InventoryItemData { Item = input1, Amount = inputAmount1 }, new InventoryItemData { Item = input2, Amount = inputAmount2 }, new InventoryItemData { Item = input3, Amount = inputAmount3 }, new InventoryItemData { Item = input4, Amount = inputAmount4 }, new InventoryItemData { Item = input5, Amount = inputAmount5 } };
            recipe.Output = new InventoryItemData { Item = output, Amount = outputAmount };
            recipe.RequiredUpgrades = baseRecipe.RequiredUpgrades;

            recipe.Categories = baseRecipe.Categories.ToArray();

            var guid = GUID.Parse(itemId);

            typeof(Definition).GetField("m_assetId", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(recipe, guid);

            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = recipe, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);
            using (StreamWriter writer = new StreamWriter(QuestingMod.path, true))
            {
                writer.WriteLine("[Questing Update | Recipes]: Recipe " + recipeName + " has been Loaded");
                writer.Dispose();
            }
        }

        private void Create2IngRecipeLooping(RecipeCategory recipeCategory, string recipeName, string inputName1, string inputName2, string outputName, string baseRecipeName, int inputAmount1, int inputAmount2, int outputAmount, string itemId)
        {
            var input1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName1);
            var input2 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName2);
            var output = GameResources.Instance.Items.FirstOrDefault(s => s.name == outputName);
            var baseRecipe = GameResources.Instance.Recipes.FirstOrDefault(s => s.name == baseRecipeName);

            var recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.name = recipeName;
            recipe.Inputs = new InventoryItemData[] { new InventoryItemData { Item = input1, Amount = inputAmount1 }, new InventoryItemData { Item = input2, Amount = inputAmount2 } };
            recipe.Output = new InventoryItemData { Item = output, Amount = outputAmount };
            recipe.RequiredUpgrades = baseRecipe.RequiredUpgrades;

            recipe.Categories = new RecipeCategory[] { recipeCategory };

            var guid = GUID.Parse(itemId);

            typeof(Definition).GetField("m_assetId", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(recipe, guid);

            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = recipe, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);
            using (StreamWriter writer = new StreamWriter(QuestingMod.path, true))
            {
                writer.WriteLine("[Questing Update | Recipes]: Recipe " + recipeName + " has been Loaded");
                writer.Dispose();
            }
        }
    }
}
