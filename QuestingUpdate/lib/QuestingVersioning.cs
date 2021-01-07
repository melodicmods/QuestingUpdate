using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Dynamic;
using UnityEngine;
using System.Net;

namespace QuestingUpdate.lib
{
    class QuestingVersioning : MonoBehaviour
    {
        public bool needUpdate = false;
        public void InitVersions()
        {
            Requester("https://api.github.com/repos/melodicalbuild/questingupdate/releases/latest");
        }

        public string UpdateVersioner()
        {
            if(needUpdate == true)
            {
                return "(Update Available)";
            } else
            {
                return "";
            }
        }

        private void ResourceCheck()
        {
            using (StreamReader reader = new StreamReader("Resources/Version.txt"))
            {
                var version = reader.ReadToEnd();
                using (StreamWriter writer = new StreamWriter(QuestingMod.path, true))
                {
                    writer.WriteLine("[Questing Update | Versioning]: Resource Version is " + version);
                    writer.Dispose();
                }
                reader.Dispose();
            }
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
            if(root.tag_name != QuestingMod.version)
            {
                using (StreamWriter writer = new StreamWriter(QuestingMod.path, true))
                {
                    writer.WriteLine("[Questing Update | Versioning]: Mod is Not up to Date...");
                    writer.Dispose();
                }
                needUpdate = true;
            } else
            {
                using (StreamWriter writer = new StreamWriter(QuestingMod.path, true))
                {
                    writer.WriteLine("[Questing Update | Versioning]: Mod is Up to Date");
                    writer.Dispose();
                }
            }

        }

        public class Rootobject
        {
            public string url { get; set; }
            public string assets_url { get; set; }
            public string upload_url { get; set; }
            public string html_url { get; set; }
            public int id { get; set; }
            public Author author { get; set; }
            public string node_id { get; set; }
            public string tag_name { get; set; }
            public string target_commitish { get; set; }
            public string name { get; set; }
            public bool draft { get; set; }
            public bool prerelease { get; set; }
            public DateTime created_at { get; set; }
            public DateTime published_at { get; set; }
            public Asset[] assets { get; set; }
            public string tarball_url { get; set; }
            public string zipball_url { get; set; }
            public string body { get; set; }
        }

        public class Author
        {
            public string login { get; set; }
            public int id { get; set; }
            public string node_id { get; set; }
            public string avatar_url { get; set; }
            public string gravatar_id { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
            public string followers_url { get; set; }
            public string following_url { get; set; }
            public string gists_url { get; set; }
            public string starred_url { get; set; }
            public string subscriptions_url { get; set; }
            public string organizations_url { get; set; }
            public string repos_url { get; set; }
            public string events_url { get; set; }
            public string received_events_url { get; set; }
            public string type { get; set; }
            public bool site_admin { get; set; }
        }

        public class Asset
        {
            public string url { get; set; }
            public int id { get; set; }
            public string node_id { get; set; }
            public string name { get; set; }
            public object label { get; set; }
            public Uploader uploader { get; set; }
            public string content_type { get; set; }
            public string state { get; set; }
            public int size { get; set; }
            public int download_count { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public string browser_download_url { get; set; }
        }

        public class Uploader
        {
            public string login { get; set; }
            public int id { get; set; }
            public string node_id { get; set; }
            public string avatar_url { get; set; }
            public string gravatar_id { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
            public string followers_url { get; set; }
            public string following_url { get; set; }
            public string gists_url { get; set; }
            public string starred_url { get; set; }
            public string subscriptions_url { get; set; }
            public string organizations_url { get; set; }
            public string repos_url { get; set; }
            public string events_url { get; set; }
            public string received_events_url { get; set; }
            public string type { get; set; }
            public bool site_admin { get; set; }
        }

    }
}
