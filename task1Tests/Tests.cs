using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            List<Ingridient> ingridients = new() { new Ingridient("a", 100, 200, 0.2),
                                                   new Ingridient("b", 300, 100, 1.2),
                                                   new Ingridient("c", 167, 314, 0.3)};
            return new Bread("RWR", ingridients, 123);
        }

        private static List<BasicProduct> GetProductsExample()
        {
            List<BasicProduct> products = new()
            {
                new Bread("FISRT BREAD", new List<Ingridient> {
                                                            new Ingridient("a", 45, 455, 2.1),
                                                            new Ingridient("b", 1.02, 0.1, 1),
                                                            new Ingridient("c", 5.4, 0.7, 0.4)}, 56),
                new Cake("FISRT CAKE", new List<Ingridient> {
                                                            new Ingridient("a", 12, 45, 2.1),
                                                            new Ingridient("d", 0.25, 0.7, 0.4)}, 37),
                new Loaf("FISRT LOAF", new List<Ingridient> {
                                                            new Ingridient("a", 4, 45, 2.1),
                                                            new Ingridient("d", 1, 45, 2.1),
                                                            new Ingridient("j", 142, 45, 0.01),
                                                            new Ingridient("t", 7, 74, 2.1),
                                                            new Ingridient("d", 0.25, 0.7, 0.4)}, 90),
                new Pie("FISRT PIE", new List<Ingridient> {
                                                            new Ingridient("a", 4, 45, 2.1),
                                                            new Ingridient("j", 142, 45, 0.01),
                                                            new Ingridient("d", 0.25, 0.7, 0.4)}, 79),
                new Scone("FISRT SCONE", new List<Ingridient> {
                                                            new Ingridient("da", 1, 45, 2.1),
                                                            new Ingridient("j", 142, 45, 0.01),
                                                            new Ingridient("ta", 7, 74, 2.1),
                                                            new Ingridient("d", 78, 0.7, 0.4)}, 21),
            };
            return products;
        }

        private static Ingridient GetIngridientExample()
        {
            return new Ingridient("test name", 45, 124, 0.78);
        }

        [TestMethod]
        public void CaloricityTest()
        {
            Assert.AreEqual(254.2, GetBasicProductExample().Caloricity, 0.000001);
        }

        [TestMethod]
        public void PriceTest()
        {
            Assert.AreEqual(516.12, GetBasicProductExample().Price, 0.000001);
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
            for(int i = 0; i < test.Count; i++)
            {
                Assert.IsTrue(test[i].Equals(res[i]));
            }
        }


    }
}
