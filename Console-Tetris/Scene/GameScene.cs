using System;
using System.Threading;

namespace Console_Tetris
{
    public class GameScene : ILifeCycle
    {
        private readonly TetrisManager tetrisManager = new TetrisManager();
        private readonly Map map = new Map();

        public void Init()
        {
            map.DrawWall();
            tetrisManager.RandomTetris();
            Thread thread = new Thread(CheckInput)
            {
                IsBackground = true
            };
            thread.Start();
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
            while (true)
            {
                if (!Console.KeyAvailable) continue;
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
            // ReSharper disable once FunctionNeverReturns
        }
    }
}