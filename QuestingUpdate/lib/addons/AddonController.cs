using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestingUpdate.lib.addons.GenericMod;
using QuestingUpdate.lib.addons.scripts;
using QuestingUpdate.lib.scripts;

namespace QuestingUpdate.lib.addons
{
    class AddonController
    {
        public static readonly string path = Environment.GetEnvironmentVariable("USERPROFILE") + "/appdata/locallow/volcanoid/volcanoids/mods";
        public AddonController()
        {
            QuestLog.Log("[Addon Manager]: Addon System Enabled");
            AddonLog.Log("[Addon Manager]: Addon System Enabled", true);
            new GenericRegistry().AddonGeneric();

            AddonLog.Log("[Addon Manager]: Addon System Finished");
            QuestLog.Log("[Addon Manager]: Addon System Finished");
        }
    }
}
