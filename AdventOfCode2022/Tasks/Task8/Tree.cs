using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Tasks.Task8
{
    class Tree
    {
        public Int32 Height { get; set; }
        public Int32[] TreesOnLeftHeights { get; set; }
        public Int32[] TreesOnRightHeights { get; set; }
        public Int32[] TreesOnUpHeights { get; set; }
        public Int32[] TreesOnDownHeights { get; set; }

        public Boolean IsVisibleFromLeft => !TreesOnLeftHeights.Where(height => height >= Height).Any();
        public Boolean IsVisibleFromRight => !TreesOnRightHeights.Where(height => height >= Height).Any();
        public Boolean IsVisibleFromUp => !TreesOnUpHeights.Where(height => height >= Height).Any();
        public Boolean IsVisibleFromDown => !TreesOnDownHeights.Where(height => height >= Height).Any();
        public Boolean IsVisible => IsVisibleFromLeft || IsVisibleFromRight || IsVisibleFromUp || IsVisibleFromDown;

        public Int32 VisibleTreesOnLeft => VisibleTreesInDirection(TreesOnLeftHeights);
        public Int32 VisibleTreesOnRight => VisibleTreesInDirection(TreesOnRightHeights);
        public Int32 VisibleTreesOnUp => VisibleTreesInDirection(TreesOnUpHeights);
        public Int32 VisibleTreesOnDown => VisibleTreesInDirection(TreesOnDownHeights);
        public Int32 MultiplicationOfVisibleTrees => VisibleTreesOnLeft * VisibleTreesOnRight * VisibleTreesOnUp * VisibleTreesOnDown;

        public Int32 VisibleTreesInDirection(Int32[] trees)
        {
            Int32 visibleTrees = 0;
            foreach (var tree in trees)
            {
                visibleTrees++;
                if (tree >= Height)
                    break;
            }

            return visibleTrees;
        }   
    }
}
