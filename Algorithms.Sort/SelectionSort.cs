using System;
using System.ComponentModel;
using Algorithms.Common;

namespace Algorithms.Sort
{
    public class SelectionSort<T> : ISort<T> where T : IComparable
    {
        private readonly Action<int, T[]> progressAction = (i, ints) => { };

        public SelectionSort() { }

        public SelectionSort(Action<int, T[]> progressAction) {
            this.progressAction = progressAction;
        }

        public T[] Sort(T[] array, ListSortDirection direction) {
            for (var i = 0; i < array.Length - 1; i++) {
                var leftIndex = i;

                for (var j = i + 1; j < array.Length; j++)
                    if (CanSwapElements(array, leftIndex, j, direction))
                        leftIndex = j;

                if (leftIndex != i) {
                    progressAction(i, null);
                    array.Swap(i, leftIndex);
                }
            }

            return array;
        }

        private bool CanSwapElements(T[] array, int firstIndex, int secondIndex, ListSortDirection direction) {
            switch (direction) {
                case ListSortDirection.Ascending:
                    return array[firstIndex].CompareTo(array[secondIndex]) > 0;
                case ListSortDirection.Descending:
                    return array[firstIndex].CompareTo(array[secondIndex]) < 0;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
    }
}