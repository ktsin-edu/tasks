using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.Reader
{
    class JSONScanner : IDataScanner
    {
        JSONScanner(string filePath, IDataCollector collector)
        {
            this.collector = collector;
            this.path = filePath;
        }

        private IDataCollector collector;
        private string path;
    }
}
