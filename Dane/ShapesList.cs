using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class ShapesList : ShapesDataApi
    {
        private List<Shapes> Shapes;

        public ShapesList()
        {
           this.Shapes = new List<Shapes>();
        }

        public override void Add(Shapes shape)
        {
            Shapes.Add(shape);
        }

        public override int Count()
        {
          return Shapes.Count();
        }

        public override Shapes Get(int index)
        {
            return Shapes[index];
        }

        public override double GetRad(int index)
        {
            Sphere shape = (Sphere)Shapes[index];
            return shape.Radius;
            
        }

        public override double GetX(int index)
        {
            Sphere shape = (Sphere)Shapes[index];
            return shape.PositionX;
        }

        public override double GetY(int index)
        {
            Sphere shape = (Sphere)Shapes[index];
            return shape.PositionY;
        }

        public override void Remove(Shapes shape)
        {
            Shapes.Remove(shape);
        }
    }
}
