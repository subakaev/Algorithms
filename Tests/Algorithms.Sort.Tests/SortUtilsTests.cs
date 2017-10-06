using System;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Algorithms.Sort.Tests
{
    [TestClass]
    public class SortUtilsTests
    {
        private Mock<IComparable> moq1;
        private Mock<IComparable> moq2;
        private Mock<IComparable> moq3;
        private Mock<IComparable> moq4;

        private IComparable[] ascendingArray;
        private IComparable[] descendingArray;

        [TestInitialize]
        public void Setup() {
            moq1 = new Mock<IComparable>();
            moq2 = new Mock<IComparable>();
            moq3 = new Mock<IComparable>();
            moq4 = new Mock<IComparable>();

            moq1.Setup(m => m.CompareTo(moq1.Object)).Returns(0);
            moq1.Setup(m => m.CompareTo(moq2.Object)).Returns(-1);
            moq1.Setup(m => m.CompareTo(moq3.Object)).Returns(-1);
            moq1.Setup(m => m.CompareTo(moq4.Object)).Returns(-1);

            moq2.Setup(m => m.CompareTo(moq1.Object)).Returns(1);
            moq2.Setup(m => m.CompareTo(moq3.Object)).Returns(0);
            moq2.Setup(m => m.CompareTo(moq4.Object)).Returns(-1);

            moq3.Setup(m => m.CompareTo(moq1.Object)).Returns(1);
            moq3.Setup(m => m.CompareTo(moq2.Object)).Returns(0);
            moq3.Setup(m => m.CompareTo(moq4.Object)).Returns(-1);

            moq4.Setup(m => m.CompareTo(moq1.Object)).Returns(1);
            moq4.Setup(m => m.CompareTo(moq2.Object)).Returns(1);
            moq4.Setup(m => m.CompareTo(moq3.Object)).Returns(1);

            ascendingArray = new[] { moq1.Object, moq2.Object, moq3.Object, moq4.Object };
            descendingArray = new[] { moq4.Object, moq3.Object, moq2.Object, moq1.Object };
        }

        [TestMethod]
        public void is_sorted_ascending_test()
        {
            Assert.IsTrue(SortUtils.IsSorted(ascendingArray, ListSortDirection.Ascending));

            var otherArray = new[] { moq1.Object, moq3.Object, moq2.Object, moq4.Object };

            Assert.IsTrue(SortUtils.IsSorted(otherArray, ListSortDirection.Ascending));
        }

        [TestMethod]
        public void is_not_sorted_ascending_test() {
            Assert.IsFalse(SortUtils.IsSorted(descendingArray, ListSortDirection.Ascending));
        }

        [TestMethod]
        public void is_sorted_descending_test() {
            Assert.IsTrue(SortUtils.IsSorted(descendingArray, ListSortDirection.Descending));

            var otherArray = new[] { moq4.Object, moq2.Object, moq3.Object, moq1.Object };

            Assert.IsTrue(SortUtils.IsSorted(otherArray, ListSortDirection.Descending));
        }

        [TestMethod]
        public void is_not_sorted_descending_test() {
            Assert.IsFalse(SortUtils.IsSorted(ascendingArray, ListSortDirection.Descending));
        }

        [TestMethod]
        public void is_sorted_if_not_array_elements() {
            var empty = new IComparable[] { };

            Assert.IsTrue(SortUtils.IsSorted(empty, ListSortDirection.Ascending));
            Assert.IsTrue(SortUtils.IsSorted(empty, ListSortDirection.Descending));
        }

        [TestMethod]
        public void is_sorted_if_one_array_element() {
            var one = new[] { moq2.Object };

            Assert.IsTrue(SortUtils.IsSorted(one, ListSortDirection.Ascending));
            Assert.IsTrue(SortUtils.IsSorted(one, ListSortDirection.Descending));
        }

        [TestMethod]
        public void is_sorted_if_all_same_elements() {
            var arr = new[] { moq1.Object, moq1.Object, moq1.Object };

            Assert.IsTrue(SortUtils.IsSorted(arr, ListSortDirection.Ascending));
            Assert.IsTrue(SortUtils.IsSorted(arr, ListSortDirection.Descending));
        }
    }
}
