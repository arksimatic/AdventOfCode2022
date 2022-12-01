using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Tasks.Task1
{
    class Task1 : TaskBase
    {
        public override Int32 TaskNumber { get => 1; }

        public override void Solve()
        {
            // Get data
            Elf[] elfs = ParseData(Data);

            // First half
            Answer1 = elfs.Select(elf => elf.TotalFood).Max().ToString();

            // Second half
            Answer2 = elfs.OrderByDescending(elf => elf.TotalFood).Take(3).Select(elf => elf.TotalFood).Sum().ToString();

            // Save answer
            SaveData();
        }

        private Elf[] ParseData(String data)
        {
            List<Elf> elfs = new List<Elf>();

            data.Split("\r\n\r\n").ToList().ForEach(elfData =>
            {
                List<Int32> cargoList = new List<Int32>();

                elfData.Split("\r\n").ToList().ForEach(cargo =>
                    cargoList.Add(Convert.ToInt32(cargo))
                    );

                elfs.Add(
                    new Elf()
                    {
                        FoodPackages = cargoList.ToArray()
                    });
            });

            return elfs.ToArray();
        }
    }
}
