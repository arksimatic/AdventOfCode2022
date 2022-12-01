using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Tasks.Task1
{
    public class Elf
    {
        public Int32[] FoodPackages { get; set; }
        public Int32 TotalFood 
        { 
            get { return FoodPackages.Sum(); }
        }
    }
}
