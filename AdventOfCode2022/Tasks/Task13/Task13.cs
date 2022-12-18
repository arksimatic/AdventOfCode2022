using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Tasks.Task13
{
    class Task13 : TaskBase
    {
        public override int TaskNumber => 13;

        public override void Solve()
        {
            // Get data
            (Packet first, Packet second)[] packetPair = LoadData1();

            // First half
            Int32 sumOfPairsWithWrongOrder = 0;
            for(int i = 0; i < packetPair.Length; i++)
            {
                if (PacketManager.IsCorrectOrder(packetPair[i].first, packetPair[i].second) != OrderStatus.WrongOrder)
                    sumOfPairsWithWrongOrder += (i + 1);
            }
            Answer1 = sumOfPairsWithWrongOrder.ToString();

            // Second half
            Packet addinationalItem1 = new Packet { Childs = new Packet[] { new Packet { Childs = new Packet[] { new Packet { Value = 2 } } } } };
            Packet addinationalItem2 = new Packet { Childs = new Packet[] { new Packet { Childs = new Packet[] { new Packet { Value = 6 } } } } };
            List<Packet> packages = LoadData2().ToList();
            packages.AddRange(new Packet[] { addinationalItem1, addinationalItem2 });
            List<Packet> packagesInOrder = PacketManager.CorrectOrder(packages.ToArray()).ToList();
            Int32 addinationalItem1Index = 1 + packagesInOrder.IndexOf(
                packagesInOrder
                .Where(package => PacketManager.IsCorrectOrder(package, addinationalItem1) == OrderStatus.Equal)
                .Single());
            Int32 addinationalItem2Index = 1 + packagesInOrder.IndexOf(
                packagesInOrder
                .Where(package => PacketManager.IsCorrectOrder(package, addinationalItem2) == OrderStatus.Equal)
                .Single());
            Answer2 = (addinationalItem1Index * addinationalItem2Index).ToString();

            // Save answer
            SaveData();
        }

        public (Packet first, Packet second)[] LoadData1()
        {
            List<(Packet first, Packet second)> packetPair = new List<(Packet, Packet)>();
            foreach(var pair in Data.Split("\r\n\r\n"))
            {
                packetPair.Add((
                    ParsePacketGroup(pair.Split("\r\n")[0]),
                    ParsePacketGroup(pair.Split("\r\n")[1])
                ));
            }

            return packetPair.ToArray();
        }

        public Packet[] LoadData2() => LoadData1().Select(data => data.first).Concat(LoadData1().Select(data => data.second)).ToArray();

        public Packet ParsePacketGroup(String group)
        {
            List<Packet> subpackets = new List<Packet>();

            if (group.Length == 0)
                return new Packet() { Childs = subpackets.ToArray() };

            if (Int32.TryParse(group, out _))
                return new Packet() { Value = Convert.ToInt32(group) };
            
            group = group.Substring(1, group.Length - 2);

            foreach (var element in SplitRow(group))
            {
                if (Int32.TryParse(element, out _))
                    subpackets.Add(new Packet() { Value = Convert.ToInt32(element) });
                else
                    subpackets.Add(ParsePacketGroup(element));
            }

            if(subpackets.Count == 0 && group.Length != 0)
                subpackets.Add(ParsePacketGroup(group));

            return new Packet() { Childs = subpackets.ToArray() };
        }

        public String[] SplitRow(String row)
        {
            List<String> splitted = new List<String>();
            Int32 blockingBrackets = 0;
            String currentItem = "";
            foreach(var character in row)
            {
                if (character == '[')
                {
                    currentItem += '[';
                    blockingBrackets += 1;
                }
                else if (character == ']')
                {
                    currentItem += ']';
                    blockingBrackets -= 1;
                }
                else if (character == ',' && blockingBrackets == 0)
                {
                    splitted.Add(currentItem);
                    currentItem = "";
                }
                else
                    currentItem += character;
            }

            if (currentItem != "")
                splitted.Add(currentItem);

            return splitted.ToArray();
        }
    }
}
