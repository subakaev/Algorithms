using System;
using System.ComponentModel;
using Algorithms.Common;

namespace Algorithms.Sort
{
    public class BubbleSelectionSort<T> : ISort<T> where T : IComparable
    {
        private readonly Action<int, T[]> progressAction = (i, ints) => { };

        public BubbleSelectionSort() { }

        public BubbleSelectionSort(Action<int, T[]> progressAction) {
            this.progressAction = progressAction;
        }

        public T[] Sort(T[] array, ListSortDirection direction) {
            for (var i = 0; i < array.Length - 1; i++) {
                var leftIndex = i;
                var isBreak = true;

                for (var j = i; j < array.Length - i - 1; j++) {
                    if (TrySwapElements(array, j, j + 1, direction))
                        isBreak = false;

                    if (CheckIsLeft(array[leftIndex], array[j], direction))
                        leftIndex = j;
                }

                if (isBreak)
                    break;

                if (leftIndex != i)
                    Swap(array, i, leftIndex);
            }

            return array;
        }

        private bool TrySwapElements(T[] array, int firstIndex, int secondIndex, ListSortDirection direction)
        {
            if (CanSwapElements(array[firstIndex], array[secondIndex], direction))
            {
                Swap(array, firstIndex, secondIndex);

                return true;
            }

            return false;
        }

        private bool CanSwapElements(T first, T second, ListSortDirection direction)
        {
            switch (direction)
            {
                case ListSortDirection.Ascending:
                    return first.CompareTo(second) > 0;
                case ListSortDirection.Descending:
                    return first.CompareTo(second) < 0;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }

        private bool CheckIsLeft(T first, T second, ListSortDirection direction) {
            switch (direction) {
                case ListSortDirection.Ascending:
                    return first.CompareTo(second) > 0;
                case ListSortDirection.Descending:
                    return first.CompareTo(second) < 0;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }

        private void Swap(T[] array, int firstIndex, int secondIndex) {
            progressAction(secondIndex, null);

            array.Swap(firstIndex, secondIndex);
        }
    }
}