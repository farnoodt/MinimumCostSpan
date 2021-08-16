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

        public int FindParent(Subset[] Subsets, int i)
        {
            if (Subsets[i].Parent != i)
                Subsets[i].Parent = FindParent(Subsets, Subsets[i].Parent);

            return Subsets[i].Parent;

        }

        public void Union(Subset[] subsets, int X, int Y)
        {
            int xRoot = FindParent(subsets, X);
            int yRoot = FindParent(subsets, Y);

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
