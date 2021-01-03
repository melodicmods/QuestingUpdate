using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static QuestingUpdate.lib.QuestingVersioning;

namespace QuestingUpdate.lib
{
    class QuestingNamer : MonoBehaviour
    {
        private string updateName;
        public string Namer()
        {
            var version = QuestingMod.version;
            Requester("https://api.github.com/repos/melodicalbuild/questingupdate/releases/tags/" + version);
            return updateName;
        }
        private string html;
        private void Requester(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = "MelodicAlbuild";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            var root = JsonConvert.DeserializeObject<Rootobject>(html);

            updateName = root.name;
        }
    }
}
