using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task1.Reader;

namespace task1.DataClasses.Products
{
    public class BasicCollector : IDataCollector
    {
        public BasicCollector() { }
        public BasicCollector(List<BasicProduct> products)
        {
            if (products != null)
                this.products = products;
        }

        public BasicProduct[] GetSource()
        {
            List<BasicProduct> ret = new();
            foreach (var e in products)
                ret.Add(e);
            return ret.ToArray();
        }

        public void Push(BasicProduct product)
        {
            if (product != null)
                products.Add(product);
        }

        public List<BasicProduct> GetFullSource()
        {
            return products;
        }

        List<BasicProduct> products;
    }
}
