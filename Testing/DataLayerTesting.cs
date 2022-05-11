using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dane;

namespace Testing
{
    [TestClass]
    public class DataLayerTesting
    {
        [TestMethod]
        public void CreateSphereDataTest()
        {
            DataAbstractApi api;
            api = DataAbstractApi.CreateSphereData();
            Assert.IsNotNull(api);
        }

        [TestMethod]
        public void SetterGetterTest() 
        {
            DataAbstractApi api;
            api = DataAbstractApi.CreateSphereData();
            api.setX(3);
            api.setY(4);

            Assert.AreEqual(api.getX(), 3);
            Assert.AreEqual(api.getY(), 4);
            api.setX(4);
            api.setY(3);
            Assert.AreEqual(api.getX(), 4);
            Assert.AreEqual(api.getY(), 3);
        }
    }
}
