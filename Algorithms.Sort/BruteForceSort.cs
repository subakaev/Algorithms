using System;
using System.ComponentModel;
using Algorithms.Common;

namespace Algorithms.Sort
{
    public class BruteForceSort<T> : ISort<T> where T : IComparable<T>
    {
        private int iterationsCount;
        private T[] sorted;
        private bool isSorted;

        public T[] Sort(T[] array, ListSortDirection direction) {
            if (array.Length <= 1)
                return array;

            iterationsCount = 0;

            isSorted = false;

            SortInternal(new T[array.Length], array, 0, direction);

            return sorted;
        }

        public T[] SortDebug(T[] array, ListSortDirection direction, out long ticks) {
            var result = Sort(array, direction);

            ticks = iterationsCount;

            return result;
        }

        private void SortInternal(T[] result, T[] array, int index, ListSortDirection direction) {
            if (isSorted)
                return;

            for (var i = 0; i < array.Length; i++) {
                result[index] = array[i];

                if (array.Length == 1) {
                    if (SortUtils.IsSorted(result, direction)) {
                        sorted = result;
                        isSorted = true;
                    }

                    iterationsCount++;

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