using QuestingUpdate.lib.scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestingUpdate.lib
{
    class QuestingQuests
    {
        private QuestRuntime[] m_runtimes;
        public ArrayReader<QuestRuntime> Quests => m_runtimes;
        public void InitQuests()
        {
            Tests();
        }

        private void Tests()
        {
            foreach (QuestManagerState state in PlayerQuestManager.Local.States)
            {
                foreach (QuestRuntime quest in state.Manager.Quests)
                {
                    QuestLog.Log("[Questing Update | Quests]: " + quest);
                }
            }
        }
    }
}
