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
    class QuestingStations : MonoBehaviour
    {
        public void InitStations()
        {
            FactoryType forging = Findcategories("AlloyForge");
            CreateStation(forging, "AlloyForgeStation", 99, "Alloy Station", "The Alloying Station", "B1F1B7BD39D34806ACCC4E1A151557F4");

            Debug.Log("[Questing Update | Stations]: Stations Loaded...");
        }

        private static void Initialize<T>(ref T str)
        where T : struct, ISerializationCallbackReceiver
        {
            str.OnAfterDeserialize();
        }

        private FactoryType tempcategory;
        public FactoryType Findcategories(string categoryname)
        {
            tempcategory = null;
            foreach (FactoryType type in GameResources.Instance.FactoryTypes)
            {
                    if (type != null && categoryname != null)
                    {
                        if (type.name == categoryname)
                        {
                            tempcategory = type;
                        }
                    }
            }
            return tempcategory;
        }

        private void CreateStation(FactoryType categories, string codename, int maxstack, LocalizedString name, LocalizedString desc, string guidstring)
        {
            var category = GameResources.Instance.Items.FirstOrDefault(s => s.name == "ProductionStation").Category;
            var item = ScriptableObject.CreateInstance<ItemDefinition>();
            item.name = codename;
            item.Category = category;
            item.MaxStack = maxstack;

            LocalizedString nameStr = name;
            LocalizedString descStr = desc;
            Initialize(ref nameStr);
            Initialize(ref descStr);

            var prefabParent = new GameObject();
            var olditem = GameResources.Instance.Items.FirstOrDefault(s => s.name == "ProductionStation");
            var newmodule = Instantiate(olditem.Prefabs[0], prefabParent.transform);
            var module = newmodule.GetComponentInChildren<FactoryStation>();
            typeof(FactoryStation).GetField("m_factoryType", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(module, categories);
            typeof(ItemDefinition).GetField("m_name", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, nameStr);
            typeof(ItemDefinition).GetField("m_description", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, descStr);
            var guid = GUID.Parse(guidstring);
            typeof(Definition).GetField("m_assetId", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, guid);

            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = item, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);
        }
    }
}
