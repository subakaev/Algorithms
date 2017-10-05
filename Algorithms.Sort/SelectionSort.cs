using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Common;

namespace Algorithms.Sort
{
    public class SelectionSort<T> : ISort<T> where T : IComparable<T>
    {
        public T[] Sort(T[] array, ListSortDirection direction) {
            for (var i = 0; i < array.Length - 1; i++) {
                var minIndex = i;

                for (var j = i + 1; j < array.Length; j++) {
                    switch (direction) {
                        case ListSortDirection.Ascending:
                            if (array[i].CompareTo(array[j]) > 0)
                                minIndex = j;
                            break;
                        case ListSortDirection.Descending:
                            if (array[i].CompareTo(array[j]) < 0)
                                minIndex = j;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
                    }
                }

                if (minIndex != i)
                    array.Swap(i, minIndex);
            }

            return array;
        }
    }
}
