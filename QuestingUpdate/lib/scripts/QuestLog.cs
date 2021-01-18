using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestingUpdate.lib.scripts
{
    public static class QuestLog
    {
        public static readonly string path = System.Environment.GetEnvironmentVariable("USERPROFILE") + "/appdata/locallow/volcanoid/volcanoids/QuestingUpdate.log";
        private static StreamWriter writer;

        public static void Log(string msg)
        {
            if (writer == null) writer = new StreamWriter(path, true);

            writer.WriteLine(msg);

            // So it's not kept in the buffer and you can see it in an external program.
            writer.Flush();

            // You don't need dispose. In this case we're leaving it open while the game is running.
            // Call `Close()` somewhere on game shutdown.
        }

        public static void Close()
        {
            writer?.Close();
        }
    }
}
