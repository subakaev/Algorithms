using System;
using System.ComponentModel;
using Algorithms.Common;

namespace Algorithms.Sort
{
    public class PancakeSort<T> : ISort<T> where T : IComparable
    {
        public T[] Sort(T[] array, ListSortDirection direction) {
            for (var i = array.Length - 1; i >= 0; --i) {
                var pos = i;

                for (var j = 0; j < i; j++) {
                    switch (direction) {
                        case ListSortDirection.Ascending:
                            if (array[j].CompareTo(array[pos]) > 0)
                                pos = j;
                            break;
                        case ListSortDirection.Descending:
                            if (array[j].CompareTo(array[pos]) < 0)
                                pos = j;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
                    }
                }

                if (pos == i)
                    continue;

                if (pos != 0) 
                    Flip(array, pos + 1);

                Flip(array, i + 1);
            }

            return array;
        }

        private void Flip(T[] array, int n) {
            for (var i = 0; i < n; i++) {
                --n;
                array.Swap(i, n);
            }
        }
    }
}
