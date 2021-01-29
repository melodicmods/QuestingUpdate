using System.Linq;
using System.Reflection;
using UnityEngine;
using System.IO;
using QuestingUpdate.lib.storage;
using QuestingUpdate.lib.scripts;

namespace QuestingUpdate.lib
{
    class QuestingRecipes
    {
        public void InitRecipes()
        {
            CreateRecipe("CobaltIngotRecipe", "CobaltOre", "CobaltIngot", "TitaniumIngotRecipe", 2, 1, "66A6E0D5D3EA4F37A7E8C8B8494EBEAB", FindCategories("RefinementTier2"));
            CreateRecipe("TinIngotRecipe", "TinOre", "TinIngot", "CopperIngotRecipe", 1, 1, "813C576F2689476C930CE875A6920541");
            CreateRecipe(FindCategories("ForgeTier1"), "BronzeIngotRecipe", "TinIngot", "CopperIngot", "BronzeIngot", "CopperIngotRecipe", 2, 2, 1, "5834A7C544EA44B7B2F499846F65A5F7");
            CreateRecipe(FindCategories("ForgeTier2"), "SteelIngotRecipe", "CoalOre", "IronIngot", "SteelIngot", "IronIngotRecipe", 2, 1, 1, "31285829C32547AFAA7566C70AC01F7B");
            CreateRecipe("TinOreWorktableRecipe", "CoalOre", "SulfurPowder", "TinOre", "CopperLadderWorktableRecipe", 1, 1, 1, "D00D8B60000F49F9ACE357F6475D5845");
            CreateRecipe("TinOreRecipe", "CoalOre", "SulfurPowder", "TinOre", "CopperLadderRecipe", 1, 1, 1, "F91D87B941924FC4AF9D3DFDA6F0DA30");

            // Bolts
            CreateRecipe("BronzeBoltsRecipe", "BronzeIngot", "BronzeBolts", "CopperBoltsRecipe", 1, 1, "29DC3D5941A040BABF089C8837220D56");
            CreateRecipe("CobaltBoltsRecipe", "CobaltIngot", "CobaltBolts", "TitaniumBoltsRecipe", 1, 1, "BF883E730A0E4571A498BD520CC41A03");
            CreateRecipe("SteelBoltsRecipe", "SteelIngot", "SteelBolts", "IronBoltsRecipe", 1, 1, "92339DD53B59431F8AD4AF33919286E0");
            CreateRecipe("TinBoltsRecipe", "TinIngot", "TinBolts", "CopperBoltsRecipe", 1, 1, "B57DC13501594BBCB8770598CC9E1493");
            CreateRecipe("TinBoltsWorktableRecipe", "TinIngot", "TinBolts", "CopperBoltsWorktableRecipe", 1, 1, "429FDCDF78454A9E83C6E7B529F5DE2D");

            // Plates
            CreateRecipe("BronzePlatesRecipe", "BronzeIngot", "BronzePlates", "CopperPlatesRecipe", 1, 1, "D418515C6B2E42649D5979E1BD2AF624");
            CreateRecipe("CobaltPlatesRecipe", "CobaltIngot", "CobaltPlates", "TitaniumPlatesRecipe", 1, 1, "233F48A2ABB140729F2A6FAB1FBE8942");
            CreateRecipe("SteelPlatesRecipe", "SteelIngot", "SteelPlates", "IronPlatesRecipe", 1, 1, "F85498173406424D97A23C86575D56EE");
            CreateRecipe("TinPlatesRecipe", "TinIngot", "TinPlates", "CopperPlatesRecipe", 1, 1, "07C7F4B4E6834A8F9BB3D1E2026B46FD");
            CreateRecipe("TinPlatesWorktableRecipe", "TinIngot", "TinPlates", "CopperPlatesWorktableRecipe", 1, 1, "8C544BCE2A2C44CDA9A073278F9A3EF2");

            // Tubes
            CreateRecipe("BronzeTubesRecipe", "BronzeIngot", "BronzeTubes", "CopperTubesRecipe", 1, 1, "177273172C324BC98A3E280BE760F7CD");
            CreateRecipe("CobaltTubesRecipe", "CobaltIngot", "CobaltTubes", "TitaniumTubesRecipe", 1, 1, "D92B11B3B83C4FAC81E26D5B2A762284");
            CreateRecipe("SteelTubesRecipe", "SteelIngot", "SteelTubes", "IronTubesRecipe", 1, 1, "D10ED3794F4C445BB392B7D28EC912A2");
            CreateRecipe("TinTubesRecipe", "TinIngot", "TinTubes", "CopperTubesRecipe", 1, 1, "8F2793C875104B889C29EF1005271171");
            CreateRecipe("TinTubesWorktableRecipe", "TinIngot", "TinTubes", "CopperTubesWorktableRecipe", 1, 1, "1C5868D46B4A41EC9F19869633B8D9D6");

            // Misc
            CreateRecipe("AlloyStationRecipe", "CopperTubes", "SulfurPowder", "AlloyForgeStation", "ProductionControlStationRecipe", 3, 1, 1, "2177E7806F3842FF9D929941930DA96F");
            CreateRecipe("AlloyStationWorktableRecipe", "CopperTubes", "SulfurPowder", "AlloyForgeStation", "ProductionControlStationWorktableRecipe", 3, 1, 1, "3E0CB457B5AC44928A4476652F33B18A");

            // Schematics
            // Tier 1
            CreateRecipe("UpgradeResourceRefining1Recipe", "IntelRefineryT1", "UpgradeResourceRefining1", "UpgradeStarterRefineryRecipe", 1, 1, "4B9CF15AF3C04BCD8964DF6C3C426A77", "UpgradeStarterRefinery");
            CreateRecipe("UpgradeCopperworkingRecipe", "IntelRefineryT1", "CopperIngot", "UpgradeCopperworking", "UpgradeStarterRefineryRecipe", 1, 5, 1, "F6D20287D16444149E22ECCB43F217AF", "UpgradeStarterRefinery");
            CreateRecipe("UpgradeCopperArmorRecipe", "IntelProductionT1", "CopperIngot", "CopperPlates", "UpgradeCopperArmor", "UpgradeStarterRefineryRecipe", 1, 5, 5, 1, "4FD0DCE1595F45A8A13BAC166D42255A", "UpgradeCopperworking");
            CreateRecipe("UpgradeSimpleWeaponsRecipe", "IntelProductionT1", "CopperIngot", "CopperBolts", "UpgradeSimpleWeapons", "UpgradeStarterRefineryRecipe", 1, 5, 5, 1, "808A3382BB6F4D97B526FF57CEC85C93", "UpgradeCopperworking", "SimpleExplosivesSchematic");
            CreateRecipe("UpgradeBasicAlloyingRecipe", "IntelRefineryT1", "CopperIngot", "TinIngot", "UpgradeBasicAlloying", "UpgradeStarterRefineryRecipe", 1, 5, 5, 1, "AC93E7D8912F4A1E98AF130612852441", "UpgradeCopperworking", "UpgradeResourceRefining1");
            CreateRecipe("UpgradeAlloyForge1Recipe", "IntelRefineryT1", "TinIngot", "UpgradeAlloyForge1", "UpgradeStarterRefineryRecipe", 2, 15, 1, "B2C92D2FD58942DB84758DB5174DC6AB", "UpgradeBasicAlloying");
            CreateRecipe("UpgradeBronzeworkingRecipe", "IntelProductionT1", "BronzeIngot", "UpgradeBronzeworking", "UpgradeStarterRefineryRecipe", 1, 10, 1, "71EF043D09FF4DC4AB60946A74D43061", "UpgradeAlloyForge1");
            CreateRecipe("UpgradeTurretsTier1Recipe", "SulfurPowder", "CopperGunComponents", "UpgradeTurretsTier1", "UpgradeStarterRefineryRecipe", 10, 2, 1, "3FF61953BE6D4728B1FBFB5EE211FC9D", "UpgradeBronzeworking", "UpgradeSimpleWeapons");
            CreateRecipe("UpgradeBronzeArmorRecipe", "BronzePlates", "BronzeBolts", "UpgradeBronzeArmor", "UpgradeStarterRefineryRecipe", 10, 10, 1, "3E64FBD9E921493F95F39F7807BD3954", "UpgradeBronzeworking", "UpgradeCopperArmor");
            CreateRecipe("UpgradeDrillshipParts1Recipe", "IntelProductionT1", "BronzeIngot", "UpgradeDrillshipParts1", "UpgradeStarterRefineryRecipe", 2, 20, 1, "2BF4096EB29D44669847368D1CB34AA8", "UpgradeBronzeworking");
            CreateRecipe("UpgradeAdvancedTurrets1Recipe", "TurretModule", "IntelProductionT1", "BronzeIngot", "UpgradeAdvancedTurrets1", "UpgradeStarterRefineryRecipe", 1, 2, 20, 1, "9865CE4C53DC4D52A8A0DC349859C510", "UpgradeTurretsTier1");

            // Tier 2
            CreateRecipe("UpgradeIronRefiningRecipe", "CopperIngot", "IntelRefineryT2", "UpgradeIronRefining", "UpgradeStarterRefineryRecipe", 10, 1, 1, "1E4FF66AEF594127940F6B1CC2BFBC5B", QuestingGUIDs.UpgradeBasicProduction);
            CreateRecipe("UpgradeIronworkingRecipe", "IronOre", "IntelRefineryT2", "UpgradeIronworking", "UpgradeStarterRefineryRecipe", 20, 1, 1, "189D623C94974D9D99E4BABA3A3C3C04", "UpgradeIronRefining");
            CreateRecipe("UpgradeAdvancedIronPartsRecipe", "IronIngot", "IntelProductionT2", "UpgradeAdvancedIronParts", "UpgradeStarterRefineryRecipe", 10, 1, 1, "CC5FDB6325D84483A5D7D0B94CA1176A", "UpgradeIronworking");
            CreateRecipe("UpgradeIronArmorRecipe", "IronIngot", "IronPlates", "IntelProductionT2", "UpgradeIronArmor", "UpgradeStarterRefineryRecipe", 10, 10, 2, 1, "FCC3D9E22DDE483096EE61B52544351C", "UpgradeIronworking", "UpgradeBronzeArmor");
            CreateRecipe("UpgradeResourceRefining2Recipe", "IronOre", "BronzeIngot", "IntelRefineryT2", "UpgradeResourceRefining2", "UpgradeStarterRefineryRecipe", 10, 10, 2, 1, "71FF16A7CC8B4F9EBB4E438FE3A52DB5", QuestingGUIDs.UpgradeBasicProduction);
            CreateRecipe("UpgradeAdvancedAlloyingRecipe", "BronzeIngot", "CopperIngot", "IntelResearchT2", "UpgradeAdvancedAlloying", "UpgradeStarterRefineryRecipe", 10, 10, 2, 1, "E54B5252D1AC4CBAB1CC8FE3A4162445", "UpgradeResourceRefining2", "UpgradeIronworking");
            CreateRecipe("UpgradeAlloyForge2Recipe", "BronzeIngot", "IronIngot", "IntelResearchT2", "UpgradeAlloyForge2", "UpgradeStarterRefineryRecipe", 10, 20, 2, 1, "25F63E963AFF4D33B52874A4F29E0383", "UpgradeAdvancedAlloying");
            CreateRecipe("UpgradeSteelworkingRecipe", "SteelIngot", "IntelRefineryT2", "UpgradeSteelworking", "UpgradeStarterRefineryRecipe", 10, 3, 1, "D70B44803CEA47418C166E69DBD9DA98", "UpgradeAlloyForge2");
            CreateRecipe("UpgradeSteelArmorRecipe", "SteelIngot", "SteelPlates", "IntelProductionT2", "UpgradeSteelArmor", "UpgradeStarterRefineryRecipe", 10, 15, 3, 1, "AAA6EEB4996F4A93A746BED6BAC73469", "UpgradeSteelworking", "UpgradeIronArmor");
            CreateRecipe("UpgradeImprovedWeaponsRecipe", "SteelIngot", "BlackPowder", "IntelProductionT2", "UpgradeImprovedWeapons", "UpgradeStarterRefineryRecipe", 10, 10, 3, 1, "39855DEAA2994BDB9533560C234013F7", "ImprovedExplosivesSchematic", "UpgradeSimpleWeapons", "UpgradeSteelworking");
            CreateRecipe("UpgradeTurretsTier2Recipe", "TurretModule", "SteelIngot", "IntelResearchT2", "UpgradeTurretsTier2", "UpgradeStarterRefineryRecipe", 3, 10, 3, 1, "16CC22FA14A54A708B9D1495F956BCA5", "UpgradeImprovedWeapons", "UpgradeAdvancedTurrets1");
            CreateRecipe("UpgradeAdvancedTurrets2Recipe", "TurretModule", "SteelPlates", "IntelResearchT2", "UpgradeAdvancedTurrets2", "UpgradeStarterRefineryRecipe", 5, 15, 3, 1, "13868650384046CF875FF50BA83F2117", "UpgradeTurretsTier2");
            CreateRecipe("UpgradeDrillshipParts2Recipe", "ShipCoreUpgrade1", "SteelIngot", "IntelProductionT2", "UpgradeDrillshipParts2", "UpgradeStarterRefineryRecipe", 1, 50, 5, 1, "1DCCCE0FF2E440988A2D381E2E51D6D1", "UpgradeSteelworking", "UpgradeAdvancedIronParts");

            // Tier 3
            CreateRecipe("UpgradeExpertAlloyingRecipe", "CobaltIngot", "IntelRefineryT3", "UpgradeExpertAlloying", "UpgradeStarterRefineryRecipe", 20, 5, 1, "6C8FA823ED9C4D6D9E02044C4BF22516", "UpgradeCobaltworking", "UpgradeResourceRefining3");
            CreateRecipe("UpgradeResourceRefining3Recipe", "CobaltOre", "IntelRefineryT3", "UpgradeResourceRefining3", "UpgradeStarterRefineryRecipe", 10, 4, 1, "EF4D2CFFC3C44FCF951190E86C9105E5", QuestingGUIDs.UpgradeAdvancedRefinery);
            CreateRecipe("UpgradeCobaltRefiningRecipe", "SteelIngot", "IntelRefineryT3", "UpgradeCobaltRefining", "UpgradeStarterRefineryRecipe", 20, 4, 1, "DF7FEF8C7A08437A9F03F9DD172FE87C", QuestingGUIDs.UpgradeAdvancedRefinery);
            CreateRecipe("UpgradeCobaltworkingRecipe", "CobaltIngot", "IntelProductionT3", "UpgradeCobaltworking", "UpgradeStarterRefineryRecipe", 10, 4, 1, "32D4E1FFAB624402983DC58317C4F408", "UpgradeCobaltRefining");
            CreateRecipe("UpgradeAdvancedCobaltPartsRecipe", "CobaltIngot", "IntelProductionT3", "UpgradeAdvancedCobaltParts", "UpgradeStarterRefineryRecipe", 50, 5, 1, "D2C9D442F83D4498B251691DFB09B0F1", "UpgradeCobaltworking");
            CreateRecipe("UpgradeAlloyingTier3Recipe", "SteelIngot", "IntelRefineryT3", "UpgradeAlloyingTier3", "UpgradeStarterRefineryRecipe", 50, 5, 1, "E75309EBF5F8493496166A83D59BEA5D", "UpgradeExpertAlloying");
            CreateRecipe("UpgradeTitanworkingRecipe", "TitaniumIngot", "IntelProductionT3", "UpgradeTitanworking", "UpgradeStarterRefineryRecipe", 30, 5, 1, "DDC05BA7041F4B1EBEBAF7603931DB32", "UpgradeAlloyingTier3");
            CreateRecipe("UpgradeCobaltArmorRecipe", "CobaltPlates", "CobaltBolts", "IntelProductionT3", "UpgradeCobaltArmor", "UpgradeStarterRefineryRecipe",15, 10, 5, 1, "6CEBEA28FF7E43609FAC1A7198FAC86E", "UpgradeAdvancedCobaltParts", "UpgradeSteelArmor");
            CreateRecipe("UpgradeTitanArmorRecipe", "TitaniumPlates", "TitaniumBolts", "IntelProductionT3", "UpgradeTitanArmor", "UpgradeStarterRefineryRecipe", 15, 10, 5, 1, "D0EBEA1A2E4A490AAAEE9E53ACD15B22", "UpgradeTitanworking", "UpgradeCobaltArmor");
            CreateRecipe("UpgradeAdvancedWeaponsRecipe", "TitaniumPlates", "TitaniumIngot", "IntelProductionT3", "UpgradeAdvancedWeapons", "UpgradeStarterRefineryRecipe", 15, 10, 10, 1, "4012E17308B444A89F6C29232FD76116", "AdvancedExplosivesSchematic", "UpgradeImprovedWeapons", "UpgradeTitanworking");
            CreateRecipe("UpgradeTurretsTier3Recipe", "TurretModuleSMG", "TitaniumPlates", "IntelProductionT3", "UpgradeTurretsTier3", "UpgradeStarterRefineryRecipe", 3, 10, 5, 1, "F52CDA0029644EACB72C532FFD4B1D20", "UpgradeAdvancedTurrets2", "UpgradeAdvancedWeapons");
            CreateRecipe("UpgradeAdvancedTurrets3Recipe", "TurretModuleMortar", "TitaniumIngot", "IntelProductionT3", "UpgradeAdvancedTurrets3", "UpgradeStarterRefineryRecipe", 3, 10, 5, 1, "454F57A8C23F48F4B67995B3539FF222", "UpgradeTurretsTier3");
            CreateRecipe("UpgradeDrillshipParts3Recipe", "ShipCoreUpgrade2", "TitaniumIngot", "IntelProductionT3", "UpgradeDrillshipParts3", "UpgradeStarterRefineryRecipe", 3, 75, 7, 1, "DDD84EAE2C374BA891A06DC18B09C1BB", "UpgradeTitanworking");
            CreateRecipe("UpgradeDrill4Recipe", "ShipCoreUpgrade3", "TitaniumIngot", "IntelProductionT3", "UpgradeDrill4", "UpgradeStarterRefineryRecipe", 3, 100, 10, 1, "7BCFEA88A7DA4925930FDAFF27734AFF", "UpgradeDrillshipParts3");
            CreateRecipe("UpgradeHeatResistanceRecipe", "DrillT4_Diamond", "TitaniumIngot", "IntelProductionT3", "UpgradeHeatResistance", "UpgradeStarterRefineryRecipe", 1, 100, 10, 1, "0B7B46FE83644DD489E2239AD5287179", "UpgradeAdvancedWeapons", "UpgradeTitanArmor", "UpgradeDrill4");

            // Modules
            CreateRecipe("AlloyForgeTier1Recipe", "CopperPlates", "CopperBolts", "RefineryT1_Shredder", "IntelRefineryT1", "AlloyForgeTier1", "RefineryModuleSide1Recipe", 3, 3, 1, 1, 1, "1A6B5BFD59D5418A9ADD618B85F812E2");
            CreateRecipe("AlloyForgeTier2Recipe", "BronzePlates", "BronzeBolts", "RefineryT2_Boiler", "IntelRefineryT2", "AlloyForgeTier2", "RefineryModuleSide2Recipe", 6, 6, 2, 1, 1, "7DAAE7F9C18448E082D8719E10CBDE52");
            CreateRecipe("AlloyForgeTier3Recipe", "SteelPlates", "SteelBolts", "RefineryT3_Furnace", "IntelRefineryT3", "AlloyForgeTier3", "RefineryModuleSide3Recipe", 9, 9, 2, 1, 1, "48969D10B2344354967CCB4039EB0CBC");

            QuestLog.Log("[Questing Update | Recipes]: Recipes Loaded...");
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
        private void CreateRecipe(string recipeName, string inputName, string outputName, string baseRecipeName, int inputAmount, int outputAmount, string itemId)
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

            QuestingDict.questingRegistry[recipeName] = guid;
            QuestLog.Log("[Questing Update | Recipes]: Recipe " + recipeName + " has been Loaded");
        }

        private void CreateRecipe(string recipeName, string inputName, string outputName, string baseRecipeName, int inputAmount, int outputAmount, string itemId, string requiredItem)
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

            QuestingDict.questingRegistry[recipeName] = guid;
            QuestLog.Log("[Questing Update | Recipes]: Recipe " + recipeName + " has been Loaded");
        }

        private void CreateRecipe(string recipeName, string inputName1, string inputName2, string outputName, string baseRecipeName, int inputAmount1, int inputAmount2, int outputAmount, string itemId, string requiredItem)
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

            QuestingDict.questingRegistry[recipeName] = guid;
            QuestLog.Log("[Questing Update | Recipes]: Recipe " + recipeName + " has been Loaded");
        }

        private void CreateRecipe(string recipeName, string inputName1, string inputName2, string outputName, string baseRecipeName, int inputAmount1, int inputAmount2, int outputAmount, string itemId, GUID requiredItem)
        {
            var input1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName1);
            var input2 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName2);
            var output = GameResources.Instance.Items.FirstOrDefault(s => s.name == outputName);
            var baseRecipe = GameResources.Instance.Recipes.FirstOrDefault(s => s.name == baseRecipeName);
            var requiredItemWrite = GameResources.Instance.Items.FirstOrDefault(s => s.AssetId == requiredItem);

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

            QuestingDict.questingRegistry[recipeName] = guid;
            QuestLog.Log("[Questing Update | Recipes]: Recipe " + recipeName + " has been Loaded");
        }

        private void CreateRecipe(string recipeName, string inputName1, string inputName2, string outputName, string baseRecipeName, int inputAmount1, int inputAmount2, int outputAmount, string itemId, string requiredItem1, string requiredItem2)
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

            QuestingDict.questingRegistry[recipeName] = guid;
            QuestLog.Log("[Questing Update | Recipes]: Recipe " + recipeName + " has been Loaded");
        }

        private void CreateRecipe(string recipeName, string inputName1, string inputName2, string inputName3, string outputName, string baseRecipeName, int inputAmount1, int inputAmount2, int inputAmount3, int outputAmount, string itemId, string requiredItem)
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

            QuestingDict.questingRegistry[recipeName] = guid;
            QuestLog.Log("[Questing Update | Recipes]: Recipe " + recipeName + " has been Loaded");
        }

        private void CreateRecipe(string recipeName, string inputName1, string inputName2, string inputName3, string outputName, string baseRecipeName, int inputAmount1, int inputAmount2, int inputAmount3, int outputAmount, string itemId, GUID requiredItem)
        {
            var input1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName1);
            var input2 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName2);
            var input3 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName3);
            var output = GameResources.Instance.Items.FirstOrDefault(s => s.name == outputName);
            var baseRecipe = GameResources.Instance.Recipes.FirstOrDefault(s => s.name == baseRecipeName);
            var requiredItemWrite = GameResources.Instance.Items.FirstOrDefault(s => s.AssetId == requiredItem);

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

            QuestingDict.questingRegistry[recipeName] = guid;
            QuestLog.Log("[Questing Update | Recipes]: Recipe " + recipeName + " has been Loaded");
        }

        private void CreateRecipe(string recipeName, string inputName1, string inputName2, string inputName3, string outputName, string baseRecipeName, int inputAmount1, int inputAmount2, int inputAmount3, int outputAmount, string itemId, string requiredItem1, string requiredItem2)
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

            QuestingDict.questingRegistry[recipeName] = guid;
            QuestLog.Log("[Questing Update | Recipes]: Recipe " + recipeName + " has been Loaded");
        }

        private void CreateRecipe(string recipeName, string inputName1, string inputName2, string inputName3, string outputName, string baseRecipeName, int inputAmount1, int inputAmount2, int inputAmount3, int outputAmount, string itemId, string requiredItem1, string requiredItem2, string requiredItem3)
        {
            var input1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName1);
            var input2 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName2);
            var input3 = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName3);
            var output = GameResources.Instance.Items.FirstOrDefault(s => s.name == outputName);
            var baseRecipe = GameResources.Instance.Recipes.FirstOrDefault(s => s.name == baseRecipeName);
            var requiredItemWrite1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == requiredItem1);
            var requiredItemWrite2 = GameResources.Instance.Items.FirstOrDefault(s => s.name == requiredItem2);
            var requiredItemWrite3 = GameResources.Instance.Items.FirstOrDefault(s => s.name == requiredItem3);

            var recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.name = recipeName;
            recipe.Inputs = new InventoryItemData[] { new InventoryItemData { Item = input1, Amount = inputAmount1 }, new InventoryItemData { Item = input2, Amount = inputAmount2 }, new InventoryItemData { Item = input3, Amount = inputAmount3 } };
            recipe.Output = new InventoryItemData { Item = output, Amount = outputAmount };
            recipe.RequiredUpgrades = new ItemDefinition[] { requiredItemWrite1, requiredItemWrite2, requiredItemWrite3 };

            recipe.Categories = baseRecipe.Categories.ToArray();

            var guid = GUID.Parse(itemId);

            typeof(Definition).GetField("m_assetId", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(recipe, guid);

            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = recipe, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);

            QuestingDict.questingRegistry[recipeName] = guid;
            QuestLog.Log("[Questing Update | Recipes]: Recipe " + recipeName + " has been Loaded");
        }

        private void CreateRecipe(string recipeName, string inputName, string outputName, string baseRecipeName, int inputAmount, int outputAmount, string itemId, string requiredItem1, string requiredItem2)
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

            QuestingDict.questingRegistry[recipeName] = guid;
            QuestLog.Log("[Questing Update | Recipes]: Recipe " + recipeName + " has been Loaded");
        }

        private void CreateRecipe(string recipeName, string inputName, string outputName, string baseRecipeName, int inputAmount, int outputAmount, string itemId, string requiredItem1, string requiredItem2, string requiredItem3)
        {
            var input = GameResources.Instance.Items.FirstOrDefault(s => s.name == inputName);
            var output = GameResources.Instance.Items.FirstOrDefault(s => s.name == outputName);
            var baseRecipe = GameResources.Instance.Recipes.FirstOrDefault(s => s.name == baseRecipeName);
            var requiredItemWrite1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == requiredItem1);
            var requiredItemWrite2 = GameResources.Instance.Items.FirstOrDefault(s => s.name == requiredItem2);
            var requiredItemWrite3 = GameResources.Instance.Items.FirstOrDefault(s => s.name == requiredItem3);

            var recipe = ScriptableObject.CreateInstance<Recipe>();
            recipe.name = recipeName;
            recipe.Inputs = new InventoryItemData[] { new InventoryItemData { Item = input, Amount = inputAmount } };
            recipe.Output = new InventoryItemData { Item = output, Amount = outputAmount };
            recipe.RequiredUpgrades = new ItemDefinition[] { requiredItemWrite1, requiredItemWrite2, requiredItemWrite3 };

            recipe.Categories = baseRecipe.Categories.ToArray();

            var guid = GUID.Parse(itemId);

            typeof(Definition).GetField("m_assetId", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(recipe, guid);

            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = recipe, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);

            QuestingDict.questingRegistry[recipeName] = guid;
            QuestLog.Log("[Questing Update | Recipes]: Recipe " + recipeName + " has been Loaded");
        }

        private void CreateRecipe(string recipeName, string inputName, string outputName, string baseRecipeName, int inputAmount, int outputAmount, string itemId, RecipeCategory recipeCategory)
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

            QuestingDict.questingRegistry[recipeName] = guid;
            QuestLog.Log("[Questing Update | Recipes]: Recipe " + recipeName + " has been Loaded");
        }

        private void CreateRecipe(string recipeName, string inputName1, string inputName2, string outputName, string baseRecipeName, int inputAmount1, int inputAmount2, int outputAmount, string itemId)
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

            QuestingDict.questingRegistry[recipeName] = guid;
            QuestLog.Log("[Questing Update | Recipes]: Recipe " + recipeName + " has been Loaded");
        }

        private void CreateRecipe(string recipeName, string inputName1, string inputName2, string inputName3, string inputName4, string outputName, string baseRecipeName, int inputAmount1, int inputAmount2, int inputAmount3, int inputAmount4, int outputAmount, string itemId)
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

            QuestingDict.questingRegistry[recipeName] = guid;
            QuestLog.Log("[Questing Update | Recipes]: Recipe " + recipeName + " has been Loaded");
        }

        private void CreateRecipe(string recipeName, string inputName1, string inputName2, string inputName3, string inputName4, string inputName5, string outputName, string baseRecipeName, int inputAmount1, int inputAmount2, int inputAmount3, int inputAmount4, int inputAmount5, int outputAmount, string itemId)
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

            QuestingDict.questingRegistry[recipeName] = guid;
            QuestLog.Log("[Questing Update | Recipes]: Recipe " + recipeName + " has been Loaded");
        }

        private void CreateRecipe(RecipeCategory recipeCategory, string recipeName, string inputName1, string inputName2, string outputName, string baseRecipeName, int inputAmount1, int inputAmount2, int outputAmount, string itemId)
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

            QuestingDict.questingRegistry[recipeName] = guid;
            QuestLog.Log("[Questing Update | Recipes]: Recipe " + recipeName + " has been Loaded");
        }
    }
}
