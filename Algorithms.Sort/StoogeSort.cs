using System;
using System.ComponentModel;
using Algorithms.Common;

namespace Algorithms.Sort
{
    public class StoogeSort<T> : ISort<T> where T : IComparable
    {
        private readonly Action<int, T[]> progressAction = (i, ints) => { };

        public StoogeSort() { }

        public StoogeSort(Action<int, T[]> progressAction) {
            this.progressAction = progressAction;
        }

        public T[] Sort(T[] array, ListSortDirection direction) {
            if (array.Length == 1)
                return array;

            Stooge(array, 0, array.Length - 1, direction);

            return array;
        }

        private void Stooge(T[] array, int startIndex, int endIndex, ListSortDirection direction) {
            if (CanSwapItems(array[startIndex], array[endIndex], direction))
                SwapItems(array, startIndex, endIndex);

            if (endIndex - startIndex > 1) {
                var t = (endIndex - startIndex + 1) / 3;
                Stooge(array, startIndex, endIndex - t, direction);
                Stooge(array, startIndex + t, endIndex, direction);
                Stooge(array, startIndex, endIndex - t, direction);
            }
        }

        private bool CanSwapItems(T first, T second, ListSortDirection direction) {
            switch (direction) {
                case ListSortDirection.Ascending:
                    return first.CompareTo(second) > 0;
                case ListSortDirection.Descending:
                    return first.CompareTo(second) < 0;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }

        private void SwapItems(T[] array, int firstIndex, int secondIndex) {
            progressAction(secondIndex, null);
            array.Swap(firstIndex, secondIndex);
        }
    }
}