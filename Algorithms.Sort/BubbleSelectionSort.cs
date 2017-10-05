using System;
using System.ComponentModel;
using Algorithms.Common;

namespace Algorithms.Sort
{
    public class BubbleSelectionSort<T> : ISort<T> where T: IComparable<T>
    {
        public T[] Sort(T[] array, ListSortDirection direction) {
            for (var i = 0; i < array.Length - 1; i++) {
                var minIndex = i;
                var isBreak = true;

                for (var j = i; j < array.Length - i - 1; j++) {
                    switch (direction) {
                        case ListSortDirection.Ascending:
                            if (array[j].CompareTo(array[j + 1]) > 0) {
                                array.Swap(j, j + 1);
                                isBreak = false;
                            }
                            if (array[minIndex].CompareTo(array[j]) > 0)
                                minIndex = j;
                            break;
                        case ListSortDirection.Descending:
                            if (array[j].CompareTo(array[j + 1]) < 0) {
                                array.Swap(j, j + 1);
                                isBreak = false;
                            }
                            if (array[minIndex].CompareTo(array[j]) < 0)
                                minIndex = j;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
                    }
                }

                if (isBreak)
                    break;

                if (minIndex != i)
                    array.Swap(i, minIndex);
            }

            return array;
        }
    }
}
