using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SoldierFSMSytem
{
    //集合存储当前拥有的所有状态
    private List<ISoldierState> mStates = new List<ISoldierState>();

    private ISoldierState mCurrentState;
    public ISoldierState currentState { get { return mCurrentState; } }


    public void AddState(params ISoldierState[] states)
    {
        foreach (ISoldierState s in states)
        {
            AddState(s);
        }
    }

    public void AddState(ISoldierState state)
    {
        if (state == null)
        {
            Debug.LogError("要添加的状态为空"); return;
        }
        if (mStates.Count == 0)
        {
            mStates.Add(state);
            mCurrentState = state;
            return;
        }
        //遍历状态集合
        foreach (ISoldierState s in mStates)
        {
            if (s.stateID == state.stateID)//说明要添加的状态已经存在
            {
                Debug.LogError("要添加的状态ID[" + s.stateID + "]已经添加"); return;
            }
        }
        //说明状态不存在于集合中，所以把状态添加进去
        mStates.Add(state);
    }

    public void DeleteState(SoldierStateID stateID)
    {
        if (stateID==SoldierStateID.NullState)
        {
            Debug.LogError("要删除的状态ID为空"+stateID); return;
        }
        foreach (ISoldierState s in mStates)
        {
            if (s.stateID==stateID)
            {
                mStates.Remove(s); return;
            }            
        }
        Debug.LogError("要删除的StateID不存在集合中：" + stateID); return;

    }

    //用来执行转变
    public void PerformTransition(SoldierTransition trans)
    {
        if (trans==SoldierTransition.NullTansition)
        {
            Debug.LogError("要执行的转换条件为空：" + trans); return;
        }
       SoldierStateID nextstateID =  mCurrentState.GetOutPutState(trans);
        if (nextstateID==SoldierStateID.NullState)
        {
            Debug.LogError("在转换条件["+trans+"]下，没有对应的转换状态" ); return;
        }
        foreach (ISoldierState s in mStates)
        {
            if (s.stateID==nextstateID)
            {
                mCurrentState.DoBeforeLeaving();
                mCurrentState = s;
                mCurrentState.DoBeforeEntering();
                return;
            }
        }
    }




}

