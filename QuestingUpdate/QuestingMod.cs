using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using VolcQuestingUpdate.lib;

namespace VolcanoidsMod {
    public class QuestingMod : GameMod
    {
        private const string version = "0.1.3";

        public override void Load()
        {
            var lastWrite = File.GetLastWriteTime(typeof(QuestingMod).Assembly.Location);
            Debug.Log($"[Questing Update | Main]: Questing Update loaded: {version}, build time: {lastWrite.ToShortTimeString()}");

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode) {
            switch (scene.name)
            {
                case "MainMenu":
                    GameObject.Find("EarlyAccess").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Questing Update " + version;
                    GameObject.Find("SteamBranch").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Questing Update";
                    GameObject.Find("Version").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text     = "Version: 1.25.72 (ClosedTesting)";
                    break;
                case "Island":
                    new QuestingItems().InitItems();
                    new QuestingRecipes().InitRecipes();
                    new QuestingDeposits().InitDeposits();
                    new QuestingCategories().InitCategories();
                    new QuestingModules().InitModules();
                    new QuestingStations().InitStations();
                    break;
            }
        }

        public override void Unload()
        {
            Debug.Log("[Questing Update | Main]: Questing Update unloaded");
        }
    }
}

