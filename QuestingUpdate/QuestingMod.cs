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
using System;
using System.Reflection;
using QuestingUpdate.lib.manager;

namespace QuestingUpdate
{
    public class QuestingMod : GameMod
    {
        public static bool key = true;
        public const string version = "0.3.6";
        private string update = "";
        private string updateName = "";
        public static readonly string path = Environment.GetEnvironmentVariable("USERPROFILE") + "/appdata/locallow/volcanoid/volcanoids/QuestingUpdate.log";
        public static readonly string defaultPath = Environment.GetEnvironmentVariable("USERPROFILE") + "/appdata/locallow/volcanoid/volcanoids/QuestingUpdate/";
        public RenderPipelineAsset pipelineAsset = (RenderPipelineAsset)Resources.Load(Environment.GetEnvironmentVariable("USERPROFILE") + "/appdata/locallow/volcanoid/volcanoids/mods/resources/renderer/UniversalRP-HighQuality.asset");
        public override void Load()
        {
            GraphicsSettings.renderPipelineAsset = pipelineAsset;
            var lastWrite = File.GetLastWriteTime(typeof(QuestingMod).Assembly.Location);
            UnityEngine.Debug.Log($"[Questing Update | Main]: Questing Update loaded: {version}, build time: {lastWrite.ToShortTimeString()}");
            QuestLog.Log($"[Questing Update | Main]: Questing Update loaded: {version}, build time: {lastWrite.ToShortTimeString()}", true);

            //new MainGUI();

            if (!Directory.Exists(defaultPath))
            {
                Directory.CreateDirectory(defaultPath);
                File.Create(defaultPath + "Manager.log");
            }

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

            new GlobalManager();
            new GlobalStorage();
            QuestLog.Log("[Questing Update | Main]: Managers Loaded without Error. Version Tags are now Enabled");

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
                    if (GlobalStorage.managerData[9].enabled)
                    {
                        QuestLog.Log("---Addon Registration Begin---");
                        new AddonController();
                        QuestLog.Log("---Addon Registration End---");
                    }

                    if (GlobalStorage.managerData[0].enabled)
                    {
                        QuestLog.Log("---Questing Items Begin---");
                        new QuestingItems().InitItems();
                        QuestLog.Log("[Questing Update | Main]: Items Done.");
                        QuestLog.Log("---Questing Items End---");
                    }

                    if (GlobalStorage.managerData[4].enabled)
                    {
                        QuestLog.Log("---Questing Deposits Begin---");
                        new QuestingDeposits().InitDeposits();
                        QuestLog.Log("[Questing Update | Main]: Deposits Done.");
                        QuestLog.Log("---Questing Deposits End---");
                    }

                    if (GlobalStorage.managerData[5].enabled)
                    {
                        QuestLog.Log("---Questing Categories Begin---");
                        new QuestingCategories().InitCategories();
                        QuestLog.Log("[Questing Update | Main]: Categories Done.");
                        QuestLog.Log("---Questing Categories End---");
                    }

                    if (GlobalStorage.managerData[2].enabled)
                    {
                        QuestLog.Log("---Questing Modules Begin---");
                        new QuestingModules().InitModules();
                        QuestLog.Log("[Questing Update | Main]: Modules Done.");
                        QuestLog.Log("---Questing Modules End---");
                    }

                    if (GlobalStorage.managerData[3].enabled)
                    {
                        QuestLog.Log("---Questing Stations Begin---");
                        new QuestingStations().InitStations();
                        QuestLog.Log("[Questing Update | Main]: Stations Done.");
                        QuestLog.Log("---Questing Stations End---");
                    }

                    if (GlobalStorage.managerData[1].enabled)
                    {
                        QuestLog.Log("---Questing Recipes Begin---");
                        new QuestingRecipes().InitRecipes();
                        QuestLog.Log("[Questing Update | Main]: Recipes Done.");
                        QuestLog.Log("---Questing Recipes End---");
                    }

                    if (GlobalStorage.managerData[6].enabled)
                    {
                        QuestLog.Log("---Questing Modifier Begin---");
                        new QuestingModifier().InitModifier();
                        QuestLog.Log("[Questing Update | Main]: Modifier Done.");
                        QuestLog.Log("---Questing Modifier End---");
                    }

                    if(GlobalStorage.managerData[10].enabled)
                    {
                        QuestLog.Log("---Questing Weapons Begin---");
                        new QuestingWeapons();
                        QuestLog.Log("[Questing Update | Main]: Weapons Done.");
                        QuestLog.Log("---Questing Weapons End---");
                    }

                    if (GlobalStorage.managerData[8].enabled)
                    {
                        QuestLog.Log("---Questing Quests Begin---");
                        new QuestingQuests().InitQuests();
                        QuestLog.Log("[Questing Update | Main]: Quests Done.");
                        QuestLog.Log("---Questing Quests End---");
                    }

                    ReturnAllData();
                    QuestLog.Log("[Questing Update | Main]: Done with Init.");
                    QuestLog.Log("---Questing Init End---");
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

        //public static void Runtime()
        //{
        //    foreach (var obj in ExportHandler.questingSchematics)
        //    {
        //        QuestLog.Log(obj.Key.name);
        //    }
        //    QuestLog.Log("[Questing Update | Main]: Runtime Activated");
        //}

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
                //TechTree.Enable(QuestingMod.key);
                QuestingMod.key = !QuestingMod.key;
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.U))
            {
                //QuestingMod.Desync();
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.Q))
            {
                //MainGUI.Enable(QuestingMod.key);
                QuestingMod.key = !QuestingMod.key;
            }
        }
    }
}

