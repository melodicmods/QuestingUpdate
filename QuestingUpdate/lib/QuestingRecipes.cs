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

            // Schematics
            // Tier 1
            Create1IngRecipeSchematic("UpgradeResourceRefining1Recipe", "IntelRefineryT1", "UpgradeResourceRefining1", "UpgradeStarterRefineryRecipe", 1, 1, "4B9CF15AF3C04BCD8964DF6C3C426A77", "UpgradeStarterRefinery");
            Create2IngRecipeSchematic("UpgradeCopperworkingRecipe", "IntelRefineryT1", "CopperIngot", "UpgradeCopperworking", "UpgradeStarterRefineryRecipe", 1, 5, 1, "F6D20287D16444149E22ECCB43F217AF", "UpgradeStarterRefinery");
            Create3IngRecipeSchematic("UpgradeCopperArmorRecipe", "IntelProductionT1", "CopperIngot", "CopperPlates", "UpgradeCopperArmor", "UpgradeStarterRefineryRecipe", 1, 5, 5, 1, "4FD0DCE1595F45A8A13BAC166D42255A", "UpgradeCopperworking");
            Create3IngRecipeSchematic2("UpgradeSimpleWeaponsRecipe", "IntelProductionT1", "CopperIngot", "CopperBolts", "UpgradeSimpleWeapons", "UpgradeStarterRefineryRecipe", 1, 5, 5, 1, "808A3382BB6F4D97B526FF57CEC85C93", "UpgradeCopperworking", "SimpleExplosivesSchematic");
            Create3IngRecipeSchematic2("UpgradeBasicAlloyingRecipe", "IntelRefineryT1", "CopperIngot", "TinIngot", "UpgradeBasicAlloying", "UpgradeStarterRefineryRecipe", 1, 5, 5, 1, "AC93E7D8912F4A1E98AF130612852441", "UpgradeCopperworking", "UpgradeResourceRefining1");
            Create2IngRecipeSchematic("UpgradeAlloyForge1Recipe", "IntelRefineryT1", "TinIngot", "UpgradeAlloyForge1", "UpgradeStarterRefineryRecipe", 2, 15, 1, "B2C92D2FD58942DB84758DB5174DC6AB", "UpgradeBasicAlloying");
            Create2IngRecipeSchematic("UpgradeBronzeworkingRecipe", "IntelProductionT1", "BronzeIngot", "UpgradeBronzeworking", "UpgradeStarterRefineryRecipe", 1, 10, 1, "71EF043D09FF4DC4AB60946A74D43061", "UpgradeAlloyForge1");
            Create2IngRecipeSchematic2("UpgradeTurretsTier1Recipe", "SulfurPowder", "CopperGunComponents", "UpgradeTurretsTier1", "UpgradeStarterRefineryRecipe", 10, 2, 1, "3FF61953BE6D4728B1FBFB5EE211FC9D", "UpgradeBronzeworking", "UpgradeSimpleWeapons");
            Create2IngRecipeSchematic2("UpgradeBronzeArmorRecipe", "BronzePlates", "BronzeBolts", "UpgradeBronzeArmor", "UpgradeStarterRefineryRecipe", 10, 10, 1, "3E64FBD9E921493F95F39F7807BD3954", "UpgradeBronzeworking", "UpgradeCopperArmor");
            Create2IngRecipeSchematic("UpgradeDrillshipParts1Recipe", "IntelProductionT1", "BronzeIngot", "UpgradeDrillshipParts1", "UpgradeStarterRefineryRecipe", 2, 20, 1, "2BF4096EB29D44669847368D1CB34AA8", "UpgradeBronzeworking");
            Create3IngRecipeSchematic("UpgradeAdvancedTurrets1Recipe", "TurretModule", "IntelProductionT1", "BronzeIngot", "UpgradeAdvancedTurrets1", "UpgradeStarterRefineryRecipe", 1, 2, 20, 1, "9865CE4C53DC4D52A8A0DC349859C510", "UpgradeTurretsTier1");

            // Tier 2

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

        private void Create1IngRecipeSchematic(string recipeName, string inputName, string outputName, string baseRecipeName, int inputAmount, int outputAmount, string itemId, string requiredItem)
        {
            var input = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName);
            var output = GameResources.Instance.Items.FirstOrDefault(s => s.name == outputName);
            var baseRecipe = GameResources.Instance.Recipes.FirstOrDefault(s => s.name == baseRecipeName);
            var requiredItemWrite = GameResources.Instance.Items.FirstOrDefault(s => s.name == requiredItem);

            var recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.name = recipeName;
            recipe.Inputs = new InventoryItemData[] { new InventoryItemData { Item = input, Amount = inputAmount } };
            recipe.Output = new InventoryItemData { Item = output, Amount = outputAmount };
            recipe.RequiredUpgrades = new ItemDefinition[] { requiredItemWrite };

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

        private void Create2IngRecipeSchematic(string recipeName, string inputName1, string inputName2, string outputName, string baseRecipeName, int inputAmount1, int inputAmount2, int outputAmount, string itemId, string requiredItem)
        {
            var input1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName1);
            var input2 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName2);
            var output = GameResources.Instance.Items.FirstOrDefault(s => s.name == outputName);
            var baseRecipe = GameResources.Instance.Recipes.FirstOrDefault(s => s.name == baseRecipeName);
            var requiredItemWrite = GameResources.Instance.Items.FirstOrDefault(s => s.name == requiredItem);

            var recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.name = recipeName;
            recipe.Inputs = new InventoryItemData[] { new InventoryItemData { Item = input1, Amount = inputAmount1 }, new InventoryItemData { Item = input2, Amount = inputAmount2 } };
            recipe.Output = new InventoryItemData { Item = output, Amount = outputAmount };
            recipe.RequiredUpgrades = new ItemDefinition[] { requiredItemWrite };

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

        private void Create2IngRecipeSchematic2(string recipeName, string inputName1, string inputName2, string outputName, string baseRecipeName, int inputAmount1, int inputAmount2, int outputAmount, string itemId, string requiredItem1, string requiredItem2)
        {
            var input1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName1);
            var input2 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName2);
            var output = GameResources.Instance.Items.FirstOrDefault(s => s.name == outputName);
            var baseRecipe = GameResources.Instance.Recipes.FirstOrDefault(s => s.name == baseRecipeName);
            var requiredItemWrite1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == requiredItem1);
            var requiredItemWrite2 = GameResources.Instance.Items.FirstOrDefault(s => s.name == requiredItem2);

            var recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.name = recipeName;
            recipe.Inputs = new InventoryItemData[] { new InventoryItemData { Item = input1, Amount = inputAmount1 }, new InventoryItemData { Item = input2, Amount = inputAmount2 } };
            recipe.Output = new InventoryItemData { Item = output, Amount = outputAmount };
            recipe.RequiredUpgrades = new ItemDefinition[] { requiredItemWrite1, requiredItemWrite2 };

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

        private void Create3IngRecipeSchematic(string recipeName, string inputName1, string inputName2, string inputName3, string outputName, string baseRecipeName, int inputAmount1, int inputAmount2, int inputAmount3, int outputAmount, string itemId, string requiredItem)
        {
            var input1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName1);
            var input2 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName2);
            var input3 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName3);
            var output = GameResources.Instance.Items.FirstOrDefault(s => s.name == outputName);
            var baseRecipe = GameResources.Instance.Recipes.FirstOrDefault(s => s.name == baseRecipeName);
            var requiredItemWrite = GameResources.Instance.Items.FirstOrDefault(s => s.name == requiredItem);

            var recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.name = recipeName;
            recipe.Inputs = new InventoryItemData[] { new InventoryItemData { Item = input1, Amount = inputAmount1 }, new InventoryItemData { Item = input2, Amount = inputAmount2 }, new InventoryItemData { Item = input3, Amount = inputAmount3 } };
            recipe.Output = new InventoryItemData { Item = output, Amount = outputAmount };
            recipe.RequiredUpgrades = new ItemDefinition[] { requiredItemWrite };

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

        private void Create3IngRecipeSchematic2(string recipeName, string inputName1, string inputName2, string inputName3, string outputName, string baseRecipeName, int inputAmount1, int inputAmount2, int inputAmount3, int outputAmount, string itemId, string requiredItem1, string requiredItem2)
        {
            var input1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName1);
            var input2 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName2);
            var input3 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName3);
            var output = GameResources.Instance.Items.FirstOrDefault(s => s.name == outputName);
            var baseRecipe = GameResources.Instance.Recipes.FirstOrDefault(s => s.name == baseRecipeName);
            var requiredItemWrite1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == requiredItem1);
            var requiredItemWrite2 = GameResources.Instance.Items.FirstOrDefault(s => s.name == requiredItem2);

            var recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.name = recipeName;
            recipe.Inputs = new InventoryItemData[] { new InventoryItemData { Item = input1, Amount = inputAmount1 }, new InventoryItemData { Item = input2, Amount = inputAmount2 }, new InventoryItemData { Item = input3, Amount = inputAmount3 } };
            recipe.Output = new InventoryItemData { Item = output, Amount = outputAmount };
            recipe.RequiredUpgrades = new ItemDefinition[] { requiredItemWrite1, requiredItemWrite2 };

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

        private void Create1IngRecipeSchematic2(string recipeName, string inputName, string outputName, string baseRecipeName, int inputAmount, int outputAmount, string itemId, string requiredItem1, string requiredItem2)
        {
            var input = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName);
            var output = GameResources.Instance.Items.FirstOrDefault(s => s.name == outputName);
            var baseRecipe = GameResources.Instance.Recipes.FirstOrDefault(s => s.name == baseRecipeName);
            var requiredItemWrite1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == requiredItem1);
            var requiredItemWrite2 = GameResources.Instance.Items.FirstOrDefault(s => s.name == requiredItem2);

            var recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.name = recipeName;
            recipe.Inputs = new InventoryItemData[] { new InventoryItemData { Item = input, Amount = inputAmount } };
            recipe.Output = new InventoryItemData { Item = output, Amount = outputAmount };
            recipe.RequiredUpgrades = new ItemDefinition[] { requiredItemWrite1, requiredItemWrite2 };

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
