using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Tasks.Task10
{
    public class Instruction
    {
        public InstructionType InstructionType { get; set; }
        public Int32 Cycles { get; set; } = 1;
        public Int32? NumberToAdd { get; set; }
    }
}
