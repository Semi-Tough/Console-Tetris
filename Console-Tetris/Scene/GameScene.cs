using System;

namespace Console_Tetris
{
    public class GameScene : ILifeCycle
    {
        public void Init()
        {
            Console.ReadKey();
            GameRoot.ChangeScene(ESceneType.End);
        }

        public void Update()
        {
        }
    }
}