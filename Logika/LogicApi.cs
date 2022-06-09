using Dane;
using System.ComponentModel;

namespace Logika
{
    public abstract class LogicLayerAbstractAPI
    {
        public static LogicLayerAbstractAPI CreateAPI(DataLayerAbstractAPI data = default)
        {
            return new LogicLayer(data ?? DataLayerAbstractAPI.CreateAPI());
        }

        public abstract void CreateBox(int height, int width, int numberOfBalls, int radiusOfBalls);
        public abstract void StartMovingBalls();
        public abstract void DestroyThreads();

        public abstract List<BallConnector> GetBalls();

        private List<BallConnector> ballOperators;


        internal class LogicLayer : LogicLayerAbstractAPI
        {
            internal LogicLayer(DataLayerAbstractAPI dataLayerAbstractAPI)
            {
                MyDataLayer = dataLayerAbstractAPI;
            }

            public override void CreateBox(int height, int width, int numberOfBalls, int radiusOfBalls)
            {
                ballOperators = new List<BallConnector>();
                MyDataLayer.CreateBox(height, width, numberOfBalls, radiusOfBalls);

                foreach (Ball ball in MyDataLayer.GetBalls())
                {
                    ballOperators.Add(new BallConnector(ball));
                    ball.PropertyChanged += CheckMovement;
                }

            }

            public void CheckMovement(object sender, PropertyChangedEventArgs e)
            {
                Ball b = (Ball)sender;
                if (e.PropertyName == "Position")
                {
                    UpdateVelocity(b);
                }

            }

            private void UpdateVelocity(Ball ball)
            {
                BounceFromBoundaries(ball, MyDataLayer.GetBox());
                Ball collided = CheckCollisions(ball);
                if (collided != null)
                {
                    double XDiff = ball.X - collided.X;
                    double YDiff = ball.Y - collided.Y;

                    if (XDiff * (collided.XStep - ball.XStep) + YDiff * (collided.YStep - ball.YStep) > 0)
                    {
                        double V1X = ball.XStep;
                        double V1Y = ball.YStep;

                        double tmp = 2 * (XDiff * (V1X - collided.XStep) +
                                          YDiff * (V1Y - collided.YStep)) /
                                         (XDiff * XDiff + YDiff * YDiff) /
                                         (ball.M + collided.M);

                        ball.XStep -= collided.M * XDiff * tmp;
                        ball.YStep -= collided.M * YDiff * tmp;

                        collided.XStep += ball.M * XDiff * tmp;
                        collided.YStep += ball.M * YDiff * tmp;
                    }

                }

            }

            private void BounceFromBoundaries(Ball ball, Box box)
            {
                if (!(ball.X >= ball.R && ball.X <= box.Width - ball.R))
                {
                    if (ball.XStep > 0)
                        ball.X = box.Width - ball.R;
                    else
                        ball.X = ball.R;

                    ball.XStep *= -1;
                }


                if (!(ball.Y >= ball.R && ball.Y <= box.Height - ball.R))
                {
                    if (ball.YStep > 0)
                        ball.Y = box.Height - ball.R;
                    else
                        ball.Y = ball.R;

                    ball.YStep *= -1;
                }
            }

            private Ball CheckCollisions(Ball ball)
            {
                foreach (Ball other in MyDataLayer.GetBalls())
                {
                    if (other == ball)
                        continue;

                    double distance = Math.Sqrt((ball.X - other.X) * (ball.X - other.X) +
                                                (ball.Y - other.Y) * (ball.Y - other.Y));

                    if (distance <= ball.R + other.R)
                        return other;
                }

                return null;

            }


            public override void StartMovingBalls()
            {
                MyDataLayer.StartMovingBalls();
            }

            public override void DestroyThreads()
            {
                MyDataLayer.StopMovingBalls();
            }

            public override List<BallConnector> GetBalls()
            {
                return ballOperators;
            }

            private readonly DataLayerAbstractAPI MyDataLayer;
        }




    }


}

