using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;

namespace pracAndroid
{
    public class JsonReader
    {
        public Dictionary<string, Items> ReadProducts = new Dictionary<string, Items>();
        public List<string> PKeys = new List<string>();

        public Dictionary<string, Items> ReadJson()
        {
            string jsonFileName = "productOs.json";

            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream r = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
            using (var reader = new System.IO.StreamReader(r))
            {
                var json = reader.ReadToEnd();
                ReadProducts = JsonConvert.DeserializeObject<Dictionary<string, Items>>(json);
                return ReadProducts;
            }
        }
    }

    public class Items
    {
        public List<string> OS { get; set; }
    }

}
