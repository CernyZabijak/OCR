using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace WinFormsApp1
{
    public class Field
    {
        public int Size;
        public int Cost;
        public int CostPerMeter;
        public string Owner = "";
        public double pH;

        public Field(int size, int cost, double pH, string location) //full cost
        {
            this.Size = size;
            this.Cost = cost;
            this.Owner = location;
            this.pH = pH;
        }
        public Field(string location, int size, int costPerMenter, double pH)//cost per meter
        {
            this.Size = size;
            this.Owner = location;
            this.CostPerMeter = costPerMenter;
            this.pH = pH;
        }
       
    }
}
