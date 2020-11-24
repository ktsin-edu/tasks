using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace task1.DataClasses
{
    [Serializable]
    public abstract class BasicProduct : IProduct
    {
        public BasicProduct(string categoryName, string productName, double overprice, int prodCount)
        {
            this.overprice = overprice;
            this.productName = productName;
            this.categoryName = categoryName;
            this.productCount = prodCount;
        }
        [IgnoreDataMember]
        public double Caloricity { get => (double)ingridients?.Sum((ingridient) => ingridient.caloricity * ingridient.weight); }
        [IgnoreDataMember]
        public double Price { get => (double)ingridients?.Sum((ingridient) => ingridient.price * ingridient.weight); }
        [IgnoreDataMember]
        public double SalePrice { get => (double)ingridients?.Sum((ingridient) => ingridient.price * ingridient.weight) * overprice; }

        public readonly string categoryName;

        public readonly string productName;

        public override string ToString()
        {
            return $"{categoryName} {productName}";
        }

        public override int GetHashCode()
        {
            return categoryName.GetHashCode() ^
                   productName.GetHashCode() ^
                   ingridients.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return (this.Price == (obj as BasicProduct)?.Price) &&
                   (this.Caloricity == (obj as BasicProduct)?.Caloricity);
        }
        [DataMember]
        public List<Ingridient> ingridients;
        [DataMember]
        public readonly double overprice;
        [DataMember]
        public int productCount;
    }
}
