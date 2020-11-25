using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.DataClasses.Products
{
    /// <summary>
    /// Product type -- Pie
    /// </summary>
    [Serializable]
    public class Pie : BasicProduct
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ingredients">List of ingredients</param>
        /// <param name="prodCount"> Count of produced pies </param>
        /// <param name="productName"> Pie name </param>
        public Pie(string productName, List<Ingredient> ingredients, int prodCount) : base("Pie", productName, 1.55, prodCount)
        {
            this.ingredients = ingredients;
        }
    }
}
