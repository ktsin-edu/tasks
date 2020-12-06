using ProductsClassLibrary;
using Xunit;

namespace task2Tests
{
    public class UnitTests
    {
        [Fact]
        public void test1()
        {
            var tmp = new Smartphones(new SmartphonesParams() {
                                        CPUVendor = "VCPU",
                                        CPUCharacteristics="2.2GHz",
                                        batt=5.12F,
                                        ram = 4.0F,
                                        internalStor=16.0F,
                                        os=MobileOs.GenericLinux,
                                        Description="No desc.",
                                        diag=5.5F,
                                        CellularNetworkType = ((int)NetworkType._2G | (int)NetworkType._2_5G | (int)NetworkType._3G | (int)NetworkType._3G)
            },
                                        "name", 1.8, 100, 900);
            string temp = tmp.ToString();
            Assert.True(true);
        }
    }
}
