using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ProductsClassLibrary
{
    public class ProductByUnit : GenericProduct
    {
        public ProductByUnit(string name, double overprice, uint count, double price) : base(count, name, overprice, price) { }

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

        public static ProductByUnit operator- (ProductByUnit a, int b)
        {
            var clone = (a.MemberwiseClone() as ProductByUnit);
            if (clone.Count - (uint)b < 0)
                throw new ArgumentOutOfRangeException($"{a.Count} - {(uint)b} < 0");
            clone.Count -= (uint)Math.Abs(b);
            return clone;
        }

        public static explicit operator int(ProductByUnit a) => (int)Math.Ceiling(a.FullPrice * 100);

        public static explicit operator double(ProductByUnit a) => Math.Ceiling(a.FullPrice * 100);
    }
}
