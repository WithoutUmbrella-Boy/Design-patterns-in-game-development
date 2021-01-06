using System;
using System.Collections.Generic;
using System.Text;


public class BattleState:ISceneState
{
    public BattleState(SceneStateController controller) : base("03BattleScene", controller)
    {

    }

    //private GameFacade mFacade;改成单例模式进行访问，此变量弃用
    //兵营 关卡 角色管理 行动力 成就系统。。。

    public override void StateStart()
    {
        GameFacade.Insance.Init();//初始化
    }
    public override void StateEnd()
    {
        GameFacade.Insance.Release();//结束后进行的操作
    }
    public override void StateUpdata()
    {
        if (GameFacade.Insance.isGameOver)
        {
            mController.SetState(new MainMenuState(mController));
        }
        GameFacade.Insance.Update();
    }
}

