using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.DataClasses.Products
{
    public class Scone : BasicProduct
    {
        public Scone(string productName, List<Ingridient> ingridients) : base("Scone", productName, 1.32)
        {
            this.ingridients = ingridients;
        }
    }
}
