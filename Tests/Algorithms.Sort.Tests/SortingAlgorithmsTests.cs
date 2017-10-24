using System;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Algorithms.Sort.Tests
{
    [TestClass]
    public class SortingAlgorithmsTests
    {
        private readonly int[] intUniqueArray = { 2, 3, 1, 5, 4 };
        private readonly int[] intArray = { 2, 2, 1, 4, 3, 3 };

        private readonly MoqUniqueArray moqUniqueArray = new MoqUniqueArray();

        private readonly MoqArray moqArray = new MoqArray();

        private class SortAlgorithms<T> where T : IComparable
        {
            public ISort<T>[] Algorithms { get; }

            public SortAlgorithms() {
                Algorithms = new ISort<T>[] {
                    new BruteForceSort<T>(),
                    new StoogeSort<T>(),
                    new BubbleSort<T>(),
                    new SelectionSort<T>(),
                    new BubbleSelectionSort<T>(),
                    new PancakeSort<T>(), 
                    new GnomeSort<T>(),
                    new InsertionSort<T>(),
                    new CombSort<T>(), 
                    new OddEvenSort<T>(), 
                    new CocktailSort<T>(), 
                    new TreeSort<T>(), 
                };
            }
        }

        private class MoqUniqueArray
        {
            public readonly Mock<IComparable> Moq1;
            public readonly Mock<IComparable> Moq2;
            public readonly Mock<IComparable> Moq3;

            public IComparable[] Array => new[] { Moq1.Object, Moq2.Object, Moq3.Object };

            public MoqUniqueArray() {
                Moq1 = new Mock<IComparable>(); // 2
                Moq2 = new Mock<IComparable>(); // 3
                Moq3 = new Mock<IComparable>(); // 1

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
            public readonly Mock<IComparable> Moq1;
            public readonly Mock<IComparable> Moq2;
            public readonly Mock<IComparable> Moq3;

            public IComparable[] Array => new[] { Moq1.Object, Moq2.Object, Moq3.Object };

            public MoqArray() {
                Moq1 = new Mock<IComparable>(); // 2
                Moq2 = new Mock<IComparable>(); // 2
                Moq3 = new Mock<IComparable>(); // 1

                Moq1.Setup(m => m.CompareTo(Moq2.Object)).Returns(0);
                Moq1.Setup(m => m.CompareTo(Moq3.Object)).Returns(1);

                Moq2.Setup(m => m.CompareTo(Moq1.Object)).Returns(0);
                Moq2.Setup(m => m.CompareTo(Moq3.Object)).Returns(1);

                Moq3.Setup(m => m.CompareTo(Moq1.Object)).Returns(-1);
                Moq3.Setup(m => m.CompareTo(Moq2.Object)).Returns(-1);
            }
        }

        [TestMethod]
        public void only_unique_int_array_values_ascending_test() {
            foreach (var algorithm in new SortAlgorithms<int>().Algorithms) {
                var result = algorithm.Sort(intUniqueArray, ListSortDirection.Ascending);

                Assert.AreEqual(1, result[0], GetMessage(algorithm));
                Assert.AreEqual(2, result[1], GetMessage(algorithm));
                Assert.AreEqual(3, result[2], GetMessage(algorithm));
                Assert.AreEqual(4, result[3], GetMessage(algorithm));
                Assert.AreEqual(5, result[4], GetMessage(algorithm));
            }
        }

        [TestMethod]
        public void only_unique_int_array_values_descending_test() {
            foreach (var algorithm in new SortAlgorithms<int>().Algorithms) {
                var result = algorithm.Sort(intUniqueArray, ListSortDirection.Descending);

                Assert.AreEqual(5, result[0], GetMessage(algorithm));
                Assert.AreEqual(4, result[1], GetMessage(algorithm));
                Assert.AreEqual(3, result[2], GetMessage(algorithm));
                Assert.AreEqual(2, result[3], GetMessage(algorithm));
                Assert.AreEqual(1, result[4], GetMessage(algorithm));
            }
        }

        [TestMethod]
        public void int_array_values_ascending_test() {
            foreach (var algorithm in new SortAlgorithms<int>().Algorithms) {
                var result = algorithm.Sort(intArray, ListSortDirection.Ascending);

                Assert.AreEqual(1, result[0], GetMessage(algorithm));
                Assert.AreEqual(2, result[1], GetMessage(algorithm));
                Assert.AreEqual(2, result[2], GetMessage(algorithm));
                Assert.AreEqual(3, result[3], GetMessage(algorithm));
                Assert.AreEqual(3, result[4], GetMessage(algorithm));
                Assert.AreEqual(4, result[5], GetMessage(algorithm));
            }
        }

        [TestMethod]
        public void int_array_values_descending_test() {
            foreach (var algorithm in new SortAlgorithms<int>().Algorithms) {
                var result = algorithm.Sort(intArray, ListSortDirection.Descending);

                Assert.AreEqual(4, result[0], GetMessage(algorithm));
                Assert.AreEqual(3, result[1], GetMessage(algorithm));
                Assert.AreEqual(3, result[2], GetMessage(algorithm));
                Assert.AreEqual(2, result[3], GetMessage(algorithm));
                Assert.AreEqual(2, result[4], GetMessage(algorithm));
                Assert.AreEqual(1, result[5], GetMessage(algorithm));
            }
        }

        [TestMethod]
        public void only_unique_moq_array_values_ascending_test() {
            foreach (var algorithm in new SortAlgorithms<IComparable>().Algorithms) {
                var result = algorithm.Sort(moqUniqueArray.Array, ListSortDirection.Ascending);

                Assert.AreEqual(moqUniqueArray.Moq1.Object, result[1], GetMessage(algorithm));
                Assert.AreEqual(moqUniqueArray.Moq2.Object, result[2], GetMessage(algorithm));
                Assert.AreEqual(moqUniqueArray.Moq3.Object, result[0], GetMessage(algorithm));
            }
        }

        [TestMethod]
        public void only_unique_moq_array_values_descending_test() {
            foreach (var algorithm in new SortAlgorithms<IComparable>().Algorithms) {
                var result = algorithm.Sort(moqUniqueArray.Array, ListSortDirection.Descending);

                Assert.AreEqual(moqUniqueArray.Moq1.Object, result[1], GetMessage(algorithm));
                Assert.AreEqual(moqUniqueArray.Moq2.Object, result[0], GetMessage(algorithm));
                Assert.AreEqual(moqUniqueArray.Moq3.Object, result[2], GetMessage(algorithm));
            }
        }

        [TestMethod]
        public void only_moq_array_values_ascending_test() {
            foreach (var algorithm in new SortAlgorithms<IComparable>().Algorithms) {
                var result = algorithm.Sort(moqArray.Array, ListSortDirection.Ascending);

                Assert.IsTrue(moqArray.Moq1.Object == result[1] || moqArray.Moq1.Object == result[2], GetMessage(algorithm));
                Assert.IsTrue(moqArray.Moq2.Object == result[1] || moqArray.Moq2.Object == result[2], GetMessage(algorithm));
                Assert.AreEqual(moqArray.Moq3.Object, result[0], GetMessage(algorithm));
            }
        }

        [TestMethod]
        public void only_moq_array_values_descending_test() {
            foreach (var algorithm in new SortAlgorithms<IComparable>().Algorithms) {
                var result = algorithm.Sort(moqArray.Array, ListSortDirection.Descending);

                Assert.AreEqual(moqArray.Moq1.Object, result[0], GetMessage(algorithm));
                Assert.AreEqual(moqArray.Moq2.Object, result[1], GetMessage(algorithm));
                Assert.AreEqual(moqArray.Moq3.Object, result[2], GetMessage(algorithm));
            }
        }

        [TestMethod]
        public void only_one_array_item_ascending_test() {
            foreach (var algorithm in new SortAlgorithms<IComparable>().Algorithms) {
                var result = algorithm.Sort(new[] { moqArray.Moq1.Object }, ListSortDirection.Ascending);

                Assert.AreEqual(moqArray.Moq1.Object, result[0], GetMessage(algorithm));
            }
        }

        [TestMethod]
        public void only_one_array_item_descending_test() {
            foreach (var algorithm in new SortAlgorithms<IComparable>().Algorithms) {
                var result = algorithm.Sort(new[] { moqArray.Moq1.Object }, ListSortDirection.Descending);

                Assert.AreEqual(moqArray.Moq1.Object, result[0], GetMessage(algorithm));
            }
        }

        [TestMethod]
        public void only_two_array_item_ascending_test() {
            foreach (var algorithm in new SortAlgorithms<IComparable>().Algorithms) {
                var result = algorithm.Sort(new[] { moqUniqueArray.Moq1.Object, moqUniqueArray.Moq2.Object }, ListSortDirection.Ascending);

                Assert.AreEqual(moqUniqueArray.Moq1.Object, result[0], GetMessage(algorithm));
                Assert.AreEqual(moqUniqueArray.Moq2.Object, result[1], GetMessage(algorithm));
            }
        }

        [TestMethod]
        public void only_two_array_item_descending_test() {
            foreach (var algorithm in new SortAlgorithms<IComparable>().Algorithms) {
                var result = algorithm.Sort(new[] { moqUniqueArray.Moq1.Object, moqUniqueArray.Moq2.Object }, ListSortDirection.Descending);

                Assert.AreEqual(moqUniqueArray.Moq1.Object, result[1], GetMessage(algorithm));
                Assert.AreEqual(moqUniqueArray.Moq2.Object, result[0], GetMessage(algorithm));
            }
        }

        private string GetMessage(object obj) {
            return $"Ошибка в алгоритме {obj.GetType().Name}";
        }
    }
}