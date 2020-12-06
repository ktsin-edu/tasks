using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsClassLibrary
{
    [Serializable]
    public class Smartphones : GenericPhones
    {
        public Smartphones(SmartphonesParams param, string name, double overprice, uint count, double price) 
            : base(param, name, overprice, count, price)
        {
            CPUVendor = param.CPUVendor;
            CPUCharacteristics = param.CPUCharacteristics;
            Description = param.Description;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), CPUVendor, CPUCharacteristics, Description);
        }

        public override string ToString()
        {
            return base.ToString() + $"CPU: {CPUVendor}, {CPUCharacteristics}\nDescription: {Description}";
        }

        public string CPUVendor { get; set; }
        public string CPUCharacteristics { get; set; }
        public string Description { get; set; }
    }

    public class SmartphonesParams : MobilePhoneParametersBasic{
        public string CPUVendor;
        public string CPUCharacteristics;
        public string Description;
    }
}
