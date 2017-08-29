using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleProject.Controllers;

namespace SampleProjectTest
{
    [TestClass]
    public class ParcelCalculation
    {
        [TestMethod]
        public void GetRule()
        {
            var controller = new ParcelCalculationController();
            var getrule = controller.GetRule(10, 10);
            Assert.AreEqual("Small", getrule);
        }

        [TestMethod]
        public void GetCost()
        {
            var controller = new ParcelCalculationController();
            var getcost = controller.GetCost(10, 10, "Small");
            Assert.AreEqual("40", getcost);
        }
    }
}
