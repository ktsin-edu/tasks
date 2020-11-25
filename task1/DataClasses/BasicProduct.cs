using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace task1.DataClasses
{
    /// <summary>
    /// Represents abstract class of product
    /// </summary>
    [Serializable]
    public abstract class BasicProduct : IProduct
    {
        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="categoryName">Name of product category</param>
        /// <param name="productName">Name of product</param>
        /// <param name="overprice">Value of overpricing</param>
        /// <param name="prodCount">Produced bakery:</param>
        public BasicProduct(string categoryName, string productName, double overprice, int prodCount)
        {
            this.overprice = overprice;
            this.productName = productName;
            this.categoryName = categoryName;
            this.productCount = prodCount;
        }

        /// <summary>
        /// Caloricity of product
        /// </summary>
        [IgnoreDataMember]
        public double Caloricity { get => (double)ingredients?.Sum((ingredient) => ingredient.caloricity * ingredient.weight); }
        
        /// <summary>
        /// Basic price of product
        /// </summary>
        [IgnoreDataMember]
        public double Price { get => (double)ingredients?.Sum((ingredient) => ingredient.price * ingredient.weight); }
        
        /// <summary>
        /// Price of product with overprice
        /// </summary>
        [IgnoreDataMember]
        public double SalePrice { get => (double)ingredients?.Sum((ingredient) => ingredient.price * ingredient.weight) * overprice; }

        /// <summary>
        /// Name of product category
        /// </summary>
        public readonly string categoryName;

        /// <summary>
        /// Name of product
        /// </summary>
        public readonly string productName;


        /// <summary>
        /// basic ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{categoryName} {productName}";
        }

        /// <summary>
        /// basic GetHashCode()
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return categoryName.GetHashCode() ^
                   productName.GetHashCode() ^
                   ingredients.GetHashCode();
        }

        /// <summary>
        /// basic Equals()
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (this.Price == (obj as BasicProduct)?.Price) &&
                   (this.Caloricity == (obj as BasicProduct)?.Caloricity);
        }

        /// <summary>
        /// List of ingridients
        /// </summary>
        [DataMember]
        public List<Ingredient> ingredients;

        /// <summary>
        /// overprice
        /// </summary>
        [DataMember]
        public readonly double overprice;

        /// <summary>
        /// Produced bakery
        /// </summary>
        [DataMember]
        public int productCount;
    }
}
