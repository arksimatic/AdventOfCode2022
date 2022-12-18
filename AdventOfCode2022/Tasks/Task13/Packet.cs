using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Tasks.Task13
{
    class Packet
    {
        public Int32? Value { get; set; }
        public Packet[] Childs { get; set; } = Array.Empty<Packet>();
    }
}
