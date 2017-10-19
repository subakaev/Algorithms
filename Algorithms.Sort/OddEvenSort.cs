using System;
using System.ComponentModel;
using Algorithms.Common;

namespace Algorithms.Sort
{
    public class OddEvenSort<T> : SortBase<T> where T: IComparable
    {
        public OddEvenSort() { }
        public OddEvenSort(Action<int, T[]> progressAction) : base(progressAction) { }

        public override T[] Sort(T[] array, ListSortDirection direction) {
            for (var i = 0; i < array.Length; i++) {
                for (var j = (i % 2); j < array.Length - 1; j += 2) {
                    if (CanSwapElements(array[j], array[j + 1], direction)) {
                        array.Swap(j, j + 1);
                        ProgressAction(j + 1, null);

                        if (IsCanceled)
                            return array;
                    }
                }
            }

            return array;
        }

        public bool CanSwapElements(T first, T second, ListSortDirection direction) {
            switch (direction) {
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
