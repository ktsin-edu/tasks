using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.DataClasses.Products
{
    /// <summary>
    /// Basic loaf
    /// </summary>
    [Serializable]
    public class Loaf : BasicProduct
    {
        /// <inheritdoc/>
        public Loaf(string productName, List<Ingredient> ingredients, int prodCount) : base("Loaf", productName, 1.4, prodCount)
        {
            this.ingredients = ingredients;
        }
        
    }
}
