using System.Collections.Generic;

namespace Console_Tetris
{
    public class Map
    {
        public readonly List<DrawType> WallList = new List<DrawType>();
        public readonly List<DrawType> TetrisList = new List<DrawType>();
        
        public const int MapWide= GameRoot.Wide;
        public const int MapHigh = GameRoot.High - 1;

        public Map()
        {
            for (int i = 2; i < MapWide; i += 2)
            {
                WallList.Add(new DrawType(ETetrisType.Wall, i, 34));
            }

            for (int i = 0; i < MapHigh ; i++)
            {
                WallList.Add(new DrawType(ETetrisType.Wall, 0, i));
                WallList.Add(new DrawType(ETetrisType.Wall, 48, i));
            }
        }

        public void Draw()
        {
            for (int i = 0; i < WallList.Count; i++)
            {
                WallList[i].Draw();
            }
        }
    }
}