using System;
using System.Collections.Generic;

namespace AdventOfCode2022
{
    class Program
    {
        static void Main(string[] args)
        {
            Int32 completedTasks;
            if (DateTime.Today > new DateTime(2022, 12, 25))
                completedTasks = 25;
            else
                completedTasks = Math.Min(DateTime.Today.Day, 25);

            List<TaskBase> tasks = new List<TaskBase>();
            for(int i = 1; i <= completedTasks; i++)
                tasks.Add((TaskBase)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance($"AdventOfCode2022.Tasks.Task{i}.Task{i}"));

            tasks.ForEach(task => task.Solve());
        }
    }
}
