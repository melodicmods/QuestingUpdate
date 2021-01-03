using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestingUpdate.lib.scripts
{
    class QuestingReferences
    {
        public static TrainProduction.GroupInfo GetOrCreateTyping(FactoryType factoryType)
        {
            TrainProduction production = new TrainProduction();
            return production.GetOrCreate(factoryType);
        }
    }
}
