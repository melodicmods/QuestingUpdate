using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Dynamic;
using UnityEngine;
using System.Net;
using System.IO.Compression;
using QuestingUpdate.lib.scripts;

namespace QuestingUpdate.lib
{
    class QuestingVersioning : MonoBehaviour
    {
        private string resourceVersion = "";
        private static readonly string ResourcePath = Environment.GetEnvironmentVariable("USERPROFILE") + "/appdata/locallow/volcanoid/volcanoids/mods/Resources";
        private static readonly string DownloadPath = Environment.GetEnvironmentVariable("USERPROFILE") + "/appdata/locallow/volcanoid/volcanoids/mods/QuestingResources.zip";
        private static readonly string ExtractPath = Environment.GetEnvironmentVariable("USERPROFILE") + "/appdata/locallow/volcanoid/volcanoids/mods/";
        public bool needUpdate = false;
        public void InitVersions()
        {
            Requester("https://live-downloads.herokuapp.com/versioning");
            ResourceCheck();
        }

        public string UpdateVersioner()
        {
            if (needUpdate == true)
            {
                return "(Update Available)";
            }
            else
            {
                return "";
            }
        }

        private void ResourceCheck()
        {
            if (Directory.Exists(@ResourcePath))
            {
                if (File.Exists(@ResourcePath + "/Version.txt"))
                {
                    var version = "";
                    version = File.ReadAllText(Path.Combine(@ResourcePath, "Version.txt"));
                    QuestLog.Log("[Questing Update | Versioning]: " + version);
                    if (version != resourceVersion)
                    {
                        Directory.Delete(@ResourcePath, true);
                        using (WebClient wc = new WebClient())
                        {
                            wc.DownloadFile(
                                new System.Uri("https://live-downloads.herokuapp.com/downloads/resources/QuestingResources.zip"),
                                @DownloadPath
                            );
                        }
                        ZipFile.ExtractToDirectory(@DownloadPath, @ExtractPath);
                        File.Delete(@DownloadPath);

                        QuestLog.Log("[Questing Update | Versioning]: Resource Version Updated to " + version);
                    }
                    else
                    {
                        QuestLog.Log("[Questing Update | Versioning]: Resource Version is " + version);
                    }
                }
                else
                {
                    File.WriteAllText(@ResourcePath + "/Version.txt", "0.0.0");
                }
            }
            else
            {
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFile(
                        new System.Uri("https://live-downloads.herokuapp.com/downloads/resources/QuestingResources.zip"),
                        @DownloadPath
                    );
                }
                ZipFile.ExtractToDirectory(@DownloadPath, @ExtractPath);
                File.Delete(@DownloadPath);
            }
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
            if (root.modVersion != QuestingMod.version)
            {
                QuestLog.Log("[Questing Update | Versioning]: Mod is Not up to Date...");
                needUpdate = true;
            }
            else
            {
                QuestLog.Log("[Questing Update | Versioning]: Mod is Up to Date");
            }
            resourceVersion = root.resourceVersion;
        }


        public class Rootobject
        {
            public string resourceVersion { get; set; }
            public string modVersion { get; set; }
            public string updateName { get; set; }
        }


    }
}
