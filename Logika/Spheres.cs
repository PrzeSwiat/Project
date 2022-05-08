
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
                    XPosition += XVelocity / Math.Abs(XVelocity);
                    x++;
                    moved = true;

                }
                if (y < Math.Abs(YVelocity))
                {
                    YPosition += YVelocity / Math.Abs(YVelocity); 
                    y++;
                    moved = true;

                }
                BounceIfOnEdge(width,height);
            }
        }
        private void BounceIfOnEdge(int width, int height)
        {
            if (XPosition <= Radius)           
            {
                XVelocity = Math.Abs(XVelocity);
            }
            if (XPosition >= width - Radius)    
            {
                XVelocity = Math.Abs(XVelocity) * (-1);
            }

            if (YPosition <= Radius)      
            {
                YVelocity = Math.Abs(YVelocity);
            }
            if (YPosition >= height - Radius)  
            {
                YVelocity = Math.Abs(YVelocity) * (-1);
            }
        }
    }
}
