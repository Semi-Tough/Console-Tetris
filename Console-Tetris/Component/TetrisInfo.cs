using System.Collections.Generic;

namespace Console_Tetris
{
    public class TetrisInfo
    {
        private readonly List<Position[]> positionsList = new List<Position[]>();

        public TetrisInfo(ETetrisType type)
        {
            switch (type)
            {
                case ETetrisType.O:
                    positionsList.Add(new[]
                    {
                        new Position(2, 0),
                        new Position(0, 1),
                        new Position(2, 1)
                    });
                    break;
                case ETetrisType.I:
                    positionsList.Add(new[]
                    {
                        new Position(0, -1),
                        new Position(0, 1),
                        new Position(0, 2)
                    });
                    positionsList.Add(new[]
                    {
                        new Position(-4, 0),
                        new Position(-2, 0),
                        new Position(2, 0)
                    });
                    break;
                case ETetrisType.T:
                    positionsList.Add(new[]
                    {
                        new Position(-2, 0),
                        new Position(2, 0),
                        new Position(0, 1)
                    });
                    positionsList.Add(new[]
                    {
                        new Position(0, -1),
                        new Position(-2, 0),
                        new Position(0, 1)
                    });
                    positionsList.Add(new[]
                    {
                        new Position(0, -1),
                        new Position(-2, 0),
                        new Position(2, 0)
                    });
                    positionsList.Add(new[]
                    {
                        new Position(0, -1),
                        new Position(2, 0),
                        new Position(0, 1)
                    });
                    break;
                case ETetrisType.LeftZ:
                    positionsList.Add(new[]
                    {
                        new Position(0, -1),
                        new Position(-2, 0),
                        new Position(-2, 1)
                    });
                    positionsList.Add(new[]
                    {
                        new Position(-2, -1),
                        new Position(0, -1),
                        new Position(2, 0)
                    });
                    positionsList.Add(new[]
                    {
                        new Position(2, -1),
                        new Position(2, 0),
                        new Position(0, 1)
                    });
                    positionsList.Add(new[]
                    {
                        new Position(-2, 0),
                        new Position(0, 1),
                        new Position(2, 1)
                    });
                    break;
                case ETetrisType.RightZ:
                    positionsList.Add(new[]
                    {
                        new Position(0, -1),
                        new Position(2, 0),
                        new Position(2, 1)
                    });
                    positionsList.Add(new[]
                    {
                        new Position(2, 0),
                        new Position(-2, 1),
                        new Position(0, 1)
                    });
                    positionsList.Add(new[]
                    {
                        new Position(-2, -1),
                        new Position(-2, 0),
                        new Position(0, 1)
                    });
                    positionsList.Add(new[]
                    {
                        new Position(0, -1),
                        new Position(2, -1),
                        new Position(-2, 0)
                    });
                    break;
                case ETetrisType.LeftL:
                    positionsList.Add(new[]
                    {
                        new Position(-2, -1),
                        new Position(0, -1),
                        new Position(0, 1),
                    });
                    positionsList.Add(new[]
                    {
                        new Position(2, 1),
                        new Position(-2, 0),
                        new Position(2, 0),
                    });
                    positionsList.Add(new[]
                    {
                        new Position(0, -1),
                        new Position(0, 1),
                        new Position(2, 1),
                    });
                    positionsList.Add(new[]
                    {
                        new Position(-2, 0),
                        new Position(2, 0),
                        new Position(-2, 1),
                    });
                    break;
                case ETetrisType.RightL:
                    positionsList.Add(new[]
                    {
                        new Position(0, -1),
                        new Position(2, -1),
                        new Position(0, 1),
                    });
                    positionsList.Add(new[]
                    {
                        new Position(-2, 0),
                        new Position(2, 0),
                        new Position(2, 1),
                    });
                    positionsList.Add(new[]
                    {
                        new Position(0, -1),
                        new Position(-2, 1),
                        new Position(0, 1),
                    });
                    positionsList.Add(new[]
                    {
                        new Position(-2, -1),
                        new Position(-2, 0),
                        new Position(2, 0),
                    });
                    break;
            }
        }

        public Position[] this[int index]
        {
            get
            {
                if (index >= 0 && index < positionsList.Count)
                {
                    return positionsList[index];
                }

                return null;
            }
        }

        public int Count => positionsList.Count;
    }
}