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
    class QuestingItems
    {
        public void InitItems()
        {
            CreateItem("CobaltIngot", 20, "Cobalt Ingot",
                "Used in production to produce base components \r\n" + "Part of the Questing Update",
                "6939388A466C45B899EEF83634EEA6C6", "TitaniumIngot", Sprite2("Resources/Ingots/CobaltIngot.png"));
            CreateItem("CobaltOre", 100, "Cobalt Ore",
            "The Base Ore for Cobalt Ingots \r\n" + "Part of the Questing Update",
            "F614E50F801E4806943C8AEEDE851680", "TitaniumOre", Sprite2("Resources/Ore/CobaltOre.png"));
            CreateItem("BronzeIngot", 50, "Bronze Ingot",
            "An Alloy of Copper and Tin \r\n" + "Part of the Questing Update",
            "B336DD641E644F54847FCFEDA51AD91A", "CopperIngot", Sprite2("Resources/Ingots/BronzeIngot.png"));
            CreateItem("TinIngot", 50, "Tin Ingot",
            "A Lightweight and Flimsy Metal \r\n" + "Part of the Questing Update",
            "894431113D60413AA9996840E2C17873", "CopperIngot", Sprite2("Resources/Ingots/TinIngot.png"));
            CreateItem("TinOre", 100, "Tin Ore",
            "The Base Ore for Tin Ingots \r\n" + "Part of the Questing Update",
            "75B8677E7AB04B19AB44BB9CD513E3E1", "CopperOre", Sprite2("Resources/Ore/TinOre.png"));
            CreateItem("SteelIngot", 50, "Steel Ingot",
            "A Lightweight and Strong Alloy \r\n" + "Part of the Questing Update",
            "A810DD6B32D64081B84029724C9496AC", "IronIngot", Sprite2("Resources/Ingots/SteelIngot.png"));
            CreateItem("BronzeBolts", 99, "Bronze Bolts",
            "Alloyed Bolts, Stronger than those of Copper or Tin \r\n" + "Part of the Questing Update",
            "E8C57A5C658E42ECAED404FB2B92A6DD", "CopperBolts", Sprite2("Resources/Items/BronzeBolts.png"));
            CreateItem("BronzePlates", 99, "Bronze Plates",
            "Alloyed Plates, Stronger than those of Copper or Tin \r\n" + "Part of the Questing Update",
            "ABCFA112CE1E4A358C8FFEA726686E93", "CopperPlates", Sprite2("Resources/Items/BronzePlates.png"));
            CreateItem("BronzeTubes", 99, "Bronze Tubes",
            "Alloyed Tubes, Stronger than those of Copper or Tin \r\n" + "Part of the Questing Update",
            "004199204E964EFBA4599E2F7A8BF5C2", "CopperTubes", Sprite2("Resources/Items/BronzeTubes.png"));
            CreateItem("CobaltBolts", 99, "Cobalt Bolts",
            "Shiny Blue Bolts \r\n" + "Part of the Questing Update",
            "7447972B67FA47F28673BA5135827B92", "TitaniumBolts", Sprite2("Resources/Items/CobaltBolts.png"));
            CreateItem("CobaltPlates", 99, "Cobalt Plates",
            "Shiny Blue Plates \r\n" + "Part of the Questing Update",
            "A1F8674359484C92AFFC6B67BD8FA1F4", "TitaniumPlates", Sprite2("Resources/Items/CobaltPlates.png"));
            CreateItem("CobaltTubes", 99, "Cobalt Tubes",
            "Shiny Blue Tubes \r\n" + "Part of the Questing Update",
            "843209B8B0F5409F843EB660AC69535B", "TitaniumTubes", Sprite2("Resources/Items/CobaltTubes.png"));
            CreateItem("SteelBolts", 99, "Steel Bolts",
            "Alloyed Bolts, Stronger than those of Iron \r\n" + "Part of the Questing Update",
            "3F660A0559474433A6E2A91E0C7D62C6", "IronBolts", Sprite2("Resources/Items/SteelBolts.png"));
            CreateItem("SteelPlates", 99, "Steel Plates",
            "Alloyed Plates, Stronger than those of Iron \r\n" + "Part of the Questing Update",
            "704B9BE418024F64BFA8F4CAC549DAB3", "IronPlates", Sprite2("Resources/Items/SteelPlates.png"));
            CreateItem("SteelTubes", 99, "Steel Tubes",
            "Alloyed Tubes, Stronger than those of Iron \r\n" + "Part of the Questing Update",
            "FC6A2C44E9B94320BFF9813306DF53DF", "IronTubes", Sprite2("Resources/Items/SteelTubes.png"));
            CreateItem("TinBolts", 99, "Tin Bolts",
            "Shiny White Bolts, Very Weak \r\n" + "Part of the Questing Update",
            "342B6C85C6D44AC58B89269E41F50E66", "CopperBolts", Sprite2("Resources/Items/TinBolts.png"));
            CreateItem("TinPlates", 99, "Tin Plates",
            "Shiny White Plates, Very Weak \r\n" + "Part of the Questing Update",
            "EF40281A91D54F519452E205D343EADD", "CopperPlates", Sprite2("Resources/Items/TinPlates.png"));
            CreateItem("TinTubes", 99, "Tin Tubes",
            "Shiny White Tubes, Very Weak \r\n" + "Part of the Questing Update",
            "F51DB9FAEA524382A6EF69C540923127", "CopperTubes", Sprite2("Resources/Items/TinTubes.png"));
            CreateItem("NullItem", 1000, "Null Item",
                "This item is to indicate that an item is null",
                "29B8BE6CAB6E43BB99ED496C06553B0A", "IronIngot", Sprite2("Resources/Icon/QuestingLogo.png"));

            Debug.Log("[Questing Update | Items]: Items Loaded...");
        }

        private static void Initialize<T>(ref T str)
        where T : struct, ISerializationCallbackReceiver
        {
            str.OnAfterDeserialize();
        }
        private Sprite Sprite2(string iconpath)
        {
            var path = System.IO.Path.Combine(Application.persistentDataPath, "Mods", iconpath);
            if (!File.Exists(path))
            {
                Debug.LogError("[Questing Update | Items]: Specified Icon path not found: " + path);
                return null;
            }
            var bytes = File.ReadAllBytes(path);


            var texture = new Texture2D(512, 512, TextureFormat.ARGB32, true);
            texture.LoadImage(bytes);

            var sprite = Sprite.Create(texture, new Rect(Vector2.zero, Vector2.one * texture.width), new Vector2(0.5f, 0.5f), texture.width, 0, SpriteMeshType.FullRect, Vector4.zero, false);
            return sprite;
        }

        private void CreateItem(string codename, int maxstack, LocalizedString name, LocalizedString desc, string guidstring, string recipecategoryname, Sprite icon)
        {
            var recipecategory = GameResources.Instance.Items.FirstOrDefault(s => s.name == recipecategoryname);

            var item = ScriptableObject.CreateInstance<ItemDefinition>();
            item.name = codename;
            item.Category = recipecategory.Category;
            item.MaxStack = maxstack;
            item.Icon = icon;
            LocalizedString nameStr = name;
            LocalizedString descStr = desc;
            Initialize(ref nameStr);
            Initialize(ref descStr);

            typeof(ItemDefinition).GetField("m_name", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, nameStr);
            typeof(ItemDefinition).GetField("m_description", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, descStr);

            var guid = GUID.Parse(guidstring);

            typeof(Definition).GetField("m_assetId", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).SetValue(item, guid);

            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = item, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);
        }
    }
}
