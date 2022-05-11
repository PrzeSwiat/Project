using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public abstract class DataAbstractApi
    {
        public abstract double getX();
        public abstract double getY();
        public abstract void setX(double x);
        public abstract void setY(double y);
        public static DataAbstractApi CreateSphereData() 
        {
            return new DataApi();
        }
        
    }
}
