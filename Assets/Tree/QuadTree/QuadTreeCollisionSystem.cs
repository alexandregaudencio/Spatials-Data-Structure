using CustomIntersection;
using System.Collections.Generic;
using UnityEngine;
namespace QuadTree
{

    public class QuadTreeCollisionSytem
    {
        private Quadtree quadtree;

        public QuadTreeCollisionSytem(AABB bounds)
        {
            quadtree = new Quadtree(0, bounds);
        }

        public void AddObject(AABB aabb)
        {
            quadtree.Insert(aabb);
        }

        public List<AABB> CheckCollisions(AABB aabb)
        {
            var potentialCollisions = new List<AABB>();
            quadtree.Retrieve(potentialCollisions, aabb);

            var collisions = new List<AABB>();
            foreach (var other in potentialCollisions)
            {
                if (aabb.Intersects(other))
                {
                    collisions.Add(other);
                }
            }

            return collisions;
        }
    }

}
