using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProductsClassLibrary
{
    [Serializable]
    public abstract class GenericProduct
    {
        public GenericProduct(uint count, string prodName, double overprice, double price)
        {
            this.Count = count;
            this.ProductName = prodName;
            this.Overprice = overprice;
            this.PurchaseValue = price;
        }
        [DataMember]
        public string ProductName { set; get; }
        [IgnoreDataMember]
        public virtual double FullPrice { get => PurchaseValue*Overprice*Count; }
        //public virtual double PriceByCount { get => FullPrice / Count; }
        [DataMember]
        public virtual double Overprice { get; set; }
        [DataMember]
        public virtual uint Count { get; set; }
        [DataMember]
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
            return $"{ProductName}: {PurchaseValue} * {Overprice}; Count: {Count}";
        }
    }
}
