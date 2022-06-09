using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public abstract class DataLayerAbstractAPI
    {
        public static DataLayerAbstractAPI CreateAPI()
        {
            return new DataLayer();
        }

        public abstract void CreateBox(int height, int width, int numberOfBalls, int radiusOfBalls);
        public abstract void AddBall(double x, double y, double radius, double mass, int id);
        public abstract void StartMovingBalls();
        public abstract void StopMovingBalls();
        public abstract bool CanCreateBallHere(double x, double y, double radius);
        public abstract Box GetBox();
        public abstract List<Ball> GetBalls();



        internal class DataLayer : DataLayerAbstractAPI
        {
            private Box box;
            private List<Thread> threads;
            private bool _moving = false;
            private object _lock = new object();
            Logger logger;

            public DataLayer()
            {

            }

            public override void CreateBox(int height, int width, int numberOfBalls, int radiusOfBalls)
            {
                box = new Box(height, width);
                threads = new List<Thread>();

                Random r = new Random();

                for (int i = 0; i < numberOfBalls; i++)
                {
                    double x;
                    double y;
                    double mass = 5;
                    do
                    {
                        x = r.NextDouble() * (width - 2 - 2 * radiusOfBalls) + radiusOfBalls + 1;
                        y = r.NextDouble() * (height - 2 - 2 * radiusOfBalls) + radiusOfBalls + 1;

                    } while (!CanCreateBallHere(x, y, radiusOfBalls));

                    AddBall(x, y, radiusOfBalls, mass, i);

                }

            }

            public override void AddBall(double x, double y, double radius, double mass, int id)
            {
                if (box == null)
                {
                    throw new Exception();
                }

                Ball ball = new Ball(x, y, radius, mass, id);
                box.AddBall(ball);

                Thread t = new Thread(() =>
                {

                    while (_moving)
                    {

                        lock (_lock)
                        {
                            ball.Move();
                        }

                        Thread.Sleep(1);
                    }

                });
                t.IsBackground = true;

                threads.Add(t);

            }


            public override void StartMovingBalls()
            {
                _moving = true;
                foreach (Thread t in threads)
                {
                    t.Start();
                }

                logger = new Logger(GetBalls());



            }

            public override void StopMovingBalls()
            {
                _moving = false;
                if (logger != null)
                {
                    logger.StopLogging();
                }
            }

            public override Box GetBox()
            {
                return box;
            }

            public override List<Ball> GetBalls()
            {
                return box.GetBalls();
            }

            public override bool CanCreateBallHere(double x, double y, double radius)
            {
                foreach (Ball other in GetBalls())
                {
                    double distance = Math.Sqrt((x - other.X) * (x - other.X) + (y - other.Y) * (y - other.Y));
                    if (distance <= radius + other.R + 1)
                        return false;
                }
                return true;
            }


        }

    }
}
