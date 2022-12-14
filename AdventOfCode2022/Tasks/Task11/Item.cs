using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AdventOfCode2022.Tasks.Task11
{
    class Item
    {
        private Int32 _startingValue { get; set; }
        public Int32 StartingValue => _startingValue;
        public Number[] NumberModulos { get; set; }
        public Item(Int32 number) => _startingValue = number;
        public void SetMonkeyDividers(Int32[] monkeyDividers)
        {
            List<Number> numbers = new List<Number>();
            foreach(var divider in monkeyDividers)
            {
                Number newNumber = new Number(divider);
                newNumber.Value = _startingValue;
                numbers.Add(newNumber);
            }
            NumberModulos = numbers.ToArray();
        }
        public void PerformOperation(Operation operation)
        {
            foreach (var number in NumberModulos)
                number.Value = operation.PerformOperation(number.Value);
        }
    }
}
