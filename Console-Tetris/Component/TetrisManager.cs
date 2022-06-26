using System;
using System.Collections.Generic;

namespace Console_Tetris
{
    public enum ELeftAndRightType
    {
        Left,
        Right
    }

    public class TetrisManager : IDraw
    {
        private List<DrawType> tetris;
        private readonly Dictionary<ETetrisType, TetrisInfo> tetrisInfoDic;
        private readonly Random random = new Random();
        private TetrisInfo currentTetrisInfo;
        private int currentTetrisIndex;
        public int MoveInterval = 500;


        public TetrisManager()
        {
            tetris = new List<DrawType>();
            tetrisInfoDic = new Dictionary<ETetrisType, TetrisInfo>()
            {
                {ETetrisType.O, new TetrisInfo(ETetrisType.O)},
                {ETetrisType.I, new TetrisInfo(ETetrisType.I)},
                {ETetrisType.T, new TetrisInfo(ETetrisType.T)},
                {ETetrisType.LeftZ, new TetrisInfo(ETetrisType.LeftZ)},
                {ETetrisType.RightZ, new TetrisInfo(ETetrisType.RightZ)},
                {ETetrisType.LeftL, new TetrisInfo(ETetrisType.LeftL)},
                {ETetrisType.RightL, new TetrisInfo(ETetrisType.RightL)}
            };
        }

        public void RandomTetris()
        {
           // ETetrisType type = (ETetrisType) random.Next(0, 7);
            ETetrisType type = ETetrisType.I;
            tetris = new List<DrawType>
            {
                new DrawType(type),
                new DrawType(type),
                new DrawType(type),
                new DrawType(type)
            };
            currentTetrisInfo = tetrisInfoDic[type];
            currentTetrisIndex = 0;
            Position[] positions = currentTetrisInfo[currentTetrisIndex];
            tetris[0].Position = new Position(24, 5);
            MoveInterval = 500;
            for (int i = 0; i < positions.Length; i++)
            {
                tetris[i + 1].Position = tetris[0].Position + positions[i];
            }

            Draw();
        }

        public void Transformation(ELeftAndRightType type, Map map)
        {
            if (!CanTransformation(type, map)) return;
            Clean();

            switch (type)
            {
                case ELeftAndRightType.Left:
                    --currentTetrisIndex;
                    if (currentTetrisIndex < 0)
                    {
                        currentTetrisIndex = currentTetrisInfo.Count - 1;
                    }

                    break;
                case ELeftAndRightType.Right:
                    ++currentTetrisIndex;
                    if (currentTetrisIndex >= currentTetrisInfo.Count)
                    {
                        currentTetrisIndex = 0;
                    }

                    break;
            }

            Position[] positions = currentTetrisInfo[currentTetrisIndex];
            for (int i = 0; i < positions.Length; i++)
            {
                tetris[i + 1].Position = tetris[0].Position + positions[i];
            }

            Draw();
        }

        private bool CanTransformation(ELeftAndRightType leftAndRightType, Map map)
        {
            int nextIndex = currentTetrisIndex;
            switch (leftAndRightType)
            {
                case ELeftAndRightType.Left:
                    --nextIndex;
                    if (nextIndex < 0)
                    {
                        nextIndex = currentTetrisInfo.Count - 1;
                    }

                    break;
                case ELeftAndRightType.Right:
                    ++nextIndex;
                    if (nextIndex >= currentTetrisInfo.Count)
                    {
                        nextIndex = 0;
                    }

                    break;
            }

            Position[] positions = currentTetrisInfo[nextIndex];
            Position tempPosition;

            for (int i = 0; i < positions.Length; i++)
            {
                tempPosition = positions[i] + tetris[0].Position;

                for (int j = 0; j < map.WallList.Count; j++)
                {
                    if (tempPosition == map.WallList[j].Position)
                    {
                        return false;
                    }
                }
            }

            for (int i = 0; i < positions.Length; i++)
            {
                tempPosition = positions[i] + tetris[0].Position;

                for (int j = 0; j < map.TetrisList.Count; j++)
                {
                    if (tempPosition == map.TetrisList[j].Position)
                    {
                        return false;
                    }
                }
            }


            return true;
        }

        public void MoveLr(ELeftAndRightType type, Map map)
        {
            if (!CanMoveLr(type, map)) return;
            Clean();
            for (int i = 0; i < tetris.Count; i++)
            {
                tetris[i].Position += new Position(type == ELeftAndRightType.Left ? -2 : 2, 0);
            }

            Draw();
        }

        private bool CanMoveLr(ELeftAndRightType type, Map map)
        {
            Position tempPosition;
            for (int i = 0; i < tetris.Count; i++)
            {
                tempPosition = tetris[i].Position + new Position(type == ELeftAndRightType.Left ? -2 : 2, 0);
                for (int j = 0; j < map.WallList.Count; j++)
                {
                    if (tempPosition == map.WallList[j].Position)
                    {
                        return false;
                    }
                }
            }

            for (int i = 0; i < tetris.Count; i++)
            {
                tempPosition = tetris[i].Position + new Position(type == ELeftAndRightType.Left ? -2 : 2, 0);

                for (int j = 0; j < map.TetrisList.Count; j++)
                {
                    if (tempPosition == map.TetrisList[j].Position)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void AutoMove(Map map)
        {
            if (!CanAutoMove(map)) return;
            Clean();
            Position tempPosition = new Position(0, 1);
            for (int i = 0; i < tetris.Count; i++)
            {
                tetris[i].Position += tempPosition;
            }

            Draw();
        }

        private bool CanAutoMove(Map map)
        {
            Position tempPosition;
            for (int i = 0; i < tetris.Count; i++)
            {
                tempPosition = tetris[i].Position + new Position(0, 1);
                for (int j = 0; j < map.WallList.Count; j++)
                {
                    if (tempPosition == map.WallList[j].Position)
                    {
                        map.AddTetrisList(tetris);
                        RandomTetris();

                        return false;
                    }
                }
            }

            for (int i = 0; i < tetris.Count; i++)
            {
                tempPosition = tetris[i].Position + new Position(0, 1);

                for (int j = 0; j < map.TetrisList.Count; j++)
                {
                    if (tempPosition == map.TetrisList[j].Position)
                    {
                        map.AddTetrisList(tetris);
                        RandomTetris();
                        return false;
                    }
                }
            }

            return true;
        }

        private void Clean()
        {
            for (int i = 0; i < tetris.Count; i++)
            {
                tetris[i].Clean();
            }
        }

        public void Draw()
        {
            for (int i = 0; i < tetris.Count; i++)
            {
                tetris[i].Draw();
            }
        }
    }
}