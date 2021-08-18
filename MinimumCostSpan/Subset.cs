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
            int xParent = FindParent(subsets, X);
            int yParent = FindParent(subsets, Y);

            if (subsets[xParent].Rank > subsets[yParent].Rank)
                subsets[yParent].Parent = xParent;
            else if (subsets[xParent].Rank < subsets[yParent].Rank)
                subsets[xParent].Parent = yParent;
            else
            {
                subsets[yParent].Parent = xParent;
                subsets[xParent].Rank++;
            }
        }
    }
}
