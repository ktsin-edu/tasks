using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using task1;
using task1.DataClasses;
using task1.DataClasses.Products;
using task1.Reader;
using task1.Writer;

namespace task1Tests
{
    [TestClass]
    public class Tests
    {
        private static BasicProduct GetBasicProductExample()
        {
            List<Ingredient> ingredients = new()
            {
                new Ingredient("a", 100, 200, 0.2),
                new Ingredient("b", 300, 100, 1.2),
                new Ingredient("c", 167, 314, 0.3)
            };
            return new Bread("RWR", ingredients, 123);
        }

        private static List<BasicProduct> GetProductsExample()
        {
            List<BasicProduct> products = new()
            {
                new Bread("FISRT BREAD", new List<Ingredient> {
                                                            new Ingredient("a", 45, 455, 2.1),
                                                            new Ingredient("b", 1.02, 0.1, 1),
                                                            new Ingredient("c", 5.4, 0.7, 0.4)}, 56),
                new Cake("FISRT CAKE", new List<Ingredient> {
                                                            new Ingredient("a", 12, 45, 2.1),
                                                            new Ingredient("d", 0.25, 0.7, 0.4)}, 37),
                new Loaf("FISRT LOAF", new List<Ingredient> {
                                                            new Ingredient("a", 4, 45, 2.1),
                                                            new Ingredient("d", 1, 45, 2.1),
                                                            new Ingredient("j", 142, 45, 0.01),
                                                            new Ingredient("t", 7, 74, 2.1),
                                                            new Ingredient("d", 0.25, 0.7, 0.4)}, 90),
                new Pie("FISRT PIE", new List<Ingredient> {
                                                            new Ingredient("a", 4, 45, 2.1),
                                                            new Ingredient("j", 142, 45, 0.01),
                                                            new Ingredient("d", 0.25, 0.7, 0.4)}, 79),
                new Scone("FISRT SCONE", new List<Ingredient> {
                                                            new Ingredient("da", 1, 45, 2.1),
                                                            new Ingredient("j", 142, 45, 0.01),
                                                            new Ingredient("ta", 7, 74, 2.1),
                                                            new Ingredient("d", 78, 0.7, 0.4)}, 21),
            };
            return products;
        }

        private static Ingredient GetingredientExample()
        {
            return new Ingredient("test name", 45, 124, 0.78);
        }

        [TestMethod]
        public void CaloricityTest()
        {
            Assert.AreEqual(254.2, GetBasicProductExample().Caloricity, 0.000001);
        }

        [TestMethod]
        public void PriceTest()
        {
            Assert.AreEqual(516.12, GetBasicProductExample().SalePrice, 0.000001);
        }

        [TestMethod]
        public void WriteFileTest()
        {
            var test = GetProductsExample();
            BasicCollector collector = new(test);
            JSONWriter writer = new();
            Assert.IsTrue(writer.Open("test.json"));
            Assert.IsTrue(writer.Write(collector));
        }

        [TestMethod]
        public void ReadFileTest()
        {
            WriteFileTest();
            var test = GetProductsExample();
            BasicCollector collector = new();
            JSONScanner scanner = new();
            Assert.IsTrue(scanner.Open("test.json"));
            Assert.IsTrue(scanner.Read(collector));
            var res = collector.GetSource();
            for (int i = 0; i < test.Count; i++)
            {
                Assert.IsTrue(test[i].Equals(res[i]));
            }
        }

        [TestMethod]
        public void GetSortedCopyByCaloricityTest()
        {
            var test = GetProductsExample();
            var res = Logic.GetSortedCopyByCaloricity(test.ToArray());
            Assert.AreEqual(955.88, res[0].Caloricity, 0.00001);
        }

        [TestMethod]
        public void GetSortedCopyByCostTest()
        {
            var test = GetProductsExample();
            var res = Logic.GetSortedCopyByCost(test.ToArray());
            Assert.AreEqual(97.68, res[0].Price, 0.00001);
        }

        [TestMethod]
        public void GetEqualProductsTest()
        {
            var test = GetProductsExample();
            var res = Logic.GetEqualProducts(test.ToArray(), 97.68, 955.88);
            Assert.AreEqual(97.68, res[0].Price, 0.00001);
            Assert.AreEqual(1, res.Length);
        }

        [TestMethod]
        public void GetProductsByIngiridientWeightTest()
        {
            var test = GetProductsExample();
            var res = Logic.GetProductsByIngiridientWeight(test.ToArray(), "a", 0);
            Assert.AreEqual(4, res.Length);
        }

        [TestMethod]
        public void GetProductsByIngiridientsCountTest()
        {
            var test = GetProductsExample();
            var res = Logic.GetProductsByIngiridientsCount(test.ToArray(), 3);
            Assert.AreEqual(2, res.Length);
        }

    }
}
