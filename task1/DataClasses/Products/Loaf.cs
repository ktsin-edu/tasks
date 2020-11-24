using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.DataClasses.Products
{
    public class Loaf : BasicProduct
    {
        public Loaf(string productName, List<Ingridient> ingridients) : base("Loaf", productName, 1.4)
        {
            this.ingridients = ingridients;
        }
        
    }
}
