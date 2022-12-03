using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Tasks.Task3
{
    class Rucksack
    {
        public String Compartments { get; set; }
        public String Compartment1 { get => Compartments.Substring(0, Compartments.Length / 2); }
        public String Compartment2 { get => Compartments.Substring(Compartments.Length / 2, Compartments.Length / 2); }
        public Char Priority { get => Compartment1.Where(compartment => Compartment2.Contains(compartment)).ToList().First(); }
    }
}
