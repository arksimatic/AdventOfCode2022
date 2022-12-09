using System;
using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2022.Tasks.Task9
{
    public class Position : IEquatable<Position>
    {
        public Int32 X { get; set; }
        public Int32 Y { get; set; }
        public Position(Int32 x, Int32 y)
        {
            X = x;
            Y = y;
        }
        public static Boolean operator ==(Position pos1, Position pos2) => pos1.X == pos2.X && pos1.Y == pos2.Y;
        public static Boolean operator !=(Position pos1, Position pos2) => pos1.X != pos2.X || pos1.Y != pos2.Y;

        public override bool Equals(object obj)
        {
            Position position = obj as Position;
            if (position == null)
                return false;
            else
                return this.Equals(position);
        }

        public bool Equals(Position other)
        {
            return this == other;
        }

        public override int GetHashCode() => HashCode.Combine(X, Y);
    }
}
