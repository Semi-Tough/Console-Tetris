using System;

namespace Console_Tetris
{
    public enum ESceneType
    {
        Begin,
        Game,
        End
    }

    public class GameRoot
    {
        public const int Wide = 50;
        public const int High = 35;

        private static BeginScene beginScene;
        private static GameScene gameScene;
        private static EndScene endScene;

        private static ILifeCycle currentScene;

        public GameRoot()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(Wide, High);
            Console.SetBufferSize(Wide, High);

            beginScene = new BeginScene();
            gameScene = new GameScene();
            endScene = new EndScene();

            ChangeScene(ESceneType.Begin);
        }

        public void Start()
        {
            while (true)
            {
                currentScene?.Update();
            }
            // ReSharper disable once FunctionNeverReturns
        }

        public static void ChangeScene(ESceneType sceneType)
        {
            Console.Clear();
            switch (sceneType)
            {
                case ESceneType.Begin:
                    currentScene = beginScene;
                    currentScene.Init();
                    break;
                case ESceneType.Game:
                    currentScene = gameScene;
                    currentScene.Init();
                    break;
                case ESceneType.End:
                    currentScene = endScene;
                    currentScene.Init();
                    break;
            }
        }
    }
}