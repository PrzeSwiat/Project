using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logika;
using System.Collections.Generic;
using System;

namespace Testing
{
    
    [TestClass]
    public class LogicLayerTesting
    {
        

        [TestMethod]
        public void CreateSpheresTest()
        {
            LogicApi api = LogicApi.Initialize(100, 100);

            api.CreateSpheres(10);
            var spheres = api.GetAllSpheres();
            Assert.AreEqual(10, spheres.Count);
        }

        [TestMethod]
        public void SpheresPossitionTest()
        {
            LogicApi api = LogicApi.Initialize(100, 50);

            api.CreateSpheres(10);

            for (int i = 0; i < 1000; i++)
            {
                foreach (var sphere in api.GetAllSpheres())
                {
                    Assert.IsTrue(sphere.XPosition >= 0);
                    Assert.IsTrue(sphere.XPosition <= 100);

                    Assert.IsTrue(sphere.YPosition >= 0);
                    Assert.IsTrue(sphere.YPosition <= 50);
                }

            }

        }



    }
}
