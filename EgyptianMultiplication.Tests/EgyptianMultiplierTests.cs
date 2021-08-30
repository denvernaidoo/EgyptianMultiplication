using EgyptianMultiplication.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace EgyptianMultiplication.Tests
{
    [TestClass]
    public class EgyptianMultiplierTests
    {
        private EgyptianMultiplier _egyptianMultiplier;

        [TestInitialize]
        public void TestInitialize()
        {
            _egyptianMultiplier = new EgyptianMultiplier();
        }

        [TestMethod]
        public void Multiply_TwoPositiveIntegers_ReturnsProduct()
        {
            var product = _egyptianMultiplier.Multiply(21, 10);
            Assert.AreEqual(210, product, "Failed to multiply 2 positive integers correctly.");
        }

        [TestMethod]
        public void Multiply_NegativeFactorA_ExceptionThrown()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _egyptianMultiplier.Multiply(-13, 12), "Failed to guard against negative factor A");
        }

        [TestMethod]
        public void Multiply_NegativeFactorB_ExceptionThrown()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _egyptianMultiplier.Multiply(13, -12), "Failed to guard against negative factor B.");
        }

        [TestMethod]
        public void Multiply_BothNegativeFactors_ExceptionThrown()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _egyptianMultiplier.Multiply(-13, -12), "Failed to guard against both negative factors.");
        }

        [TestMethod]
        public void Multiply_ZeroFactorA_ReturnsProduct()
        {
            var product = _egyptianMultiplier.Multiply(0, 20);
            Assert.AreEqual(0, product, "Failed to multiply zero and a non zero positive factor.");
        }

        [TestMethod]
        public void Multiply_ZeroFactorB_ReturnsProduct()
        {
            var product = _egyptianMultiplier.Multiply(30, 0);
            Assert.AreEqual(0, product, "Failed to multiply non zero factor and a zero.");
        }

        [TestMethod]
        public void Multiply_BothZeroFactors_ReturnsProduct()
        {
            var product = _egyptianMultiplier.Multiply(0, 0);
            Assert.AreEqual(0, product, "Failed to multiply factors where both are 0.");
        }
    }
}
