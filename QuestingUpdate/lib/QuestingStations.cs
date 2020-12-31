using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace VolcQuestingUpdate.lib {
    class QuestingStations : MonoBehaviour {
        private static readonly GUID      productionStationGUID            = GUID.Parse("7c32d187420152f4da3a79d465cbe87a");
        private static readonly FieldInfo FactoryStation_mFactoryTypeField = typeof(FactoryStation).GetField("m_factoryType", BindingFlags.NonPublic | BindingFlags.Instance);
        private static readonly FieldInfo ItemDef_mDescriptionField        = typeof(ItemDefinition).GetField("m_description", BindingFlags.NonPublic | BindingFlags.Instance);
        private static readonly FieldInfo ItemDef_mNameField               = typeof(ItemDefinition).GetField("m_name", BindingFlags.NonPublic | BindingFlags.Instance);
        private static readonly FieldInfo Def_AssetIdField                 = typeof(Definition).GetField("m_assetId", BindingFlags.NonPublic | BindingFlags.Instance);

        public void InitStations() {
            var forging = FindCategories("AlloyForge");
            CreateStation(forging, "AlloyForgeStation", 99, "Alloy Station", "The Alloying Station", "B1F1B7BD39D34806ACCC4E1A151557F4");

            Debug.Log("[Questing Update | Stations]: Stations Loaded...");
        }

        private static void Initialize<T>(ref T str)
            where T : struct, ISerializationCallbackReceiver {
            str.OnAfterDeserialize();
        }

        public FactoryType FindCategories(string categoryName) {
            return GameResources.Instance.FactoryTypes.FirstOrDefault(type => type?.name == categoryName);
        }

        private void CreateStation(FactoryType factoryType, string codename, int maxStack, LocalizedString name, LocalizedString desc, string guidString) {
            var guid        = GUID.Parse(guidString);
            var prodStation = GameResources.Instance.Items.FirstOrDefault(s => s.AssetId == productionStationGUID);
            if (prodStation == null) {
                Debug.LogError($"No production station item found ({productionStationGUID}).");
                return;
            }

            var item = ScriptableObject.CreateInstance<ItemDefinition>();
            item.name     = codename;
            item.Category = prodStation.Category;
            item.MaxStack = maxStack;

            var nameStr = name;
            var descStr = desc;
            Initialize(ref nameStr);
            Initialize(ref descStr);
            ItemDef_mNameField?.SetValue(item, nameStr);
            ItemDef_mDescriptionField?.SetValue(item, descStr);

            Def_AssetIdField?.SetValue(item, guid);

            // Copy prefabs, update props, and set as out new item's prefabs.
            item.Prefabs = new GameObject[prodStation.Prefabs.Length];

            for (var i = 0; i < prodStation.Prefabs.Length; i++) {
                item.Prefabs[i] = Instantiate(prodStation.Prefabs[i], prodStation.Prefabs[i].transform);

                if (item.Prefabs[i].TryGetComponent<FactoryStation>(out var factoryStation)) {
                    FactoryStation_mFactoryTypeField.SetValue(factoryStation, factoryType);
                }
            }

            AssetReference[] assets = {new AssetReference {Object = item, Guid = guid, Labels = new string[0]}};
            RuntimeAssetStorage.Add(assets, default);
        }
    }
}