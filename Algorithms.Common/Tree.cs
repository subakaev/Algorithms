using System;

namespace Algorithms.Common
{
    public class Tree<T> where T : IComparable
    {
        public T Key { get; }

        public Tree<T> Left { get; private set; }

        public Tree<T> Right { get; private set; }

        public Tree(T key) {
            Key = key;
        }

        public void Insert(T item) {
            if (Key.CompareTo(item) > 0) {
                if (Left != null)
                    Left.Insert(item);
                else 
                    Left = new Tree<T>(item);
            }
            else {
                if (Right != null)
                    Right.Insert(item);
                else
                    Right = new Tree<T>(item);
            }
        }

        public void Traverse(ITreeVisitor<T> visitor) {
            Left?.Traverse(visitor);

            visitor.Visit(this);

            Right?.Traverse(visitor);
        }
    }

    public interface ITreeVisitor<T> where T : IComparable
    {
        void Visit(Tree<T> tree);
    }
}
