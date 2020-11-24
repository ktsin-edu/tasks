using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.DataClasses.Products
{
    [Serializable]
    public class Bread : BasicProduct
    {
        public Bread(string productName, in List<Ingridient> ingridients, int prodCount) : base("Bread", productName, 1.2, prodCount)
        {
            this.ingridients = ingridients;
        }
    }
}
