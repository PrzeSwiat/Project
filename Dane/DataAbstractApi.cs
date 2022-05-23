using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public abstract class DataAbstractApi
    {
        public static DataAbstractApi getSphere(double x, double y) 
        {
            return new DataApi(x, y);
        }

        public double XPosition { get; set; }
        public double YPosition { get; set; }
        public double Radius { get; set; }

        public double Vx { get; set; }
        public double Vy { get; set; }

        public double Mass { get; set; }

        public abstract void move();

        public abstract event PropertyChangedEventHandler? PropertyChanged;



    }
}
