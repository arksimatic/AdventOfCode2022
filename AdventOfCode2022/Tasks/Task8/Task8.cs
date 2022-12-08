using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Tasks.Task8
{
    class Task8 : TaskBase
    {
        public override int TaskNumber => 8;

        public override void Solve()
        {
            // Get data
            Tree[] trees = LoadData();

            // First half
            Answer1 = trees.Where(tree => tree.IsVisible).Count().ToString();

            // Second half
            Answer2 = trees.Select(tree => tree.MultiplicationOfVisibleTrees).OrderByDescending(treeValue => treeValue).First().ToString();

            // Save data
            SaveData();
        }

        public Tree[] LoadData()
        {
            String[] splittedData = Data.Split("\r\n");

            Int32 rows = splittedData[0].Length;
            Int32 columns = splittedData.Length;

            List<Tree> trees = new List<Tree>();

            for(int row = 0; row < rows; row++)
            {
                for(int col = 0; col < columns; col++)
                {
                    (Int32 row, Int32 col) position = (row, col);

                    List<Int32> left = new List<Int32>();
                    for (int l = position.col - 1; l >= 0; l--)
                        left.Add(splittedData[position.row][l]);

                    List<Int32> right = new List<Int32>();
                    for (int r = position.col + 1; r < columns; r++)
                        right.Add(splittedData[position.row][r]);

                    List<Int32> up = new List<Int32>();
                    for (int u = position.row - 1; u >= 0; u--)
                        up.Add(splittedData[u][position.col]);

                    List<Int32> down = new List<Int32>();
                    for (int d = position.row + 1; d < rows; d++)
                        down.Add(splittedData[d][position.col]);

                    trees.Add(new Tree()
                    {
                        Height = Convert.ToInt32(splittedData[position.row][position.col]),
                        TreesOnLeftHeights = left.ToArray(),
                        TreesOnRightHeights = right.ToArray(),
                        TreesOnUpHeights = up.ToArray(),
                        TreesOnDownHeights = down.ToArray()
                    });
                }
            }

            return trees.ToArray();
        }
    }
}
