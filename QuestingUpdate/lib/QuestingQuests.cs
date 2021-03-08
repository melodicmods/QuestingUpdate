using QuestingUpdate.lib.scripts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace QuestingUpdate.lib
{
    class QuestingQuests
    {
        private static Quest[] alteredQuests;
        private static FieldInfo mQuestsField;
        private static readonly string path = Environment.GetEnvironmentVariable("USERPROFILE") + "/appdata/locallow/volcanoid/volcanoids/mods/Resources/";
        public void InitQuests()
        {
            Tests();
            foreach (Quest obj in alteredQuests)
            {
                QuestLog.Log("" + obj.name);
            }
        }

        private void Tests()
        {
            mQuestsField = typeof(QuestManager).GetField("m_quests", BindingFlags.NonPublic | BindingFlags.Instance);
            var questManagers = Resources.FindObjectsOfTypeAll<QuestManager>();

            if (questManagers != null)
            {
                foreach (var questManager in questManagers)
                {
                    // If we got here quests are enabled.
                    ProcessQuestManager(questManager);
                }
            }
        }

        private void ProcessQuestManager(QuestManager questManager)
        {
            var quests = (Quest[])mQuestsField.GetValue(questManager);
            if (quests?.Length > 0)
            {
                if (alteredQuests != null)
                {
                    // We've already setup the quests, just overwrite the list.
                    mQuestsField.SetValue(questManager, alteredQuests);
                    return;
                }

                // New quests haven't been setup yet, do so and cache the result.
                alteredQuests = CreateNewQuests(quests);

                mQuestsField.SetValue(questManager, alteredQuests);
            }
        }

        private static void Initialize<T>(ref T str)
        where T : struct, ISerializationCallbackReceiver
        {
            str.OnAfterDeserialize();
        }

        private Quest[] CreateNewQuests(Quest[] oldQuests)
        {
            string name = "A Royal Pain in my Ass";
            string desc = "A Royal Pain in my Ass";
            //QuestLog.Log("[Questing Update | Quests]: " + typeof(Quest).GetField("Description", BindingFlags.NonPublic | BindingFlags.Instance));
            GameObject baseObject = new GameObject();
            PlayerQuest baseQuest = baseObject.AddComponent<PlayerQuest>();
            baseQuest.name = "Q73_ARoyalPainInMyAss";
            QuestDescription description = ScriptableObject.CreateInstance<QuestDescription>();

            LocalizedString nameStr = name;
            LocalizedString descStr = desc;
            Initialize(ref nameStr);
            Initialize(ref descStr);

            typeof(QuestDescription).GetField("m_description", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(description, descStr);
            typeof(QuestDescription).GetField("m_name", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(description, nameStr);
            typeof(QuestDescription).GetField("m_icon", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(description, Sprite2(path + "Schematics/NullSchematic.png"));

            typeof(Quest).GetField("m_priority", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(baseQuest, 0);
            typeof(Quest).GetField("m_description", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(baseQuest, description);
            typeof(Quest).GetField("m_isEvent", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(baseQuest, false);
            alteredQuests = oldQuests;
            List<Quest> quests = alteredQuests.ToList();
            quests.Add(baseQuest);
            alteredQuests = quests.ToArray();
            return alteredQuests;
            //throw new NotImplementedException();
        }

        private Sprite Sprite2(string iconpath)
        {
            var path = Path.Combine(Application.persistentDataPath, "Mods", iconpath);
            if (!File.Exists(path))
            {
                QuestLog.Log("ERROR: [Questing Update | Modules]: Specified Icon path not found: " + path);

                Debug.LogError("[Questing Update | Modules]: Specified Icon path not found: " + path);
                return null;
            }
            var bytes = File.ReadAllBytes(path);


            var texture = new Texture2D(512, 512, TextureFormat.ARGB32, true);
            texture.LoadImage(bytes);

            var sprite = Sprite.Create(texture, new Rect(Vector2.zero, Vector2.one * texture.width), new Vector2(0.5f, 0.5f), texture.width, 0, SpriteMeshType.FullRect, Vector4.zero, false);
            return sprite;
        }
    }
}
