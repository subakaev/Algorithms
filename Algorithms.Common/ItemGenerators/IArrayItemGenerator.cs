using System;

namespace Algorithms.Common.ItemGenerators
{
    public interface IArrayItemGenerator<out T> where T : IComparable<T>
    {
        T GenerateNext();
    }
}