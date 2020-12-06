using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ProductsClassLibrary
{
    /// <summary>
    /// Basic class for descripting products which sells by units
    /// </summary>
    [Serializable]
    public class ProductByUnit : GenericProduct
    {
        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="overprice"></param>
        /// <param name="count"></param>
        /// <param name="price"></param>
        public ProductByUnit(string name, double overprice, uint count, double price) : base(count, name, overprice, price) { }

        /// <summary>
        /// adds prod. b to prod. a
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static ProductByUnit operator+(ProductByUnit a, ProductByUnit b)
        {
            if(a.ProductName == b.ProductName)
            {
                var clone = a.MemberwiseClone() as ProductByUnit;
                clone.Count += b.Count;
                clone.PurchaseValue = (a.PurchaseValue*a.Count + b.PurchaseValue*b.Count)/(a.Count + b.Count);
                clone.Overprice = (a.Overprice * a.Count + b.Overprice * b.Count) / (a.Count + b.Count);
                return clone;
            }
            throw new ArgumentException($"'{a}' not equal to '{b}'");
        }


        /// <summary>
        /// sub. count
        /// </summary>
        /// <param name="a">products</param>
        /// <param name="b">count</param>
        /// <returns></returns>
        public static ProductByUnit operator- (ProductByUnit a, int b)
        {
            var clone = (a.MemberwiseClone() as ProductByUnit);
            if ((int)clone.Count - b < 0)
                throw new ArgumentOutOfRangeException($"{a.Count} - {(uint)b} < 0");
            clone.Count -= (uint)Math.Abs(b);
            return clone;
        }

        /// <summary>
        /// getting kopecks (int)
        /// </summary>
        /// <param name="a"></param>
        public static explicit operator int(ProductByUnit a) => (int)Math.Ceiling(a.FullPrice * 100);

        /// <summary>
        /// getting kopecks (double)
        /// </summary>
        /// <param name="a"></param>
        public static explicit operator double(ProductByUnit a) => Math.Ceiling(a.FullPrice * 100);
    }
}
