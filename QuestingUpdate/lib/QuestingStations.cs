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

namespace QuestingUpdate.lib
{
    class QuestingStations : MonoBehaviour
    {
        public void InitStations()
        {


            Debug.Log("[Questing Update | Stations]: Stations Loaded...");
        }

        private void CreateStation()
        {
            var station = ScriptableObject.CreateInstance<FactoryStation>();
        }
    }
}
