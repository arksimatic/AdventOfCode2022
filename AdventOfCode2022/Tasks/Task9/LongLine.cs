using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Tasks.Task9
{
    class LongLine
    {
        private List<Line> _lines = new List<Line>();
        public Line[] Lines { get { return _lines.ToArray(); } }
        public Position[] TailsVisitedIndividualPositions => _lines.SelectMany(line => line.TailVisitedIndividualPositions).Distinct().OrderBy(line => line.X).ThenBy(line => line.Y).ToArray();
        public LongLine(Int32 length)
        {
            for(int i = 0; i < length-1; i++)
                _lines.Add(new Line());
        }
        public void MoveLongLine(Direction[] directions)
        {
            foreach (Direction direction in directions)
                MoveLongLine(direction);
        }
        public void MoveLongLine(Direction direction)
        {
            Direction tailDireciton = direction;
            foreach(var line in _lines)
                tailDireciton = MoveLineDeduceNextDirection(line, tailDireciton);
        }
        private Direction MoveLineDeduceNextDirection(Line line, Direction direction)
        {
            Position oldTailPosition = new Position(line.Tail.X, line.Tail.Y); 
            line.MoveLine(direction);
            Position newTailPosition = new Position(line.Tail.X, line.Tail.Y);
            if (newTailPosition == oldTailPosition)
                return Direction.None;
            if (newTailPosition.Y > oldTailPosition.Y)
            {
                if (newTailPosition.X > oldTailPosition.X)
                    return Direction.RightUp;
                if (newTailPosition.X < oldTailPosition.X)
                    return Direction.LeftUp;
                else
                    return Direction.Up;
            }
            if (newTailPosition.Y < oldTailPosition.Y)
            {
                if (newTailPosition.X > oldTailPosition.X)
                    return Direction.RightDown;
                if (newTailPosition.X < oldTailPosition.X)
                    return Direction.LeftDown;
                else
                    return Direction.Down;
            }
            if (newTailPosition.X > oldTailPosition.X)
                return Direction.Right;
            if (newTailPosition.X < oldTailPosition.X)
                return Direction.Left;
            return Direction.None;
        }
    }
}
