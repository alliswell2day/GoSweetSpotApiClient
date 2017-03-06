﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GoSweetSpotApiClientLib
{
    class Common
    {
        public static HttpClient GetHttpClient(string apiToken)
        {
            HttpClient client;
            MediaTypeFormatter jsonFormatter = new JsonMediaTypeFormatter();

            client = new HttpClient();
            client.BaseAddress = new Uri("https://api.gosweetspot.com");
            client.DefaultRequestHeaders.Add("access_key", apiToken);
            client.DefaultRequestHeaders.Add("User-Agent", "GoSweetSpotApiClientLib." + Assembly.GetEntryAssembly().GetName().Version.ToString());
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            return client;
        }
        public static string GetTempFolder()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "TempGSS\\";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }
    }
}
