
using System;
using System.Collections.Generic;

namespace Tree { 
	public class TreeNode<T>
	{
		public T Data;
		public TreeNode<T> Parent;
		public List<TreeNode<T>> Children = new();

		public TreeNode(T data) 
		{
			Data = data;
		}

		public TreeNode<T> AddChild(T data)
		{
			var node = new TreeNode<T>(data) { Parent = this };
			Children.Add(node);
			return node;
		}

		public bool RemoveChild(TreeNode<T> child)
		{
			return Children.Remove(child);
		}

		public void Traverse(Action<TreeNode<T>> visitor)
		{
			visitor(this);
			foreach (var child in Children)
			{
				child.Traverse(visitor);
			}
		}

		public TreeNode<T>? Find(Predicate<TreeNode<T>> match)
		{
			if (match(this)) return this;
			foreach (var child in Children)
			{
				var found = child.Find(match);
				if (found != null) return found;
			}
			return null;
		}
	}
}
