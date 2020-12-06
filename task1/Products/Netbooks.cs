using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsClassLibrary
{
    /// <summary>
    /// Realistion for Netbooks
    /// </summary>
    [Serializable]
    public class Netbooks : GenericNotebooks
    {
        /// <summary>
        /// JSON constructor
        /// </summary>
        [JsonConstructor]
        public Netbooks(string name, double overprice, double price, uint count) : base(new(), name, overprice, price, count) { }

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="param">prams of wireless comm.</param>
        /// <param name="name"></param>
        /// <param name="overprice"></param>
        /// <param name="price"></param>
        /// <param name="count"></param>
        public Netbooks(MobileParametersEx param, string name, double overprice, double price, uint count) : base(param, name, overprice, price, count)
        {
            WiFi = param.WiFi;
            Cellular = param.Cellular;
            Bluetooth = param.Bluetooth;
            NFC = param.NFC;
            Weight = param.Weight;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return base.ToString() + $"\nWeight: {Weight}, WiFi: {WiFi}, Cell.: {Cellular}, BT: {Bluetooth}, NFC: {NFC}";
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), WiFi, Cellular, Bluetooth, NFC, Weight);
        }

        /// <inheritdoc/>
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

    /// <summary>
    /// Parameters for Devices with wireless communication.
    /// </summary>
    public class MobileParametersEx : MobileParameters
    {
        public bool WiFi;
        public bool Cellular;
        public bool Bluetooth;
        public bool NFC;
        public float Weight;
    }
}
