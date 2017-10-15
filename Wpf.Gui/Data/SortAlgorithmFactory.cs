using System;
using Algorithms.Sort;

namespace Wpf.Gui.Data
{
    static class SortAlgorithmFactory
    {
        public static ISort<T> Get<T>(SortAlgorithmType type, Action<int, T[]> progressAction) where T : IComparable {
            switch (type) {
                case SortAlgorithmType.Bogo:
                    return new Bogosort<T>(progressAction);
                case SortAlgorithmType.BruteForce:
                    return new BruteForceSort<T>(progressAction);
                case SortAlgorithmType.Bubble:
                    return new BubbleSort<T>(progressAction);
                case SortAlgorithmType.BubbleSelection:
                    return new BubbleSelectionSort<T>(progressAction);
                case SortAlgorithmType.Selection:
                    return new SelectionSort<T>(progressAction);
                case SortAlgorithmType.Pancake:
                    return new PancakeSort<T>(progressAction);
                case SortAlgorithmType.Stooge:
                    return new StoogeSort<T>(progressAction);
                case SortAlgorithmType.Gnome:
                    return new GnomeSort<T>(progressAction);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
