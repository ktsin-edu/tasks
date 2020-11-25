using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.DataClasses.Products
{
    /// <summary>
    /// basic scone
    /// </summary>
    [Serializable]
    public class Scone : BasicProduct
    {
        /// <inheritdoc/>
        public Scone(string productName, List<Ingredient> ingredients, int prodCount) : base("Scone", productName, 1.32, prodCount)
        {
            this.ingredients = ingredients;
        }
    }
}
