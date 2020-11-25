using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.DataClasses.Products
{
    /// <summary>
    /// Basic bread
    /// </summary>
    [Serializable]
    public class Bread : BasicProduct
    {
        /// <inheritdoc/>
        public Bread(string productName, in List<Ingredient> ingredients, int prodCount) : base("Bread", productName, 1.2, prodCount)
        {
            this.ingredients = ingredients;
        }
    }
}
