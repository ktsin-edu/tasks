using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task1.DataClasses;

namespace task1
{
    /// <summary>
    /// Provides static methods for business-logic
    /// </summary>
    public static class Logic
    {
        /// <summary>
        /// Getting sorted copy by caloricity of BasicProduct[]
        /// </summary>
        /// <param name="products">BasicProduct[] source</param>
        /// <returns> Returns sorted copy of products</returns>
        public static BasicProduct[] GetSortedCopyByCaloricity(BasicProduct[] products)
        {
            BasicProduct[] copy = Array.Empty<BasicProduct>();
            Array.Resize(ref copy, products.Length);
            products.CopyTo(copy, 0);
            Array.Sort(copy, (a, b) => b.Caloricity.CompareTo(a.Caloricity));
            return copy;
        }
        /// <summary>
        /// Getting sorted copy by price of BasicProduct[]
        /// </summary>
        /// <param name="products">BasicProduct[] source</param>
        /// <returns> Returns sorted copy of products</returns>
        public static BasicProduct[] GetSortedCopyByCost(BasicProduct[] products)
        {
            BasicProduct[] copy = Array.Empty<BasicProduct>();
            Array.Resize(ref copy, products.Length);
            products.CopyTo(copy, 0);
            Array.Sort(copy, (a, b) => b.Price.CompareTo(a.Price));
            return copy;
        }

        /// <summary>
        /// Getting array of elements which has equal price and caloricity with provided by parameters
        /// </summary>
        /// <param name="products">BasicProducts[] source</param>
        /// <param name="price">Price of BasicProduct</param>
        /// <param name="caloricity">Caloricity of BasicProduct</param>
        /// <returns></returns>
        public static BasicProduct[] GetEqualProducts(BasicProduct[] products, double price, double caloricity)
        {
            var res = products.Where(e=>compareDouble(e.Price, price)
                                        && compareDouble(e.Caloricity, caloricity));
            return res.ToArray();
        }

        /// <summary>
        /// Returns array of elements which have in their composition ingredient with greater weight than provided in parameters
        /// </summary>
        /// <param name="products">BasicProducts[] source</param>
        /// <param name="ingredientName"> ingredient name</param>
        /// <param name="weight">Weight level</param>
        /// <returns>BasicProduct[] array</returns>
        public static BasicProduct[] GetProductsByIngiridientWeight(BasicProduct[] products, string ingredientName, double weight)
        {
            var res = products.Where(e => e.ingredients?.FindAll(el => (el.weight > weight && el.name == ingredientName))?.Count > 0);
            return res?.ToArray();
        }

        /// <summary>
        /// Returns array of elements which have in their composition ingredients count greater than provided in parameters
        /// </summary>
        /// <param name="products">BasicProducts[] source</param>
        /// <param name="ingredientCount"> Ingredients count </param>
        /// <returns>BasicProduct[] array</returns>
        public static BasicProduct[] GetProductsByIngiridientsCount(BasicProduct[] products, int ingredientCount)
        {
            return products.Where(e=>e.ingredients.Count > ingredientCount).ToArray();
        }

        private static Func<double, double, bool> compareDouble = new((a, b) => Math.Abs(a - b) < 0.000001);
    }
}
