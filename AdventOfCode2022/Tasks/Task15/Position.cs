using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Tasks.Task15
{
    public class Position
    {
        public Int32 X { get; set; }
        public Int32 Y { get; set; }

        public Position(Int32 x, Int32 y)
        {
            X = x;
            Y = y;
        }
    }
}
