using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using QuestingUpdate.lib.scripts;

namespace QuestingUpdate.lib
{
    class QuestingDeposits
    {
        public void InitDeposits()
        {
            depositsurface = Resources.FindObjectsOfTypeAll<DepositLocationSurface>();
            depositunderground = Resources.FindObjectsOfTypeAll<DepositLocationUnderground>();
            CreateDeposit(false, 20, "TinOre", 2, 5, "SulfurOre");
            CreateDeposit(false, 100, "CobaltOre", 2, 5, "TitaniumOre");
            CreateDeposit(true, 100, "CobaltOre", 2, 5, "TitaniumOre");

            QuestLog.Log("[Questing Update | Deposits]: Deposits Loaded...");

            Debug.Log("[Questing Update | Deposits]: Deposits Loaded...");
        }
        public void CreateDeposit(bool Underground, int PercentageToReplace, string outputname, float minyield, float maxyield, string ItemToReplace)
        {

            if (Underground)
            {
                foreach (DepositLocationUnderground underground in depositunderground)
                {
                    if (UnityEngine.Random.Range(0, 100) <= PercentageToReplace)
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
                    if (UnityEngine.Random.Range(0, 100) <= PercentageToReplace)
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
