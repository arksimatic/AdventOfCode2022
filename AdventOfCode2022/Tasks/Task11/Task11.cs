using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2022.Tasks.Task11
{
    class Task11 : TaskBase
    {
        public override int TaskNumber => 11;

        public override void Solve()
        {
            // Get data
            Monkey[] monkeys = LoadData();

            // First half
            foreach (var monkey in monkeys)
            {
                foreach (var item in monkey.Items)
                    item.SetMonkeyDividers(monkeys.Select(monkey => monkey.Test.DivisibleBy).ToArray());
            }

            for (int i = 0; i < 20; i++)
            {
                foreach (var monkey in monkeys)
                    monkey.MakeTurn();
            }

            Answer1 = monkeys.Select(monkey => monkey.InspectCounter).OrderByDescending(counter => counter).Take(2).Aggregate(1, (x, y) => x * y).ToString();

            // Second half
            monkeys = LoadData();
            foreach(var item in monkeys.SelectMany(monkey => monkey.Items))
                    item.SetMonkeyDividers(monkeys.Select(monkey => monkey.Test.DivisibleBy).ToArray());

            for (int i = 0; i < 10_000; i++)
            {
                foreach (var monkey in monkeys)
                    monkey.MakeTurnWithoutDecreasingWorryLevel();
            }

            Int32[] best2MonkeyCounters = monkeys.Select(monkey => monkey.InspectCounter).OrderByDescending(counter => counter).Take(2).ToArray();
            Answer2 = ((BigInteger)best2MonkeyCounters[0] * (BigInteger)best2MonkeyCounters[1]).ToString();

            // Save answer
            SaveData();
        }

        private Monkey[] LoadData()
        {
            List<Monkey> monkeys = new List<Monkey>();

            foreach(var monkeyInfo in Data.Split("\r\n\r\n"))
            {
                String[] lines = monkeyInfo.Split("\r\n");

                monkeys.Add(new Monkey(lines[1].Substring(18).Split(", ").Select(num => (Int32)Convert.ToInt32(num)).ToArray())
                {
                    Id = Convert.ToInt32(lines[0].Split(" ")[1].First().ToString()),
                    Operation = new Operation()
                    {
                        OperationType = lines[2].Substring(23).Split(" ")[0][0] == '*' ? OperationType.Multiplication : OperationType.Addition,
                        OperationValue = Int32.TryParse(lines[2].Substring(23).Split(" ")[1], out _) ? (Int32?)Convert.ToInt32(lines[2].Substring(23).Split(" ")[1]) : null
                    },
                    Test = new Test()
                    {
                        DivisibleBy = (Int32)Convert.ToInt32(lines[3].Split(" ").Last()),
                        MonkeyIdIfTrue = Convert.ToInt32(lines[4].Split(" ").Last()),
                        MonkeyIdIfFalse = Convert.ToInt32(lines[5].Split(" ").Last()),
                    }
                });
             }

            foreach (var monkey in monkeys)
                monkey.AllMonkeys = monkeys;

            return monkeys.ToArray();
        }
    }
}
