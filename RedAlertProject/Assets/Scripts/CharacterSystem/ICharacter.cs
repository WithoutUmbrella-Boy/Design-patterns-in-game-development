using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.AI;

public abstract class ICharacter
{

    protected ICharacterAttr mAttr;
    protected GameObject mGameObject;
    protected NavMeshAgent mNavAgent;
    protected AudioSource mAudio;
    protected Animation mAnim;
    protected IWeapon mWeapon ;

    public IWeapon weapon { set { mWeapon = value; } }

    public Vector3 position
    {
        get
        {
            if (mGameObject == null)
            {
                Debug.LogError("mGameObject为空"); return Vector3.zero;
            }
            return mGameObject.transform.position;
        }
    }

    public float atkRange
    {
        get
        {
            return mWeapon.atkRange;
        }
    }



    public void Attack(ICharacter target)
    {
        mWeapon.Fire(target.position);
    }
    
    public void PlayAnim(string animName)
    {
        mAnim.CrossFade(animName);
    }

    public void MoveTo(Vector3 targetPosition)
    {
        mNavAgent.SetDestination(targetPosition);
    }

    
}

