using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logika;
using System.Collections.Generic;

namespace Testing
{
    
    [TestClass]
    public class LogicLayerTesting
    {
        

        [TestMethod]
        public void CreateSpheresTest()
        {
            ShapesDataApi api = ShapesDataApi.Initialize(100, 100);

            api.CreateSpheres(10);
            List<ShapesDataApi.SpheresAPI> spheres = api.GetAllSpheres();
            Assert.AreEqual(10, spheres.Count);
        }

        [TestMethod]
        public void CorrectSpheresPositionTest()
        {
            ShapesDataApi api = ShapesDataApi.Initialize(100, 60);

            api.CreateSpheres(1000);

            foreach (ShapesDataApi.SpheresAPI sphere in api.GetAllSpheres())
            {
                Assert.AreEqual(60 / 30, sphere.Radius);

                Assert.IsTrue(sphere.XPosition >= sphere.Radius);
                Assert.IsTrue(sphere.XPosition <= 100 - sphere.Radius);

                Assert.IsTrue(sphere.YPosition >= sphere.Radius);
                Assert.IsTrue(sphere.YPosition <= 60 - sphere.Radius);
            }
        }

        [TestMethod]
        public void SphereMoveTest()
        {
            ShapesDataApi api = ShapesDataApi.Initialize(100, 100);

            api.CreateSpheres(1000);
            List<ShapesDataApi.SpheresAPI> spheres = api.GetAllSpheres();

            int[] startingXs = new int[10];
            int[] startingYs = new int[10];
            for (int i = 0; i < startingXs.Length; i++)
            {
                startingXs[i] = spheres[i].XPosition;
                startingYs[i] = spheres[i].YPosition;
            }
            api.TickSpheres();
            for (int i = 0; i < startingXs.Length; i++)
            {
                Assert.AreNotEqual(startingXs[i], spheres[i].XPosition);
                Assert.AreNotEqual(startingYs[i], spheres[i].YPosition);
            }
        }

        [TestMethod]
        public void SpheresTickPossitionTest()
        {
            ShapesDataApi api = ShapesDataApi.Initialize(100, 50);

            api.CreateSpheres(10);

            for (int i = 0; i < 1000; i++)
            {
                foreach (ShapesDataApi.SpheresAPI sphere in api.GetAllSpheres())
                {
                    Assert.IsTrue(sphere.XPosition >= 0);
                    Assert.IsTrue(sphere.XPosition <= 100);

                    Assert.IsTrue(sphere.YPosition >= 0);
                    Assert.IsTrue(sphere.YPosition <= 50);
                }
                api.TickSpheres();

            }

        }


    }
}
