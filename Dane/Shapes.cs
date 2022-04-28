using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public abstract class Shapes
    {
        private double PositionX { get; set; }
        private double PositionY { get; set; }
        private double VectorX { get; set; }
        private double VectorY { get; set; }
    }
    internal class Sphere : Shapes
    {
        private double Radius { get; set; }
        private double PositionX { get; set; }
        private double PositionY { get; set; }
        private double VectorX { get; set; }
        private double VectorY { get; set; }

        public Sphere(double positionX, double positionY, double radius)
        {
            Radius = radius;
            PositionX = positionX;
            PositionY = positionY;
            
        }

        public void Move(double vectorX, double vectorY)
        {
            VectorX = vectorX;
            VectorY = vectorY;
            PositionX += VectorX;
            PositionY += VectorY;
        }



    }

    

}
