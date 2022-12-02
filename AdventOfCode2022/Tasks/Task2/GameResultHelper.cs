using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Tasks.Task2
{
    class GameResultHelper
    {
        public static GameResult GameStatusFromString(String status)
        {
            return status switch
            {
                "X" => GameResult.Lose,
                "Y" => GameResult.Draw,
                "Z" => GameResult.Win,
                _ => throw new Exception("Unexpected status"),
            };
        }
    }
}
