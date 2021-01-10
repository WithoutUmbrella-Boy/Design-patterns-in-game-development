﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WeaponGun : IWeapon
{

    public WeaponGun(int atk, float atkRange, GameObject gameObject) : base(atk, atkRange, gameObject) { }

    protected override void PlayBulletEffect(Vector3 targetPosition)
    {
        DoPlayBulletEffect(0.05f, targetPosition);
    }



    protected override void PlaySound()
    {
        DoPlaySound("GunShot");
    }

    protected override void SetEffetDisplayTime()
    {
        mEffectDisplayTime = 0.2f;
    }
}

