using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsClassLibrary
{
    [Serializable]
    public class BasicPhones : GenericPhones
    {
        public BasicPhones(byte simCount, string name, double overprice, uint count, double price) : base(new(), name, overprice, count, price) { }
        public BasicPhones(byte simCount, MobilePhoneParametersBasic param, string name, double overprice, uint count, double price)
            : base(param, name, overprice, count, price)
        {
            SimCount = simCount;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), SimCount);
        }

        public override bool Equals(object obj)
        {
            return (base.Equals(obj) && (obj as BasicPhones)?.SimCount == SimCount);
        }

        public override string ToString()
        {
            return base.ToString() + $"; Sim counts: {SimCount}";
        }

        public byte SimCount { get; set; }
    }
}
