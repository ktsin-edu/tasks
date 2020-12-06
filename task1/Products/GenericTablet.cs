using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsClassLibrary
{
    [Serializable]
    public class GenericTablet : ProductByUnit
    {
        [JsonConstructor]
        public GenericTablet(double overprice, string name, uint count, double price) : base(name, overprice, count, price) { }
        public GenericTablet(MobileParameters param, double overprice, string name, uint count, double price) : base(name, overprice, count, price)
        {
            Diagonal = param.diag;
            BatteryPower = param.batt;
            RAM = param.ram;
            InternalStorage = param.internalStor;
            Os = param.os;
        }

        public static explicit operator GenericNotebooks(GenericTablet a)
        {
            var res = new GenericNotebooks(new MobileParameters()
            {
                batt = a.BatteryPower,
                diag = a.Diagonal,
                internalStor = a.InternalStorage,
                os = a.Os,
                ram = a.RAM
            }, a.ProductName, a.Overprice, a.PurchaseValue, a.Count);
            return res;
        }

        public float Diagonal { get; set; }
        public float BatteryPower { get; set; }
        public float RAM { get; set; }
        public float InternalStorage { get; set; }
        public MobileOs Os { get; set; }
    }



    public class MobileParameters
    {
        public float diag;
        public float batt;
        public float ram;
        public float internalStor;
        public MobileOs os;
    }
}
