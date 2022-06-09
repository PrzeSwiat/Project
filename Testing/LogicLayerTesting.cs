using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logika;
using System.Collections.Generic;
using System;
using Dane;

namespace Testing
{

    [TestClass]
    public class LogicLayerAPITest
    {
        [TestMethod]
        public void LogicLayerTests()
        {
            DataLayerAbstractAPI dataApi = DataLayerAbstractAPI.CreateAPI();
            LogicLayerAbstractAPI LogicAPI = LogicLayerAbstractAPI.CreateAPI(dataApi);

            LogicAPI.CreateBox(200, 100, 3, 2);

            Assert.AreEqual(3, LogicAPI.GetBalls().Count);

            foreach (BallConnector ball in LogicAPI.GetBalls())
            {
                Assert.AreEqual(2, ball.R);
                Assert.IsTrue(ball.X >= ball.R && ball.X <= (100 - ball.R));
                Assert.IsTrue(ball.Y >= ball.R && ball.Y <= (200 - ball.R));
            }


        }

    }
}
