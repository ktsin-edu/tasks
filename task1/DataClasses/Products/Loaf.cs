using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.DataClasses.Products
{
    [Serializable]
    public class Loaf : BasicProduct
    {
        public Loaf(string productName, List<Ingridient> ingridients, int prodCount) : base("Loaf", productName, 1.4, prodCount)
        {
            this.ingridients = ingridients;
        }
        
    }
}
