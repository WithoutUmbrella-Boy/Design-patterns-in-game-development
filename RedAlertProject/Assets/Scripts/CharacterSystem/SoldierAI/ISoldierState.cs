using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//枚举定义状态转换的条件
public enum SoldierTransition
{
    NullTansition = 0,
    SeeEnemy,
    NoEnemy,
    CanAttack
}

//定义Soldier状态
public enum SoldierStateID
{
    NullState,
    Idle,
    Chase,
    Attack
}


public abstract class ISoldierState
{
    //字典存储状态转换的条件
    protected Dictionary<SoldierTransition, SoldierStateID> mMap = new Dictionary<SoldierTransition, SoldierStateID>();
    protected SoldierStateID mStateID;//存储状态的ID
    protected ICharacter mCharacter;
    protected SoldierFSMSytem mFSM;

    public ISoldierState(SoldierFSMSytem fsm,ICharacter character)
    {
        mFSM = fsm;
        mCharacter = character;
    }


    public SoldierStateID stateID { get { return mStateID; } }

    public void AddTransition(SoldierTransition trans, SoldierStateID id)
    {
        //安全校验
        if (trans == SoldierTransition.NullTansition)
        {
            Debug.LogError("SoldierState Error: trans不能为空"); return;
        }
        if (id == SoldierStateID.NullState)
        {
            Debug.LogError("SoldierState Error: id不能为空"); return;
        }
        if (mMap.ContainsKey(trans))
        {
            Debug.LogError("SoldierState Error: " + trans + "已经添加上了"); return;
        }
        mMap.Add(trans, id);
    }


    public void DeleteTransition(SoldierTransition trans)
    {
        if (mMap.ContainsKey(trans) == false)
        {
            Debug.LogError("删除转换条件的时候，转换条件：[" + trans + "]不存在"); return;
        }
        mMap.Remove(trans);
    }

    //判断当前转换条件下是否能进行状态的转换
    public SoldierStateID GetOutPutState(SoldierTransition trans)
    {
        if (mMap.ContainsKey(trans)==false)//不能进行状态转换
        {
            return SoldierStateID.NullState;
        }
        else//需要进行状态转换
        {
            return mMap[trans];
        }
    }


    //有些状态可能需要进行初始化，有些则不需要，所以声明成虚方法在需要的时候在进行重写
    public virtual void DoBeforeEntering() { }
    public virtual void DoBeforeLeaving() { }

    //这两个方法都需要进行重写，所以声明成抽象方法
    public abstract void Reason(List<ICharacter> targets);
    public abstract void Act(List<ICharacter> targets);

    

    
}

