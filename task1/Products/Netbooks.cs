using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsClassLibrary
{
    [Serializable]
    public class Netbooks : GenericNotebooks
    {
        [JsonConstructor]
        public Netbooks(string name, double overprice, double price, uint count) : base(new(), name, overprice, price, count) { }

        public Netbooks(MobileParametersEx param, string name, double overprice, double price, uint count) : base(param, name, overprice, price, count)
        {
            WiFi = param.WiFi;
            Cellular = param.Cellular;
            Bluetooth = param.Bluetooth;
            NFC = param.NFC;
            Weight = param.Weight;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nWeight: {Weight}, WiFi: {WiFi}, Cell.: {Cellular}, BT: {Bluetooth}, NFC: {NFC}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), WiFi, Cellular, Bluetooth, NFC, Weight);
        }

        public override bool Equals(object obj)
        {
            Netbooks tmp = obj as Netbooks;
            return (base.Equals(obj) && tmp.WiFi == WiFi && tmp.Cellular == Cellular && Bluetooth == tmp.Bluetooth && NFC == tmp.NFC && Weight == tmp.Weight);
        }

        public bool WiFi { get; set; }
        public bool Cellular { get; set; }
        public bool Bluetooth { get; set; }
        public bool NFC { get; set; }
        public float Weight { get; set; }

    }

    public class MobileParametersEx : MobileParameters
    {
        public bool WiFi;
        public bool Cellular;
        public bool Bluetooth;
        public bool NFC;
        public float Weight;
    }
}
