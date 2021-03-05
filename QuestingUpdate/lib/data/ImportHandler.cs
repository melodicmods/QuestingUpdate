using Newtonsoft.Json;
using QuestingUpdate.lib.scripts;
using System.IO;

namespace QuestingUpdate.lib.data
{
    public class ImportHandler
    {
        public ImportHandler()
        {
            QuestLog.Log("[Import Handler]: Import Started");
            Import();
            QuestLog.Log("[Import Handler]: Import Complete");
        }
        public static Rootobject imports;
        private static readonly string path = System.Environment.GetEnvironmentVariable("USERPROFILE") + "/appdata/locallow/volcanoid/volcanoids/mods/resources/JSON/main.json";
        private void Import()
        {
            var root = JsonConvert.DeserializeObject<Rootobject>(File.ReadAllText(path));
            imports = root;
        }
    }


    public class Rootobject
    {
        public Item[] items { get; set; }
        public Recipe[] recipes { get; set; }
        public Module[] modules { get; set; }
        public Station[] stations { get; set; }
        public Deposit[] deposits { get; set; }
        public Category[] categories { get; set; }
        public Modifier[] modifiers { get; set; }
        public Schematic[] schematics { get; set; }
    }

    public class Item
    {
        public string item_name { get; set; }
        public int stack_size { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string guid { get; set; }
        public string base_item { get; set; }
        public string icon_path { get; set; }
    }

    public class Recipe
    {
        public string recipe_name { get; set; }
        public int input_amount { get; set; }
        public Input[] inputs { get; set; }
        public object[] output { get; set; }
        public string base_recipe { get; set; }
        public string itemID { get; set; }
        public string[] required_items { get; set; }
        public string recipe_category { get; set; }
    }

    public class Input
    {
        public string input_name { get; set; }
        public int input_amount { get; set; }
    }

    public class Module
    {
        public string module_name { get; set; }
        public string variant { get; set; }
        public int stack_size { get; set; }
        public string base_item { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string guid { get; set; }
        public string category_name { get; set; }
        public string factory_type { get; set; }
        public string icon_path { get; set; }
        public string[] categories { get; set; }
        public bool first { get; set; }
    }

    public class Station
    {
        public string factory_type { get; set; }
        public string station_name { get; set; }
        public int stack_size { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string guid { get; set; }
        public string icon_path { get; set; }
        public string variant { get; set; }
        public string[] categories { get; set; }
    }

    public class Deposit
    {
        public bool underground { get; set; }
        public int percent_replace { get; set; }
        public string output_name { get; set; }
        public int[] yields { get; set; }
        public string replaced_item { get; set; }
    }

    public class Category
    {
        public string category_type { get; set; }
        public string name { get; set; }
        public string guid { get; set; }
    }

    public class Modifier
    {
        public string modification_type { get; set; }
        public string target { get; set; }
        public string[] modifiers { get; set; }
    }

    public class Schematic
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public int tier { get; set; }
        public string tooltip { get; set; }
        public int?[] requirements { get; set; }
    }


}
