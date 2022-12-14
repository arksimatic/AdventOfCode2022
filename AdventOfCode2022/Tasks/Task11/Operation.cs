using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AdventOfCode2022.Tasks.Task11
{
    public class Operation
    {
        public OperationType OperationType { get; set; }
        public Int32? OperationValue { get; set; }
        public Int32 PerformOperation(Int32 number)
        {
            return OperationType switch
            {
                OperationType.Addition => number + (OperationValue ?? number),
                OperationType.Multiplication => number * (OperationValue ?? number),
                _ => number,
            };
        }
    }
}
