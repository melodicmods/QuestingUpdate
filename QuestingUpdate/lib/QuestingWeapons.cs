using QuestingUpdate.lib.scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace QuestingUpdate.lib
{
    class QuestingWeapons
    {
        public QuestingWeapons()
        {
            Test();
            CopyRevolver();
        }

        public static void Test()
        {
            var smg = GameResources.Instance.Items.FirstOrDefault(s => s.name == "SMG");
            var something = GameResourcesTools.Instance.ToolGroupLookup.ToArray();
            foreach(var obj in something)
            {
                foreach(var thing in obj.Value)
                {
                    if(thing.name == "SMG")
                    {
                        thing.name = "SMG Modified";
                        thing.SetName("SMG Modified");
                        QuestLog.Log(thing.name);
                        QuestLog.Log(thing.Name);
                        QuestLog.Log(thing.Description);
                        smg.name = "SMG Modified";
                    }
                }
            }

        }

        public static void CopyRevolver()
        {
            var revolver = GameResources.Instance.Items.FirstOrDefault(s => s.name == "Revolver");

            QuestLog.Log("" + revolver.Category);

            var guid = GUID.Parse("CA25D7B116F14B97A7D51EFB94406B93");

            var item = UnityEngine.Object.Instantiate(revolver);
            item.name = "Super Revolver";
            item.Category = revolver.Category;
            item.MaxStack = revolver.MaxStack;
            item.Icon = revolver.Icon;

            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = item, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);
        }
    }
}
