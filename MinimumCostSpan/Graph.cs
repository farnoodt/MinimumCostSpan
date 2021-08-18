using System;
using System.Collections.Generic;



namespace MinimumCostSpan
{
    class Graph
    {
        List<Edge> MyGraph = new List<Edge>();
        public int Node;
        public Graph(int N)
        {
            this.Node = N;
        }

        public void AddEdge( int Source, int Destination, int Weight)
        {
            MyGraph.Add(new Edge(Source, Destination, Weight));
        }

        public void KruskalMST()
        {
            List<Edge> result = new List<Edge>();
            Subset S = new Subset();
            Subset[] subsets = new Subset[Node];

            MyGraph.Sort();
            
            for (int i = 0; i < Node; ++i)
            {
                subsets[i] = new Subset();
                subsets[i].Parent = i;
                subsets[i].Rank = 0;
            }

            for (int i = 0; i < MyGraph.Count; i++)
            {
                // Step 2: Pick the smallest edge. And increment the index for next iteration 
                Edge next_edge = new Edge();
                next_edge = MyGraph[i];

                int x = S.FindParent(subsets, next_edge.Source);
                int y = S.FindParent(subsets, next_edge.Destination);

                // If including this edge does't cause cycle, include it in result and increment the index of result for next edge 
                if (x != y)
                {
                    result.Add(next_edge);
                    S.Union(subsets, x, y);
                }
            }

            for (int i = 0; i < result.Count; ++i)
                Console.WriteLine(result[i].Source + " -- " + result[i].Destination + " == " + result[i].Weight);
            Console.ReadLine();
        }
    }
}
