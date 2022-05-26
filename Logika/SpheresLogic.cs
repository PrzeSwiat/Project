
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


        public override void BounceIfOnEdge(DataAbstractApi sphere)
        {
            if (sphere.XPosition <= sphere.Radius)    
            {
                sphere.Vx = Math.Abs(sphere.Vx);
            }
            if (sphere.XPosition >= _windowWidth - sphere.Radius)   
            {
                sphere.Vx = Math.Abs(sphere.Vx) * (-1);
            }

            if (sphere.YPosition <= sphere.Radius)         
            {
                sphere.Vy = Math.Abs(sphere.Vy);
            }
            if (sphere.YPosition >= _windowHeight - sphere.Radius)   
            {
                sphere.Vy = Math.Abs(sphere.Vy) * (-1);
            }
        }

        public override List<IAbstractSphere> GetAllSpheres()
        {
            List<IAbstractSphere> list = new();
            foreach (DataAbstractApi sphere in _SphereStorage)
            {
                list.Add(new AbstractSphere(sphere.XPosition, sphere.YPosition));
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
        public void AssignThreads()
        {
            threads = new List<Thread>();

            foreach (DataAbstractApi sphere in _SphereStorage)
            {
                Thread t = new Thread(() =>
                {
                    while (isMoving)
                    {
                        sphere.move();
                        BounceIfOnEdge(sphere);
                        lock (_lock)
                        {
                            CollisionEvent(sphere);
                        }
                        System.Diagnostics.Debug.WriteLine("Ball =" + sphere.XPosition.ToString() + ", speed=" + sphere.YPosition.ToString());
                        Thread.Sleep(5);
                    }
                });
                threads.Add(t);
            }
        }
        public override void SummonSpheres(int amount)
        {
            CreateSpheres(amount);
            AssignThreads();

            if (!isMoving)
            {
                isMoving = true;
                foreach (Thread t in threads)
                {
                    t.Start();
                }
            }
        }

        public override void ClearThreads()
        {
            isMoving = false;
            threads.Clear();
        }
    }
}
