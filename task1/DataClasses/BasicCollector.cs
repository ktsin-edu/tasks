using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task1.Reader;

namespace task1.DataClasses.Products
{
    /// <summary>
    /// Represents basic collector for BasicProduct instances
    /// </summary>
    public class BasicCollector : IDataCollector
    {
        /// <summary>
        /// Basic constructor
        /// </summary>
        public BasicCollector() { products = new(); }
        /// <summary>
        /// Accepts list of BasicProducts
        /// </summary>
        /// <param name="products">List of BasicProducts instances</param>
        public BasicCollector(List<BasicProduct> products)
        {
            if (products != null)
                this.products = products;
        }

        /// <summary>
        /// Method for getting the source array
        /// </summary>
        /// <returns>BasicProduct[]</returns>
        public BasicProduct[] GetSource()
        {
            List<BasicProduct> ret = new();
            foreach (var e in products)
                ret.Add(e);
            return ret.ToArray();
        }

        /// <summary>
        /// Adds new BasicProduct instance to collector
        /// </summary>
        /// <param name="product">Basicroduct instance</param>
        public void Push(BasicProduct product)
        {
            if (product != null)
                products.Add(product);
        }

        List<BasicProduct> products;
    }
}
