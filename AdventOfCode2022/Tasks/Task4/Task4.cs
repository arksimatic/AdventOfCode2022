using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Tasks.Task4
{
    class Task4 : TaskBase
    {
        public override int TaskNumber => 4;

        public override void Solve()
        {
            //Get data
            AssigmentsPair[] assigmentsPairs = ParseData();

            //First half
            Answer1 = assigmentsPairs.Where(ass => ass.FullyOverlapping).Count().ToString();

            //Second half
            Answer2 = assigmentsPairs.Where(ass => ass.PartiallyOveralpping).Count().ToString();

            // Save answer
            SaveData();
        }

        public AssigmentsPair[] ParseData()
        {
            List<AssigmentsPair> assigmentspairs = new List<AssigmentsPair>();

            Data.Split("\r\n").ToList().ForEach(line =>
            {
                assigmentspairs.Add(new AssigmentsPair()
                {
                    FirstAssigmnets = new Assignments
                    {
                        StartAssignment = Convert.ToInt32(line.Split(',')[0].Split('-')[0]),
                        EndAssignment = Convert.ToInt32(line.Split(',')[0].Split('-')[1])
                    },
                    SecondAssigments = new Assignments
                    {
                        StartAssignment = Convert.ToInt32(line.Split(',')[1].Split('-')[0]),
                        EndAssignment = Convert.ToInt32(line.Split(',')[1].Split('-')[1])
                    },
                });
            });

            return assigmentspairs.ToArray();
        }
    }
}
