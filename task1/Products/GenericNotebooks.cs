using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsClassLibrary
{
    /// <summary>
    /// Generic notebook desc.
    /// </summary>
    [Serializable]
    public class GenericNotebooks : ProductByUnit
    {
        /// <summary>
        /// Json const.
        /// </summary>
        [JsonConstructor]
        public GenericNotebooks(string name, double overprice, double price, uint count) : base(name, overprice, count, price) { }

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="param"> parameters from MobileParameters</param>
        /// <param name="name"></param>
        /// <param name="overprice"></param>
        /// <param name="price"></param>
        /// <param name="count"></param>
        public GenericNotebooks(MobileParameters param, string name, double overprice, double price, uint count) : base(name, overprice, count, price)
        {
            Diagonal = param.diag;
            BatteryPower = param.batt;
            RAM = param.ram;
            InternalStorage = param.internalStor;
            Os = param.os;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return base.ToString() + $"\nDiag: {Diagonal}, Batt: {BatteryPower}, RAM: {RAM}, Int. storage: {InternalStorage}, OS: {Os}";
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Diagonal, BatteryPower, RAM, InternalStorage, Os);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            var tmp = (obj as GenericNotebooks);
            return (base.Equals(obj) && tmp.RAM == RAM && tmp.Diagonal == Diagonal && tmp.BatteryPower == BatteryPower && tmp.Os == Os && InternalStorage == InternalStorage);
        }


        /// <summary>
        /// Explicit cast from GenericNotebook to GenTablet
        /// </summary>
        /// <param name="a"></param>
        public static explicit operator GenericTablet(GenericNotebooks a)
        {
            var res = new GenericTablet(new MobileParameters()
            {
                batt = a.BatteryPower,
                diag = a.Diagonal,
                internalStor = a.InternalStorage,
                os = a.Os,
                ram = a.RAM
            }, a.Overprice, a.ProductName, a.Count, a.PurchaseValue);
            return res;
        }

        /// <summary>
        /// Screen diagonal
        /// </summary>
        public float Diagonal { get; set; }
        /// <summary>
        /// Battery power, w*h
        /// </summary>
        public float BatteryPower { get; set; }
        /// <summary>
        /// RAM, mb
        /// </summary>
        public float RAM { get; set; }
        /// <summary>
        /// Internal Storage, GB
        /// </summary>
        public float InternalStorage { get; set; }
        /// <summary>
        /// Notebook OS
        /// </summary>
        public MobileOs Os { get; set; }
    }
}
