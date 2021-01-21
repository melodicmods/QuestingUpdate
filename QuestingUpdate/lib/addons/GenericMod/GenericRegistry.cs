using QuestingUpdate.lib.addons.scripts;
using QuestingUpdate.lib.scripts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuestingUpdate.lib.addons.GenericMod
{
    class GenericRegistry
    {
        public static readonly Dictionary<string, GUID> genericmodRegistry = new Dictionary<string, GUID>();
        public void AddonGeneric()
        {
            var check = Registry();
            if (check == true)
            {
                QuestLog.Log("[Addon Manager]: GenericMod Addon Enabled");
                AddonLog.Log("---GenericMod Addon Begin---");
                RegisterRecipes();
                RegisterItems();
                foreach (KeyValuePair<string, GUID> dict in genericmodRegistry)
                {
                    AddonLog.Log("[Addon Manager | GenericMod]: Name: " + dict.Key + " | GUID: " + dict.Value + " Has been Registered");
                }
                AddonLog.Log("---GenericMod Addon End---");
            } else
            {
                QuestLog.Log("[Addon Manager]: GenericMod Addon Disabled");
            }
        }

        private void RegisterRecipes()
        {
            genericmodRegistry["5xCopperSmeltingRecipe"] = GUID.Parse("0B7717FC2854467FA3D23347E3B9DCFB");
            genericmodRegistry["5xCopperScrapSmeltingRecipe"] = GUID.Parse("C887223B8D2E4A35BD21412BC6243BD5");
            genericmodRegistry["10xCopperSmeltingRecipe"] = GUID.Parse("B98720D4DB54470B82DBC2D1B4D7C8C4");
            genericmodRegistry["5xIronSmeltingRecipe"] = GUID.Parse("D2EFA87BECC544D28864889E28A9A022");
            genericmodRegistry["5xIronScrapSmeltingRecipe"] = GUID.Parse("33AB9A638A9748528674F2857007CC2A");
            genericmodRegistry["10xIronSmeltingRecipe"] = GUID.Parse("9E9FBCF1D8B649D8A89D970AC316B6C0");
            genericmodRegistry["5xCrystalSmeltingRecipe"] = GUID.Parse("BE6B310CCD124943A9F66D49083BCAEC");
            genericmodRegistry["10xCrystalSmeltingRecipe"] = GUID.Parse("D7AD946D9CE340EBBADB19D96D2A48B7");
            genericmodRegistry["5xTitaniumSmeltingRecipe"] = GUID.Parse("3244E6E78A9043D99BC1D847A30473B1");
            genericmodRegistry["5xTitaniumScrapSmeltingRecipe"] = GUID.Parse("FE5251FD26D747EDA935BDFF7822CE3A");
            genericmodRegistry["5xDiamondSmeltingRecipe"] = GUID.Parse("A4E2E0A221264B26A316899DC25B84B3");

            genericmodRegistry["AlloyT1toAlloyT3Recipe"] = GUID.Parse("B01B65E123DB438D98D1AB7DED917DE5");
            genericmodRegistry["AlloyT2toAlloyT3Recipe"] = GUID.Parse("0E98FAF0FA9449338428C7DC771E42F6");
            genericmodRegistry["TungstenIngotRecipe"] = GUID.Parse("2E3EE998AD8F470CAF35471421CA3AAE");
            genericmodRegistry["UnobtainiumIngotRecipe"] = GUID.Parse("61C5C4430D7F42D2B599A582C44E930E");
            genericmodRegistry["AlloyT4Recipe"] = GUID.Parse("A7E62288C0D646739C2F53968C210957");
            genericmodRegistry["TungstenPlatesRecipe"] = GUID.Parse("46ACCE55EE28490BA14F73C08A83050C");
            genericmodRegistry["TungstenTubesRecipe"] = GUID.Parse("A5D9565795624D7FAD861F8FC0B0403D");
            genericmodRegistry["TungstenBoltsRecipe"] = GUID.Parse("CFA38F3064494CF884D40EE8DA2772E8");
            genericmodRegistry["UnobtainiumPlatesRecipe"] = GUID.Parse("71FAB79094F4495291EDABB2D67146B0");
            genericmodRegistry["UnobtainiumTubesRecipe"] = GUID.Parse("66BFCE9D2EEF494BA6AC7CF56DB66E1C");
            genericmodRegistry["UnobtainiumBoltsRecipe"] = GUID.Parse("4C1A520F5ECB45B0A0C0CD3E2A2CC109");
            genericmodRegistry["TracksT5Recipe"] = GUID.Parse("EABEBE7067F44B228BDEBAC23548AE47");
            genericmodRegistry["ShipCoreUpgrade4Recipe"] = GUID.Parse("23CA71CB89644644881DC484A1879D0D");
            genericmodRegistry["ShipCoreUpgrade5Recipe"] = GUID.Parse("D7415C76EB4A438C86432501D59998E0");
            genericmodRegistry["ShipCoreUpgrade6Recipe"] = GUID.Parse("35FCCDDC5C464FD5A3F7FFA6094AAF53");
            genericmodRegistry["HullUpgrade5Recipe"] = GUID.Parse("A3046813A43345AEB6A8AA5353E8A77B");
            genericmodRegistry["HullUpgrade6Recipe"] = GUID.Parse("B37606501B2B40FABF697CEF68C26DA4");
            genericmodRegistry["DrillUpgrade5Recipe"] = GUID.Parse("2CBFF4BD72C54C6AA7D85B4AA22711D7");
            genericmodRegistry["DrillUpgrade6Recipe"] = GUID.Parse("C922C8F07B294F98BAF5AAAD706F2E4E4");
            genericmodRegistry["EngineUpgrade4Recipe"] = GUID.Parse("3A53A2D331444AF0A4AE125736F232AF");
            genericmodRegistry["EngineUpgrade5Recipe"] = GUID.Parse("F0B832C6187D44CE86A6F63165A6D698");
        }

        private void RegisterItems()
        {
            genericmodRegistry["TracksT5_Supreme"] = GUID.Parse("713A4D41B14346EFB234A548B16BADEC");
            genericmodRegistry["ShipCoreUpgrade4"] = GUID.Parse("787AE6617DA54690BBD05D89653FF707");
            genericmodRegistry["ShipCoreUpgrade5"] = GUID.Parse("2602080730BE43979380D9F381927002");
            genericmodRegistry["ShipCoreUpgrade6"] = GUID.Parse("FD05057E43F64735843E8C52B3DCA447");
            genericmodRegistry["HullT5_Tungsten"] = GUID.Parse("5A806861DF50469CA38CD13DD4E7598F");
            genericmodRegistry["TungstenIngot"] = GUID.Parse("DD81B8351C2F47A5B55F9400E2ECA86F");
            genericmodRegistry["DrillT5_Tungsten"] = GUID.Parse("652CE5F6CC9544AA94D96D9EEA862C8B");
            genericmodRegistry["DrillT6_Unobtainium"] = GUID.Parse("BC676806155B4E5BA4190344105A11D4");
            genericmodRegistry["HullT6_Unobtainium"] = GUID.Parse("F84B796D47474DBFA81A6579716807DE");
            genericmodRegistry["AlloyT4Ingot"] = GUID.Parse("6939388A466C45B899EEF83634EEA6C6");
            genericmodRegistry["UnobtainiumIngot"] = GUID.Parse("C84135CD0447417B9668570D5AADF502");
            genericmodRegistry["TungstenPlates"] = GUID.Parse("CF9FB96DD9B049C5A88CD1E8195AFE94");
            genericmodRegistry["TungstenBolts"] = GUID.Parse("CE39BCA989E84E62AEA54306BCF8F60C");
            genericmodRegistry["TungstenTubes"] = GUID.Parse("BA7D952FDAA24DFF999682365156F6DB");
            genericmodRegistry["UnobtainiumPlates"] = GUID.Parse("1243872643B54937B0B91ECDD5FCB1B6");
            genericmodRegistry["UnobtainiumBolts"] = GUID.Parse("7A296148A35F44639DA94EB165D2BFF7");
            genericmodRegistry["UnobtainiumTubes"] = GUID.Parse("7C3BAEF8C42F4A07B10810BC76F73015");
            genericmodRegistry["EngineUpgrade4"] = GUID.Parse("D550C8AA6D6E408385F40C66882B15BA");
            genericmodRegistry["EngineUpgrade5"] = GUID.Parse("4F0ACF6B26A541A2AF2DB7D7FA50134C");
            genericmodRegistry["TungstenOre"] = GUID.Parse("27144EB886144A0C84AEA4FEE5026D73");
            genericmodRegistry["Volcanite"] = GUID.Parse("864DF411103A4CF49B4407BCE047222C");
        }

        private bool Registry()
        {
            if(File.Exists(AddonController.path + "/VolcanoidsMod.dll"))
            {
                return true;
            }
            return false;
        }
    }
}
