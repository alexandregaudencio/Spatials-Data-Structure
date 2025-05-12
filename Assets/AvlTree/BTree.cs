using System.Collections.Generic;
using System;

namespace Tree
{
    public class BTreeNode<T> where T : IComparable<T>
    {
        public List<T> Keys = new();
        public List<BTreeNode<T>> Children = new();
        public bool IsLeaf = true;

        public BTreeNode() { }
    }

}