using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task1.DataClasses;

namespace task1.Reader
{
    public interface IDataCollector
    {
        public void Push(BasicProduct product);
        public BasicProduct[] GetSource();
    }
}
