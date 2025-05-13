using System;
using UnityEngine;

namespace Tree
{
    public class AVLNode<T> where T : IComparable<T>
    {
        public T Value;
        public AVLNode<T> Left;
        public AVLNode<T> Right;
        public int Height;

        public AVLNode(T value)
        {
            Value = value;
            Height = 1;
        }
    }

}