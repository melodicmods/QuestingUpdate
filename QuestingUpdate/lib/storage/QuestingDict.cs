using QuestingUpdate.lib.scripts;
using QuestingUpdate.lib.storage.scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestingUpdate.lib.storage
{
    class QuestingDict
    {
        public static readonly Dictionary<string, GUID> questingRegistry = new Dictionary<string, GUID>();
        public QuestingDict()
        {
            QuestLog.Log("[Dictionary Manager]: Dictionary Verified and Running, Continuing Init");
        }

        public static void ReturnAllData()
        {
            foreach (KeyValuePair<string, GUID> dict in questingRegistry)
            {
                DictLog.Log("[Dictionary Manager]: Name: " + dict.Key + " | GUID: " + dict.Value + " has been Registered");
            }
        }
    }
}
