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
    public class Bogosort<T> : ISort<T> where T : IComparable<T>
    {
        public T[] Sort(T[] array, ListSortDirection direction) {
            if (array.Length <= 1)
                return array;

            while (!SortUtils.IsSorted(array, direction)) {
                array.Shuffle();
            }

            return array;
        }
    }
}