using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2022
{
    public class DataManager
    {
        public static String LoadTask(Int32 taskNumber)
        {
            String fullPath = Path.Combine(Directory.GetCurrentDirectory(), $"task{taskNumber}.txt");
            try
            {
                if (File.Exists(fullPath))
                    return File.ReadAllText(fullPath).TrimEnd();
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static void SaveAnswer(Int32 taskNumber, String answer1, String answer2)
        {
            String fullPath = Path.Combine(Directory.GetCurrentDirectory(), $"task{taskNumber}_answers.txt");
            File.WriteAllText(fullPath, answer1 + "\r\n\r\n" + answer2);
        }

    }
}
