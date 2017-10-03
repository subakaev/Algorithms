using System;
using System.Linq;
using Algorithms.Common.ItemGenerators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Algorithms.Common.Tests
{
    [TestClass]
    public class ArrayGeneratorTests
    {
        [TestMethod]
        public void generate_generics_test() {
            var moq = new Mock<IArrayItemGenerator<IComparable<object>>>();

            moq.Setup(m => m.GenerateNext()).Returns(It.IsAny<IComparable<object>>());

            var arr = ArrayGenerator.Generate(10, moq.Object);

            Assert.AreEqual(10, arr.Length);
        }

        [TestMethod]
        public void generate_int_unique_test() {
            var arr = ArrayGenerator.Generate(3, false, 1, 4);

            Assert.IsTrue(arr.Contains(1));
            Assert.IsTrue(arr.Contains(2));
            Assert.IsTrue(arr.Contains(3));
        }

        [TestMethod]
        public void generate_int_unique_exception_test() {
            Assert.ThrowsException<InvalidOperationException>(() => ArrayGenerator.Generate(3, false, 1, 3));
        }

        [TestMethod]
        public void generate_int_not_unique_test() {
            var arr = ArrayGenerator.Generate(3, true, 1, 1);

            Assert.AreEqual(1, arr[0]);
            Assert.AreEqual(1, arr[1]);
            Assert.AreEqual(1, arr[2]);
        }
    }
}
