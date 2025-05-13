using System;

namespace Tree.Binary
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public BinaryNode<T> Root;

        public void Insert(T value)
        {
            Root = InsertRecursive(Root, value);
        }

        private BinaryNode<T> InsertRecursive(BinaryNode<T> node, T value)
        {
            if (node == null) return new BinaryNode<T>(value);

            //Verifica se o resultado é menor, maior ou igual(-1, 1 ou  0). para tomar decisão de vai para um lado ou para o outro
            int cmp = value.CompareTo(node.Value);

            if (cmp < 0)
                node.Left = InsertRecursive(node.Left, value);
            else if (cmp > 0)
                node.Right = InsertRecursive(node.Right, value);
            // Se for igual, ignora ou trata duplicatas aqui

            return node;
        }

        public bool Contains(T value)
        {
            return SearchRecursive(Root, value) != null;
        }

        private BinaryNode<T> SearchRecursive(BinaryNode<T> node, T value)
        {
            if (node == null) return null;

            int cmp = value.CompareTo(node.Value);

            if (cmp == 0) return node;
            if (cmp < 0) return SearchRecursive(node.Left, value);
            return SearchRecursive(node.Right, value);
        }

        
        public void TraverseInOrder(Action<T> action)
        {
            InOrder(Root, action);
        }

        private void InOrder(BinaryNode<T> node, Action<T> action)
        {
            if (node == null) return;

            InOrder(node.Left, action);
            action(node.Value);
            InOrder(node.Right, action);
        }
    }

}