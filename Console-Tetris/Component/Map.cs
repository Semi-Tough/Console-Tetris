using System.Collections.Generic;

namespace Console_Tetris
{
    public class Map
    {
        public readonly List<DrawType> WallList = new List<DrawType>();
        public readonly List<DrawType> TetrisList = new List<DrawType>();
        private readonly int[] rawInfo;
        private readonly int mapWide;

        public Map()
        {
            mapWide = GameRoot.Wide;
            rawInfo = new int[GameRoot.High - 2];

            for (int i = 0; i < mapWide; i += 2)
            {
                WallList.Add(new DrawType(ETetrisType.Wall, i, GameRoot.High - 2));
            }

            for (int i = 0; i < GameRoot.High - 2; i++)
            {
                WallList.Add(new DrawType(ETetrisType.Wall, 0, i));
                WallList.Add(new DrawType(ETetrisType.Wall, GameRoot.Wide - 2, i));
            }
        }

        public void AddTetrisList(List<DrawType> tetris)
        {
            for (int i = 0; i < tetris.Count; i++)
            {
                TetrisList.Add(tetris[i]);

                rawInfo[tetris[i].Position.Y] += 1;
            }

            if (!CheckRaw()) return;
            CleanTetris();
            RemoveRaw();
            DrawTetris();
        }

        public void DrawWall()
        {
            for (int i = 0; i < WallList.Count; i++)
            {
                WallList[i].Draw();
            }
        }

        private void CleanTetris()
        {
            for (int i = 0; i < TetrisList.Count; i++)
            {
                TetrisList[i].Clean();
            }
        }

        private void DrawTetris()
        {
            for (int i = 0; i < TetrisList.Count; i++)
            {
                TetrisList[i].Draw();
            }
        }

        private void RemoveRaw()
        {
            List<DrawType> cleanRaw = new List<DrawType>();
            for (int i = 0; i < rawInfo.Length; i++)
            {
                if (rawInfo[i] == mapWide / 2 - 2)
                {
                    for (int j = 0; j < TetrisList.Count; j++)
                    {
                        if (i == TetrisList[j].Position.Y)
                        {
                            cleanRaw.Add(TetrisList[j]);
                        }
                        else if (TetrisList[j].Position.Y < i)
                        {
                            TetrisList[j].Position.Y += 1;
                        }
                    }

                    for (int j = 0; j < cleanRaw.Count; j++)
                    {
                        TetrisList.Remove(cleanRaw[j]);
                    }

                    for (int j = i - 1; j > 0; j--)
                    {
                        rawInfo[j + 1] = rawInfo[j];
                    }

                    RemoveRaw();
                    break;
                }
            }
        }

        private bool CheckRaw()
        {
            for (int i = 0; i < rawInfo.Length; i++)
            {
                if (rawInfo[i] == mapWide / 2 - 2)
                {
                    return true;
                }
            }

            return false;
        }
    }
}