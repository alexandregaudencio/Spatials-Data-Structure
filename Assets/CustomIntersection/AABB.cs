using System.Numerics;

namespace CustomIntersection
{
    // A simple Axis-Aligned Bounding Box (AABB) class for 2D space.
    // It defines a rectangle by its minimum and maximum corners.
    public class AABB
    {
        public Vector3 Min { get; private set; }
        public Vector3 Max { get; private set; }

        public AABB(Vector3 min, Vector3 max)
        {
            Min = min;
            Max = max;
        }

        public bool Intersects(AABB other)
        {
            return Max.X > other.Min.X && Min.X < other.Max.X &&
                   Max.Y > other.Min.Y && Min.Y < other.Max.Y &&
                   Max.Z > other.Min.Z && Min.Z < other.Max.Z;
        }


        public bool Contains(Vector3 point)
        {
            return point.X >= Min.X && point.X <= Max.X &&
                   point.Y >= Min.Y && point.Y <= Max.Y &&
                   point.Z >= Min.Z && point.Z <= Max.Z;
        }
    }
}

