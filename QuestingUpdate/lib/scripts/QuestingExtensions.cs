using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace QuestingUpdate.lib.scripts
{
    public static class QuestingExtensions
    {
        public static bool SetPrivateField<T>(this T obj, string fieldName, object newValue)
        {
            var fieldInfo = typeof(ItemDefinition).GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            if (fieldInfo == null)
            {
                Debug.LogError($"Error: Unable to find private field `{fieldName}` in `{typeof(T)}`.");
                return false;
            }
            fieldInfo.SetValue(obj, newValue);
            return true;
        }

        private static readonly FieldInfo LOCALIZED_UI_TEXT_M_TEXT = typeof(LocalizedUiText).GetField("m_text", BindingFlags.NonPublic | BindingFlags.Instance);
        private static readonly FieldInfo LOCALIZED_TEXT_M_TEXT = typeof(LocalizedText).GetField("m_id", BindingFlags.NonPublic | BindingFlags.Instance);
        public static void SetText(this LocalizedUiText localizedUiText, string newText)
        {
            var mText = (TMP_Text)LOCALIZED_UI_TEXT_M_TEXT.GetValue(localizedUiText);
            if (mText == null)
            {
                Debug.LogWarning($"mText null for {localizedUiText}");
            }
            else
            {
                LOCALIZED_TEXT_M_TEXT.SetValue(localizedUiText, ".");
                mText.text = newText;
            }
        }
    }
}
