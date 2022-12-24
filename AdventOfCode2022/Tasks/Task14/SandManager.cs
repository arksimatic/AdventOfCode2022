using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Tasks.Task14
{
    class SandManager
    {
        public static BlockType[][] FillWithSand(BlockType[][] grid)
        {
            while(grid[500][1] == BlockType.Air)
            {
                (Int32 x, Int32 y) newPosition = (500, 1);
                while (true)
                {
                    if (newPosition.y == 999 || newPosition.x == 0 || newPosition.x == 999)
                        break;

                    if (grid[newPosition.x][newPosition.y + 1] == BlockType.Air || grid[newPosition.x][newPosition.y + 1] == BlockType.Void)
                    {
                        newPosition = (newPosition.x, newPosition.y + 1);
                        continue;
                    }
                    else if (grid[newPosition.x - 1][newPosition.y + 1] == BlockType.Air || grid[newPosition.x - 1][newPosition.y + 1] == BlockType.Void)
                    {
                        newPosition = (newPosition.x - 1, newPosition.y + 1);
                        continue;
                    }
                    else if (grid[newPosition.x + 1][newPosition.y + 1] == BlockType.Air || grid[newPosition.x + 1][newPosition.y + 1] == BlockType.Void)
                    {
                        newPosition = (newPosition.x + 1, newPosition.y + 1);
                        continue;
                    }
                    else
                        break;
                }
                if (grid[newPosition.x][newPosition.y] == BlockType.Void)
                    break;
                else
                    grid[newPosition.x][newPosition.y] = BlockType.Sand;
            }

            return grid;
        }

        public static BlockType[][] FillWithSandWithInfiniteFloor(BlockType[][] grid, out Int32 outOfBoundarySandAmount)
        {
            // Out of boundary sand was meant to calculate all the sand that goes outside primary grid, but it wasn't actually needed
            outOfBoundarySandAmount = 0;
            while (grid[500][0] == BlockType.SandGenerator)
            {
                (Int32 x, Int32 y) newPosition = (500, 0);
                while (true)
                {
                    if (newPosition.y == 999)
                        break;

                    if (newPosition.x == 0 || newPosition.x == 999)
                    {
                        outOfBoundarySandAmount += (999 - newPosition.y);
                        break;
                    }
                    else if (grid[newPosition.x][newPosition.y + 1] == BlockType.Air || grid[newPosition.x][newPosition.y + 1] == BlockType.Void)
                    {
                        newPosition = (newPosition.x, newPosition.y + 1);
                        continue;
                    }
                    else if (grid[newPosition.x - 1][newPosition.y + 1] == BlockType.Air || grid[newPosition.x - 1][newPosition.y + 1] == BlockType.Void)
                    {
                        newPosition = (newPosition.x - 1, newPosition.y + 1);
                        continue;
                    }
                    else if (grid[newPosition.x + 1][newPosition.y + 1] == BlockType.Air || grid[newPosition.x + 1][newPosition.y + 1] == BlockType.Void)
                    {
                        newPosition = (newPosition.x + 1, newPosition.y + 1);
                        continue;
                    }
                    else
                        break;
                }
                if (grid[newPosition.x][newPosition.y] == BlockType.Void)
                    break;
                if (grid[newPosition.x][newPosition.y] == BlockType.SandGenerator)
                {
                    grid[newPosition.x][newPosition.y] = BlockType.Sand;
                    break;
                }
                else
                    grid[newPosition.x][newPosition.y] = BlockType.Sand;
            }

            return grid;
        }
    }
}
