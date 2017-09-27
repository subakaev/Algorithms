using System;
using System.Collections.Generic;

namespace Algorithms.Common.ItemGenerators
{
    class IntArrayItemGenerator : IArrayItemGenerator<int>
    {
        private readonly Random random = new Random();

        private readonly bool isSameValuesAllowed;
        private readonly int minValue;
        private readonly int maxValue;

        private readonly HashSet<int> generated = new HashSet<int>();

        public IntArrayItemGenerator(bool isSameValuesAllowed = true, int minValue = 0, int maxValue = int.MaxValue) {
            this.isSameValuesAllowed = isSameValuesAllowed;
            this.minValue = minValue;
            this.maxValue = maxValue;

            if (maxValue < minValue)
                throw new InvalidOperationException("maxValue must be greater than minValue.");
        }

        public int GenerateNext() {
            return isSameValuesAllowed ? random.Next(minValue, maxValue) : GenerateUnique();
        }

        private int GenerateUnique() {
            if (maxValue - minValue <= generated.Count)
                throw new InvalidOperationException("Cannot generate unique item because limit reached.");

            var newItem = random.Next(minValue, maxValue);

            var tryCount = 0;

            while (generated.Contains(newItem)) {
                newItem = random.Next(minValue, maxValue);
                tryCount++;

                if (tryCount == int.MaxValue)
                    throw new InvalidOperationException("Max count reached.");
            }

            generated.Add(newItem);

            return newItem;
        }
    }
}