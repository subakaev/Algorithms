using System;
using System.ComponentModel;
using Algorithms.Common;

namespace Algorithms.Sort
{
    public class CocktailSort<T> : SortBase<T> where T : IComparable
    {
        public CocktailSort() { }
        public CocktailSort(Action<int, T[]> progressAction) : base(progressAction) { }

        public override T[] Sort(T[] array, ListSortDirection direction) {
            var left = 0;
            var right = array.Length - 1;

            while (left < right) {
                var isBreak = true;

                for (var i = left; i < right; i++) 
                    if (CanSwapElements(array[i], array[i + 1], direction)) {
                        SwapElements(array, i, i + 1);
                        isBreak = false;
                    }
                right--;
                
                for (var i = right; i > left; i--)
                    if (CanSwapElements(array[i - 1], array[i], direction)) {
                        SwapElements(array, i - 1, i);
                        isBreak = false;
                    }
                left++;

                if (isBreak)
                    break;
            }

            return array;
        }

        private bool CanSwapElements(T first, T second, ListSortDirection direction) {
            switch (direction) {
                case ListSortDirection.Ascending:
                    return first.CompareTo(second) > 0;
                case ListSortDirection.Descending:
                    return first.CompareTo(second) < 0;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }

        private void SwapElements(T[] array, int firstIndex, int secondIndex) {
            array.Swap(firstIndex, secondIndex);

            ProgressAction(secondIndex, null);
        }
    }
}
