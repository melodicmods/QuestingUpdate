using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using QuestingUpdate.lib;
using System.Diagnostics;
using QuestingUpdate.lib.scripts;
using QuestingUpdate.lib.addons;

namespace QuestingUpdate {
    public class QuestingMod : GameMod
    {
        public const string version = "0.3.1";
        private string update = "";
        private string updateName = "";
        public static readonly string path = System.Environment.GetEnvironmentVariable("USERPROFILE") + "/appdata/locallow/volcanoid/volcanoids/QuestingUpdate.log";
        public override void Load()
        {
            var lastWrite = File.GetLastWriteTime(typeof(QuestingMod).Assembly.Location);
            UnityEngine.Debug.Log($"[Questing Update | Main]: Questing Update loaded: {version}, build time: {lastWrite.ToShortTimeString()}");
            QuestLog.Log($"[Questing Update | Main]: Questing Update loaded: {version}, build time: {lastWrite.ToShortTimeString()}", true);

            QuestingVersioning versioning = new QuestingVersioning();
            versioning.InitVersions();
            update = versioning.UpdateVersioner();

            if(versioning.needUpdate == false)
            {
                QuestingNamer namer = new QuestingNamer();
                updateName = namer.Namer();
            } else
            {
                updateName = "Questing Update";
            }
            

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode) {
            switch (scene.name)
            {
                case "MainMenu":
                    GameObject.Find("EarlyAccess").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Questing Update " + version;
                    GameObject.Find("SteamBranch").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = updateName + " " + update;
                    GameObject.Find("Version").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text     = "Version: 1.25.72 (ClosedTesting)";
                    break;
                case "Island":
                    QuestLog.Log("---Addon Registration Begin---");
                    new AddonController();
                    QuestLog.Log("---Addon Registration End---");
                    QuestLog.Log("---Questing Items Begin---");
                    new QuestingItems().InitItems();
                    QuestLog.Log("[Questing Update | Main]: Items Done.");
                    QuestLog.Log("---Questing Items End---");

                    QuestLog.Log("---Questing Deposits Begin---");
                    new QuestingDeposits().InitDeposits();
                    QuestLog.Log("[Questing Update | Main]: Deposits Done.");
                    QuestLog.Log("---Questing Deposits End---");

                    QuestLog.Log("---Questing Categories Begin---");
                    new QuestingCategories().InitCategories();
                    QuestLog.Log("[Questing Update | Main]: Categories Done.");
                    QuestLog.Log("---Questing Categories End---");

                    QuestLog.Log("---Questing Modules Begin---");
                    new QuestingModules().InitModules();
                    QuestLog.Log("[Questing Update | Main]: Modules Done.");
                    QuestLog.Log("---Questing Modules End---");

                    QuestLog.Log("---Questing Stations Begin---");
                    new QuestingStations().InitStations();
                    QuestLog.Log("[Questing Update | Main]: Stations Done.");
                    QuestLog.Log("---Questing Stations End---");
                    
                    QuestLog.Log("---Questing Recipes Begin---");
                    new QuestingRecipes().InitRecipes();
                    QuestLog.Log("[Questing Update | Main]: Recipes Done.");
                    QuestLog.Log("---Questing Recipes End---");
                    
                    QuestLog.Log("---Questing Modifier Begin---");
                    new QuestingModifier().InitModifier();
                    QuestLog.Log("[Questing Update | Main]: Modifier Done.");
                    QuestLog.Log("---Questing Modifier End---");
                    
                    QuestLog.Log("[Questing Update | Main]: Done with Init.");
                    break;
            }
        }

        public override void Unload()
        {
            UnityEngine.Debug.Log("[Questing Update | Main]: Questing Update unloaded");
            QuestLog.Log("[Questing Update | Main]: Game Finished, Closing...");
        }
    }
}

