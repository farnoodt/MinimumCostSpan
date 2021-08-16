using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumCostSpan
{
    public class Subset
    {
        public int Parent;
        public int Rank;

        public int Find(Subset[] Subsets, int i)
        {
            if (Subsets[i].Parent != i)
                Subsets[i].Parent = Find(Subsets, Subsets[i].Parent);

            return Subsets[i].Parent;

        }

        public void Union(Subset[] subsets, int X, int Y)
        {
            int xRoot = Find(subsets, X);
            int yRoot = Find(subsets, Y);

            if (subsets[xRoot].Rank > subsets[yRoot].Rank)
                subsets[yRoot].Parent = xRoot;
            else if (subsets[xRoot].Rank < subsets[yRoot].Rank)
                subsets[xRoot].Parent = yRoot;
            else
            {
                subsets[yRoot].Parent = xRoot;
                subsets[xRoot].Rank++;
            }
        }
    }
}
