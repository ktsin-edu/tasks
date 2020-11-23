using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.Reader
{
    public interface IDataScanner
    {
        public bool Open(object path);
        public bool Read(IDataCollector collector);
    }
}
