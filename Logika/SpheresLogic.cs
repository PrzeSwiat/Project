using Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public class SpheresLogic
    {
        private ShapesDataApi shapesDataApi;
        private Shapes shape;

        public Shapes InitializeSphere()
        {
            Random rnd = new Random();
            double rndX = rnd.Next(100, 800);
            double rndY = rnd.Next(100, 500);
            double rndR = rnd.Next(20, 50);

            shapesDataApi = ShapesDataApi.CreateShapesList();
            shape = ShapesDataApi.CreateSphere(rndX,rndY,rndR);
            shapesDataApi.Add(shape);

            return shape;
        }

    }
}
