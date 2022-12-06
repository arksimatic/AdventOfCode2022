using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Tasks.Task6
{
    class Task6 : TaskBase
    {
        public override int TaskNumber => 6;

        public override void Solve()
        {
            // Get data
            String data = Data;
            Int32 howManyStringsInSub;

            // First half
            howManyStringsInSub = 4;
            Answer1 = (data.IndexOf(GetSubXOfString(data, howManyStringsInSub).Where(sub => sub.Distinct().Count() == howManyStringsInSub).First()) + howManyStringsInSub).ToString();

            // Second half
            howManyStringsInSub = 14;
            Answer2 = (data.IndexOf(GetSubXOfString(data, howManyStringsInSub).Where(sub => sub.Distinct().Count() == howManyStringsInSub).First()) + howManyStringsInSub).ToString();

            // Save data
            SaveData();
        }

        private String[] GetSubXOfString(String data, Int32 howManyStringsInSub)
        {
            List<String> subStrings = new List<String>();
            for (int i = 0; i < data.Length - howManyStringsInSub; i++)
            {
                List<Char> subString = new List<Char>();
                for (int j = i; j < i + howManyStringsInSub; j++)
                    subString.Add(data[j]);
                subStrings.Add(new String(subString.ToArray()));
            }
            return subStrings.ToArray();
        }
    }
}
