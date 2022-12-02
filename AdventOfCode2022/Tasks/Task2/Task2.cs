using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Tasks.Task2
{
    class Task2 : TaskBase
    {
        public override int TaskNumber => 2;

        public override void Solve()
        {
            //Get data 1
            Sparring[] sparrings1 = ParseDataPart1(Data);

            //First half
            Answer1 = sparrings1.Select(sparring => sparring.MyPointsFromSparring).Sum().ToString();

            //Get data 2
            Sparring[] sparrings2 = ParseDataPart2(Data);

            //Second half
            Answer2 = sparrings2.Select(sparring => sparring.MyPointsFromSparring).Sum().ToString();

            // Save answer
            SaveData();
        }

        public Sparring[] ParseDataPart1(String date)
        {
            List<Sparring> sparrings = new List<Sparring>();
            date.Split("\r\n").ToList().ForEach(sparring => 
            {
                Move opponentMove = MoveHelper.MoveFromString(sparring.Split()[0]);
                Move myMove = MoveHelper.MoveFromString(sparring.Split()[1]);

                sparrings.Add(new Sparring()
                {
                    OpponentMove = opponentMove,
                    MyMove = myMove,
                });
            });

            return sparrings.ToArray();
        }

        public Sparring[] ParseDataPart2(String date)
        {
            List<Sparring> sparrings = new List<Sparring>();
            date.Split("\r\n").ToList().ForEach(sparring =>
            {
                Move opponentMove = MoveHelper.MoveFromString(sparring.Split()[0]);
                GameResult expectedGameResult = GameResultHelper.GameStatusFromString(sparring.Split()[1]);

                sparrings.Add(new Sparring()
                {
                    OpponentMove = opponentMove,
                    MyMove = MoveHelper.DeduceOwnMove(opponentMove, expectedGameResult),
                });
            });
            
            return sparrings.ToArray();
        }
    }
}
