using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Tasks.Task12
{
    class BFS
    {
        public static Edge[] FindShortestPath(Vertice[] vertices, Edge[] edges)
        {
            List<(Vertice vertice, Edge[] edges)> verticesWithPath = new List<(Vertice vertice, Edge[] edges)>();
            verticesWithPath.Add((vertices.Where(ver => ver.Level == -1).Single(), new Edge[0]));

            List<Vertice> verticesToVisit = new List<Vertice>();
            verticesToVisit.AddRange(vertices.Where(ver => ver.Level == -1));

            for (int i = 0; i < verticesToVisit.Count; i++)
            {
                List<Vertice> potentialVertices = edges
                    .Where(edge => verticesToVisit[i] == edge.StartVertice)
                    .Select(edge => edge.EndVertice)
                    .Where(vertice => !verticesWithPath.Select(vwp => vwp.vertice).Contains(vertice))
                    .ToList();

                foreach (var potentialVertice in potentialVertices)
                {
                    List<Edge> pathToVertice = verticesWithPath.Where(vwp => vwp.vertice == verticesToVisit[i]).Single().edges.ToList();
                    pathToVertice.Add(edges.Where(edge => edge.StartVertice == verticesToVisit[i] && edge.EndVertice == potentialVertice).Single());
                    verticesWithPath.Add((potentialVertice, pathToVertice.ToArray()));

                    if (potentialVertice.Level == 26)
                        return pathToVertice.ToArray();

                    if (!verticesToVisit.Contains(potentialVertice) || !verticesWithPath.Where(vwp => vwp.vertice == potentialVertice).Any())
                        verticesToVisit.Add(potentialVertice);
                }
            }

            return verticesWithPath.Where(vwp => vwp.vertice.Level == 26).Select(vwp => vwp.edges).Single();
        }

        public static Edge[] FindShortestPathBackward(Vertice[] vertices, Edge[] edges)
        {
            List<(Vertice vertice, Edge[] edges)> verticesWithPath = new List<(Vertice vertice, Edge[] edges)>();
            verticesWithPath.Add((vertices.Where(ver => ver.Level == 26).Single(), new Edge[0]));

            List<Vertice> verticesToVisit = new List<Vertice>();
            verticesToVisit.AddRange(vertices.Where(ver => ver.Level == 26));

            for (int i = 0; i < verticesToVisit.Count; i++)
            {
                List<Vertice> potentialVertices = edges
                    .Where(edge => verticesToVisit[i] == edge.StartVertice)
                    .Select(edge => edge.EndVertice)
                    .Where(vertice => !verticesWithPath.Select(vwp => vwp.vertice).Contains(vertice))
                    .ToList();

                foreach (var potentialVertice in potentialVertices)
                {
                    List<Edge> pathToVertice = verticesWithPath.Where(vwp => vwp.vertice == verticesToVisit[i]).Single().edges.ToList();
                    pathToVertice.Add(edges.Where(edge => edge.StartVertice == verticesToVisit[i] && edge.EndVertice == potentialVertice).Single());
                    verticesWithPath.Add((potentialVertice, pathToVertice.ToArray()));

                    if (potentialVertice.Level == 0 || potentialVertice.Level == -1)
                        return pathToVertice.ToArray();

                    if (!verticesToVisit.Contains(potentialVertice) || !verticesWithPath.Where(vwp => vwp.vertice == potentialVertice).Any())
                        verticesToVisit.Add(potentialVertice);
                }
            }

            return verticesWithPath.Where(vwp => vwp.vertice.Level == 26).Select(vwp => vwp.edges).Single();
        }
    }
}
