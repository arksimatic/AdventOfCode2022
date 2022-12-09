using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Tasks.Task9
{
    public class Line
    {
        private Position _head = new Position(0, 0);
        private Position _tail = new Position(0, 0);
        private List<Position> _tailVisitedCoordinates = new List<Position>();
        public Position Head { get { return _head; } }
        public Position Tail { get { return _tail; } }
        public Position[] TailVisitedIndividualPositions { get { return _tailVisitedCoordinates.ToArray(); } }
        public Line() => _tailVisitedCoordinates.Add(new Position(0, 0));
        public void MoveLine(Direction direction)
        {
            Position headBeforeMove = new Position(_head.X, _head.Y);
            _head = GetPositionAfterMove(_head, direction);
            if (!IsTailInRange())
            {
                _tail = GetPositionAfterMove(_tail, DeduceTailMove());
                if(!_tailVisitedCoordinates.Where(pos => pos.X == _tail.X && pos.Y == _tail.Y).Any())
                    _tailVisitedCoordinates.Add(new Position(_tail.X, _tail.Y));
            }
        }
        public Direction DeduceTailMove()
        {
            if(_head.X == _tail.X)
            {
                if (_head.Y == _tail.Y + 2)
                    return Direction.Up;
                if (_head.Y == _tail.Y - 2)
                    return Direction.Down;
            }
            if(_head.Y == _tail.Y)
            {
                if (_head.X == _tail.X + 2)
                    return Direction.Right;
                if (_head.X == _tail.X - 2)
                    return Direction.Left;
            }
            if (_head.X > _tail.X)
            {
                if (_head.Y > _tail.Y)
                    return Direction.RightUp;
                if (_head.Y < _tail.Y)
                    return Direction.RightDown;
            }
            if (_head.X < _tail.X)
            {
                if (_head.Y > _tail.Y)
                    return Direction.LeftUp;
                if (_head.Y < _tail.Y)
                    return Direction.LeftDown;
            }

            return Direction.None;
        }
        public void MoveLine(Direction[] directions)
        {
            foreach (var direction in directions)
                MoveLine(direction);
        }
        private Position GetPositionAfterMove(Position position, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    position.Y++;
                    break;
                case Direction.Right:
                    position.X++;
                    break;
                case Direction.Down:
                    position.Y--;
                    break;
                case Direction.Left:
                    position.X--;
                    break;

                case Direction.RightUp:
                    position.Y++;
                    position.X++;
                    break;
                case Direction.LeftUp:
                    position.Y++;
                    position.X--;
                    break;
                case Direction.RightDown:
                    position.Y--;
                    position.X++;
                    break;
                case Direction.LeftDown:
                    position.Y--;
                    position.X--;
                    break;

                case Direction.None:
                    break;
            }

            return position;
        }
        private Boolean IsTailInRange()
        {
            List<Position> allowedPositions = new List<Position>();
            for(int i = _head.X - 1; i <= _head.X + 1; i++)
            {
                for (int j = _head.Y - 1; j <= _head.Y + 1; j++)
                    allowedPositions.Add(new Position(i, j));
            }

            return allowedPositions.Where(pos => pos.X == _tail.X && pos.Y == _tail.Y).Any();
        }
    }
}
