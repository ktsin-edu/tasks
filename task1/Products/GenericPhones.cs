using System;
using System.Text;

namespace ProductsClassLibrary
{
    public class GenericPhones : ProductByUnit
    {
        public GenericPhones(MobilePhoneParametersBasic param, string name, double overprice, uint count, double price) : base(name, overprice, count, price)
        {
            Diagonal = param.diag;
            BatteryPower = param.batt;
            RAM = param.ram;
            InternalStorage = param.internalStor;
            Os = param.os;
            CellularNetworkType = param.CellularNetworkType;
        }

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

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), CellularNetworkType, Diagonal, BatteryPower, RAM, InternalStorage, Os);
        }

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

        public float Diagonal { get; set; }
        public float BatteryPower { get; set; }
        public float RAM { get; set; }
        public float InternalStorage { get; set; }
        public MobileOs Os { get; set; }
        public Int32 CellularNetworkType;

    }

    public class MobilePhoneParametersBasic : MobileParameters
    {
        public Int32 CellularNetworkType;
    }

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
