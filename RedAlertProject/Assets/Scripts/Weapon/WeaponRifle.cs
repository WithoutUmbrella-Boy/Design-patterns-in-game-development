using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WeaponRifle : IWeapon
{

    public WeaponRifle(int atk, float atkRange, GameObject gameObject) : base(atk, atkRange, gameObject) { }
    protected override void PlayBulletEffect(Vector3 targetPosition)
    {
        DoPlayBulletEffect(0.1f, targetPosition);
    }
    protected override void PlaySound()
    {
        DoPlaySound("RifleShot");
    }

    protected override void SetEffetDisplayTime()
    {
        mEffectDisplayTime = 0.3f;
    }
}

