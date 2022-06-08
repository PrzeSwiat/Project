
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dane
{
    public class DataApi : DataAbstractApi
    {
        private double XPos;
        private double YPos;
        private double radius;
        private double VelX;
        private double VelY;
        private double mass;
        private List<DataApi> Apis = new List<DataApi>();

        public object _lock = new object();
        private bool isMoving { get; set; }
        private List<Thread> threads;

        public override List<DataApi> DataApis => Apis;
        public override double XPosition { get => XPos; }
        public override double YPosition { get => YPos; }
        public override double Radius { get => radius; }
        public override double Vx { get => VelX; set => VelX = value; }
        public override double Vy { get => VelY; set => VelY = value; }
        public override double Mass { get => mass; }

        

        public DataApi(double x, double y) 
        {
            XPos = x;
            YPos = y;
            radius = 15;
            mass = 10;

            Random rnd = new Random();
            do
            {
                Vx = rnd.Next(-3, 3);
                Vy = rnd.Next(-3, 3);
            } while (Vx == 0 || Vy == 0);

            Apis.Add(this);
        }


        private void BounceIfOnEdge()
        {
            if (this.XPosition <= this.Radius)
            {
                this.Vx = Math.Abs(this.Vx);
            }
            if (this.XPosition >= 800 - this.Radius)
            {
                this.Vx = Math.Abs(this.Vx) * (-1);
            }

            if (this.YPosition <= this.Radius)
            {
                this.Vy = Math.Abs(this.Vy);
            }
            if (this.YPosition >= 500 - this.Radius)
            {
                this.Vy = Math.Abs(this.Vy) * (-1);
            }
        }

        public void AssignThreads()
        {
            threads = new List<Thread>();

            foreach (DataApi sphere in Apis)
            {
                Thread t = new Thread(() =>
                {
                    while (isMoving)
                    {
                        actualizePos();
                        BounceIfOnEdge();
                        lock (_lock)
                        {
                            //CollisionEvent(sphere);
                        }
                        System.Diagnostics.Debug.WriteLine("Ball =" + sphere.XPosition.ToString() + ", speed=" + sphere.YPosition.ToString());
                        Thread.Sleep(5);
                    }
                });
                threads.Add(t);
            }
        }

        public void ClearThreads()
        {
            isMoving = false;
            threads.Clear();
           
        }

        public override void move()
        {
            AssignThreads();
        }

        private void actualizePos() 
        {
            XPos += Vx;
            YPos += Vy;
        }

        public override List<DataApi> GetAllSpheres()
        {
            return Apis;
        }
    }
}