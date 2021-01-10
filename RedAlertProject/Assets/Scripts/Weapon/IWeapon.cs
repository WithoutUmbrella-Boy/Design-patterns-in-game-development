using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public enum WeaponType
{
    Gun,
    Rifle,
    Rocket
}



public abstract class IWeapon
{
    //protected int mAtk;
    //protected float mAtkRange;
    //protected int mAtkPlusValue;

    protected WeaponBaseAttr mBaseAttr;

    protected GameObject mGameObject;
    protected ICharacter mOwner;
    protected ParticleSystem mPariticle;
    protected LineRenderer mLine;
    protected Light mLight;
    protected AudioSource mAudio;


    protected float mEffectDisplayTime = 0;


    public float atkRange
    {
        get
        {
            return mBaseAttr.atkRange;
        }
    }

    public int atk {
        get { return mBaseAttr.atk; }
    }

    public ICharacter owner { set { mOwner = value; } }
    public GameObject gameObject { get { return mGameObject; } }
    public IWeapon(WeaponBaseAttr baseAttr,GameObject gameObject)
    {
        mBaseAttr = baseAttr;
        mGameObject = gameObject;
        Transform effect = mGameObject.transform.Find("Effect");
        mPariticle = effect.GetComponent<ParticleSystem>();
        mLine = effect.GetComponent<LineRenderer>();
        mLight = effect.GetComponent<Light>();
        mAudio = effect.GetComponent<AudioSource>();

    }


    public void Update()
    {
        if (mEffectDisplayTime>0)
        {
            mEffectDisplayTime -= Time.deltaTime;
            if (mEffectDisplayTime<=0)
            {
                DisableEffect();
            }
        }
    }

    //模板方法模式
    public void Fire(Vector3 targetPosition)
    {
        
        //显示枪口特效
        PlayMuzzleEffect();

        //显示子弹轨迹特效
        PlayBulletEffect(targetPosition);

        //设置特效显示时间
        SetEffetDisplayTime();

        //播放声音
        PlaySound();

    }


    protected abstract void SetEffetDisplayTime();


    protected virtual void PlayMuzzleEffect()
    {
        mPariticle.Stop();
        mPariticle.Play();
        mLight.enabled = true;
    }


    //虚方法和抽象方法的一个区别就是，抽象方法的话子类必须重写改抽象方法，虚方法的话有方法体，可以选择重写或者不重写
    protected abstract void PlayBulletEffect(Vector3 targetPosition);
    
        
    


    protected void DoPlayBulletEffect(float width,Vector3 targetPosition)
    {
        mLine.enabled = true;
        mLine.startWidth = width; mLine.endWidth = width;
        mLine.SetPosition(0, mGameObject.transform.position);
        mLine.SetPosition(1, targetPosition);
    }

    //虚方法和抽象方法的一个区别就是，抽象方法的话子类必须重写改抽象方法，虚方法的话有方法体，可以选择重写或者不重写
    protected abstract void PlaySound();
    
        
        
    


    protected void DoPlaySound(string clipName)
    {
        AudioClip clip = FactoryManager.assetFactory.LoadAudioClip(clipName);
        mAudio.clip = clip;
        mAudio.Play();
    }

    private void DisableEffect()
    {
        mLine.enabled = false;
        mLight.enabled = false;
    }

}

