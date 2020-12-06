﻿using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsClassLibrary
{
    /// <summary>
    /// Implementation of IDataScanner for JSON source
    /// </summary>
    public class JSONScanner : IDataScanner
    {
        /// <summary>
        /// basic constructor
        /// </summary>
        public JSONScanner()
        {
            settings = new() { TypeNameHandling = TypeNameHandling.Objects,
                               Formatting = Formatting.Indented };
        }

        /// <inheritdoc/>
        public bool Open(object path)
        {
            this.path = path as string;
            if (this.path != null)
                return File.Exists(this.path);
            else
                return false;
        }

        /// <inheritdoc/>
        public bool Read(IDataCollector collector)
        {
            string jsonRepresentation = File.ReadAllText(path);
            var list = JsonConvert
                        .DeserializeObject<List<BasicProduct>>(jsonRepresentation, 
                                                               settings);
            if (list.Count != 0)
            {
                foreach (var element in list)
                    collector?.Push(element);
                return true;
            }
            return false;
        }

        private string path;
        private JsonSerializerSettings settings;
    }
}
