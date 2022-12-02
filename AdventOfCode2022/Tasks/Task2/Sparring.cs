using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Tasks.Task2
{
    class Sparring
    {
        public Move MyMove { get; set; }
        public Move OpponentMove { get; set; }

        public Int32 MyPointsFromSparring 
        {
            get
            {
                Int32 myScore = (Int32)MyMove;

                if (MyMove == OpponentMove)
                    myScore += 3;
                else if (MyMove == Move.Paper && OpponentMove == Move.Rock)
                    myScore += 6;
                else if (MyMove == Move.Rock && OpponentMove == Move.Scissors)
                    myScore += 6;
                else if (MyMove == Move.Scissors && OpponentMove == Move.Paper)
                    myScore += 6;

                return myScore;
            }
        }
    }
}
