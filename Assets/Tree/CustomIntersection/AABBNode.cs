using CustomIntersection;


namespace Tree { 
    public class AABBNode : TreeNode<AABB>
    {
        public AABBNode(AABB bounds) : base(bounds) 
        { 
        }

        public bool IsLeaf => Children.Count == 0;
    }
}