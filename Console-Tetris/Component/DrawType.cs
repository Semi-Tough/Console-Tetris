using System;

namespace Console_Tetris
{
    public enum ETetrisType
    {
        O,
        I,
        T,
        LeftZ,
        RightZ,
        LeftL,
        RightL,
        Wall
    }

    public class DrawType : IDraw
    {
        private readonly ETetrisType tetrisType;
        public Position Position;

        public DrawType(ETetrisType type, int x, int y) : this(type)
        {
            Position = new Position(x, y);
        }

        public DrawType(ETetrisType type)
        {
            tetrisType = type;
        }

        public void Draw()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            switch (tetrisType)
            {
                case ETetrisType.O:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case ETetrisType.I:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case ETetrisType.T:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case ETetrisType.LeftL:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case ETetrisType.RightL:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case ETetrisType.LeftZ:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case ETetrisType.RightZ:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case ETetrisType.Wall:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }

            Console.Write("■");
        }

        public void Clean()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write("  ");
        }
    }
}