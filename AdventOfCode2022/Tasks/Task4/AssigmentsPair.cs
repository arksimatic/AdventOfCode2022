using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Tasks.Task4
{
    class AssigmentsPair
    {
        public Assignments FirstAssigmnets { get; set; }
        public Assignments SecondAssigments { get; set; }
        public Boolean FullyOverlapping 
        { 
            get => 
                !FirstAssigmnets.AllAssigments.
                Except(SecondAssigments.AllAssigments)
                .Any() || 
                !SecondAssigments.AllAssigments
                .Except(FirstAssigmnets.AllAssigments)
                .Any();
        }
        public Boolean PartiallyOveralpping 
        { 
            get => 
                FirstAssigmnets.AllAssigments
                .Intersect(SecondAssigments.AllAssigments)
                .Any() || 
                SecondAssigments.AllAssigments
                .Intersect(FirstAssigmnets.AllAssigments)
                .Any();
        }
    }
}
