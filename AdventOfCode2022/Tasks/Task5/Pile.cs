using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Tasks.Task5
{
    class Pile
    {
        private List<Char> _items = new List<Char>();
        public Int32 Id { get; private set; }
        public Char[] Items => _items.ToArray();
        public Pile(Int32 id) => Id = id;
        public void PutItemAtTop(Char item) => _items.Add(item);
        public Char PickUpTopItem()
        {
            Char item = _items.Last();
            _items.RemoveAt(_items.Count - 1);
            return item;
        }
    }
}
