using System;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Algorithms.Sort.Tests
{
    [TestClass]
    public class BruteForceTests
    {
        private readonly int[] intUniqueArray = { 2, 3, 1, 5, 4 };
        private readonly int[] intArray = { 2, 2, 1, 4, 3, 3 };

        private BruteForceSort<int> intSort;
        private BruteForceSort<IComparable<object>> objSort;

        private readonly MoqUniqueArray moqUniqueArray = new MoqUniqueArray();

        private readonly MoqArray moqArray = new MoqArray();

        private class MoqUniqueArray
        {
            public readonly Mock<IComparable<object>> Moq1;
            public readonly Mock<IComparable<object>> Moq2;
            public readonly Mock<IComparable<object>> Moq3;

            public IComparable<object>[] Array => new[] { Moq1.Object, Moq2.Object, Moq3.Object };

            public MoqUniqueArray() {
                Moq1 = new Mock<IComparable<object>>(); // 2
                Moq2 = new Mock<IComparable<object>>(); // 3
                Moq3 = new Mock<IComparable<object>>(); // 1

                Moq1.Setup(m => m.CompareTo(Moq2.Object)).Returns(-1);
                Moq1.Setup(m => m.CompareTo(Moq3.Object)).Returns(1);

                Moq2.Setup(m => m.CompareTo(Moq1.Object)).Returns(1);
                Moq2.Setup(m => m.CompareTo(Moq3.Object)).Returns(1);

                Moq3.Setup(m => m.CompareTo(Moq1.Object)).Returns(-1);
                Moq3.Setup(m => m.CompareTo(Moq2.Object)).Returns(-1);
            }
        }

        private class MoqArray
        {
            public readonly Mock<IComparable<object>> Moq1;
            public readonly Mock<IComparable<object>> Moq2;
            public readonly Mock<IComparable<object>> Moq3;

            public IComparable<object>[] Array => new[] { Moq1.Object, Moq2.Object, Moq3.Object };

            public MoqArray() {
                Moq1 = new Mock<IComparable<object>>(); // 2
                Moq2 = new Mock<IComparable<object>>(); // 2
                Moq3 = new Mock<IComparable<object>>(); // 1

                Moq1.Setup(m => m.CompareTo(Moq2.Object)).Returns(0);
                Moq1.Setup(m => m.CompareTo(Moq3.Object)).Returns(1);

                Moq2.Setup(m => m.CompareTo(Moq1.Object)).Returns(0);
                Moq2.Setup(m => m.CompareTo(Moq3.Object)).Returns(1);

                Moq3.Setup(m => m.CompareTo(Moq1.Object)).Returns(-1);
                Moq3.Setup(m => m.CompareTo(Moq2.Object)).Returns(-1);
            }
        }

        [TestInitialize]
        public void Setup() {
            intSort = new BruteForceSort<int>();
            objSort = new BruteForceSort<IComparable<object>>();
        }

        [TestMethod]
        public void only_unique_int_array_values_ascending_test() {
            var result = intSort.Sort(intUniqueArray, ListSortDirection.Ascending);

            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(2, result[1]);
            Assert.AreEqual(3, result[2]);
            Assert.AreEqual(4, result[3]);
            Assert.AreEqual(5, result[4]);
        }

        [TestMethod]
        public void only_unique_int_array_values_descending_test() {
            var result = intSort.Sort(intUniqueArray, ListSortDirection.Descending);

            Assert.AreEqual(5, result[0]);
            Assert.AreEqual(4, result[1]);
            Assert.AreEqual(3, result[2]);
            Assert.AreEqual(2, result[3]);
            Assert.AreEqual(1, result[4]);
        }

        [TestMethod]
        public void int_array_values_ascending_test() {
            var result = intSort.Sort(intArray, ListSortDirection.Ascending);

            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(2, result[1]);
            Assert.AreEqual(2, result[2]);
            Assert.AreEqual(3, result[3]);
            Assert.AreEqual(3, result[4]);
            Assert.AreEqual(4, result[5]);
        }

        [TestMethod]
        public void int_array_values_descending_test() {
            var result = intSort.Sort(intArray, ListSortDirection.Descending);

            Assert.AreEqual(4, result[0]);
            Assert.AreEqual(3, result[1]);
            Assert.AreEqual(3, result[2]);
            Assert.AreEqual(2, result[3]);
            Assert.AreEqual(2, result[4]);
            Assert.AreEqual(1, result[5]);
        }

        [TestMethod]
        public void only_unique_moq_array_values_ascending_test() {
            var result = objSort.Sort(moqUniqueArray.Array, ListSortDirection.Ascending);

            Assert.AreEqual(moqUniqueArray.Moq1.Object, result[1]);
            Assert.AreEqual(moqUniqueArray.Moq2.Object, result[2]);
            Assert.AreEqual(moqUniqueArray.Moq3.Object, result[0]);
        }

        [TestMethod]
        public void only_unique_moq_array_values_descending_test() {
            var result = objSort.Sort(moqUniqueArray.Array, ListSortDirection.Descending);

            Assert.AreEqual(moqUniqueArray.Moq1.Object, result[1]);
            Assert.AreEqual(moqUniqueArray.Moq2.Object, result[0]);
            Assert.AreEqual(moqUniqueArray.Moq3.Object, result[2]);
        }

        [TestMethod]
        public void only_moq_array_values_ascending_test() {
            var result = objSort.Sort(moqArray.Array, ListSortDirection.Ascending);

            Assert.IsTrue(moqArray.Moq1.Object == result[2]);
            Assert.IsTrue(moqArray.Moq2.Object == result[1]);
            Assert.AreEqual(moqArray.Moq3.Object, result[0]);
        }

        [TestMethod]
        public void only_moq_array_values_descending_test() {
            var result = objSort.Sort(moqArray.Array, ListSortDirection.Descending);

            Assert.AreEqual(moqArray.Moq1.Object, result[0]);
            Assert.AreEqual(moqArray.Moq2.Object, result[1]);
            Assert.AreEqual(moqArray.Moq3.Object, result[2]);
        }

        [TestMethod]
        public void only_one_array_item_ascending_test() {
            var result = objSort.Sort(new[] { moqArray.Moq1.Object }, ListSortDirection.Ascending);

            Assert.AreEqual(moqArray.Moq1.Object, result[0]);
        }

        [TestMethod]
        public void only_one_array_item_descending_test() {
            var result = objSort.Sort(new[] { moqArray.Moq1.Object }, ListSortDirection.Descending);

            Assert.AreEqual(moqArray.Moq1.Object, result[0]);
        }
        
        [TestMethod]
        public void only_two_array_item_ascending_test() {
            var result = objSort.Sort(new[] { moqUniqueArray.Moq1.Object, moqUniqueArray.Moq2.Object }, ListSortDirection.Ascending);

            Assert.AreEqual(moqUniqueArray.Moq1.Object, result[0]);
            Assert.AreEqual(moqUniqueArray.Moq2.Object, result[1]);
        }

        [TestMethod]
        public void only_two_array_item_descending_test() {
            var result = objSort.Sort(new[] { moqUniqueArray.Moq1.Object, moqUniqueArray.Moq2.Object }, ListSortDirection.Descending);

            Assert.AreEqual(moqUniqueArray.Moq1.Object, result[1]);
            Assert.AreEqual(moqUniqueArray.Moq2.Object, result[0]);
        }
    }
}