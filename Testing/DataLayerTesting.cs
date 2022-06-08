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
            api = DataAbstractApi.getSphere(3,4);
            Assert.IsNotNull(api);
            Assert.IsTrue(api.XPosition==3);
            Assert.IsTrue(api.YPosition==4);
        }

      
    }
}
