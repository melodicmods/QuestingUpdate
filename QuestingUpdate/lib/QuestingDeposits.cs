using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using QuestingUpdate.lib.scripts;
using System.Collections.Generic;
using static QuestingUpdate.lib.data.ExportHandler;
using QuestingUpdate.lib.data;

namespace QuestingUpdate.lib
{
    class QuestingDeposits
    {
        public void InitDeposits()
        {
            depositsurface = Resources.FindObjectsOfTypeAll<DepositLocationSurface>();
            depositunderground = Resources.FindObjectsOfTypeAll<DepositLocationUnderground>();

            foreach (KeyValuePair<Deposit, string> dict in questingDeposits)
            {
                CreateDeposit(dict.Key.underground, dict.Key.percent_replace, dict.Key.output_name, dict.Key.yields[0], dict.Key.yields[1], dict.Key.replaced_item);
            }

            QuestLog.Log("[Questing Update | Deposits]: Deposits Loaded...");
        }
        public void CreateDeposit(bool Underground, int PercentageToReplace, string outputname, float minyield, float maxyield, string ItemToReplace)
        {

            if (Underground)
            {
                foreach (DepositLocationUnderground underground in depositunderground)
                {
                    if (Random.Range(0, 100) <= PercentageToReplace)
                    {
                        if ((ItemToReplace != null && underground.Ore == GetItem(ItemToReplace)) || ItemToReplace == null)
                        {
                            underground.Yield = UnityEngine.Random.Range(minyield, maxyield);
                            OreField.SetValue(underground, GetItem(outputname));
                        }
                    }
                }
            }
            if (!Underground)
            {
                foreach (DepositLocationSurface surface in depositsurface)
                {
                    if (Random.Range(0, 100) <= PercentageToReplace)
                    {
                        if ((ItemToReplace != null && surface.Ore == GetItem(ItemToReplace)) || ItemToReplace == null)
                        {
                            surface.Yield = UnityEngine.Random.Range(minyield, maxyield);
                            OreField.SetValue(surface, GetItem(outputname));
                        }
                    }
                }
            }
            QuestLog.Log("[Questing Update | Deposits]: Deposit Replacing " + ItemToReplace + " has been replaced with " + outputname);
        }
        private ItemDefinition GetItem(string itemname)
        {
            ItemDefinition item = GameResources.Instance.Items.FirstOrDefault(s => s.name == itemname);
            if (item == null)
            {
                QuestLog.Log("ERROR: [Questing Update | Deposits]: Item is null, name: " + itemname + ". Replacing with NullItem");

                Debug.LogError("[Questing Update | Deposits]: Item is null, name: " + itemname + ". Replacing with NullItem");
                return GameResources.Instance.Items.FirstOrDefault(s => s.name == "NullItem");
            }
            return item;

        }
        private DepositLocationSurface[] depositsurface;
        private DepositLocationUnderground[] depositunderground;
        private static readonly FieldInfo OreField = typeof(DepositLocation).GetField("m_ore", BindingFlags.NonPublic | BindingFlags.Instance);

    }
}
