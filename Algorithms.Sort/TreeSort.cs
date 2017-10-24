using System;
using System.Collections.Generic;
using System.ComponentModel;
using Algorithms.Common;

namespace Algorithms.Sort
{
    public class TreeSort<T> : SortBase<T> where T : IComparable
    {
        public TreeSort() { }
        public TreeSort(Action<int, T[]> progressAction) : base(progressAction) { }

        private class TreeVisitor : ITreeVisitor<T>
        {
            private readonly Action<int, T[]> progressAction;

            public readonly List<T> Result = new List<T>();

            public TreeVisitor(Action<int, T[]> progressAction) {
                this.progressAction = progressAction;
            }

            public void Visit(Tree<T> tree)
            {
                Result.Add(tree.Key);

                progressAction(-1, null);
            }
        }

        public override T[] Sort(T[] array, ListSortDirection direction) {
            var tree = new Tree<T>(array[0]);

            for (var i = 1; i < array.Length; i++)
                tree.Insert(array[i]);

            var visitor = new TreeVisitor(ProgressAction);

            tree.Traverse(visitor);

            if (direction == ListSortDirection.Descending)
                visitor.Result.Reverse();

            ProgressAction(-1, visitor.Result.ToArray());

            return visitor.Result.ToArray();
        }
    }
}
