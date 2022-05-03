using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logika;
using Dane;
using System;

namespace Testing
{
    [TestClass]
    public class LogicLayerTesting
    {
        private SpheresLogic spheresLogic = new SpheresLogic();

        [TestMethod]
        public void InitializeMethodTest()
        {
            Sphere sphereTest = new Sphere(50, 50, 2);
            Sphere sphere1 = (Sphere)spheresLogic.InitializeSphere();

            Assert.AreEqual(sphere1.GetType(), sphereTest.GetType());
            
            for(int i=0; i<1000; i++)
            {
                Sphere sphere2 = (Sphere)spheresLogic.InitializeSphere();
                Assert.IsTrue(sphere2.PositionX <= 800);
                Assert.IsTrue(sphere2.PositionX >= 100);
                Assert.IsTrue(sphere2.PositionY <= 500);
                Assert.IsTrue(sphere2.PositionY >= 100);
            }
        }

        [TestMethod]
        public void DatasCounterTest()
        {
            spheresLogic.InitializeSphere();
            spheresLogic.InitializeSphere();
            spheresLogic.InitializeSphere();

            Assert.AreEqual(spheresLogic.DatasCounter(), 3);
        }

       
    }
}
