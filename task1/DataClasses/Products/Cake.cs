using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.DataClasses.Products
{
    /// <summary>
    /// Basic cake
    /// </summary>
    [Serializable]
    public class Cake : BasicProduct
    {
        /// <inheritdoc/>
        public Cake(string productName, in List<Ingredient> ingredients, int prodCount) : base("Cake", productName, 1.6, prodCount)
        {
            this.ingredients = ingredients;
        }
    }
}
