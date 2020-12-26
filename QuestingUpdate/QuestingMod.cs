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
using VolcQuestingUpdate.lib;

namespace VolcanoidsMod
{
    public class QuestingMod : GameMod
    {
        private string version = "0.1.1";
        public override void Load()
        {
            var lastWrite = File.GetLastWriteTime(typeof(QuestingMod).Assembly.Location);
            Debug.Log($"[Questing Update | Main]: Questing Update loaded: {version}, build time: {lastWrite.ToShortTimeString()}");

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            if (arg0.name == "MainMenu")
            {
                GameObject.Find("EarlyAccess").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Questing Update " + version;
                GameObject.Find("SteamBranch").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Questing Update";
                GameObject.Find("Version").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Version: 1.25.4 (ClosedTesting)";
            }
            if (arg0.name == "Island")
            {
                QuestingItems items = new QuestingItems();
                items.InitItems();
                QuestingRecipes recipes = new QuestingRecipes();
                recipes.InitRecipes();
                QuestingDeposits deposits = new QuestingDeposits();
                deposits.InitDeposits();
                QuestingCategories categories = new QuestingCategories();
                categories.InitCategories();
                QuestingModules modules = new QuestingModules();
                modules.InitModules();
            }
        }

        public override void Unload()
        {
            Debug.Log("[Questing Update | Main]: Questing Update unloaded");
        }
    }
}

