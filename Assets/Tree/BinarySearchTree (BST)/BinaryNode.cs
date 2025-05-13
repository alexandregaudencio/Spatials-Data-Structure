
using System;

namespace Tree.Binary { 
    public class BinaryNode<T> where T : IComparable<T>
    {
        public T Value;
        public BinaryNode<T> Left;
        public BinaryNode<T> Right;

        public BinaryNode(T value)
        {
            Value = value;
        }
        }
}
