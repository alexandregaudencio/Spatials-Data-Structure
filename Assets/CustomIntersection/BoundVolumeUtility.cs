

using System.Numerics;


namespace CustomIntersection 
{
     public static class BoundVolumeUtility
    {
        public static AABB MergeBounds(AABB a, AABB b)
        {
            return new AABB(Vector3.Min(a.Min, b.Min), Vector3.Max(a.Max, b.Max));
        }


    }
}