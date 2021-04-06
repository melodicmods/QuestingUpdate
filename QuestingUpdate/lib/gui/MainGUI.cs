using QuestingUpdate.lib.scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace QuestingUpdate.lib.gui
{
    class MainGUI
    {
        public static GameObject canvas = new GameObject();
        public MainGUI()
        {
            var newCanvasStuff = QuestingAssets.GetAsset("questingbundle", "assets/questing/techtree/canvas.prefab");
            DefaultControls.Resources uiResources = new DefaultControls.Resources();
            //Set the Panel Background Image someBgSprite;
            uiResources.background = newCanvasStuff.GetComponentInChildren<Image>().sprite;
            GameObject uiPanel = DefaultControls.CreatePanel(uiResources);
            uiPanel.transform.SetParent(canvas.transform, false);
        }

        public static void Enable(bool activate)
        {
            canvas.SetActive(activate);
        }
    }
}
