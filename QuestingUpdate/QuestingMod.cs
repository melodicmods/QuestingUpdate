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
                    Debug.Log("QuestingMod: Items Done.");

                    new QuestingDeposits().InitDeposits();
                    Debug.Log("QuestingMod: Deposits Done.");

                    new QuestingCategories().InitCategories();
                    Debug.Log("QuestingMod: Categories Done.");

                    new QuestingModules().InitModules();
                    Debug.Log("QuestingMod: Modules Done.");

                    new QuestingStations().InitStations();
                    Debug.Log("QuestingMod: Stations Done.");

                    new QuestingRecipes().InitRecipes();
                    Debug.Log("QuestingMod: Recipes Done.");

                    Debug.Log("QuestingMod: Done with init.");
                    break;
            }
        }

        public override void Unload()
        {
            Debug.Log("[Questing Update | Main]: Questing Update unloaded");
        }
    }
}

