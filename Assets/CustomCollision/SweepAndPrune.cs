using CustomIntersection;
using System.Collections.Generic;

namespace SweepAndPrune
{
    public class SweepAndPrune
    {
        private List<SapEntry> entries = new();

        public void Add(AABB box, object userData)
        {
            entries.Add(new SapEntry { Box = box, UserData = userData });
        }

        public List<(object, object)> ComputePairs()
        {
            List<(object, object)> pairs = new();

            // Ordena por Min.x (sweep no eixo X)
            entries.Sort((a, b) => a.Box.Min.X.CompareTo(b.Box.Min.X));

            for (int i = 0; i < entries.Count; i++)
            {
                var a = entries[i];
                for (int j = i + 1; j < entries.Count; j++)
                {
                    var b = entries[j];

                    // Early exit: se b.Min.x > a.Max.x, não há interseção no eixo X
                    if (b.Box.Min.X> a.Box.Max.X)
                        break;

                    // Verifica colisão completa em 3D (Narrow check)
                    if (a.Box.Intersects(b.Box))
                    {
                        pairs.Add((a.UserData, b.UserData));
                    }
                }
            }

            return pairs;
        }
    }

}