using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsClassLibrary
{
    public class BasicCollector : IDataCollector
    {
        public GenericProduct[] GetSource()
        {
            return source.ToArray();
        }

        public void Push(GenericProduct product)
        {
            if (product != null)
                source.Add(product);
            else
                throw new ArgumentNullException();
        }

        private List<GenericProduct> source = new();
    }
}
