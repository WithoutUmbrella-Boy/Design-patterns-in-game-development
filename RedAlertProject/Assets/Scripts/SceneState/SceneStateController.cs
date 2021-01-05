using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneStateController
{
    private ISceneState mState;
    private AsyncOperation mAO;
    private bool mIsRunStart = false;

    public void SetState(ISceneState state, bool isLoadScene = true)
    {
        if (mState != null)
        {
            mState.StateEnd();//让上一个场景状态做一下清理工作
        }
        mState = state;
        if (isLoadScene)
        {
            mAO = SceneManager.LoadSceneAsync(mState.SceneName);
            mIsRunStart = false;
        }
        else
        {
            mState.StateStart();
            mIsRunStart = true;
        }


    }

    public void StateUpdate()
    {
        if (mAO != null && mAO.isDone == false) return;//表示场景正在加载，所以不执行下面的代码


        if (mIsRunStart == false && mAO != null && mAO.isDone == true)
        {
            mState.StateStart();
            mIsRunStart = true;//控制只调用一次
        }

        if (mState != null)
        {
            mState.StateUpdata();
        }
    }

}

