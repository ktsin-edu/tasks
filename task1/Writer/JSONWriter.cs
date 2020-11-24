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
            settings.TypeNameHandling = TypeNameHandling.Objects;
        }

        public bool Open(object path)
        {
            this.path = path as string;
            if (this.path != null)
                return File.Exists(this.path);
            else
                return false;
        }

        public bool Write(IDataCollector collector)
        {
            try
            {
                var src = collector.GetSource();
                var jsonString = JsonConvert.SerializeObject(src);
                var fileStream = File.Open(this.path, FileMode.OpenOrCreate);
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
