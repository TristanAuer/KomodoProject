using KomodoPOCO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoProjectTests
{
    [TestClass]
    public class DevListTest
    {
        [TestMethod]
        public void SetDeveloper_ShouldSetInt()
        {
            DeveloperPOCO developer = new DeveloperPOCO();

            developer.DeveloperId = 8675309;

            int expected = 8675309;
            int actual = developer.DeveloperId;

            Assert.AreEqual(expected, actual);
        }

    }
}
