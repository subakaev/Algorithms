using System;
using System.ComponentModel;

namespace Algorithms.Sort
{
    public interface ISort<T> where T : IComparable
    {
        T[] Sort(T[] array, ListSortDirection direction);

        void Cancel();
    }
}
