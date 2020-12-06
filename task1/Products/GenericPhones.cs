using Newtonsoft.Json;
using System;
using System.Text;

namespace ProductsClassLibrary
{
    /// <summary>
    /// Realisation of generic phone
    /// </summary>
    [Serializable]
    public class GenericPhones : ProductByUnit
    {
        /// <summary>
        /// JSON Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="overprice"></param>
        /// <param name="count"></param>
        /// <param name="price"></param>
        [JsonConstructor]
        public GenericPhones(string name, double overprice, uint count, double price) : base(name, overprice, count, price)  { }

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="param"> params from MibilePhoneParametersBasic</param>
        /// <param name="name"></param>
        /// <param name="overprice"></param>
        /// <param name="count"></param>
        /// <param name="price"></param>
        public GenericPhones(MobilePhoneParametersBasic param, string name, double overprice, uint count, double price)
            : base(name, overprice, count, price)
        {
            Diagonal = param.diag;
            BatteryPower = param.batt;
            RAM = param.ram;
            InternalStorage = param.internalStor;
            Os = param.os;
            CellularNetworkType = param.CellularNetworkType;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            StringBuilder networkType = new("Network: ");
            if ((CellularNetworkType & (int)NetworkType._1G) != 0)
                networkType.Append("1G, ");
            if ((CellularNetworkType & (int)NetworkType._2G) != 0)
                networkType.Append("2G, ");
            if ((CellularNetworkType & (int)NetworkType._2_5G) != 0)
                networkType.Append("2.5G, ");
            if ((CellularNetworkType & (int)NetworkType._3G) != 0)
                networkType.Append("3G, ");
            if ((CellularNetworkType & (int)NetworkType._3_5G) != 0)
                networkType.Append("3.5G, ");
            if ((CellularNetworkType & (int)NetworkType._3_75G) != 0)
                networkType.Append("3.75G, ");
            if ((CellularNetworkType & (int)NetworkType._4G) != 0)
                networkType.Append("4G, ");
            if ((CellularNetworkType & (int)NetworkType._5G) != 0)
                networkType.Append("5G, ");

            return base.ToString() + $"\nDiag: {Diagonal}, Batt: {BatteryPower}, RAM: {RAM}, Int. storage: {InternalStorage}, OS: {Os}, Net: {networkType}";
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), CellularNetworkType, Diagonal, BatteryPower, RAM, InternalStorage, Os);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            var tmp = (obj as GenericPhones);
            if (tmp != null)
                return (base.Equals(obj)
                    && tmp.RAM == RAM
                    && tmp.Diagonal == Diagonal
                    && tmp.BatteryPower == BatteryPower
                    && tmp.Os == Os
                    && tmp.InternalStorage == InternalStorage
                    && tmp.CellularNetworkType == CellularNetworkType);
            else
                throw new ArgumentException($"Wrong object. Expected {typeof(GenericPhones).Name}, got {obj.GetType().Name}");
        }

        /// <summary>
        /// Screen Diagonal
        /// </summary>
        public float Diagonal { get; set; }
        /// <summary>
        /// Battery power, w*h
        /// </summary>
        public float BatteryPower { get; set; }
        /// <summary>
        /// RAM, MBs
        /// </summary>
        public float RAM { get; set; }
        /// <summary>
        /// Internal Storage, GBs
        /// </summary>
        public float InternalStorage { get; set; }
        /// <summary>
        /// Phone OS
        /// </summary>
        public MobileOs Os { get; set; }
        /// <summary>
        /// Cell. network flags
        /// </summary>
        public Int32 CellularNetworkType;

    }

    /// <summary>
    /// Extended MobileParameters (+ cell. flags)
    /// </summary>
    public class MobilePhoneParametersBasic : MobileParameters
    {
        public Int32 CellularNetworkType;
    }

    /// <summary>
    /// Network type defines
    /// </summary>
    [Serializable]
    public enum NetworkType
    {
        _1G = 0x0001,
        _2G = 0x0010,
        _2_5G = 0x0030,
        _3G = 0x0100,
        _3_5G = 0x0300,
        _3_75G = 0x0A00,
        _4G = 0x1000,
        _5G = 0x2000
    }
}
