using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Tasks.Task10
{
    class Task10 : TaskBase
    {
        public override int TaskNumber => 10;

        public override void Solve()
        {
            //Get data
            Instruction[] instructions = LoadData();

            //First half
            Device device = new Device(instructions);
            Int32 sumOfSignnalStrength = 0;
            for (int i = 20; i <= 220; i += 40)
                sumOfSignnalStrength += device.GetSignalStrengthFromCycle(i);
            Answer1 = sumOfSignnalStrength.ToString();

            //Second half
            Answer2 = device.GetImage();

            // Save answer
            SaveData();
        }

        public Instruction[] LoadData()
        {
            List<Instruction> instructions = new List<Instruction>();

            foreach(var line in Data.Split("\r\n"))
            {
                if (line.Split()[0] == "noop")
                    instructions.Add(new Instruction() { InstructionType = InstructionType.noop });
                else
                {
                    instructions.Add(new Instruction()
                    {
                        InstructionType = InstructionType.addx,
                        Cycles = 2,
                        NumberToAdd = Convert.ToInt32(line.Split()[1])
                    });
                }
            }

            return instructions.ToArray();
        }
    }
}
