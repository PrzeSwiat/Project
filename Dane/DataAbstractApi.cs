using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public abstract List<DataApi> DataApis { get; }
        public abstract double XPosition { get; }
        public abstract double YPosition { get; }
        public abstract double Radius { get; }
        public abstract double Mass { get; }
        public abstract double Vx { get; set; }
        public abstract double Vy { get; set; }

        public abstract void move();

        public abstract List<DataApi> GetAllSpheres();

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }



    }
}
