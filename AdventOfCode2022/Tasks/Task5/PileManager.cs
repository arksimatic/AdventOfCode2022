using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Tasks.Task5
{
    class PileManager
    {
        public static Pile[] ExecuteMovesOnPiles(Pile[] piles, Move[] moves)
        {
            foreach (var move in moves)
                piles = ExecuteMoveOnPiles(piles, move);
            return piles;
        }

        private static Pile[] ExecuteMoveOnPiles(Pile[] piles, Move move)
        {
            for(int i = 0; i < move.AmountOfCargos; i++)
            {
                Char item = piles.Where(pile => pile.Id == move.Origin).First().PickUpTopItem();
                piles.Where(pile => pile.Id == move.Destination).First().PutItemAtTop(item);
            }

            return piles;
        }

        public static Pile[] ExecuteMovesOnPilesAsStack(Pile[] piles, Move[] moves)
        {
            foreach (var move in moves)
                piles = ExecuteMoveOnPilesAsStack(piles, move);
            return piles;
        }

        private static Pile[] ExecuteMoveOnPilesAsStack(Pile[] piles, Move move)
        {
            List<Char> items = new List<Char>();
            for (int i = 0; i < move.AmountOfCargos; i++)
                items.Add(piles.Where(pile => pile.Id == move.Origin).First().PickUpTopItem());

            items.Reverse();
            for (int i = 0; i < move.AmountOfCargos; i++)
                piles.Where(pile => pile.Id == move.Destination).First().PutItemAtTop(items[i]);

            return piles;
        }
    }
}
