using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using QuestingUpdate.lib;
using System.Diagnostics;
using QuestingUpdate.lib.scripts;
using QuestingUpdate.lib.addons;
using QuestingUpdate.lib.storage;
using QuestingUpdate.lib.gui;
using UnityEngine.Rendering;
using QuestingUpdate.lib.data;
using System.Collections.Generic;
using static QuestingUpdate.lib.storage.QuestingDict;

namespace QuestingUpdate
{
    public class QuestingMod : GameMod
    {
        public static bool key = true;
        public const string version = "0.3.5";
        private string update = "";
        private string updateName = "";
        public static readonly string path = System.Environment.GetEnvironmentVariable("USERPROFILE") + "/appdata/locallow/volcanoid/volcanoids/QuestingUpdate.log";
        public RenderPipelineAsset pipelineAsset = (RenderPipelineAsset)Resources.Load(System.Environment.GetEnvironmentVariable("USERPROFILE") + "/appdata/locallow/volcanoid/volcanoids/mods/resources/renderer/UniversalRP-HighQuality.asset");
        public override void Load()
        {
            GraphicsSettings.renderPipelineAsset = pipelineAsset;
            var lastWrite = File.GetLastWriteTime(typeof(QuestingMod).Assembly.Location);
            UnityEngine.Debug.Log($"[Questing Update | Main]: Questing Update loaded: {version}, build time: {lastWrite.ToShortTimeString()}");
            QuestLog.Log($"[Questing Update | Main]: Questing Update loaded: {version}, build time: {lastWrite.ToShortTimeString()}", true);

            QuestingVersioning versioning = new QuestingVersioning();
            versioning.InitVersions();
            update = versioning.UpdateVersioner();

            if (versioning.needUpdate == false)
            {
                QuestingNamer namer = new QuestingNamer();
                updateName = namer.Namer();
            }
            else
            {
                updateName = "Questing Update";
            }


            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            scene.GetRootGameObjects()[0].AddComponent<MagicStuff>();
            switch (scene.name)
            {
                case "MainMenu":
                    GameObject.Find("EarlyAccess").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Questing Update " + version;
                    GameObject.Find("SteamBranch").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = updateName + " " + update;
                    GameObject.Find("Version").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Version: 1.25.72 (ClosedTesting)";
                    break;
                case "Island":
                    QuestLog.Log("---Questing Init Begin---");
                    new QuestingDict();
                    new ImportHandler();
                    new ExportHandler();
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

                    QuestingDict.ReturnAllData();
                    QuestLog.Log("[Questing Update | Main]: Done with Init.");
                    QuestLog.Log("---Questing Init End---");

                    Runtime();
                    break;
            }
        }

        public static void Desync()
        {
            foreach (var obj in RuntimeAssetStorage.GetAssets())
            {
                foreach (KeyValuePair<string, GUID> dict in questingRegistry)
                {
                    if (obj.Value == dict.Value)
                    {
                        //QuestLog.Log("[Questing Update | Main]: " + dict.Key);
                    }
                }
            }
            QuestLog.Log("[Questing Update | Main]: Game Desynced");
        }

        public static void Runtime()
        {
            foreach (var obj in ExportHandler.questingSchematics)
            {
                QuestLog.Log(obj.Key.name);
            }
            QuestLog.Log("[Questing Update | Main]: Runtime Activated");
        }

        public override void Unload()
        {
            UnityEngine.Debug.Log("[Questing Update | Main]: Questing Update unloaded");
            QuestLog.Log("[Questing Update | Main]: Game Finished, Closing...");
        }
    }

    class MagicStuff : MonoBehaviour
    {
        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.T))
            {
                TechTree.Enable(QuestingMod.key);
                QuestingMod.key = !QuestingMod.key;
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.U))
            {
                QuestingMod.Desync();
            }
        }
    }
}

