using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022
{
    public abstract class TaskBase
    {
        public abstract Int32 TaskNumber { get; }
        public String Data { get { return DataManager.LoadTask(TaskNumber); } }
        public String Answer1 { get; set; }
        public String Answer2 { get; set; }
        public abstract void Solve();
        public void SaveData() => DataManager.SaveAnswer(TaskNumber, Answer1, Answer2);
    }
}
