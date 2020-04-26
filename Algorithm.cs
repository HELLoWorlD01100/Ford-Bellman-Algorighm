using System;
using System.Collections.Generic;
using System.Linq;


namespace Ford_Bellman
{
    public class Edge
    {
        public int From, To;
        public int Cost;
    }
    class Program
    {
        public static void Main()
        {
            var graph = new List<Edge>
            {
                new Edge {From = 0, To = 1, Cost = 2},
                new Edge {From = 0, To = 2, Cost = 5},
                new Edge {From = 2, To = 1, Cost = -4},
                new Edge {From = 1, To = 3, Cost = 3},
                new Edge {From = 1, To = 4, Cost = 2},
                new Edge {From = 3, To = 4, Cost = 1}
            };
        }

        public static int GetMinPathCost(List<Edge> edges, int startNode, int finalNode)
        {
            var maxNodeIndex =
                edges.SelectMany(e => new[] { e.From, e.To })
                    .Concat(new[] { startNode, finalNode })
                    .Max();
            var opt = Enumerable.Repeat(int.MaxValue, maxNodeIndex + 1).ToArray();
            opt[startNode] = 0;

            for (var pathSize = 1; pathSize <= maxNodeIndex; pathSize++)
                foreach (var edge in edges.Where(edge => opt[edge.From] != int.MaxValue))
                    opt[edge.To] = opt[edge.From] + edge.Cost < opt[edge.To] ? opt[edge.From] + edge.Cost : opt[edge.To];
            return opt[finalNode];
        }
    }
}
