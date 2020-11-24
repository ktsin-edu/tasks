﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task1.DataClasses;

namespace task1
{
    public static class Logic
    {
        public static BasicProduct[] GetSortedCopyByCaloricity(BasicProduct[] products)
        {
            BasicProduct[] copy = Array.Empty<BasicProduct>();
            products.CopyTo(copy, 0);
            Array.Sort(copy, (a, b) => b.Caloricity.CompareTo(a.Caloricity));
            return copy;
        }

        public static BasicProduct[] GetSortedCopyByCost(BasicProduct[] products)
        {
            BasicProduct[] copy = Array.Empty<BasicProduct>();
            products.CopyTo(copy, 0);
            Array.Sort(copy, (a, b) => b.Price.CompareTo(a.Price));
            return copy;
        }

        public static BasicProduct[] GetEqualProducts(BasicProduct[] products, double price, double caloricity)
        {
            var res = products.Where(e=>compareDouble(e.Price, price)
                                        && compareDouble(e.Caloricity, caloricity));
            return res.ToArray();
        }

        public static BasicProduct[] GetProductsByIngiridientWeight(BasicProduct[] products, string ingridientName, double weight)
        {
            var res = products.Where(e => e.ingridients?.FindAll(el => (el.weight > weight && el.name == ingridientName))?.Count > 0);
            return res?.ToArray();
        }

        public static BasicProduct[] GetProductsByIngiridientsCount(BasicProduct[] products, int ingridientCount)
        {
            return products.Where(e=>e.ingridients.Count > ingridientCount).ToArray();
        }

        private static Func<double, double, bool> compareDouble = new((a, b) => Math.Abs(a - b) < 0.000001);
    }
}
