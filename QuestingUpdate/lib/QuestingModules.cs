using QuestingUpdate.lib.scripts;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace QuestingUpdate.lib
{
    class QuestingModules : MonoBehaviour
    {
        public void InitModules() 
        {
            var tier1Forge = new RecipeCategory[] { Findcategories("ForgeTier1") };
            var tier2Forge = new RecipeCategory[] { Findcategories("ForgeTier1"), Findcategories("ForgeTier2") };
            var tier3Forge = new RecipeCategory[] { Findcategories("ForgeTier1"), Findcategories("ForgeTier2"), Findcategories("ForgeTier3") };
            CreateInitialItemModuleProduction("AlloyForgeTier1", "Tier1", 5, "RefineryModuleT1", "Alloy Forge Tier 1", "The Alloy Forge for Bronze", "4491E93910334C76AD68061AA8E71B5C", "RefineryModuleT1", "AlloyForge", Sprite2("Resources/Modules/AlloyForge1.png"), tier1Forge);
            CreateItemModuleProduction("AlloyForgeTier2", "Tier2", 5, "RefineryModuleT2", "Alloy Forge Tier 2", "The Alloy Forge for Steel", "3090980A28994112A197A342945DD1D0", "RefineryModuleT2", "AlloyForge", Sprite2("Resources/Modules/AlloyForge2.png"), tier2Forge);
            CreateItemModuleProduction("AlloyForgeTier3", "Tier3", 5, "RefineryModuleT3", "Alloy Forge Tier 3", "The Alloy Forge for Titanium", "1B2D3ED6CDCC460191183B13BA8D5F5F", "RefineryModuleT3", "AlloyForge", Sprite2("Resources/Modules/AlloyForge3.png"), tier3Forge);

            using (StreamWriter writer = new StreamWriter(QuestingMod.path, true))
            {
                writer.WriteLine("[Questing Update | Modules]: Modules Loaded...");
                writer.Dispose();
            }
            Debug.Log("[Questing Update | Modules]: Modules Loaded...");
        }
        private RecipeCategory tempcategory;
        public RecipeCategory Findcategories(string categoryname)
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
        private Sprite Sprite2(string iconpath)
        {
            var path = System.IO.Path.Combine(Application.persistentDataPath, "Mods", iconpath);
            if (!File.Exists(path))
            {
                using (StreamWriter writer = new StreamWriter(QuestingMod.path, true))
                {
                    writer.WriteLine("ERROR: [Questing Update | Modules]: Specified Icon path not found: " + path);
                    writer.Dispose();
                }

                Debug.LogError("[Questing Update | Modules]: Specified Icon path not found: " + path);
                return null;
            }
            var bytes = File.ReadAllBytes(path);


            var texture = new Texture2D(512, 512, TextureFormat.ARGB32, true);
            texture.LoadImage(bytes);

            var sprite = Sprite.Create(texture, new Rect(Vector2.zero, Vector2.one * texture.width), new Vector2(0.5f, 0.5f), texture.width, 0, SpriteMeshType.FullRect, Vector4.zero, false);
            return sprite;
        }

        private static void Initialize<T>(ref T str)
        where T : struct, ISerializationCallbackReceiver
        {
            str.OnAfterDeserialize();
        }

        public void CreateItemModuleProduction(string codename, string variantname, int maxstack, string baseitem, LocalizedString name, LocalizedString desc, string guidstring, string categoryname, string factorytypename, Sprite icon, RecipeCategory[] categories)
        {
            var category = GameResources.Instance.Items.FirstOrDefault(s => s.name == categoryname).Category;
            var item = ScriptableObject.CreateInstance<ItemDefinition>();
            item.name = codename;
            item.Category = category;
            item.MaxStack = maxstack;
            item.Icon = icon;

            var prefabParent = new GameObject();
            var olditem = GameResources.Instance.Items.FirstOrDefault(s => s.name == baseitem);
            var factorytype = GameResources.Instance.FactoryTypes.FirstOrDefault(s => s.name == factorytypename);
            prefabParent.SetActive(false);
            var newmodule = Instantiate(olditem.Prefabs[0], prefabParent.transform);
            var module = newmodule.GetComponentInChildren<ProductionModule>();
            var gridmodule = newmodule.GetComponent<GridModule>();
            gridmodule.VariantName = variantname;
            gridmodule.Item = item;
            item.Prefabs = new GameObject[] { newmodule };
            var modulecategory = RuntimeAssetCacheLookup.Get<ModuleCategory>().First(s => s.name == factorytypename);
            modulecategory.Modules = modulecategory.Modules.Concat(new ItemDefinition[] { item }).ToArray();

            var productionGroup = QuestingReferences.GetOrCreateTyping(factorytype);

            LocalizedString nameStr = name;
            LocalizedString descStr = desc;
            Initialize(ref nameStr);
            Initialize(ref descStr);

            typeof(ProductionModule).GetField("m_factoryType", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(module, factorytype);
            typeof(ProductionModule).GetField("m_module", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(module, gridmodule);
            typeof(ProductionModule).GetField("m_categories", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(module, categories);
            typeof(ProductionModule).GetField("m_productionGroup", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(module, productionGroup);
            typeof(ItemDefinition).GetField("m_name", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, nameStr);
            typeof(ItemDefinition).GetField("m_description", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, descStr);

            var guid = GUID.Parse(guidstring);

            typeof(Definition).GetField("m_assetId", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, guid);

            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = item, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);

            using (StreamWriter writer = new StreamWriter(QuestingMod.path, true))
            {
                writer.WriteLine("[Questing Update | Modules]: Module " + codename + " has been loaded");
                writer.Dispose();
            }
        }

        public void CreateInitialItemModuleProduction(string codename, string variantname, int maxstack, string basename, LocalizedString name, LocalizedString desc, string guidstring, string categoryname, string factorytypename, Sprite icon, RecipeCategory[] categories)
        {
            var category = GameResources.Instance.Items.FirstOrDefault(s => s.name == categoryname).Category;
            var item = ScriptableObject.CreateInstance<ItemDefinition>();
            item.name = codename;
            item.Category = category;
            item.MaxStack = maxstack;
            item.Icon = icon;

            var prefabParent = new GameObject();
            var olditem = GameResources.Instance.Items.FirstOrDefault(s => s.name == basename);
            var factorytype = GameResources.Instance.FactoryTypes.FirstOrDefault(s => s.name == factorytypename);
            prefabParent.SetActive(false);
            var newmodule = Instantiate(olditem.Prefabs[0], prefabParent.transform);
            var module = newmodule.GetComponentInChildren<ProductionModule>();
            var gridmodule = newmodule.GetComponent<GridModule>();
            gridmodule.VariantName = variantname;
            gridmodule.Item = item;
            item.Prefabs = new GameObject[] { newmodule };
            var modulecategory = RuntimeAssetCacheLookup.Get<ModuleCategory>().First(s => s.name == factorytypename);
            var concatinated = new ItemDefinition[] { item };
            modulecategory.Modules = concatinated.ToArray();

            LocalizedString nameStr = name;
            LocalizedString descStr = desc;
            Initialize(ref nameStr);
            Initialize(ref descStr);

            typeof(ProductionModule).GetField("m_factoryType", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(module, factorytype);
            typeof(ProductionModule).GetField("m_module", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(module, gridmodule);
            typeof(ProductionModule).GetField("m_categories", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(module, categories);
            typeof(ItemDefinition).GetField("m_name", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, nameStr);
            typeof(ItemDefinition).GetField("m_description", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, descStr);

            var guid = GUID.Parse(guidstring);

            typeof(Definition).GetField("m_assetId", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, guid);

            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = item, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);

            using (StreamWriter writer = new StreamWriter(QuestingMod.path, true))
            {
                writer.WriteLine("[Questing Update | Modules]: Module " + codename + " has been loaded");
                writer.Dispose();
            }
        }
    }
}
