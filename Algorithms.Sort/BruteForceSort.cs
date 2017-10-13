using System;
using System.ComponentModel;
using Algorithms.Common;

namespace Algorithms.Sort
{
    public class BruteForceSort<T> : SortBase<T> where T : IComparable
    {
        private T[] sorted;
        private bool isSorted;

        public BruteForceSort() { }
        public BruteForceSort(Action<int, T[]> progressAction) : base(progressAction) { }

        public override T[] Sort(T[] array, ListSortDirection direction) {
            if (array.Length <= 1)
                return array;

            isSorted = false;

            SortInternal(new T[array.Length], array, 0, direction);

            return sorted;
        }

        private void SortInternal(T[] result, T[] array, int index, ListSortDirection direction) {
            if (isSorted)
                return;

            if (IsCanceled)
                return;

            for (var i = 0; i < array.Length; i++) {
                result[index] = array[i];

                if (array.Length == 1) {
                    ProgressAction(-1, result);

                    if (SortUtils.IsSorted(result, direction)) {
                        sorted = result;
                        isSorted = true;
                    }

                    return;
                }

                var resultClone = new T[result.Length];
                Array.Copy(result, resultClone, result.Length);

                var arrayClone = (T[]) array.Clone();

                arrayClone.Swap(0, i);

                var next = new T[array.Length - 1];
                Array.Copy(arrayClone, 1, next, 0, next.Length);

                SortInternal((T[]) result.Clone(), next, index + 1, direction);
            }
        }
    }
}