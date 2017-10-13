using System;
using System.ComponentModel;
using Algorithms.Common;

namespace Algorithms.Sort
{
    public class PancakeSort<T> : SortBase<T> where T : IComparable
    {
        public PancakeSort() { }
        public PancakeSort(Action<int, T[]> progressAction) : base(progressAction) { }

        public override T[] Sort(T[] array, ListSortDirection direction) {
            for (var i = array.Length - 1; i >= 0; --i) {
                var pos = i;

                for (var j = 0; j < i; j++)
                    if (CheckElements(array[j], array[pos], direction))
                        pos = j;

                if (pos == i)
                    continue;

                if (pos != 0)
                    Flip(array, pos + 1);

                Flip(array, i + 1);

                if (IsCanceled)
                    break;
            }

            return array;
        }

        private bool CheckElements(IComparable x, IComparable y, ListSortDirection direction) {
            switch (direction) {
                case ListSortDirection.Ascending:
                    return x.CompareTo(y) > 0;
                case ListSortDirection.Descending:
                    return x.CompareTo(y) < 0;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }

        private void Flip(T[] array, int index) {
            array.Flip(index);
            ProgressAction(-1, null);
        }
    }
}