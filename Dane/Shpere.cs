using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    internal class Shpere
    {
        private double Radius { get; set; }
        private double PositionX { get; set; }
        private double PositionY { get; set; }
        private double SpeedX { get; set; }
        private double SpeedY { get; set; }

        public Shpere(double positionX, double positionY, double speedX, double speedY, double radius)
        {
            PositionX = positionX;
            PositionY = positionY;
            SpeedX = speedX;
            SpeedY = speedY;
            Radius = radius;
        }

        public void Move(double milliseconds)
        {
            PositionX += SpeedX * milliseconds;
            PositionY += SpeedY * milliseconds;
        }

    }

    

}
