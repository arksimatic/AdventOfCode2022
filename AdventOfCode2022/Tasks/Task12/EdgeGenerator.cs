using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Tasks.Task12
{
    class EdgeGenerator
    {
        public static Edge[] GenerateEdges(Vertice[] vertices)
        {
            List<Edge> edges = new List<Edge>();
            
            foreach(var vertice in vertices)
            {
                Vertice aboveV = vertices.Where(ver => ver.PosX == vertice.PosX && ver.PosY == vertice.PosY + 1).FirstOrDefault();
                Vertice underV = vertices.Where(ver => ver.PosX == vertice.PosX && ver.PosY == vertice.PosY - 1).FirstOrDefault();
                Vertice rightV = vertices.Where(ver => ver.PosX == vertice.PosX + 1 && ver.PosY == vertice.PosY).FirstOrDefault();
                Vertice leftV = vertices.Where(ver => ver.PosX == vertice.PosX - 1 && ver.PosY == vertice.PosY).FirstOrDefault();

                if (aboveV != null && vertice.Level >= aboveV.Level - 1) edges.Add(new Edge(vertice, aboveV));
                if (underV != null && vertice.Level >= underV.Level - 1) edges.Add(new Edge(vertice, underV));
                if (rightV != null && vertice.Level >= rightV.Level - 1) edges.Add(new Edge(vertice, rightV));
                if (leftV != null && vertice.Level >= leftV.Level - 1) edges.Add(new Edge(vertice, leftV));
            }

            return edges.ToArray();
        }

        public static Edge[] GenerateEdgesReverted(Vertice[] vertices)
        {
            List<Edge> edges = new List<Edge>();

            foreach (var vertice in vertices)
            {
                Vertice aboveV = vertices.Where(ver => ver.PosX == vertice.PosX && ver.PosY == vertice.PosY + 1).FirstOrDefault();
                Vertice underV = vertices.Where(ver => ver.PosX == vertice.PosX && ver.PosY == vertice.PosY - 1).FirstOrDefault();
                Vertice rightV = vertices.Where(ver => ver.PosX == vertice.PosX + 1 && ver.PosY == vertice.PosY).FirstOrDefault();
                Vertice leftV = vertices.Where(ver => ver.PosX == vertice.PosX - 1 && ver.PosY == vertice.PosY).FirstOrDefault();

                if (aboveV != null && (vertice.Level <= aboveV.Level + 1 || (aboveV.Level == -1 && vertice.Level == 1))) edges.Add(new Edge(vertice, aboveV));
                if (underV != null && (vertice.Level <= underV.Level + 1 || (underV.Level == -1 && vertice.Level == 1))) edges.Add(new Edge(vertice, underV));
                if (rightV != null && (vertice.Level <= rightV.Level + 1 || (rightV.Level == -1 && vertice.Level == 1))) edges.Add(new Edge(vertice, rightV));
                if (leftV != null && (vertice.Level <= leftV.Level + 1 || (leftV.Level == -1 && vertice.Level == 1))) edges.Add(new Edge(vertice, leftV));
            }

            return edges.ToArray();
        }
    }
}
