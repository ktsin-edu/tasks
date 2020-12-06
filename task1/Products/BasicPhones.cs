using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsClassLibrary
{
    /// <summary>
    /// Basic phone, with big buttons)
    /// </summary>
    [Serializable]
    public class BasicPhones : GenericPhones
    {
        /// <summary>
        /// Json constructor
        /// </summary>
        [JsonConstructor]
        public BasicPhones(byte simCount, string name, double overprice, uint count, double price) : base(new(), name, overprice, count, price) { }
        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="simCount"></param>
        /// <param name="param">parameters from generic phone</param>
        /// <param name="name">prod. name</param>
        /// <param name="overprice"></param>
        /// <param name="count"></param>
        /// <param name="price">purcharce price</param>
        public BasicPhones(byte simCount, MobilePhoneParametersBasic param, string name, double overprice, uint count, double price)
            : base(param, name, overprice, count, price)
        {
            SimCount = simCount;
        }
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), SimCount);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return (base.Equals(obj) && (obj as BasicPhones)?.SimCount == SimCount);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return base.ToString() + $"; Sim counts: {SimCount}";
        }

        /// <summary>
        /// Sim cards count
        /// </summary>
        public byte SimCount { get; set; }
    }
}
