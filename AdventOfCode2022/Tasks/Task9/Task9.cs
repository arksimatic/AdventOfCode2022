using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2022.Tasks.Task9
{
    partial class Task9 : TaskBase
    {
        public override int TaskNumber => 9;

        public override void Solve()
        {
            // Get data
            Direction[] directions = LoadData();

            // First half
            Line line = new Line();
            line.MoveLine(directions);
            Answer1 = line.TailVisitedIndividualPositions.Length.ToString();

            // Second half
            LongLine longLine = new LongLine(10);
            longLine.MoveLongLine(directions);
            Answer2 = longLine.Lines.Last().TailVisitedIndividualPositions.Length.ToString();

            // Save data
            SaveData();
        }

        public Direction[] LoadData()
        {
            List<Direction> movesToDirections = new List<Direction>();

            foreach(var line in Data.Split("\r\n"))
            {
                Direction direction = (Direction)Convert.ToChar(line.Split(" ")[0]);
                Int32 amount = Convert.ToInt32(line.Split(" ")[1]);

                for (int i = 0; i < amount; i++)
                    movesToDirections.Add(direction);
            }

            return movesToDirections.ToArray();
        }
    }
}
