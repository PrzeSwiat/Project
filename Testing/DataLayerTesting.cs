using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dane;

namespace Testing
{
    [TestClass]
    public class DataLayerTesting
    {
        private DataApi shapesDataApi;
        private Sphere sphere1;
        private Sphere sphere2;
        

        [TestMethod]
        public void DataApiTest()
        {

            shapesDataApi = DataApi.CreateShapesList();
            Shapes shapesTest = new Sphere(0,0,50);
            sphere1 = DataApi.CreateSphere(0, 0, 50);
            sphere2 = DataApi.CreateSphere(100, -100, 2);


            shapesDataApi.Add(sphere1);
            Assert.AreEqual(1,shapesDataApi.Count());
            shapesDataApi.Add(sphere2);
            Assert.AreEqual(2,shapesDataApi.Count());

            Assert.AreEqual(sphere2,shapesDataApi.Get(1));
            Assert.AreEqual(sphere1,shapesDataApi.Get(0));

            shapesDataApi.Remove(sphere1);

            Assert.AreEqual(1, shapesDataApi.Count());
            Assert.AreEqual(sphere2, shapesDataApi.Get(0));
            Assert.AreEqual(sphere2.GetType(), shapesTest.GetType());
        }
        

    }
}
