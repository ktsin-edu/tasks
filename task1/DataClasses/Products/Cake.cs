using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.DataClasses.Products
{
    public class Cake : BasicProduct
    {
        public Cake(string productName, in List<Ingridient> ingridients) : base("Cake", productName, 1.6)
        {
            this.ingridients = ingridients;
        }
    }
}
