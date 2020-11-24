using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.Writer
{
    public interface IDataWriter
    {
        public bool Open(object path);
        public bool Write(Reader.IDataCollector collector);
    }
}
