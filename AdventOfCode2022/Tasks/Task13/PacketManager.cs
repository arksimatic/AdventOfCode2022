using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Tasks.Task13
{
    class PacketManager
    {
        public static OrderStatus IsCorrectOrder(Packet first, Packet second)
        {
            if (first.Value != null && second.Value != null)
            {
                if (first.Value < second.Value) return OrderStatus.RightOrder;
                if (second.Value < first.Value) return OrderStatus.WrongOrder;
                return OrderStatus.Equal;
            }
            else
            {
                first = MakeChildFromValue(first);
                second = MakeChildFromValue(second);

                for (int i = 0; i < Math.Min(first.Childs.Length, second.Childs.Length); i++)
                {
                    if (IsCorrectOrder(first.Childs[i], second.Childs[i]) == OrderStatus.WrongOrder)
                        return OrderStatus.WrongOrder;
                    if (IsCorrectOrder(first.Childs[i], second.Childs[i]) == OrderStatus.RightOrder)
                        return OrderStatus.RightOrder;
                }

                if (first.Childs.Length < second.Childs.Length) return OrderStatus.RightOrder;
                if (second.Childs.Length < first.Childs.Length) return OrderStatus.WrongOrder;
                return OrderStatus.Equal;
            }
        }
        public static Packet MakeChildFromValue(Packet packet)
        {
            if (packet.Value == null) return packet;

            return new Packet()
            {
                Childs = new Packet[]
                {
                    new Packet { Value = packet.Value }
                }
            };
        }

        public static Packet[] CorrectOrder(Packet[] packets)
        {
            for(int i = 0; i < packets.Length - 1; i++)
            {
                for(int j = packets.Length - 2; j >= 0; j--)
                {
                    Packet first = packets[j];
                    Packet second = packets[j + 1];
                    if (IsCorrectOrder(first, second) == OrderStatus.WrongOrder)
                    {
                        packets[j] = second;
                        packets[j + 1] = first;
                    }
                }
            }

            return packets;
        }
    }
}
