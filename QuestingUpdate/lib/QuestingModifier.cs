using System.Collections.Generic;
using System.IO;
using System.Linq;
using QuestingUpdate.lib.storage;
using QuestingUpdate.lib.scripts;
using UnityEngine;

namespace QuestingUpdate.lib
{
    class QuestingModifier : MonoBehaviour
    {
        public void InitModifier()
        {
            ModifyCoalModule();

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
            ModifyUpgrade("UpgradeCopperArmor", QuestingGUIDs.ArmorkitCopper);
            ModifyUpgrade("UpgradeSimpleWeapons", QuestingGUIDs.RevolverWeaponRecipe);
            ModifyUpgrade("UpgradeSimpleWeapons", QuestingGUIDs.ShotgunWeaponRecipe);
            ModifyUpgrade("UpgradeTurretsTier1", QuestingGUIDs.TurretModulePistol);
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
            ModifyUpgrade(QuestingGUIDs.DrillShipParts1Upgrade, QuestingGUIDs.UpgradeBasicProduction2Recipe);
            ModifyUpgrade(QuestingGUIDs.UpgradeBasicProduction, QuestingGUIDs.UpgradeBasicResearch2Recipe);
            ModifyUpgrade(QuestingGUIDs.UpgradeBasicResearch, QuestingGUIDs.UpgradeBasicRefinery2Recipe);
            ModifyUpgrade(QuestingGUIDs.UpgradeBasicResearch, QuestingGUIDs.ImprovedStructuresSchematicRecipe);
            ModifyUpgrade("UpgradeResourceRefining2Recipe", "UpgradeAdvancedIronPartsRecipe", QuestingGUIDs.ImprovedExplosivesSchematicRecipe);

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


            QuestLog.Log("[Questing Update | Modifier]: Modifiers Loaded...");
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
            QuestLog.Log("[Questing Update | Modifier]: Titanium Recipe Modified");
        }

        private void ModifyCoalModule()
        {
            var item = GameResources.Instance.Items.FirstOrDefault(s => s.name == "CoalPowerModuleT1");
            var newPrefab = QuestingAssets.GetAsset("event.candle", "assets/chaos/candlefab.prefab");
            var newMaterial = QuestingAssets.GetMaterial("event.candle", "assets/chaos/candle.mat");

            //RuntimeAssetStorage.Add(new[] { new AssetReference() { Object = newPrefab, Guid = GUID.Parse("D653594B6BC344B3B6D8533A5CB0BA0B"), Labels = new string[0] } }, default);

            //foreach (var obj in item.Prefabs)
            //{
            //    if (obj.name == "CoalPowerModuleTop1")
            //    {
            //        Destroy(obj);
            //        item.Prefabs = new[] { item.Prefabs[0], newPrefab };
            //    }
            //}
            //QuestLog.Log("[Questing Update | Modifier]: " + newPrefab.name);
            //var newPrefab = QuestingAssets.GetAsset("questingbundle.coalplant", "assets/3dobjects/coalpowermoduletop1.prefab");
            //QuestLog.Log("[Questing Update | Modifier]: " + newPrefab);
            //foreach (var megaobj in newPrefab.GetComponentsInChildren<Transform>())
            //{
            //    QuestLog.Log("[Questing Update | Modifier]: " + megaobj);
            //}
            //var cache = NetworkResources.Instance.GridModules.Prefabs;
            //foreach (var obj in cache)
            //{
            //    if (obj.name == "CoalPowerModuleTop1")
            //    {
            //        foreach (var outobj in obj.GetComponentsInChildren<Animator>())
            //        {
            //            QuestLog.Log("[Questing Update | Modifier]: " + outobj);
            //        }
            //    }
            //}

            var cubePrefab = newPrefab;
            var coalItem = GameResources.Instance.Items.FirstOrDefault(s => s.name == "CoalPowerModuleT1");
            var coalTopPrefab = coalItem.Prefabs[1];
            var coalTop2 = coalItem.Prefabs[0];

            var parent = new GameObject();
            parent.SetActive(false);
            Object.DontDestroyOnLoad(parent);

            var copy = Object.Instantiate(coalTopPrefab, parent.transform);
            var cubeCopy = Object.Instantiate(cubePrefab, copy.transform);
            foreach (var thing in copy.GetComponentsInChildren<Animator>())
            {
                //QuestLog.Log("" + thing);
                foreach (var internalthing in thing.GetComponentsInChildren<MeshFilter>())
                {
                    foreach (var itemsthing in cubeCopy.GetComponentsInChildren<MeshFilter>())
                    {
                        if (internalthing.name == "Cylinder9648")
                        {
                            internalthing.mesh = itemsthing.mesh;
                            
                        }
                    }
                }
            }
            
            foreach(Animator thing in copy.GetComponentsInChildren<Animator>())
            {
                foreach (var internalthing in thing.GetComponentsInChildren<MeshRenderer>())
                {
                    if (internalthing.name == "Cylinder9648")
                    {
                        internalthing.sharedMaterial = newMaterial;
                        QuestLog.Log("" + newMaterial);
                    }
                }
            }

            cubeCopy.DestroyAuto();
            coalItem.Prefabs[1] = copy;
        }

        private void ModifyUpgrade(string name1, string modifyName)
        {
            var item1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == name1);
            GameResources.Instance.Recipes.FirstOrDefault(s => s.name == modifyName).RequiredUpgrades = new ItemDefinition[] { item1 };
            QuestLog.Log("[Questing Update | Modifier]: " + modifyName + " Required Upgrades Modified");
        }

        private void ModifyUpgrade(string name1, GUID woot)
        {
            var item1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == name1);
            GameResources.Instance.Recipes.FirstOrDefault(s => s.AssetId == woot).RequiredUpgrades = new ItemDefinition[] { item1 };
            QuestLog.Log("[Questing Update | Modifier]: " + woot + " Required Upgrades Modified");
        }

        private void ModifyUpgrade(GUID name1, GUID woot)
        {
            var item1 = GameResources.Instance.Items.FirstOrDefault(s => s.AssetId == name1);
            GameResources.Instance.Recipes.FirstOrDefault(s => s.AssetId == woot).RequiredUpgrades = new ItemDefinition[] { item1 };
            QuestLog.Log("[Questing Update | Modifier]: " + woot + " Required Upgrades Modified");
        }

        private void ModifyUpgrade(GUID name1, GUID name2, GUID woot)
        {
            var item1 = GameResources.Instance.Items.FirstOrDefault(s => s.AssetId == name1);
            var item2 = GameResources.Instance.Items.FirstOrDefault(s => s.AssetId == name2);
            GameResources.Instance.Recipes.FirstOrDefault(s => s.AssetId == woot).RequiredUpgrades = new ItemDefinition[] { item1, item2 };
            QuestLog.Log("[Questing Update | Modifier]: " + woot + " Required Upgrades Modified");

        }

        private void ModifyUpgrade(string name1, string name2, GUID woot)
        {
            var item1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == name1);
            var item2 = GameResources.Instance.Items.FirstOrDefault(s => s.name == name2);
            GameResources.Instance.Recipes.FirstOrDefault(s => s.AssetId == woot).RequiredUpgrades = new ItemDefinition[] { item1, item2 };
            QuestLog.Log("[Questing Update | Modifier]: " + woot + " Required Upgrades Modified");
        }

        private void ModifyTable(string name1, string modifyName)
        {
            GameResources.Instance.Recipes.FirstOrDefault(s => s.name == modifyName).Categories = new RecipeCategory[] { FindCategories(name1) };
            QuestLog.Log("[Questing Update | Modifier]: " + modifyName + " Categories Modified");
        }

        private void ModifyUpgrade(string name1, string name2, string modifyName)
        {
            var item1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == name1);
            var item2 = GameResources.Instance.Items.FirstOrDefault(s => s.name == name2);
            GameResources.Instance.Recipes.FirstOrDefault(s => s.name == modifyName).RequiredUpgrades = new ItemDefinition[] { item1, item2 };
            QuestLog.Log("[Questing Update | Modifier]: " + modifyName + " Required Upgrades Modified");
        }

        private void ModifyUpgrade(string name1, string name2, string name3, string modifyName)
        {
            var item1 = GameResources.Instance.Items.FirstOrDefault(s => s.name == name1);
            var item2 = GameResources.Instance.Items.FirstOrDefault(s => s.name == name2);
            var item3 = GameResources.Instance.Items.FirstOrDefault(s => s.name == name3);
            GameResources.Instance.Recipes.FirstOrDefault(s => s.name == modifyName).RequiredUpgrades = new ItemDefinition[] { item1, item2, item3 };
            QuestLog.Log("[Questing Update | Modifier]: " + modifyName + " Required Upgrades Modified");
        }
    }
}
