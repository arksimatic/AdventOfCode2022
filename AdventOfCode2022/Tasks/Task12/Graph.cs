using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Tasks.Task12
{
    public class Graph
    {
        public Vertice[] Vertices { get; private set; }
        public Edge[] Edges { get; private set; }
        public Graph(Vertice[] vertices)
        {
            Vertices = vertices;
            Edges = EdgeGenerator.GenerateEdges(vertices);
        }
    }
}
