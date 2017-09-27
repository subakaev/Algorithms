using System;
using Algorithms.Common.ItemGenerators;

namespace Algorithms.Common
{
    public static class ArrayGenerator
    {
        public static int[] Generate(int length, bool allowSameValues = false, int minValue = 0, int maxValue = int.MaxValue) {
            var itemGenerator = new IntArrayItemGenerator(allowSameValues, minValue, maxValue);

            return Generate(length, itemGenerator);
        }

        public static T[] Generate<T>(int length, IArrayItemGenerator<T> itemGenerator) where T : IComparable<T> {
            var result = new T[length];

            for (var i = 0; i < length; i++)
                result[i] = itemGenerator.GenerateNext();

            return result;
        }
    }
}