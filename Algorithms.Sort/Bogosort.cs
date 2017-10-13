using Algorithms.Common;
using System;
using System.ComponentModel;

namespace Algorithms.Sort
{
    /// <summary>
    /// Наивный метод сортировки. 
    /// Работает по принципу: проверяем - если массив не отсортирован, то перемешиваем данные и снова проверяем
    /// Крайне неэффективный и нестабильный метод. Плохо работает уже при количестве элементов > 5
    /// </summary>
    public class Bogosort<T> : SortBase<T> where T : IComparable
    {
        public Bogosort() { }
        public Bogosort(Action<int, T[]> progressAction) : base(progressAction) { }

        public override T[] Sort(T[] array, ListSortDirection direction) {
            if (array.Length <= 1)
                return array;

            while (!SortUtils.IsSorted(array, direction)) {
                array.Shuffle();

                ProgressAction(-1, null);

                if (IsCanceled)
                    break;
            }

            return array;
        }
    }
}