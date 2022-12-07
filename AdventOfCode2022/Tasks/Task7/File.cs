using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Tasks.Task7
{
    class File
    {
        public Int32 Size { get; set; }
        public String Name { get; set; }

        public File(Int32 size, String name)
        {
            Size = size;
            Name = name;
        }
    }
}
