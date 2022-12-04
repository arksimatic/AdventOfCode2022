using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Tasks.Task4
{
    class Assignments
    {
        public Int32 StartAssignment { get; set; }
        public Int32 EndAssignment { get; set; }
        public Int32[] AllAssigments { get => Enumerable.Range(StartAssignment, EndAssignment - StartAssignment + 1).ToArray(); }
    }
}
