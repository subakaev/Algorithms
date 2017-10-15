using System;
using System.ComponentModel;
using Algorithms.Common;

namespace Algorithms.Sort
{
    public class CombSort<T> : SortBase<T> where T : IComparable
    {
        public CombSort() { }
        public CombSort(Action<int, T[]> progressAction) : base(progressAction) { }

        public override T[] Sort(T[] array, ListSortDirection direction) {
            var factor = 1.2473309;
            var step = array.Length - 1;

            while (step >= 1) {
                for (var i = 0; i + step < array.Length; i++) {
                    if (CanSwapItems(array, i, i + step, direction))
                        SwapItems(array, i, i + step);

                    if (IsCanceled)
                        return array;
                }
                step = (int) (step / factor);
            }

            return new BubbleSort<T>(ProgressAction).Sort(array, direction);
        }

        private bool CanSwapItems(T[] array, int firstIndex, int secondIndex, ListSortDirection direction) {
            switch (direction) {
                case ListSortDirection.Ascending:
                    return array[firstIndex].CompareTo(array[secondIndex]) > 0;
                case ListSortDirection.Descending:
                    return array[firstIndex].CompareTo(array[secondIndex]) < 0;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }

        private void SwapItems(T[] array, int firstIndex, int secondIndex) {
            ProgressAction(secondIndex, null);

            array.Swap(firstIndex, secondIndex);
        }
    }
}
