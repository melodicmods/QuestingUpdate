using System.Collections.Generic;
using System.IO;
using System.Linq;
using QuestingUpdate.lib.storage;
using QuestingUpdate.lib.scripts;
using UnityEngine;
using static QuestingUpdate.lib.data.ExportHandler;
using QuestingUpdate.lib.data;

namespace QuestingUpdate.lib
{
    class QuestingModifier : MonoBehaviour
    {
        public void InitModifier()
        {
            Test(GUID.Parse("4491E93910334C76AD68061AA8E71B5C"));
            ModifyCoalModule();

            ModifyTitanium();
            ModifyUpgrade("UpgradeStarterResearch", "UpgradeStarterRefineryRecipe");
            ModifyUpgrade("UpgradeStarterResearch", "StarterStructuresSchematicRecipe");
            ModifyUpgrade("UpgradeResourceRefining1", "SimpleExplosivesSchematicRecipe");

            // Module Mesh Modifiers
            ModifyModuleMesh("questingmodules", "assets/questing/cylinderroof1.obj", "assets/questing/39_TG.mat", "Cylinder9962", "Cylinder9962", "Cylinder9962", GUID.Parse("4491E93910334C76AD68061AA8E71B5C"));

            // Tier 1 Item Updates
            ModifyUpgrade("UpgradeResourceRefining1", "TinIngotRecipe");
            ModifyUpgrade("UpgradeResourceRefining1", "CopperIngotRecipe");
            ModifyUpgrade("UpgradeCopperworking", "TinBoltsRecipe");
            ModifyUpgrade("UpgradeCopperworking", "TinPlatesRecipe");
            ModifyUpgrade("UpgradeCopperworking", "TinTubesRecipe");
            ModifyUpgrade("UpgradeCopperworking", "CopperBoltsRecipe");
            ModifyUpgrade("UpgradeCopperworking", "CopperPlatesRecipe");
            ModifyUpgrade("UpgradeCopperworking", "CopperTubesRecipe");
            ModifyUpgrade("UpgradeCopperArmor", QuestingGUIDs.ArmorKitCopperRecipe);
            ModifyUpgrade("UpgradeSimpleWeapons", QuestingGUIDs.RevolverWeaponRecipe);
            ModifyUpgrade("UpgradeSimpleWeapons", QuestingGUIDs.ShotgunWeaponRecipe);
            ModifyUpgrade("UpgradeTurretsTier1", QuestingGUIDs.RevolverTurretModuleRecipe);
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
            ModifyTable("ResearchTier3", "UpgradeExpertAlloyingRecipe");
            ModifyTable("ResearchTier3", "UpgradeResourceRefining3Recipe");
            ModifyTable("ResearchTier3", "UpgradeCobaltRefiningRecipe");
            ModifyTable("ResearchTier3", "UpgradeCobaltworkingRecipe");
            ModifyTable("ResearchTier3", "UpgradeAdvancedCobaltPartsRecipe");
            ModifyTable("ResearchTier3", "UpgradeAlloyingTier3Recipe");
            ModifyTable("ResearchTier3", "UpgradeTitanworkingRecipe");
            ModifyTable("ResearchTier3", "UpgradeCobaltArmorRecipe");
            ModifyTable("ResearchTier3", "UpgradeTitanArmorRecipe");
            ModifyTable("ResearchTier3", "UpgradeAdvancedWeaponsRecipe");
            ModifyTable("ResearchTier3", "UpgradeTurretsTier3Recipe");
            ModifyTable("ResearchTier3", "UpgradeAdvancedTurrets3Recipe");
            ModifyTable("ResearchTier3", "UpgradeDrillshipParts3Recipe");
            ModifyTable("ResearchTier3", "UpgradeDrill4Recipe");
            ModifyTable("ResearchTier3", "UpgradeHeatResistanceRecipe");

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

        private void Test(GUID builder)
        {
            var itemthing = GameResources.Instance.Items.FirstOrDefault(s => s.AssetId == builder);
            var prefab = itemthing.Prefabs[0];
            foreach (var obj in prefab.GetComponentsInChildren<Object>())
            {
                //QuestLog.Log("[Questing Update | Modifier]: " + obj);
            }
        }

        private void ModifyCoalModule()
        {
            var cubePrefab = QuestingAssets.GetAsset("event.candle", "assets/chaos/candlefab.prefab");
            var newMaterial = QuestingAssets.GetMaterial("event.candle", "assets/chaos/candle.mat");
            var coalItem = GameResources.Instance.Items.FirstOrDefault(s => s.AssetId == QuestingGUIDs.CoalPowerModuleT1);
            if (coalItem == null) {
                QuestLog.Log("CoalPowerModuleT1 not found.");
                return;
            }

            var coalTopPrefab = coalItem.Prefabs[1];

            var parent = new GameObject();
            parent.SetActive(false);
            DontDestroyOnLoad(parent);

            var coalTopPrefabCopy = Instantiate(coalTopPrefab, parent.transform);
            var cubePrefabCopy    = Instantiate(cubePrefab, coalTopPrefabCopy.transform);

            // Get the meshFilter from the instanced cube prefab.
            var cubeMeshFilter = cubePrefabCopy.GetComponentsInChildren<MeshFilter>().First();
            if (cubeMeshFilter == null) {
                QuestLog.Log("cubeMeshFilter (Cylinder9648) not found.");
                return;
            }

            // For each animator in coalTopPrefabCopy.
            foreach (var animator in coalTopPrefabCopy.GetComponentsInChildren<Animator>()) {
                // For each meshFilter in animator with name == "Cylinder9648".
                foreach (var meshFilter in animator.GetComponentsInChildren<MeshFilter>().Where(meshFilter => meshFilter.name == "Cylinder9648")) {
                    meshFilter.mesh = cubeMeshFilter.mesh;
                }

                // For each meshRenderer in animator with name == "Cylinder9648".
                foreach (var meshRenderer in animator.GetComponentsInChildren<MeshRenderer>().Where(meshRenderer => meshRenderer.name == "Cylinder9648")) {
                    meshRenderer.material.mainTexture = newMaterial.mainTexture;
                    meshRenderer.material.globalIlluminationFlags = newMaterial.globalIlluminationFlags;
                }

                foreach(var objectlist in coalTopPrefab.GetComponentsInChildren<Transform>())
                {
                    foreach (var transformMesh in objectlist.GetComponentsInChildren<MeshRenderer>().Where(transformMesh => transformMesh.name == "Cylinder9648"))
                    {
                        transformMesh.material = newMaterial;
                    }
                }
            }
            cubePrefabCopy.DestroyAuto();
            coalItem.Prefabs[1] = coalTopPrefabCopy;
        }

        private void ModifyModuleMesh(string assetBundle, string prefabAsset, string matAsset, string meshFilterName, string meshRenderName, string transformMeshName, GUID baseItem)
        {
            var cubePrefab = QuestingAssets.GetAsset(assetBundle, prefabAsset);
            var newMaterial = QuestingAssets.GetMaterial(assetBundle, matAsset);
            var coalItem = GameResources.Instance.Items.FirstOrDefault(s => s.AssetId == baseItem);
            if (coalItem == null)
            {
                QuestLog.Log("Module not found.");
                return;
            }

            var coalTopPrefab = coalItem.Prefabs[0];

            var parent = new GameObject();
            parent.SetActive(false);
            DontDestroyOnLoad(parent);
            parent.transform.position = new Vector3(100.0f, 0.0f, 0.0f);

            var coalTopPrefabCopy = Instantiate(coalTopPrefab, parent.transform);
            var cubePrefabCopy = Instantiate(cubePrefab, coalTopPrefabCopy.transform);

            // Get the meshFilter from the instanced cube prefab.
            var cubeMeshFilter = cubePrefabCopy.GetComponentsInChildren<MeshFilter>().First();
            if (cubeMeshFilter == null)
            {
                QuestLog.Log("cubeMeshFilter (Cylinder9648) not found.");
                return;
            }

            // For each animator in coalTopPrefabCopy.
            foreach (var animator in coalTopPrefabCopy.GetComponentsInChildren<Animator>())
            {
                // For each meshFilter in animator with name == "Cylinder9648".
                foreach (var meshFilter in animator.GetComponentsInChildren<MeshFilter>().Where(meshFilter => meshFilter.name == meshFilterName))
                {
                    meshFilter.mesh = cubeMeshFilter.mesh;
                }

                // For each meshRenderer in animator with name == "Cylinder9648".
                foreach (var meshRenderer in animator.GetComponentsInChildren<MeshRenderer>().Where(meshRenderer => meshRenderer.name == meshRenderName))
                {
                    meshRenderer.material = newMaterial;
                    meshRenderer.material.shader = newMaterial.shader;
                    meshRenderer.material.mainTexture = newMaterial.mainTexture;
                    foreach (var objthing in meshRenderer.materials)
                    {
                        //QuestLog.Log("" + objthing);
                    }
                }

                foreach (var objectlist in coalTopPrefab.GetComponentsInChildren<Transform>())
                {
                    foreach (var transformMesh in objectlist.GetComponentsInChildren<MeshRenderer>().Where(transformMesh => transformMesh.name == transformMeshName))
                    {
                        transformMesh.material = newMaterial;
                        transformMesh.material.shader = newMaterial.shader;
                        transformMesh.material.mainTexture = newMaterial.mainTexture;
                    }
                }
            }
            cubePrefabCopy.DestroyAuto();
            coalItem.Prefabs[0] = coalTopPrefabCopy;

            foreach(var obj in coalItem.Prefabs[0].GetComponentsInChildren<Transform>())
            {
                if(obj.name == transformMeshName)
                {
                    //QuestLog.Log("" + obj);
                    obj.position = obj.position + new Vector3(-0.5f, 0.0f, 0.0f);
                }
            }
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
