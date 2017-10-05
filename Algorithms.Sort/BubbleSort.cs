using System;
using System.ComponentModel;
using Algorithms.Common;

namespace Algorithms.Sort
{
    public class BubbleSort<T> : ISort<T> where T : IComparable<T>
    {
        public T[] Sort(T[] array, ListSortDirection direction) {
            for (var i = 0; i < array.Length; i++) {
                var isBreak = true;

                for (var j = 0; j < array.Length - i - 1; j++) {
                    switch (direction) {
                        case ListSortDirection.Ascending:
                            if (array[j].CompareTo(array[j + 1]) > 0) {
                                array.Swap(j, j + 1);
                                isBreak = false;
                            }
                            break;
                        case ListSortDirection.Descending:
                            if (array[j].CompareTo(array[j + 1]) < 0) {
                                array.Swap(j, j + 1);
                                isBreak = false;
                            }
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
                    }
                }

                if (isBreak)
                    break;
            }

            return array;
        }

        public T[] SortDebug(T[] array, ListSortDirection direction, out long ticks) {
            throw new NotImplementedException();
        }
    }
}
