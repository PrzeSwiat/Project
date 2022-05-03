using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
     public abstract class ShapesDataApi
    {
        public abstract Shapes Get(int index);
        public abstract void Add(Shapes shape);
        public abstract void Remove(Shapes shape);
        public abstract int Count();

        public static Sphere CreateSphere(double positionX, double positionY, double radius)
        {
            return new Sphere(positionX, positionY, radius);
        }

        public static ShapesList CreateShapesList()
        {
            return new ShapesList();
        }
        

       
    }
}
