using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsClassLibrary
{
    /// <summary>
    /// Smartphone's desc. class
    /// </summary>
    [Serializable]
    public class Smartphones : GenericPhones
    {
        /// <summary>
        /// JSON Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="overprice"></param>
        /// <param name="count"></param>
        /// <param name="price"></param>
        [JsonConstructor]
        public Smartphones(string name, double overprice, uint count, double price) : base(new(), name, overprice, count, price) { }
        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="param">smartphone's params</param>
        /// <param name="name"></param>
        /// <param name="overprice"></param>
        /// <param name="count"></param>
        /// <param name="price"></param>
        public Smartphones(SmartphonesParams param, string name, double overprice, uint count, double price) 
            : base(param, name, overprice, count, price)
        {
            CPUVendor = param.CPUVendor;
            CPUCharacteristics = param.CPUCharacteristics;
            Description = param.Description;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), CPUVendor, CPUCharacteristics, Description);
        }
        /// <inheritdoc/>
        public override string ToString()
        {
            return base.ToString() + $"CPU: {CPUVendor}, {CPUCharacteristics}\nDescription: {Description}";
        }

        public string CPUVendor { get; set; }
        public string CPUCharacteristics { get; set; }
        public string Description { get; set; }
    }
    /// <summary>
    /// Smartphon params.
    /// </summary>
    public class SmartphonesParams : MobilePhoneParametersBasic{
        public string CPUVendor;
        public string CPUCharacteristics;
        public string Description;
    }
}
