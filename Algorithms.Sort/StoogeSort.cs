using System;
using System.ComponentModel;
using Algorithms.Common;

namespace Algorithms.Sort
{
    public class StoogeSort<T> : ISort<T> where T : IComparable<T>
    {
        public T[] Sort(T[] array, ListSortDirection direction) {
            if (array.Length == 1)
                return array;

            Stooge(array, 0, array.Length - 1, direction);

            return array;
        }

        public T[] SortDebug(T[] array, ListSortDirection direction, out long ticks) {
            throw new NotImplementedException();
        }

        private void Stooge(T[] array, int startIndex, int endIndex, ListSortDirection direction) {
            switch (direction) {
                case ListSortDirection.Ascending:
                    if (array[startIndex].CompareTo(array[endIndex]) > 0)
                        array.Swap(startIndex, endIndex);
                    break;
                case ListSortDirection.Descending:
                    if (array[startIndex].CompareTo(array[endIndex]) < 0)
                        array.Swap(startIndex, endIndex);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }

            if (endIndex - startIndex > 1) {
                var t = (endIndex - startIndex + 1) / 3;
                Stooge(array, startIndex, endIndex - t, direction);
                Stooge(array, startIndex + t, endIndex, direction);
                Stooge(array, startIndex, endIndex - t, direction);
            }
        }
    }
}