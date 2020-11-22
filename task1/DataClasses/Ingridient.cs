using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.DataClasses
{
    public class Ingridient
    {
        public Ingridient(string name, double price, double caloricity, double weight)
        {
            this.name = name;
            this.price = price;
            this.caloricity = caloricity;
            this.weight = weight;
        }
        public string name;
        public double price;
        public double caloricity;
        public double weight;
    }
}
