using System;
using Shopping_Basket;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Assert
            Assert.AreEqual(expected, actual, 2.50, "Item not added correctly");
        }
    }
}
