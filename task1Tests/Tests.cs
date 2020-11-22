using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using task1.DataClasses;
using task1.DataClasses.Products;

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
            return new Bread("RWR", ingridients);
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
    }
}
