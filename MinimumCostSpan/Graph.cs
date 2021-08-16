using System;
using System.Collections.Generic;



namespace MinimumCostSpan
{
    class Graph
    {
        List<Edge> MyGraph = new List<Edge>();
        public int Edge;
        public int Node;
        public Graph(int N, int E)
        {
            this.Edge = E;
            this.Node = N;
            for (int i = 0; i < Edge; i++)
                MyGraph.Add(new Edge());
        }

        public void AddEdge(int Edge ,int Source, int Destination, int Weight)
        {
            MyGraph[Edge].Destination = Destination;
            MyGraph[Edge].Weight = Weight;
            MyGraph[Edge].source = Source;
        }
         
        public void KruskalMST()
        {
            int i = 0;
            int e = 0;
            Edge[] result = new Edge[Node];
            for (i = 0; i < Node; ++i)
                result[i] = new Edge();
            Subset S = new Subset();
            MyGraph.Sort();

            Subset[] subsets = new Subset[Node];
            for (i = 0; i < Node; ++i)
                subsets[i] = new Subset();


            for (int v = 0; v < Node; ++v)
            {
                subsets[v].Parent = v;
                subsets[v].Rank = 0;
            }

            i = 0; // Index used to pick next edge 

            while(e < Node - 1)
            {
                // Step 2: Pick the smallest edge. And increment 
                // the index for next iteration 
                Edge next_edge = new Edge();
                next_edge = MyGraph[i++];

                int x = S.Find(subsets, next_edge.source);
                int y = S.Find(subsets, next_edge.Destination);

                // If including this edge does't cause cycle, 
                // include it in result and increment the index 
                // of result for next edge 
                if (x != y)
                {
                    result[e++] = next_edge;
                    S.Union(subsets, x, y);
                }
            }
            for (i = 0; i < e; ++i)
                Console.WriteLine(result[i].source + " -- " +
                result[i].Destination + " == " + result[i].Weight);
            Console.ReadLine();
        }
    }
}
