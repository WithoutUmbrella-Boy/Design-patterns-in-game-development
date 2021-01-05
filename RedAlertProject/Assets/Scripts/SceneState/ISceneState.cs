using System;
using System.Collections.Generic;
using System.Text;


public class ISceneState
{
    private string mSceneName;
    private SceneStateController mController;

    public ISceneState(string sceneName,SceneStateController controller)
    {
        mSceneName = sceneName;
        mController = controller;
    }


    public virtual void StateStart()
    {

    }
    public virtual void StateEnd()
    {

    }
    public virtual void StateUpdata()
    {

    }
}

