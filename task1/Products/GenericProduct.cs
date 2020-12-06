using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsClassLibrary
{
    public abstract class GenericProduct
    {
        public GenericProduct(uint count, string prodName, double overprice, double price)
        {
            this.Count = count;
            this.ProductName = prodName;
            this.Overprice = overprice;
            this.PurchaseValue = price;
        }
        public string ProductName { set; get; }
        public virtual double FullPrice { get => PurchaseValue*Overprice; }
        public virtual double PriceByCount { get => FullPrice / Count; }
        public virtual double Overprice { get; set; }
        public virtual uint Count { get; set; }
        public virtual double PurchaseValue { get; set; }
        public override int GetHashCode()
        {
            return HashCode.Combine(ProductName, Overprice, Count, PurchaseValue);
        }

        public override bool Equals(object obj)
        {
            return (obj is GenericProduct tmp 
                    && ProductName.Equals(tmp.ProductName) 
                    && Count == tmp.Count 
                    && Math.Abs(PurchaseValue - tmp.PurchaseValue) <= 0.000001);
        }

        public override string ToString()
        {
            return $"{ProductName}: {PurchaseValue : F5} * {Overprice}; Count: {Count}";
        }
    }
}
