using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumCostSpan
{
    class Edge : IComparable<Edge>
    {
        public int Source;
        public int Destination;
        public int Weight;

        public Edge()
        {

        }
        public Edge(int Source,int Destination, int Weight)
        {
            this.Destination = Destination;
            this.Weight = Weight;
            this.Source = Source;
        }

        

        public int CompareTo(Edge other)
        {
            if (other == null)
                return 1;
            //return this.Weight - other.Weight;
            return Comparer<int>.Default.Compare(this.Weight, other.Weight);
        }
    }
}
