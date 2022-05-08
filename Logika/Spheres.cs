using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    internal class Spheres : ShapesDataApi.SpheresAPI
    {

        private int XVelocity { get; set; }
        private int YVelocity { get; set; }

        internal Spheres(int xPosition, int yPosition, int radius, int xVelocity, int yVelocity)
        {
            XPosition = xPosition;
            YPosition = yPosition;

            XVelocity = xVelocity;
            YVelocity = yVelocity;

            Radius = radius;
        }

        internal void MoveSphereWithinBox(int width, int height)
        {
            int x = 0, y = 0;
            bool moved = true;
            while (moved)
            {
                moved = false;
                if (x < Math.Abs(XVelocity))
                {
                    XPosition += XVelocity / Math.Abs(XVelocity); // -1 if Vel<0, 1 if Vel>0, Vel=0 while will not happen
                    x++;
                    moved = true;

                }
                if (y < Math.Abs(YVelocity))
                {
                    YPosition += YVelocity / Math.Abs(YVelocity); // -1 if Vel<0, 1 if Vel>0, Vel=0 while will not happen
                    y++;
                    moved = true;

                }
            }
        }
    }
}
