using System;
using System.ComponentModel;
using Algorithms.Common;

namespace Algorithms.Sort
{
    public class BubbleSort<T> : ISort<T> where T : IComparable
    {
        private readonly Action<int> afterSwapAction = i => { };

        public BubbleSort() { }

        public BubbleSort(Action<int> afterSwapAction) {
            this.afterSwapAction = afterSwapAction;
        }

        public T[] Sort(T[] array, ListSortDirection direction) {
            for (var i = 0; i < array.Length; i++) {
                var isBreak = true;

                for (var j = 0; j < array.Length - i - 1; j++) {
                    if (TrySwapElements(array, j, j + 1, direction))
                        isBreak = false;
                }

                if (isBreak)
                    break;
            }

            return array;
        }

        protected bool TrySwapElements(T[] array, int firstIndex, int secondIndex, ListSortDirection direction) {
            if (CanSwapElements(array[firstIndex], array[secondIndex], direction)) {
                array.Swap(firstIndex, secondIndex);

                afterSwapAction(secondIndex);

                return true;
            }

            return false;
        }

        private bool CanSwapElements(T first, T second, ListSortDirection direction) {
            switch (direction)
            {
                case ListSortDirection.Ascending:
                    return first.CompareTo(second) > 0;
                case ListSortDirection.Descending:
                    return first.CompareTo(second) < 0;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
    }
}
