using System;
using System.Threading;

namespace Console_Tetris
{
    public class GameScene : ILifeCycle
    {
        private TetrisManager tetrisManager;
        private Map map;
        private Thread inputThread;
        private bool isRunning;

        public void Init()
        {
            map = new Map(this);
            map.DrawWall();
            tetrisManager = new TetrisManager();
            tetrisManager.RandomTetris();
            inputThread = new Thread(CheckInput)
            {
                IsBackground = true
            };
            inputThread.Start();
            isRunning = true;
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
            while (isRunning)
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
        }

        public void StopInputThread()
        {
            isRunning = false;
            inputThread = null;
            //inputThread.Abort();
        }
    }
}