using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//枚举定义状态转换的条件
public enum EnemyTransition
{
    NullTansition = 0,
    CanAttack,
    LostSoldier
}

//定义Soldier状态
public enum EnemyStateID
{
    NullState,
    Chase,
    Attack
}

public  abstract class IEnemyState
{
    //字典存储状态转换的条件
    protected Dictionary<EnemyTransition, EnemyStateID> mMap = new Dictionary<EnemyTransition, EnemyStateID>();
    protected EnemyStateID mStateID;//存储状态的ID
    protected ICharacter mCharacter;
    protected EnemyFSMSystem mFSM;

    public IEnemyState(EnemyFSMSystem fsm, ICharacter character)
    {
        mFSM = fsm;
        mCharacter = character;
    }


    public EnemyStateID stateID { get { return mStateID; } }

    public void AddTransition(EnemyTransition trans, EnemyStateID id)
    {
        //安全校验
        if (trans == EnemyTransition.NullTansition)
        {
            Debug.LogError("EnemyState Error: trans不能为空"); return;
        }
        if (id == EnemyStateID.NullState)
        {
            Debug.LogError("EnemyState Error: id不能为空"); return;
        }
        if (mMap.ContainsKey(trans))
        {
            Debug.LogError("EnemyState Error: " + trans + "已经添加上了"); return;
        }
        mMap.Add(trans, id);
    }


    public void DeleteTransition(EnemyTransition trans)
    {
        if (mMap.ContainsKey(trans) == false)
        {
            Debug.LogError("删除转换条件的时候，转换条件：[" + trans + "]不存在"); return;
        }
        mMap.Remove(trans);
    }

    //判断当前转换条件下是否能进行状态的转换
    public EnemyStateID GetOutPutState(EnemyTransition trans)
    {
        if (mMap.ContainsKey(trans) == false)//不能进行状态转换
        {
            return EnemyStateID.NullState;
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

