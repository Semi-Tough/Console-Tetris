using System.Collections.Generic;

namespace Console_Tetris
{
    public class Map
    {
        public readonly List<DrawType> WallList = new List<DrawType>();
        public readonly List<DrawType> TetrisList = new List<DrawType>();

        public Map()
        {
            for (int i = 0; i < GameRoot.Wide; i += 2)
            {
                WallList.Add(new DrawType(ETetrisType.Wall, i, GameRoot.High - 2));
            }

            for (int i = 0; i < GameRoot.High - 2; i++)
            {
                WallList.Add(new DrawType(ETetrisType.Wall, 0, i));
                WallList.Add(new DrawType(ETetrisType.Wall, GameRoot.Wide - 2, i));
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