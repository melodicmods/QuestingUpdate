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
            Test("UpgradeAlloyForge1Recipe");
            ModifyTitanium();
            ModifyUpgrade("UpgradeStarterResearch", "UpgradeStarterRefineryRecipe");
            ModifyUpgrade("UpgradeStarterResearch", "StarterStructuresSchematicRecipe");
            ModifyUpgrade("UpgradeResourceRefining1", "SimpleExplosivesSchematicRecipe");

            // Tier 1 Item Updates
            ModifyUpgrade("UpgradeResourceRefining1", "TinIngotRecipe");
            ModifyUpgrade("UpgradeResourceRefining1", "CopperIngotRecipe");
            ModifyUpgrade("UpgradeCopperworking", "TinBoltsRecipe");
            ModifyUpgrade("UpgradeCopperworking", "TinPlatesRecipe");
            ModifyUpgrade("UpgradeCopperworking", "TinTubesRecipe");
            ModifyUpgrade("UpgradeCopperworking", "CopperBoltsRecipe");
            ModifyUpgrade("UpgradeCopperworking", "CopperPlatesRecipe");
            ModifyUpgrade("UpgradeCopperworking", "CopperTubesRecipe");
            // ModifyUpgrade("UpgradeCopperArmor", "CopperArmorRecipe");
            ModifyUpgrade("UpgradeSimpleWeapons", "RevolverRecipe");
            ModifyUpgrade("UpgradeSimpleWeapons", "ShotgunRecipe");
            //ModifyUpgrade("UpgradeTurretsTier1", "TurretModuleRecipe");
            ModifyUpgrade("UpgradeBasicAlloying", "AlloyT1Recipe");
            ModifyUpgrade("UpgradeBasicAlloying", "BronzeIngotRecipe");
            ModifyUpgrade("UpgradeBronzeworking", "BronzeTubesRecipe");
            ModifyUpgrade("UpgradeBronzeworking", "BronzePlatesRecipe");
            ModifyUpgrade("UpgradeBronzeworking", "BronzeBoltsRecipe");
            ModifyUpgrade("UpgradeDrillshipParts1", "DrillUpgrade2Recipe");
            ModifyUpgrade("UpgradeDrillshipParts1", "EngineUpgrade2Recipe");
            ModifyUpgrade("UpgradeDrillshipParts1", "HullUpgrade2Recipe");
            ModifyUpgrade("UpgradeDrillshipParts1", "TracksUpgrade2Recipe");
            ModifyUpgrade("UpgradeDrillshipParts1", "ShipCoreUpgrade2Recipe");

            // Tier 2 Item Updates
            ModifyUpgrade("UpgradeAdvancedAlloying", "AlloyT2Recipe");
            ModifyUpgrade("UpgradeDrillshipParts2", "UpgradeBasicRefinery2Recipe");

            // Tier 3 Item Updates
            ModifyUpgrade("UpgradePerfectAlloying", "AlloyT3Recipe");
            ModifyUpgrade("UpgradePerfectAlloying", "TitaniumIngotRecipe");
            ModifyUpgrade("UpgradeResourceRefining3", "CobaltIngotRecipe");

            // Tier 1
            ModifyTable("ResearchTier1", "UpgradeResourceRefining1Recipe");
            ModifyTable("ResearchTier1", "UpgradeStarterRefineryRecipe");
            ModifyTable("ResearchTier1", "SimpleExplosivesSchematicRecipe");
            ModifyTable("ResearchTier1", "StarterStructuresSchematicRecipe");
            ModifyTable("ResearchTier1", "UpgradeCopperworkingRecipe");
            ModifyTable("ResearchTier1", "UpgradeCopperArmorRecipe");
            ModifyTable("ResearchTier1", "UpgradeSimpleWeaponsRecipe");
            ModifyTable("ResearchTier1", "UpgradeBasicAlloyingRecipe");
            ModifyTable("ResearchTier1", "UpgradeAlloyForge1Recipe");
            ModifyTable("ResearchTier1", "UpgradeBronzeworkingRecipe");
            ModifyTable("ResearchTier1", "UpgradeTurretsTier1Recipe");
            ModifyTable("ResearchTier1", "UpgradeBronzeArmorRecipe");
            ModifyTable("ResearchTier1", "UpgradeDrillshipParts1Recipe");
            ModifyTable("ResearchTier1", "UpgradeAdvancedTurrets1Recipe");
            ModifyTable("ForgeTier1", "AlloyT1Recipe");
            ModifyTable("ForgeTier2", "AlloyT2Recipe");
            ModifyTable("ForgeTier3", "AlloyT3Recipe");

            // Tier 2
            ModifyTable("ResearchTier2", "UpgradeIronRefiningRecipe");
            ModifyTable("ResearchTier2", "UpgradeIronworkingRecipe");
            ModifyTable("ResearchTier2", "UpgradeAdvancedIronPartsRecipe");
            ModifyTable("ResearchTier2", "UpgradeIronArmorRecipe");
            ModifyTable("ResearchTier2", "UpgradeResourceRefining2Recipe");
            ModifyTable("ResearchTier2", "UpgradeAdvancedAlloyingRecipe");
            ModifyTable("ResearchTier2", "UpgradeAlloyForge2Recipe");
            ModifyTable("ResearchTier2", "UpgradeSteelworkingRecipe");
            ModifyTable("ResearchTier2", "UpgradeSteelArmorRecipe");
            ModifyTable("ResearchTier2", "UpgradeImprovedWeaponsRecipe");
            ModifyTable("ResearchTier2", "UpgradeTurretsTier2Recipe");
            ModifyTable("ResearchTier2", "UpgradeAdvancedTurrets2Recipe");
            ModifyTable("ResearchTier2", "UpgradeDrillshipParts2Recipe");

            // Tier 3


            using (StreamWriter writer = new StreamWriter(QuestingMod.path, true))
            {
                writer.WriteLine("[Questing Update | Modifier]: Modifiers Loaded...");
                writer.Dispose();
            }
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

        private void Test(string name)
        {
            var item = GameResources.Instance.Recipes.FirstOrDefault(s => s.name == name);
            foreach (RecipeCategory definition in item.Categories)
            {
                using (StreamWriter writer = new StreamWriter(QuestingMod.path, true))
                {
                    writer.WriteLine("[Questing Update | Modifier]: " + definition.name);
                    writer.Dispose();
                }
            }
        }

        private void ModifyTitanium()
        {
            var cobalt = GameResources.Instance.Items.FirstOrDefault(s => s.name == "CobaltIngot");
            var output = GameResources.Instance.Items.FirstOrDefault(s => s.name == "SteelIngot");
            GameResources.Instance.Recipes.FirstOrDefault(s => s.name == "TitaniumIngotRecipe").Inputs = new InventoryItemData[] { new InventoryItemData { Item = cobalt, Amount = 2 }, new InventoryItemData { Item = output, Amount = 2 } };
            GameResources.Instance.Recipes.FirstOrDefault(s => s.name == "TitaniumIngotRecipe").Categories = new RecipeCategory[] { FindCategories("ForgeTier3") };
            using (StreamWriter writer = new StreamWriter(QuestingMod.path, true))
            {
                writer.WriteLine("[Questing Update | Modifier]: Titanium Recipe Modified");
                writer.Dispose();
            }
        }

        private void ModifyUpgrade(string name1, string modifyName)
        {
            var item1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == name1);
            GameResources.Instance.Recipes.FirstOrDefault(s => s.name == modifyName).RequiredUpgrades = new ItemDefinition[] { item1 };
            using (StreamWriter writer = new StreamWriter(QuestingMod.path, true))
            {
                writer.WriteLine("[Questing Update | Modifier]: " + modifyName + " Required Upgrades Modified");
                writer.Dispose();
            }
        }

        private void ModifyTable(string name1, string modifyName)
        {
            GameResources.Instance.Recipes.FirstOrDefault(s => s.name == modifyName).Categories = new RecipeCategory[] { FindCategories(name1) };
            using (StreamWriter writer = new StreamWriter(QuestingMod.path, true))
            {
                writer.WriteLine("[Questing Update | Modifier]: " + modifyName + " Categories Modified");
                writer.Dispose();
            }
        }

        private void ModifyUpgrade(string name1, string name2, string modifyName)
        {
            var item1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == name1);
            var item2 = GameResources.Instance.Items.FirstOrDefault(s => s.name == name2);
            GameResources.Instance.Recipes.FirstOrDefault(s => s.name == modifyName).RequiredUpgrades = new ItemDefinition[] { item1, item2 };
            using (StreamWriter writer = new StreamWriter(QuestingMod.path, true))
            {
                writer.WriteLine("[Questing Update | Modifier]: " + modifyName + " Required Upgrades Modified");
                writer.Dispose();
            }
        }

        private void ModifyUpgrade(string name1, string name2, string name3, string modifyName)
        {
            var item1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == name1);
            var item2 = GameResources.Instance.Items.FirstOrDefault(s => s.name == name2);
            var item3 = GameResources.Instance.Items.FirstOrDefault(s => s.name == name3);
            GameResources.Instance.Recipes.FirstOrDefault(s => s.name == modifyName).RequiredUpgrades = new ItemDefinition[] { item1, item2, item3 };
            using (StreamWriter writer = new StreamWriter(QuestingMod.path, true))
            {
                writer.WriteLine("[Questing Update | Modifier]: " + modifyName + " Required Upgrades Modified");
                writer.Dispose();
            }
        }
    }
}
