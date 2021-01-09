using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public   class ICharacterAttr {

    protected string mName;
    protected int mMaxHP;
    protected float mMoveSpeed;

    protected int mCurrentHP;

    protected string mIconSprite;

    protected int mLv;//战士才会升级
    protected float mCritRate;//0-1暴击率
    //增加的最大血量，抵御的伤害值 暴击增加的伤害
    protected int mDmgDescValue;

    public ICharacterAttr(IAttrStrategy strategy)
    {
        mStrategy = strategy;
        //下面的两个字段当角色被创建出来的时候就已经确定了，所以在构造方法里面直接进行初始化
        mDmgDescValue = mStrategy.GetDmgDescValue(mLv);
        mCurrentHP = mMaxHP + mStrategy.GetExtraHPValue(mLv);
    }

    protected IAttrStrategy mStrategy;
    public int critValue { get { return mStrategy.GetCritDmg(mCritRate); } }
    public int currentHP { get { return mCurrentHP; } }
    //public int dmgDescValue { get { return mDmgDescValue; }}


    public void TakeDamage(int damage)
    {
        damage -= mDmgDescValue;
        if (damage < 5) damage = 5;
        
        mCurrentHP -= damage;
    }
}
