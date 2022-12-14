using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AdventOfCode2022.Tasks.Task11
{
    public class Number
    {
        private Int32 _value;
        public Int32 Value
        {
            get => _value;
            set =>_value = value % Divider;
        }
        public Int32 Divider { get; private set; }
        public Number(Int32 divider) => Divider = divider;
    }
}
