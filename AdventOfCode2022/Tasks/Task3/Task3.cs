using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022.Tasks.Task3
{
    class Task3 : TaskBase
    {
        public override int TaskNumber => 3;

        public override void Solve()
        {
            //Get data
            Rucksack[] rucksacks = ParseData();

            //First half
            Answer1 = rucksacks.Select(ruc => PriorityHelper.GetPriorityFromChar(ruc.Priority)).Sum().ToString();

            //Second half
            Answer2 = GroupBy3(rucksacks).Select(ruckGroup => PriorityHelper.GetPriorityFromChar(FindCommonItem(ruckGroup))).Sum().ToString();

            // Save answer
            SaveData();
        }

        public Rucksack[] ParseData()
        {
            List<Rucksack> rucksacks = new List<Rucksack>();

            Data.Split("\r\n").ToList().ForEach(line => 
            {
                rucksacks.Add(new Rucksack()
                {
                    Compartments = line
                });
            });

            return rucksacks.ToArray();
        }

        public Rucksack[][] GroupBy3(Rucksack[] rucksacks)
        {
            List<Rucksack[]> rucksackGroup = new List<Rucksack[]>();

            for(int i = 0; i < rucksacks.Length; i += 3)
                rucksackGroup.Add(new Rucksack[] { rucksacks[i], rucksacks[i + 1], rucksacks[i + 2] });

            return rucksackGroup.ToArray();
        }

        public Char FindCommonItem(Rucksack[] rucksacks)
        {
            foreach(var item in PriorityHelper.PriorityItems)
            {
                if (rucksacks.Where(ruck => ruck.Compartments.Contains(item)).ToList().Count == rucksacks.Length)
                    return item;
            }

            return default;
        }
    }
}
