using System;
using System.ComponentModel;

namespace Algorithms.Sort
{
    public class InsertionSort<T> : SortBase<T> where T : IComparable
    {
        public InsertionSort() { }
        public InsertionSort(Action<int, T[]> progressAction) : base(progressAction) { }

        public override T[] Sort(T[] array, ListSortDirection direction) {
            for (var j = 1; j < array.Length; j++) {
                var key = array[j];

                ProgressAction(j, null);

                var i = j - 1;

                while (i >= 0 && CanMoveElements(array[i], key, direction)) {
                    array[i + 1] = array[i];
                    ProgressAction(i, null);
                    i--;
                }

                array[i + 1] = key;

                ProgressAction(i + 1, null);
            }

            return array;
        }

        private bool CanMoveElements(T current, T key, ListSortDirection direction) {
            switch (direction) {
                case ListSortDirection.Ascending:
                    return current.CompareTo(key) > 0;
                case ListSortDirection.Descending:
                    return current.CompareTo(key) < 0;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        } 
    }
}
