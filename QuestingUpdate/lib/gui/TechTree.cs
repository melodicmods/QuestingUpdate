using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using QuestingUpdate.lib.scripts;

namespace QuestingUpdate.lib.gui
{
    public class TechTree : MonoBehaviour
    {
        private static Canvas Run()
        {
            var newTexture = QuestingAssets.GetTexture("questingbundle.textures", "fg4_borders_02_1");

            GameObject newCanvas = new GameObject("Canvas");
            Canvas c = newCanvas.AddComponent<Canvas>();
            c.renderMode = RenderMode.ScreenSpaceOverlay;
            newCanvas.AddComponent<CanvasScaler>();
            newCanvas.AddComponent<GraphicRaycaster>();
            GameObject panel = new GameObject("Panel");
            panel.AddComponent<CanvasRenderer>();
            Image i = panel.AddComponent<Image>();
            Sprite isprite = Sprite2(newTexture);

            RectTransform rt = panel.GetComponent(typeof(RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2(512, 512);

            QuestLog.Log("[Questing Update | Tech Tree]: width: " + rt.rect.width + ", height: " + rt.rect.height);

            i.sprite = isprite;
            panel.transform.SetParent(newCanvas.transform, false);
            c.enabled = false;
            return c;
        }

        public static Canvas techtree = Run();

        public static void Enable(bool activate)
        {
            techtree.enabled = activate;
        }

        private static Sprite Sprite2(Texture2D iconpath)
        {
            var sprite = Sprite.Create(iconpath, new Rect(Vector2.zero, new Vector2(iconpath.width, iconpath.height)), new Vector2(0.5f, 0.5f), iconpath.width, 0, SpriteMeshType.FullRect, Vector4.zero, false);
            return sprite;
        }
    }
}