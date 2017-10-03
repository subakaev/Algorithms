using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Algorithms.Sort
{
    public static class SortUtils
    {
        public static bool IsSorted<T>(T[] array, ListSortDirection direction) where T : IComparable<T> {
            switch (direction) {
                case ListSortDirection.Ascending:
                    return IsSorted(array, (x, y) => x.CompareTo(y) <= 0);
                case ListSortDirection.Descending:
                    return IsSorted(array, (x, y) => x.CompareTo(y) >= 0);
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }

        private static bool IsSorted<T>(IReadOnlyList<T> array, Func<T, T, bool> compareFunc) where T : IComparable<T> {
            if (array.Count <= 1)
                return true;

            for (var i = 0; i < array.Count - 1; i++) {
                if (!compareFunc(array[i], array[i + 1]))
                    return false;
            }

            return true;
        }
    }
}
