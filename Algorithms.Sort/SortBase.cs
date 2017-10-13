using System;
using System.ComponentModel;

namespace Algorithms.Sort
{
    public abstract class SortBase<T> : ISort<T> where T : IComparable
    {
        protected readonly Action<int, T[]> ProgressAction = (i, ints) => { };

        protected SortBase() { }

        protected SortBase(Action<int, T[]> progressAction) {
            ProgressAction = progressAction;
        }

        protected bool IsCanceled { get; private set; }

        public abstract T[] Sort(T[] array, ListSortDirection direction);
        
        public void Cancel() => IsCanceled = true;
    }
}
