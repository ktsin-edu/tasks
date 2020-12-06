using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsClassLibrary
{
    [Serializable]
    public class GenericNotebooks : ProductByUnit
    {
        [JsonConstructor]
        public GenericNotebooks(string name, double overprice, double price, uint count) : base(name, overprice, count, price) { }

        public GenericNotebooks(MobileParameters param, string name, double overprice, double price, uint count) : base(name, overprice, count, price)
        {
            Diagonal = param.diag;
            BatteryPower = param.batt;
            RAM = param.ram;
            InternalStorage = param.internalStor;
            Os = param.os;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nDiag: {Diagonal}, Batt: {BatteryPower}, RAM: {RAM}, Int. storage: {InternalStorage}, OS: {Os}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Diagonal, BatteryPower, RAM, InternalStorage, Os);
        }

        public override bool Equals(object obj)
        {
            var tmp = (obj as GenericNotebooks);
            return (base.Equals(obj) && tmp.RAM == RAM && tmp.Diagonal == Diagonal && tmp.BatteryPower == BatteryPower && tmp.Os == Os && InternalStorage == InternalStorage);
        }

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

        public float Diagonal { get; set; }
        public float BatteryPower { get; set; }
        public float RAM { get; set; }
        public float InternalStorage { get; set; }
        public MobileOs Os { get; set; }
    }
}
