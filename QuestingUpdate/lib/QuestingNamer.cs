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
            Requester("https://live-downloads.herokuapp.com/versioning");
            return updateName;
        }
        private string html;
        private void Requester(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";
            request.Method = "POST";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = "{ \"mod\" : \"questing\" }";

                streamWriter.Write(json);
                streamWriter.Flush();
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            var root = JsonConvert.DeserializeObject<Rootobject>(html);

            updateName = root.updateName;
        }
    }
}
