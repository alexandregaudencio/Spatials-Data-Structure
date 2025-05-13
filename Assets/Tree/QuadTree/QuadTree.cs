using CustomIntersection;
using System.Collections.Generic;
using System.Numerics;

namespace QuadTree { 
public class Quadtree
{
    private const int MaxObjects = 10;
    private const int MaxLevels = 5;
    private int level;
    private List<AABB> objects;
    private AABB bounds;
    private Quadtree[] nodes;

    public Quadtree(int level, AABB bounds)
    {
        this.level = level;
        this.bounds = bounds;
        objects = new List<AABB>();
        nodes = new Quadtree[4];
    }

    private void Split()
    {
        float subWidth = bounds.Max.X - bounds.Min.X;
        float subHeight = bounds.Max.Y - bounds.Min.Y;
        float x = bounds.Min.X;
        float y = bounds.Min.Y;

        nodes[0] = new Quadtree(level + 1, new AABB(new Vector3(x + subWidth / 2, y,0), new Vector3(x + subWidth, y + subHeight / 2,0)));
        nodes[1] = new Quadtree(level + 1, new AABB(new Vector3(x, y,0), new Vector3(x + subWidth / 2, y + subHeight / 2,0)));
        nodes[2] = new Quadtree(level + 1, new AABB(new Vector3(x, y + subHeight / 2,0), new Vector3(x + subWidth / 2, y + subHeight,0)));
        nodes[3] = new Quadtree(level + 1, new AABB(new Vector3(x + subWidth / 2, y + subHeight / 2,0), new Vector3(x + subWidth, y + subHeight,0)));
    }

    public void Insert(AABB aabb)
    {
        if (nodes[0] != null)
        {
            int index = GetIndex(aabb);
            if (index != -1)
            {
                nodes[index].Insert(aabb);
                return;
            }
        }

        objects.Add(aabb);

        if (objects.Count > MaxObjects && level < MaxLevels)
        {
            if (nodes[0] == null) Split();

            int i = 0;
            while (i < objects.Count)
            {
                int index = GetIndex(objects[i]);
                if (index != -1)
                {
                    nodes[index].Insert(objects[i]);
                    objects.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }
    }

    private int GetIndex(AABB aabb)
    {
        int index = -1;
        float verticalMidpoint = bounds.Min.X + (bounds.Max.X - bounds.Min.X) / 2;
        float horizontalMidpoint = bounds.Min.Y + (bounds.Max.Y - bounds.Min.Y) / 2;

        bool topQuadrant = (aabb.Min.Y < horizontalMidpoint && aabb.Max.Y < horizontalMidpoint);
        bool bottomQuadrant = (aabb.Min.Y > horizontalMidpoint);

        if (aabb.Min.X < verticalMidpoint && aabb.Max.X < verticalMidpoint)
        {
            if (topQuadrant) index = 1;
            else if (bottomQuadrant) index = 2;
        }
        else if (aabb.Min.X > verticalMidpoint)
        {
            if (topQuadrant) index = 0;
            else if (bottomQuadrant) index = 3;
        }

        return index;
    }

    public List<AABB> Retrieve(List<AABB> returnObjects, AABB aabb)
    {
        int index = GetIndex(aabb);
        if (index != -1 && nodes[0] != null)
        {
            nodes[index].Retrieve(returnObjects, aabb);
        }

        returnObjects.AddRange(objects);
        return returnObjects;
    }
}
}
    