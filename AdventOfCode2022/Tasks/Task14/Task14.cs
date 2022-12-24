using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Tasks.Task14
{
    class Task14 : TaskBase
    {
        public override int TaskNumber => 14;

        public override void Solve()
        {
            // Get data
            BlockType[][] data = LoadData();

            // First half
            data = SandManager.FillWithSand(data);
            Answer1 = data
                .SelectMany(array => array)
                .Where(element => element == BlockType.Sand)
                .Count()
                .ToString();

            // Second half
            BlockType[][] data2 = LoadData2();
            data2 = SandManager.FillWithSandWithInfiniteFloor(data2, out Int32 outOfBoundarySandAmount);
            Answer2 = (data2
                .SelectMany(array => array)
                .Where(element => element == BlockType.Sand)
                .Count() 
                + outOfBoundarySandAmount)
                .ToString();

            // Save answer
             SaveData();
        }

        public BlockType[][] LoadData()
        {
            BlockType[][] grid = new BlockType[1000][];
            for (int i = 0; i < 1000; i++)
                grid[i] = new BlockType[1000];

            foreach (var line in Data.Split("\r\n"))
            {
                List<(Int32 x, Int32 y)> positions = new List<(Int32 x, Int32 y)>();
                foreach(var position in line.Split(" -> "))
                    positions.Add((Convert.ToInt32(position.Split(",")[0]), Convert.ToInt32(position.Split(",")[1])));
                    
                (Int32 x, Int32 y)? previousPosition = null;
                foreach(var position in positions)
                {
                    if(previousPosition != null)
                    {
                        if(position.y == previousPosition.Value.y)
                        {
                            for (int i = Math.Min(position.x, previousPosition.Value.x); i < Math.Max(position.x, previousPosition.Value.x) + 1; i++)
                                grid[i][position.y] = BlockType.Rock;
                        }

                        if (position.x == previousPosition.Value.x)
                        {
                            for (int i = Math.Min(position.y, previousPosition.Value.y); i < Math.Max(position.y, previousPosition.Value.y) + 1; i++)
                                grid[position.x][i] = BlockType.Rock;
                        }
                    }

                    previousPosition = position;
                }

                for(int i = 0; i < 1000; i++)
                {
                    grid[999][i] = BlockType.Void;
                    grid[i][999] = BlockType.Void;
                }

                grid[500][0] = BlockType.SandGenerator;
            }

            return grid;
        }

        public BlockType[][] LoadData2()
        {
            List<Int32> heights = new List<Int32>();
            foreach (var line in Data.Split("\r\n"))
            {
                foreach (var position in line.Split(" -> "))
                    heights.Add(Convert.ToInt32(position.Split(",")[1]));
            }

            var grid = LoadData();
            for (int i = 0; i < grid[999].Length; i++)
                grid[i][heights.Max() + 2] = BlockType.Rock;

            return grid;
        }
    }
}
