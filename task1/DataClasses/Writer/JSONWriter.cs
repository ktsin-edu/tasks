﻿using Newtonsoft.Json;
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
    /// <summary>
    /// Implementation of json serializer (IDataWriter)
    /// </summary>
    public class JSONWriter : IDataWriter
    {
        /// <summary>
        /// parameterless constructor
        /// </summary>
        public JSONWriter()
        {
            settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented
            };
        }

        /// <summary>
        /// Preparing before writing
        /// </summary>
        /// <param name="path">path to file</param>
        /// <returns></returns>
        public bool Open(object path)
        {
            this.path = path as string;
            if (this.path != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Method for writing serialized data to file
        /// </summary>
        /// <param name="collector">class that implements IDataCollector interface</param>
        /// <returns></returns>
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
