using System;

namespace Console_Tetris
{
    public class EndScene : BaseScene
    {
        public override void Init()
        {
            Title = "游戏结束";
            FirstOption = "回到开始界面";
            SecondOption = "退出游戏";
            base.Init();
        }

        protected override void EnterOption()
        {
            if (CurrentIndex == 0)
            {
                GameRoot.ChangeScene(ESceneType.Begin);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}