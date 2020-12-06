using ProductsClassLibrary;
using System;
using Xunit;

namespace task2Tests
{
    public class UnitTests
    {
        public Tuple<Smartphones, Smartphones> GetTwoSmartphones()
        {
            var tmp1 = new Smartphones(new SmartphonesParams()
            {
                CPUVendor = "VCPU",
                CPUCharacteristics = "2.2GHz",
                batt = 5.12F,
                ram = 4.0F,
                internalStor = 16.0F,
                os = MobileOs.GenericLinux,
                Description = "No desc.",
                diag = 5.5F,
                CellularNetworkType = ((int)NetworkType._2G | (int)NetworkType._2_5G | (int)NetworkType._3G | (int)NetworkType._3G)
            },
                            "name", 1.8, 100, 900);
            var tmp2 = new Smartphones(new SmartphonesParams()
            {
                CPUVendor = "VCPU",
                CPUCharacteristics = "2.2GHz",
                batt = 5.12F,
                ram = 4.0F,
                internalStor = 16.0F,
                os = MobileOs.GenericLinux,
                Description = "No desc.",
                diag = 5.5F,
                CellularNetworkType = ((int)NetworkType._2G | (int)NetworkType._2_5G | (int)NetworkType._3G | (int)NetworkType._3G)
            },
                                        "name", 1.8, 100, 370);
            return new Tuple<Smartphones, Smartphones>(tmp1, tmp2);
        }

        public GenericTablet GetTablet()
        {
            return new GenericTablet(new MobileParameters() {batt = 37.6F,
                                                            diag=13.3F,
                                                            internalStor=64.0F,
                                                            os=MobileOs.GenericLinux,
                                                            ram=8014.14F  },
                                                            1.3, "Generic Tablet!!", 21, 2100);
        }

        public BasicCollector GetTestData()
        {
            var collector = new BasicCollector();
            var tmp = GetTwoSmartphones();
            collector.Push(tmp.Item1);
            collector.Push(tmp.Item2);
            collector.Push(GetTablet());
            collector.Push((GenericNotebooks)GetTablet());
            return collector;
        }

        [Fact]
        public void CheckPlusOperatorPositive()
        {
            var tmp = GetTwoSmartphones();
            var tmp3 = tmp.Item1 + tmp.Item2;
            Assert.Equal(635, tmp3.PurchaseValue);
        }

        [Fact]
        public void CheckPlusOperatorNegative()
        {
            var tmp = GetTwoSmartphones();
            tmp.Item2.ProductName = "NaN";
            Assert.Throws<ArgumentException>(() => tmp.Item1 + tmp.Item2);
        }

        [Fact]
        public void CheckSubOperatorPositive()
        {
            var tmp = GetTwoSmartphones();
            var res = tmp.Item1 - 50;
            Assert.Equal((uint)50, res.Count);
        }

        [Fact]
        public void CheckSubOperatorNegative()
        {
            var tmp = GetTwoSmartphones();
            Assert.Throws<ArgumentOutOfRangeException>(() => tmp.Item1 - 500);
        }

        [Fact]
        public void CheckTypeCastToIntDouble()
        {
            var tmp = GetTwoSmartphones();
            Assert.Equal(16200000, (int)tmp.Item1);
            Assert.Equal(16200000.0, (double)tmp.Item1);
        }

        [Fact]
        public void CheckTypesCastNotebookTablets()
        {
            bool flag = true;
            try
            {
                var tmp = GetTablet();
                var tmp0 = (GenericNotebooks)tmp;
            }
            catch
            {
                flag = false;
            }
            finally
            {
                Assert.True(flag);
            }

        }

        [Fact]
        public void TestJSONSerializer()
        {
            var collector = GetTestData();
            var write = new JSONWriter();
            Assert.True(write.Open("jsontest.json"));
            Assert.True(write.Write(collector));
        }

        [Fact]
        public void TestJSONDeserializer()
        {
            var collector = GetTestData();
            var ncollector = new BasicCollector();
            var read = new JSONScanner();
            Assert.True(read.Open("jsontest.json"));
            Assert.True(read.Read(ncollector));
            var a = collector.GetSource();
            var b = ncollector.GetSource();
            for (int i = 0; i < a.Length; i++)
                Assert.Equal(a[i], b[i]);
        }



    }
}
