using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Algorithms.Common.Tests
{
    [TestClass]
    public class ArrayUtilsTests
    {
        [TestMethod]
        public void array_utils_swap_test()
        {
            var moq1 = new Mock<IComparable>();
            var moq2 = new Mock<IComparable>();
            var moq3 = new Mock<IComparable>();

            var arr = new[] { moq1.Object, moq2.Object, moq3.Object };

            arr.Swap(0, 1);

            Assert.AreSame(moq1.Object, arr[1]);
            Assert.AreSame(moq2.Object, arr[0]);

            arr.Swap(0, 2);

            Assert.AreSame(moq3.Object, arr[0]);
            Assert.AreSame(moq2.Object, arr[2]);
        }

        [TestMethod]
        public void array_utils_shuffle_with_two_elements_test() {
            var moq1 = new Mock<IComparable>();
            var moq2 = new Mock<IComparable>();

            var arr = new[] { moq1.Object, moq2.Object };

            arr.Shuffle();

            Assert.AreSame(moq1.Object, arr[0]);
            Assert.AreSame(moq2.Object, arr[1]);
        }

        [TestMethod]
        public void array_utils_shuffle_count_with_two_elements_test() {
            var moq1 = new Mock<IComparable>();
            var moq2 = new Mock<IComparable>();

            var arr = new[] { moq1.Object, moq2.Object };

            arr.Shuffle(1);

            Assert.AreSame(moq1.Object, arr[1]);
            Assert.AreSame(moq2.Object, arr[0]);
        }

        [TestMethod]
        public void array_utils_shuffle_test() {
            var moq1 = new Mock<IComparable>();
            var moq2 = new Mock<IComparable>();
            var moq3 = new Mock<IComparable>();

            var arr = new[] { moq1.Object, moq2.Object, moq3.Object };

            arr.Shuffle(1);

            Assert.IsTrue(moq1.Object != arr[0] || moq2.Object != arr[1] || moq3.Object != arr[2]);
        }

        [TestMethod]
        public void array_utils_flip_odd_test() {
            var moq1 = new Mock<IComparable>();
            var moq2 = new Mock<IComparable>();
            var moq3 = new Mock<IComparable>();

            var arr = new[] { moq1.Object, moq2.Object, moq3.Object };
            
            arr.Flip();

            Assert.AreSame(moq1.Object, arr[2]);
            Assert.AreSame(moq2.Object, arr[1]);
            Assert.AreSame(moq3.Object, arr[0]);
        }

        [TestMethod]
        public void array_utils_flip_even_test() {
            var moq1 = new Mock<IComparable>();
            var moq2 = new Mock<IComparable>();
            var moq3 = new Mock<IComparable>();
            var moq4 = new Mock<IComparable>();

            var arr = new[] { moq1.Object, moq2.Object, moq3.Object, moq4.Object };

            arr.Flip();

            Assert.AreSame(moq4.Object, arr[0]);
            Assert.AreSame(moq3.Object, arr[1]);
            Assert.AreSame(moq2.Object, arr[2]);
            Assert.AreSame(moq1.Object, arr[3]);
        }

        [TestMethod]
        public void array_utils_flip_test() {
            var moq1 = new Mock<IComparable>();
            var moq2 = new Mock<IComparable>();
            var moq3 = new Mock<IComparable>();

            var arr = new[] { moq1.Object, moq2.Object, moq3.Object };

            arr.Flip(2);

            Assert.AreSame(moq1.Object, arr[1]);
            Assert.AreSame(moq2.Object, arr[0]);
            Assert.AreSame(moq3.Object, arr[2]);
        }
    }
}
