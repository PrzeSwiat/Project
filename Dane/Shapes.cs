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
    public class Sphere : Shapes
    {
        private double Radius { get; set; }
        public double PositionX { get; set; }
        public double PositionY { get; set; }
        private double VectorX { get; set; }
        private double VectorY { get; set; }

        public Sphere(double positionX, double positionY, double radius)
        {
            this.Radius = radius;
            this.PositionX = positionX;
            this.PositionY = positionY;
        }

        public void Move(double vectorX, double vectorY)
        {
            this.VectorX = vectorX;
            this.VectorY = vectorY;
            PositionX += VectorX;
            PositionY += VectorY;
        }

    }

    

}
