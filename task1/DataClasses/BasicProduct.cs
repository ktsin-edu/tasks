using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.DataClasses
{
    public abstract class BasicProduct : IProduct
    {
        public BasicProduct(string categoryName, string productName, double overprice)
        {
            this.overprice = overprice;
            this.productName = productName;
            this.categoryName = categoryName;
        }

        public double  Caloricity { get => (double)ingridients?.Sum((ingridient) => ingridient.caloricity*ingridient.weight); }

        public double Price { get => (double)ingridients?.Sum((ingridient) => ingridient.price*ingridient.weight)*overprice; }

        public readonly string categoryName;

        public readonly string productName;

        public override string ToString()
        {
            return $"{categoryName} {productName}";
        }

        public override int GetHashCode()
        {
            return categoryName.GetHashCode()^
                   productName.GetHashCode()^
                   ingridients.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return (this.Price == ((BasicProduct)obj).Price) &&
                   (this.Caloricity == ((BasicProduct)obj).Caloricity);
        }

        protected List<Ingridient> ingridients;

        private readonly double overprice;
    }
}
