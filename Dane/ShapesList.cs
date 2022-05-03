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

        public override void Remove(Shapes shape)
        {
            Shapes.Remove(shape);
        }
    }
}
