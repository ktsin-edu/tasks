using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProductsClassLibrary
{
    /// <summary>
    /// Root product class
    /// </summary>
    [Serializable]
    public abstract class GenericProduct
    {
        /// <summary>
        /// JSON constructor
        /// </summary>
        [JsonConstructor]
        public GenericProduct() { }

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="count">Units count</param>
        /// <param name="prodName">Name of product</param>
        /// <param name="overprice"></param>
        /// <param name="price">purchase value</param>
        public GenericProduct(uint count, string prodName, double overprice, double price)
        {
            this.Count = count;
            this.ProductName = prodName;
            this.Overprice = overprice;
            this.PurchaseValue = price;
        }
        /// <summary>
        /// Product name
        /// </summary>
        [DataMember]
        public string ProductName { set; get; }
        /// <summary>
        /// Full price (units*overprice*count)
        /// </summary>
        [IgnoreDataMember]
        public virtual double FullPrice { get => PurchaseValue*Overprice*Count; }
        //public virtual double PriceByCount { get => FullPrice / Count; }
        /// <summary>
        /// Overprice
        /// </summary>
        [DataMember]
        public virtual double Overprice { get; set; }
        /// <summary>
        /// Unit counts
        /// </summary>
        [DataMember]
        public virtual uint Count { get; set; }
        /// <summary>
        /// Purcharse value for one unit
        /// </summary>
        [DataMember]
        public virtual double PurchaseValue { get; set; }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(ProductName, Overprice, Count, PurchaseValue);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return (obj is GenericProduct tmp 
                    && ProductName.Equals(tmp.ProductName) 
                    && Count == tmp.Count 
                    && Math.Abs(PurchaseValue - tmp.PurchaseValue) <= 0.000001);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{ProductName}: {PurchaseValue} * {Overprice}; Count: {Count}";
        }
    }
}
