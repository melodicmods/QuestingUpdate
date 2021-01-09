using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using QuestingUpdate.lib;
using System.Diagnostics;

namespace QuestingUpdate {
    public class QuestingMod : GameMod
    {
        public const string version = "0.2.2";
        private string update = "";
        private string updateName = "";
        public static readonly string path = System.Environment.GetEnvironmentVariable("USERPROFILE") + "/appdata/locallow/volcanoid/volcanoids/QuestingUpdate.log";
        public override void Load()
        {
            var lastWrite = File.GetLastWriteTime(typeof(QuestingMod).Assembly.Location);
            UnityEngine.Debug.Log($"[Questing Update | Main]: Questing Update loaded: {version}, build time: {lastWrite.ToShortTimeString()}");
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine($"[Questing Update | Main]: Questing Update loaded: {version}, build time: {lastWrite.ToShortTimeString()}");
                writer.Dispose();
            }

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
            var rootGameObject = scene.GetRootGameObjects()[0];
            if (!rootGameObject.gameObject.HasComponent<Component>())
            {
                rootGameObject.gameObject.AddComponent<Component>();
            }
            switch (scene.name)
            {
                case "MainMenu":
                    GameObject.Find("EarlyAccess").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Questing Update " + version;
                    GameObject.Find("SteamBranch").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = updateName + " " + update;
                    GameObject.Find("Version").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text     = "Version: 1.25.72 (ClosedTesting)";
                    break;
                case "Island":
                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        writer.WriteLine("---Questing Items Begin---");
                        writer.Dispose();
                    }
                    new QuestingItems().InitItems();
                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        writer.WriteLine("[Questing Update | Main]: Items Done.");
                        writer.WriteLine("---Questing Items End---");
                        writer.WriteLine("---Questing Deposits Begin---");
                        writer.Dispose();
                    }

                    new QuestingDeposits().InitDeposits();
                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        writer.WriteLine("[Questing Update | Main]: Deposits Done.");
                        writer.WriteLine("---Questing Deposits End---");
                        writer.WriteLine("---Questing Categories Begin---");
                        writer.Dispose();
                    }

                    new QuestingCategories().InitCategories();
                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        writer.WriteLine("[Questing Update | Main]: Categories Done.");
                        writer.WriteLine("---Questing Categories End---");
                        writer.WriteLine("---Questing Modules Begin---");
                        writer.Dispose();
                    }

                    new QuestingModules().InitModules();
                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        writer.WriteLine("[Questing Update | Main]: Modules Done.");
                        writer.WriteLine("---Questing Modules End---");
                        writer.WriteLine("---Questing Stations Begin---");
                        writer.Dispose();
                    }

                    new QuestingStations().InitStations();
                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        writer.WriteLine("[Questing Update | Main]: Stations Done.");
                        writer.WriteLine("---Questing Stations End---");
                        writer.WriteLine("---Questing Recipes Begin---");
                        writer.Dispose();
                    }

                    new QuestingRecipes().InitRecipes();
                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        writer.WriteLine("[Questing Update | Main]: Recipes Done.");
                        writer.WriteLine("---Questing Recipes End---");
                        writer.WriteLine("---Questing Modifier Begin---");
                        writer.Dispose();
                    }

                    new QuestingModifier().InitModifier();
                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        writer.WriteLine("[Questing Update | Main]: Modifier Done.");
                        writer.WriteLine("---Questing Modifier End---");
                        writer.Dispose();
                    }

                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        writer.WriteLine("[Questing Update | Main]: Done with Init.");
                        writer.Dispose();
                    }
                    break;
            }
        }

        public override void Unload()
        {
            UnityEngine.Debug.Log("[Questing Update | Main]: Questing Update unloaded");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine("[Questing Update | Main]: Game Finished, Closing...");
                writer.Dispose();
            }
        }
    }
}

