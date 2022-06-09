
using Dane;

namespace Logika
{
    internal class SpheresLogic : LogicApi
    {
        internal readonly int _Radius = 15;
        internal readonly List<DataAbstractApi> _SphereStorage = new();

        internal readonly int _windowWidth;
        internal readonly int _windowHeight;

        public SpheresLogic(int windowWidth, int windowHeight)
        {
            _windowHeight = windowHeight;
            _windowWidth = windowWidth;
        }


        override public void CreateSpheres(int amount)
        {
            Random rnd = new Random();
            for (int i = 0; i < amount; i++)
            {
                int xPos = rnd.Next(_Radius, _windowWidth - _Radius);
                int yPos = rnd.Next(_Radius, _windowHeight - _Radius);
                _SphereStorage.Add(DataAbstractApi.getSphere(xPos, yPos));
            }
        }


        public override List<DataAbstractApi> GetAllSpheres()
        {
            List<DataAbstractApi> list = new();
            foreach (DataAbstractApi sphere in _SphereStorage)
            {
                list.Add(sphere);
            }
            return list;
        }

        private DataAbstractApi? FindCollidingSphere(DataAbstractApi sphere)
        {
            foreach (DataAbstractApi other in _SphereStorage)
            {
                if (other == sphere)
                    continue;
                double distance = Math.Sqrt(Math.Pow((sphere.XPosition + sphere.Vx - other.XPosition + other.Vx), 2) +
                                            Math.Pow((sphere.YPosition + sphere.Vy - other.YPosition + other.Vy), 2));
                if (distance <= sphere.Radius + other.Radius)
                    return other;
            }
            return null;
        }

        private void CollisionEvent(DataAbstractApi sphere)
        {
            DataAbstractApi? collided = FindCollidingSphere(sphere);
            if (collided != null)
            {
                double newX1, newX2, newY1, newY2;

                newX1 = (sphere.Vx * (sphere.Mass - collided.Mass) / (sphere.Mass + collided.Mass)
                        + (2 * collided.Mass * collided.Vx) / (sphere.Mass + collided.Mass));

                newY1 = (sphere.Vy * (sphere.Mass - collided.Mass) / (sphere.Mass + collided.Mass) 
                        + (2 * collided.Mass * collided.Vy) / (sphere.Mass + collided.Mass));

                newX2 = (collided.Vx * (collided.Mass - sphere.Mass) / (sphere.Mass + collided.Mass) 
                        + (2 * sphere.Mass * sphere.Vx) / (sphere.Mass + collided.Mass));

                newY2 = (collided.Vy * (collided.Mass - sphere.Mass) / (sphere.Mass + collided.Mass) 
                        + (2 * sphere.Mass * sphere.Vy) / (sphere.Mass + collided.Mass));

                sphere.Vx = (int)newX1;
                sphere.Vy = (int)newY1;
                collided.Vx = (int)newX2;
                collided.Vy = (int)newY2;
            }
        }
       
        public override void SummonSpheres(int amount)
        {
            CreateSpheres(amount);

            // zastąp to zaraz
            foreach (DataApi sphere in _SphereStorage) 
            {
                sphere.move();
            }

            
            //????
        }

        public override void ClearThreads()
        {
           foreach (DataApi sphere in _SphereStorage)
            {
                sphere.ClearThreads();
            }
        }
    }
}
