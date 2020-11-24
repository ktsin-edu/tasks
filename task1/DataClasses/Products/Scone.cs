using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.DataClasses.Products
{
    [Serializable]
    public class Scone : BasicProduct
    {
        public Scone(string productName, List<Ingridient> ingridients, int prodCount) : base("Scone", productName, 1.32, prodCount)
        {
            this.ingridients = ingridients;
        }
    }
}
