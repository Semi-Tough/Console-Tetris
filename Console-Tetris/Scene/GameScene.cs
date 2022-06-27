using System;
using System.Threading;

namespace Console_Tetris
{
    public class GameScene : ILifeCycle
    {
        private TetrisManager tetrisManager;
        private Map map;

        public void Init()
        {
            map = new Map(this);
            map.DrawWall();
            tetrisManager = new TetrisManager();
            tetrisManager.RandomTetris();
            InputThread.Instance.InputEvent += CheckInput;
        }

        public void Update()
        {
            lock (tetrisManager)
            {
                tetrisManager.AutoMove(map);
            }

            // ReSharper disable once InconsistentlySynchronizedField
            Thread.Sleep(tetrisManager.MoveInterval);
        }

        private void CheckInput()
        {
            if (!Console.KeyAvailable) return;
            lock (tetrisManager)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.K:
                        tetrisManager.Transformation(ELeftAndRightType.Left, map);
                        break;
                    case ConsoleKey.L:
                        tetrisManager.Transformation(ELeftAndRightType.Right, map);
                        break;
                    case ConsoleKey.A:
                        tetrisManager.MoveLr(ELeftAndRightType.Left, map);
                        break;
                    case ConsoleKey.D:
                        tetrisManager.MoveLr(ELeftAndRightType.Right, map);
                        break;
                    case ConsoleKey.J:
                        tetrisManager.MoveInterval = 50;
                        break;
                }
            }
        }

        public void StopInputThread()
        {
            InputThread.Instance.InputEvent -= CheckInput;
        }
    }
}