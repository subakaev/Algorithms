using System;
using System.ComponentModel;
using Algorithms.Common;

namespace Algorithms.Sort
{
    public class BubbleSort<T> : SortBase<T> where T : IComparable
    {
        public BubbleSort() { }
        public BubbleSort(Action<int, T[]> progressAction) : base(progressAction) { }

        public override T[] Sort(T[] array, ListSortDirection direction) {
            for (var i = 0; i < array.Length; i++) {
                var isBreak = true;

                for (var j = 0; j < array.Length - i - 1; j++) {
                    if (TrySwapElements(array, j, j + 1, direction))
                        isBreak = false;

                    if (IsCanceled)
                        return array;
                }

                if (isBreak)
                    break;
            }

            return array;
        }

        private bool TrySwapElements(T[] array, int firstIndex, int secondIndex, ListSortDirection direction) {
            if (CanSwapElements(array[firstIndex], array[secondIndex], direction)) {
                ProgressAction(secondIndex, null);

                array.Swap(firstIndex, secondIndex);

                return true;
            }

            return false;
        }

        private bool CanSwapElements(T first, T second, ListSortDirection direction) {
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
    }
}
