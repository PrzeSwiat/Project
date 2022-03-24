using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt;
namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        Class1 class1 = new Class1();

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(class1.add(2, 3), 5);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(class1.subtract(1,19), -18);
        }
        [TestMethod]
        public void TestMethodpow()
        {
            Assert.AreEqual(class1.pow(2,3),8);
        }
    }
}