﻿using System;
using System.ComponentModel;

namespace Algorithms.Sort
{
    public interface ISort<T> where T : IComparable<T>
    {
        T[] Sort(T[] array, ListSortDirection direction);

        T[] SortDebug(T[] array, ListSortDirection direction, out long ticks);
    }
}
