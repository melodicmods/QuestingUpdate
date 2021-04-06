using QuestingUpdate.lib.scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestingUpdate.lib.manager
{
    class GlobalStorage
    {
        public static readonly Dictionary<Manager, string> globalStorage = new Dictionary<Manager, string>();
        public static readonly ManagerController[] managerData = new ManagerController[11];
        public GlobalStorage()
        {
            Populate();
            QuestLog.Log("[Global Storage]: Population Complete");
            ManagerLog.Log("[Global Storage]: Population Complete");
            LinkManagers();
            QuestLog.Log("[Global Storage]: Managers Linked");
            ManagerLog.Log("[Global Storage]: Managers Linked");
            //OutputDictData();
            //ManagerLog.Log("");
            //OutputArrayData();

        }

        private void OutputDictData()
        {
            foreach (KeyValuePair<Manager, string> obj in globalStorage)
            {
                ManagerLog.Log("[Global Manager]: " + obj.Key);
            }
        }

        private void OutputArrayData()
        {
            foreach (ManagerController controller in managerData)
            {
                ManagerLog.Log("[Global Manager]: " + controller);
            }
        }

        private void Populate()
        {
            foreach (Manager manager in GlobalManager.manager.manager)
            {
                globalStorage[manager] = manager.identifier;
            }
        }

        private void LinkManagers()
        {
            foreach (KeyValuePair<Manager, string> obj in globalStorage)
            {
                managerData[obj.Key.id] = new ManagerController() { id = obj.Key.id, identifier = obj.Value, enabled = obj.Key.enabled };
            }
        }
    }

    public class ManagerController
    {
        public string identifier { get; set; }
        public int id { get; set; }
        public bool enabled { get; set; }

        public override string ToString()
        {
            return "ID: " + id + " | Identifier: " + identifier + " | Enabled: " + enabled;
        }
    }
}
