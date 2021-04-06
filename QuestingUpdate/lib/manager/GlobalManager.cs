using Newtonsoft.Json;
using QuestingUpdate.lib.scripts;
using System;
using System.IO;

namespace QuestingUpdate.lib.manager
{
    class GlobalManager
    {
        public GlobalManager()
        {
            QuestLog.Log("[Global Manager]: Import Started");
            ManagerLog.Log("[Global Manager]: Import Started", true);
            Import();
            QuestLog.Log("[Global Manager]: Import Complete");
            ManagerLog.Log("[Global Manager]: Import Complete");
        }
        public static Rootobject manager;
        private static readonly string path = Environment.GetEnvironmentVariable("USERPROFILE") + "/appdata/locallow/volcanoid/volcanoids/mods/resources/JSON/manager.json";
        private void Import()
        {
            var root = JsonConvert.DeserializeObject<Rootobject>(File.ReadAllText(path));
            manager = root;
        }
    }

    public class Rootobject
    {
        public Manager[] manager { get; set; }
    }

    public class Manager
    {
        public int id { get; set; }
        public string identifier { get; set; }
        public Setting[] settings { get; set; }
        public bool enabled { get; set; }
        public override string ToString()
        {
            return "ID: " + id + " | Identifier: " + identifier + " | Settings: " + settings[0].limit + " | " + settings[0].variation + " | Enabled: " + enabled;
        }
    }

    public class Setting
    {
        public int limit { get; set; }
        public bool variation { get; set; }
    }

}
