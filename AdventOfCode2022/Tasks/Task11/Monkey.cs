using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace AdventOfCode2022.Tasks.Task11
{
    class Monkey
    {
        private List<Item> _items = new List<Item>();
        private List<Int32> _itemsRaw = new List<Int32>();
        public Int32[] ItemsRaw => _itemsRaw.ToArray();
        public Item[] Items => _items.ToArray();
        public Int32 Id { get; set; }
        public Operation Operation { get; set; }
        public Test Test { get; set; }
        public Int32 InspectCounter { get; private set; } = 0;
        public List<Monkey> AllMonkeys { get; set; }
        public Monkey(Int32[] startingNumbers)
        {
            foreach (var number in startingNumbers)
            {
                _items.Add(new Item(number));
                _itemsRaw.Add(number);
            }
        }
        public void MakeTurn()
        {
            foreach (var item in _itemsRaw)
            {
                InspectCounter++;
                var newItem = Operation.PerformOperation(item);
                newItem /= 3;
                Int32 monkeyToThrow = Test.TestDivisibleReturnMonkeyId(newItem);
                AllMonkeys.Where(monkey => monkey.Id == monkeyToThrow).First().GiveItem(newItem);
            }
            _itemsRaw = new List<Int32>();
        }
        public void MakeTurnWithoutDecreasingWorryLevel()
        {
            foreach (var item in _items)
            {
                InspectCounter++;
                item.PerformOperation(Operation);
                Int32 monkeyToThrow = Test.TestDivisibleReturnMonkeyId(item.NumberModulos.Where(num => num.Divider == Test.DivisibleBy).Select(num => num.Value).First());
                AllMonkeys.Where(monkey => monkey.Id == monkeyToThrow).First().GiveItem(item);
            }
            _items = new List<Item>();
        }
        public void GiveItem(Int32 rawItem) => _itemsRaw.Add(rawItem);
        public void GiveItem(Item item) => _items.Add(item);
    }
}
