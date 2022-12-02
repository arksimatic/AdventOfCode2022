using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Tasks.Task2
{
    class MoveHelper
    {
        public static Move GetLoseTo(Move move)
        {
            return move switch
            {
                Move.Rock => Move.Scissors,
                Move.Paper => Move.Rock,
                Move.Scissors => Move.Paper,
                _ => throw new Exception("Unhandled move"),
            };
        }

        public static Move GetWinTo(Move move)
        {
            return move switch
            {
                Move.Rock => Move.Paper,
                Move.Paper => Move.Scissors,
                Move.Scissors => Move.Rock,
                _ => throw new Exception("Unhandled move"),
            };
        }

        public static Move MoveFromString(String move)
        {
            return move switch
            {
                "A" => Move.Rock,
                "X" => Move.Rock,
                "B" => Move.Paper,
                "Y" => Move.Paper,
                "C" => Move.Scissors,
                "Z" => Move.Scissors,
                _ => throw new Exception("Unexpected status"),
            };
        }

        public static Move DeduceOwnMove(Move opponentsMove, GameResult expectedGameResult)
        {
            return expectedGameResult switch
            {
                GameResult.Lose => MoveHelper.GetLoseTo(opponentsMove),
                GameResult.Win => MoveHelper.GetWinTo(opponentsMove),
                GameResult.Draw => opponentsMove,
                _ => throw new Exception("Unexpected move"),
            };
        }
    }
}
