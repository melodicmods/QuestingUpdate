using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace QuestingUpdate.lib.obj
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
    }
}
