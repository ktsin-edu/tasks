using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.DataClasses.Products
{
    [Serializable]
    public class Cake : BasicProduct
    {
        public Cake(string productName, in List<Ingridient> ingridients, int prodCount) : base("Cake", productName, 1.6, prodCount)
        {
            this.ingridients = ingridients;
        }
    }
}
