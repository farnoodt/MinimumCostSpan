using System;

namespace MinimumCostSpan
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph G = new Graph(5);
            G.AddEdge(0, 1, 10);
            G.AddEdge(0, 2, 6);
            G.AddEdge(0, 3, 5);
            G.AddEdge(1, 3, 15);
            G.AddEdge(2, 3, 4);
            G.AddEdge(2, 4, 1);

            G.KruskalMST();
            Console.WriteLine();
            Console.ReadLine();

        }
    }
}
