using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AdventOfCode2022.Tasks.Task11
{
    public class Test
    {
        public Int32 DivisibleBy { get; set; }
        public Int32 MonkeyIdIfTrue { get; set; }
        public Int32 MonkeyIdIfFalse { get; set; }
        public Int32 TestDivisibleReturnMonkeyId(Int32 number) => number % DivisibleBy == 0 ? MonkeyIdIfTrue : MonkeyIdIfFalse;
    }
}
