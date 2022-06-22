using System;

namespace Console_Tetris
{
    public class BeginScene:BaseScene
    {
       
        public override void Init()
        {
            Title = "俄罗斯方块";
            FirstOption = "开始游戏";
            SecondOption = "退出游戏";
            base.Init();
        }

        protected override void EnterOption()
        {
            if (CurrentIndex == 0)
            {
                GameRoot.ChangeScene(ESceneType.Game);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}