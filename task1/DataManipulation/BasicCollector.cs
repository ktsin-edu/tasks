using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsClassLibrary
{
    /// <summary>
    /// Basic realisation of IDataCollector
    /// </summary>
    public class BasicCollector : IDataCollector
    {
        /// <inheritdoc/>
        public GenericProduct[] GetSource()
        {
            return source.ToArray();
        }

        /// <inheritdoc/>
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
