using System.Diagnostics;

namespace Console_Tetris
{
    public class Position
    {
        #region OverrideEquals

        protected bool Equals(Position other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Position) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        #endregion

        public int X;
        public int Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Position pos1, Position pos2)
        {
            return pos1.X == pos2.X && pos1.Y == pos2.Y;
        }

        public static bool operator !=(Position pos1, Position pos2)
        {
            return !(pos1 == pos2);
        }


        public static Position operator +(Position pos1, Position pos2)
        {
            return new Position(pos1.X + pos2.X, pos1.Y + pos2.Y);
        }

        public static Position operator -(Position pos1, Position pos2)
        {
            return new Position(pos1.X - pos2.X, pos1.Y - pos2.Y);
        }
    }
}