using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace VolcQuestingUpdate.lib {
    class QuestingStations : MonoBehaviour {
        private static readonly GUID      productionStationGUID            = GUID.Parse("7c32d187420152f4da3a79d465cbe87a");
        public void InitStations() {
            var forging = FindCategories("AlloyForge");
            CreateStation(forging, "AlloyForgeStation", 99, "Alloy Station", "The Alloying Station", "B1F1B7BD39D34806ACCC4E1A151557F4", Sprite2("Resources/Stations/AlloyForgeControlStation.png"));

            Debug.Log("[Questing Update | Stations]: Stations Loaded...");
        }

        private static void Initialize<T>(ref T str)
            where T : struct, ISerializationCallbackReceiver {
            str.OnAfterDeserialize();
        }

        public FactoryType FindCategories(string categoryName) {
            return GameResources.Instance.FactoryTypes.FirstOrDefault(type => type?.name == categoryName);
        }

        //private void CreateStation(FactoryType factoryType, string codename, int maxStack, LocalizedString name, LocalizedString desc, string guidString) {
        //    var guid        = GUID.Parse(guidString);
        //    var prodStation = GameResources.Instance.Items.FirstOrDefault(s => s.AssetId == productionStationGUID);
        //    if (prodStation == null) {
        //        Debug.LogError($"No production station item found ({productionStationGUID}).");
        //        return;
        //    }

        //    var item = ScriptableObject.CreateInstance<ItemDefinition>();
        //    item.name     = codename;
        //    item.Category = prodStation.Category;
        //    item.MaxStack = maxStack;

        //    var nameStr = name;
        //    var descStr = desc;
        //    Initialize(ref nameStr);
        //    Initialize(ref descStr);
        //    ItemDef_mNameField?.SetValue(item, nameStr);
        //    ItemDef_mDescriptionField?.SetValue(item, descStr);

        //    Def_AssetIdField?.SetValue(item, guid);

        //    // Copy prefabs, update props, and set as out new item's prefabs.
        //    item.Prefabs = new GameObject[prodStation.Prefabs.Length];

        //    for (var i = 0; i < prodStation.Prefabs.Length; i++) {
        //        item.Prefabs[i] = Instantiate(prodStation.Prefabs[i], prodStation.Prefabs[i].transform);

        //        if (item.Prefabs[i].TryGetComponent<FactoryStation>(out var factoryStation)) {
        //            FactoryStation_mFactoryTypeField.SetValue(factoryStation, factoryType);
        //        }
        //    }

        //    AssetReference[] assets = {new AssetReference {Object = item, Guid = guid, Labels = new string[0]}};
        //    RuntimeAssetStorage.Add(assets, default);
        //}

        private Sprite Sprite2(string iconpath)
        {
            var path = System.IO.Path.Combine(Application.persistentDataPath, "Mods", iconpath);
            if (!File.Exists(path))
            {
                Debug.LogError("[Questing Update | Stations]: Specified Icon path not found: " + path);
                return null;
            }
            var bytes = File.ReadAllBytes(path);


            var texture = new Texture2D(512, 512, TextureFormat.ARGB32, true);
            texture.LoadImage(bytes);

            var sprite = Sprite.Create(texture, new Rect(Vector2.zero, Vector2.one * texture.width), new Vector2(0.5f, 0.5f), texture.width, 0, SpriteMeshType.FullRect, Vector4.zero, false);
            return sprite;
        }

        private void CreateStation(FactoryType factoryType, string codename, int maxStack, LocalizedString name, LocalizedString desc, string guidString, Sprite icon)
        {
            var category = GameResources.Instance.Items.FirstOrDefault(s => s.AssetId == productionStationGUID).Category;
            var item = ScriptableObject.CreateInstance<ItemDefinition>();
            item.name = codename;
            item.Category = category;
            item.MaxStack = maxStack;
            item.Icon = icon;

            var prefabParent = new GameObject();
            var olditem = GameResources.Instance.Items.FirstOrDefault(s => s.AssetId == productionStationGUID);
            var factorytype = factoryType;
            prefabParent.SetActive(false);
            var newmodule = Instantiate(olditem.Prefabs[0], prefabParent.transform);
            newmodule.SetActive(false);
            var module = newmodule.GetComponentInChildren<FactoryStation>();
            item.Prefabs = new GameObject[] { newmodule };

            LocalizedString nameStr = name;
            LocalizedString descStr = desc;
            Initialize(ref nameStr);
            Initialize(ref descStr);

            typeof(FactoryStation).GetField("m_factoryType", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(module, factorytype);
            typeof(ItemDefinition).GetField("m_name", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, nameStr);
            typeof(ItemDefinition).GetField("m_description", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, descStr);

            var guid = GUID.Parse(guidString);

            typeof(Definition).GetField("m_assetId", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, guid);

            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = item, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);
        }
    }
}