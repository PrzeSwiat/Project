using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dane;
using System.Collections.Generic;

namespace Testing
{
    [TestClass]
    public class BallTest
    {
        [TestMethod]
        public void BallTests()
        {
            Ball ball = new Ball(1, 2, 3, 5, 0);

            Assert.AreEqual(ball.X, 1);
            Assert.AreEqual(ball.Y, 2);
            Assert.AreEqual(ball.R, 3);
            Assert.AreEqual(ball.M, 5);

            ball.X = 10;
            ball.Y = 20;
            ball.R = 30;
            ball.M = 10;

            Assert.AreEqual(ball.X, 10);
            Assert.AreEqual(ball.Y, 20);
            Assert.AreEqual(ball.R, 30);
            Assert.AreEqual(ball.M, 10);

            Assert.ThrowsException<System.ArgumentException>(() => ball.R = -10);

            ball.Move();

            Assert.IsTrue(ball.X == 10 + ball.XStep);
            Assert.IsTrue(ball.Y == 20 + ball.YStep);

        }

        [TestMethod]
        public void ConstructorAndPropertiesTest()
        {
            Box box = new Box(100, 200);
            Ball ball = new Ball(100, 200, 10, 10, 0);

            Assert.AreEqual(100, box.Height);
            Assert.AreEqual(200, box.Width);
            Assert.AreEqual(0, box.GetBalls().Count);
            Assert.ThrowsException<System.ArgumentException>(() => new Box(-100, 200));
            Assert.ThrowsException<System.ArgumentException>(() => new Box(100, -200));

            box.AddBall(ball);

            Assert.AreEqual(1, box.GetBalls().Count);



        }

        [TestMethod]
        public void DataLayerTests()
        {
            DataLayerAbstractAPI layer = DataLayerAbstractAPI.CreateAPI();

            layer.CreateBox(1000, 2000, 2, 2);

            Box box = layer.GetBox();
            List<Ball> balls = box.GetBalls();

            Assert.AreEqual(box.Height, 1000);
            Assert.AreEqual(box.Width, 2000);
            Assert.AreEqual(balls.Count, 2);

            foreach (Ball ball in balls)
            {
                Assert.AreEqual(ball.R, 2);
            }

            if (layer.CanCreateBallHere(500, 500, 2))
            {
                layer.AddBall(500, 500, 1, 2, 0);
                Assert.AreEqual(balls.Count, 3);
                Assert.IsTrue(!layer.CanCreateBallHere(500, 500, 2));
            }
            else
            {
                Assert.AreEqual(balls.Count, 2);
            }



        }
    }
}
