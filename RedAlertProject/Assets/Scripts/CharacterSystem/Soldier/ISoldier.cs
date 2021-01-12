using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum SoldierType
{
    Rookie,
    Sergeant,
    Captain,
    Captive
}


public abstract class ISoldier : ICharacter
{
    protected SoldierFSMSytem mFSMSystem;
    public ISoldier() : base()
    {
        MakeFSM();
    }






    public override void UpdateFSMAI(List<ICharacter> targets)
    {
        mFSMSystem.currentState.Reason(targets);
        mFSMSystem.currentState.Act(targets);
    }


    protected void MakeFSM()
    {
        mFSMSystem = new SoldierFSMSytem();

        SoldierIdleState idleState = new SoldierIdleState(mFSMSystem, this);
        idleState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

        SoldierChaseState chaseState = new SoldierChaseState(mFSMSystem, this);
        chaseState.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        chaseState.AddTransition(SoldierTransition.CanAttack, SoldierStateID.Attack);

        SoldierAttackState attackState = new SoldierAttackState(mFSMSystem, this);
        attackState.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        attackState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

        mFSMSystem.AddState(idleState, chaseState, attackState);

    }


    public override void UnderAttack(int damage)
    {
        base.UnderAttack(damage);

        if (mAttr.currentHP <= 0)
        {
            PlaySound();
            PlayEffect();
            Killed();
        }
    }


    protected abstract void PlaySound();
    protected abstract void PlayEffect();
    

}
