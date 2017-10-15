using System;
using System.ComponentModel;
using Algorithms.Common;

namespace Algorithms.Sort
{
    public class GnomeSort<T> : SortBase<T> where T : IComparable
    {
        private int current;
        private int next;

        public GnomeSort() { }
        public GnomeSort(Action<int, T[]> progressAction) : base(progressAction) { }

        public override T[] Sort(T[] array, ListSortDirection direction) {
            current = 1;
            next = 2;

            while (current < array.Length) {
                if (CanSwapItems(array, direction))
                    SwapItems(array);
                else
                    current = next++;

                if (IsCanceled)
                    return array;
            }

            return array;
        }

        private bool CanSwapItems(T[] array, ListSortDirection direction) {
            switch (direction) {
                case ListSortDirection.Ascending:
                    return array[current - 1].CompareTo(array[current]) > 0;
                case ListSortDirection.Descending:
                    return array[current - 1].CompareTo(array[current]) < 0;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }

        private void SwapItems(T[] array) {
            ProgressAction(current, null);

            array.Swap(current - 1, current);

            current--;

            if (current == 0)
                current = next++;
        }
    }
}