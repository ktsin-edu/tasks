using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.DataClasses.Products
{
    public class Pie : BasicProduct
    {
        public Pie(string productName, List<Ingridient> ingridients) : base("Pie", productName, 1.55)
        {
            this.ingridients = ingridients;
        }
    }
}
