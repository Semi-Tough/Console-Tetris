using System;

namespace Console_Tetris
{
    public class GameScene : ILifeCycle
    {
        private readonly TetrisManager tetrisManager = new TetrisManager();
        private readonly Map map = new Map();

        public void Init()
        {
            map.Draw();
            tetrisManager.RandomTetris();
        }

        public void Update()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    tetrisManager.Transformation(ETransformationType.Left, map);
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    tetrisManager.Transformation(ETransformationType.Right, map);
                    break;
                case ConsoleKey.Q:
                    tetrisManager.RandomTetris();
                    break;
            }
        }
        
        
    }
}