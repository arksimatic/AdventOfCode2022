using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Tasks.Task12
{
    public class Edge
    {
        public Vertice StartVertice { get; set; }
        public Vertice EndVertice { get; set; }
        public Edge(Vertice startVertice, Vertice endVertice)
        {
            StartVertice = startVertice;
            EndVertice = endVertice;    
        }
    }
}
