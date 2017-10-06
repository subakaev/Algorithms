using System;

namespace Algorithms.Common
{
    public static class ArrayUtils
    {
        public static void Shuffle<T>(this T[] array) where T : IComparable {
            Shuffle(array, array.Length);
        }

        public static void Shuffle<T>(this T[] array, int shufflesCount) where T : IComparable {
            if (array.Length <= 1 || shufflesCount <= 0)
                return;

            var random = new Random();

            var currentShufflesCount = 0;

            while (currentShufflesCount < shufflesCount) {
                var firstIndex = random.Next(0, array.Length);
                var secondIndex = random.Next(0, array.Length);

                if (firstIndex == secondIndex)
                    continue;

                array.Swap(firstIndex, secondIndex);

                currentShufflesCount++;
            }
        }

        public static void Swap<T>(this T[] array, int firstIndex, int secondIndex) where T : IComparable {
            var dummy = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = dummy;
        }
    }
}
