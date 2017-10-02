using Algorithms.Common;
using System;
using System.ComponentModel;

namespace Algorithms.Sort
{
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

        public T[] SortDebug(T[] array, ListSortDirection direction, out long ticks) {
            ticks = 0;

            if (array.Length <= 1)
                return array;

            while (!SortUtils.IsSorted(array, direction)) {
                array.Shuffle();
                ticks++;
            }

            return array;
        }
    }
}