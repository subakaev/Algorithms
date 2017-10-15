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

                while (i >= 0 && array[i].CompareTo(key) > 0) {
                    array[i + 1] = array[i];
                    ProgressAction(i, null);
                    i--;
                }

                array[i + 1] = key;

                ProgressAction(i + 1, null);
            }

            return array;
        }
    }
}
