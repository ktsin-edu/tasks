using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.DataClasses
{
    /// <summary>
    /// Represents ingredient of product
    /// </summary>
    public class Ingredient
    {
        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="name">Name of ingredient</param>
        /// <param name="price">Price of 1 kg</param>
        /// <param name="caloricity">caloricity of 1 kg</param>
        /// <param name="weight">Weight in kgs</param>
        public Ingredient(string name, double price, double caloricity, double weight)
        {
            this.name = name;
            this.price = price;
            this.caloricity = caloricity;
            this.weight = weight;
        }
        /// <summary>
        /// Name of ingredient
        /// </summary>
        public string name;
        /// <summary>
        /// Price of 1 kg
        /// </summary>
        public double price;
        /// <summary>
        /// caloricity of 1 kg
        /// </summary>
        public double caloricity;
        /// <summary>
        /// Weight in kgs
        /// </summary>
        public double weight;
    }
}
