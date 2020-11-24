using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.DataClasses.Products
{
    [Serializable]
    public class Pie : BasicProduct
    {
        public Pie(string productName, List<Ingridient> ingridients, int prodCount) : base("Pie", productName, 1.55, prodCount)
        {
            this.ingridients = ingridients;
        }
    }
}
