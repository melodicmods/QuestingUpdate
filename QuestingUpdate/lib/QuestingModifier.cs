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
            ModifyItem1Upgrade("UpgradeStarterResearch", "UpgradeStarterRefineryRecipe");
            ModifyItem1Upgrade("UpgradeStarterResearch", "StarterStructuresSchematicRecipe");
            ModifyItem1Upgrade("UpgradeResourceRefining1", "SimpleExplosivesSchematicRecipe");

            // Tier 1
            ModifyItem1Table("ResearchTier1", "UpgradeResourceRefining1Recipe");
            ModifyItem1Table("ResearchTier1", "UpgradeStarterRefineryRecipe");
            ModifyItem1Table("ResearchTier1", "SimpleExplosivesSchematicRecipe");
            ModifyItem1Table("ResearchTier1", "StarterStructuresSchematicRecipe");
            ModifyItem1Table("ResearchTier1", "UpgradeCopperworkingRecipe");
            ModifyItem1Table("ResearchTier1", "UpgradeCopperArmorRecipe");
            ModifyItem1Table("ResearchTier1", "UpgradeSimpleWeaponsRecipe");
            ModifyItem1Table("ResearchTier1", "UpgradeBasicAlloyingRecipe");
            ModifyItem1Table("ResearchTier1", "UpgradeAlloyForge1Recipe");
            ModifyItem1Table("ResearchTier1", "UpgradeBronzeworkingRecipe");
            ModifyItem1Table("ResearchTier1", "UpgradeTurretsTier1Recipe");
            ModifyItem1Table("ResearchTier1", "UpgradeBronzeArmorRecipe");
            ModifyItem1Table("ResearchTier1", "UpgradeDrillshipParts1Recipe");
            ModifyItem1Table("ResearchTier1", "UpgradeAdvancedTurrets1Recipe");

            // Tier 2

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

        private void ModifyItem1Upgrade(string name1, string modifyName)
        {
            var item1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == name1);
            GameResources.Instance.Recipes.FirstOrDefault(s => s.name == modifyName).RequiredUpgrades = new ItemDefinition[] { item1 };
            using (StreamWriter writer = new StreamWriter(QuestingMod.path, true))
            {
                writer.WriteLine("[Questing Update | Modifier]: " + modifyName + " Required Upgrades Modified");
                writer.Dispose();
            }
        }

        private void ModifyItem1Table(string name1, string modifyName)
        {
            GameResources.Instance.Recipes.FirstOrDefault(s => s.name == modifyName).Categories = new RecipeCategory[] { FindCategories(name1) };
            using (StreamWriter writer = new StreamWriter(QuestingMod.path, true))
            {
                writer.WriteLine("[Questing Update | Modifier]: " + modifyName + " Categories Modified");
                writer.Dispose();
            }
        }

        private void ModifyItem2Upgrade(string name1, string name2, string modifyName)
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

        private void ModifyItem3Upgrade(string name1, string name2, string name3, string modifyName)
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
