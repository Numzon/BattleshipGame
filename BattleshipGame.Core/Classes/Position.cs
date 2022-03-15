using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BattleshipGame.Core.Classes
{
    public class Position : IEquatable<Position>
    {        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Position other)
        {
            if (other == null)
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.GetType() != other.GetType())
            {
                return false;
            }

            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as Position);
        }

        public override int GetHashCode() => (X, Y).GetHashCode();

        public override string ToString()
        {
            return base.ToString();
        }    }
}
