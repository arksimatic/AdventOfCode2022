using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Tasks.Task3
{
    class PriorityHelper
    {
        public static Int32 GetPriorityFromChar(Char priorityChar) => Char.IsUpper(priorityChar) ? (Int32)priorityChar - 38 : (Int32)priorityChar - 96;
        public static String PriorityItems => "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    }
}
