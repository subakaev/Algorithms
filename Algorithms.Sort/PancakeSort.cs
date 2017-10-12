using System;
using System.ComponentModel;
using Algorithms.Common;

namespace Algorithms.Sort
{
    public class PancakeSort<T> : ISort<T> where T : IComparable
    {
        private readonly Action<int, T[]> progressAction = (i, ints) => { };

        public PancakeSort() { }

        public PancakeSort(Action<int, T[]> progressAction) {
            this.progressAction = progressAction;
        }

        public T[] Sort(T[] array, ListSortDirection direction) {
            for (var i = array.Length - 1; i >= 0; --i) {
                var pos = i;

                for (var j = 0; j < i; j++) 
                    if (CheckElements(array[j], array[pos], direction))
                        pos = j;

                if (pos == i)
                    continue;

                if (pos != 0) {
                    array.Flip(pos + 1);
                    progressAction(-1, null);
                }

                array.Flip(i + 1);
                progressAction(-1, null);
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
    }
}