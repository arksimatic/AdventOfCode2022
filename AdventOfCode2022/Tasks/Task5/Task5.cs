using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Tasks.Task5
{
    class Task5 : TaskBase
    {
        public override int TaskNumber => 5;

        public override void Solve()
        {
            // Get data
            (Pile[] piles1, Move[] moves1) = LoadData();
            (Pile[] piles2, Move[] moves2) = LoadData();

            // First half
            PileManager.ExecuteMovesOnPiles(piles1, moves1);
            Answer1 = new String(piles1.Select(pile => pile.Items.Last()).ToArray());

            // Second half
            PileManager.ExecuteMovesOnPilesAsStack(piles2, moves2);
            Answer2 = new String(piles2.Select(pile => pile.Items.Last()).ToArray());

            // Save answer
            SaveData();
        }

        public (Pile[] piles, Move[] moves) LoadData()
        {
            String[] cargosStr = Data.Split("\r\n\r\n", StringSplitOptions.None)[0].Split("\r\n");
            String[] movesStr = Data.Split("\r\n\r\n", StringSplitOptions.None)[1].Split("\r\n");

            #region Cargos

            Array.Reverse(cargosStr);
            List<Pile> piles = new List<Pile>();

            //first row is numeration
            foreach(var pileId in cargosStr.First().Split(" ").Where(id => id.Trim() != ""))
                    piles.Add(new Pile(Convert.ToInt32(pileId.Trim())));

            //leaving first row because it's numeration
            for(int i = 1; i < cargosStr.Length; i++)
            {
                for(int j = 0; j < cargosStr[0].Length; j += 4)
                {
                    if(cargosStr[i][j + 1] != ' ')
                        piles.Where(pile => pile.Id == j / 4 + 1).First().PutItemAtTop(cargosStr[i][j + 1]);
                }
            }

            #endregion Cargos

            #region Moves

            List<Move> moves = new List<Move>();

            foreach(var move in movesStr) 
            {
                String[] moveSplitted = move.Split(" ");
                moves.Add(new Move()
                {
                    AmountOfCargos = Convert.ToInt32(moveSplitted[1]),
                    Origin = Convert.ToInt32(moveSplitted[3]),
                    Destination = Convert.ToInt32(moveSplitted[5])
                });
            }

            #endregion Moves

            return (piles.ToArray(), moves.ToArray());
        }
    }
}
