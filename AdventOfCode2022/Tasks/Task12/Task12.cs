using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Tasks.Task12
{
    class Task12 : TaskBase
    {
        public override int TaskNumber => 12;

        public override void Solve()
        {
            // Get data
            Vertice[] vertices = LoadData();
            Edge[] edges = EdgeGenerator.GenerateEdges(vertices);

            // First half
            Answer1 = BFS.FindShortestPath(vertices, edges).Length.ToString();

            // Second half
            Edge[] edgesRevert = EdgeGenerator.GenerateEdgesReverted(vertices);
            Answer2 = BFS.FindShortestPathBackward(vertices, edgesRevert).Length.ToString();

            // Save answer
            SaveData();
        }

        public Vertice[] LoadData()
        {
            List<Vertice> vertices = new List<Vertice>();

            var lines = Data.Split("\r\n");
            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[0].Length; x++)
                {
                    vertices.Add(new Vertice()
                    {
                        PosX = x,
                        PosY = y,
                        Level = (Int32)lines[y][x] switch 
                        { 
                            'S' => -1,
                            'E' =>26,
                            _ => (Int32)lines[y][x] - 97
                        }
                    });
                }
            }
            return vertices.ToArray();
        }
    }
}
