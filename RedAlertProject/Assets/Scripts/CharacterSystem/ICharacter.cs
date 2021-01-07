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
    protected IWeapon mWeapon ;

    public IWeapon weapon { set { mWeapon = value; } }



    public void Attack(Vector3 targetPosition)
    {
        mWeapon.Fire(targetPosition);
    }
    

}

