using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task1.Reader;

namespace task1.Writer
{
    public class JSONWriter : IDataWriter
    {
        public JSONWriter()
        {
            settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented
            };
        }

        public bool Open(object path)
        {
            this.path = path as string;
            if (this.path != null)
                return true;
            else
                return false;
        }

        public bool Write(IDataCollector collector)
        {
            try
            {
                var src = collector.GetSource();
                var jsonString = JsonConvert.SerializeObject(src, settings);
                var fileStream = File.Open(this.path, File.Exists(path)?FileMode.Truncate:FileMode.CreateNew);
                fileStream.Write(Encoding.Default.GetBytes(jsonString));
                fileStream.Flush();
                fileStream.Close();
                return true;
            }
            catch(Exception ex)
            {
                Debug.Print(ex.Message);
                return false;
            }
        }

        private string path;
        private readonly JsonSerializerSettings settings;
    }
}
