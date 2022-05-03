using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class ShapesList : ShapesDataApi
    {
        private List<Shapes> shapes;

        public ShapesList()
        {
           this.shapes = new List<Shapes>();
        }

        public override void Add(Shapes shape)
        {
            shapes.Add(shape);
        }

        public override int Count()
        {
          return shapes.Count();
        }

        public override Shapes Get(int index)
        {
            return shapes[index];
        }

        public override void Remove(Shapes shape)
        {
            shapes.Remove(shape);
        }
    }
}
