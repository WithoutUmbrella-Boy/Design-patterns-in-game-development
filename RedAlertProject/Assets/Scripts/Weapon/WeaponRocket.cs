using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WeaponRocket : IWeapon
{
    protected override void PlayBulletEffect(Vector3 targetPosition)
    {
        DoPlayBulletEffect(0.3f, targetPosition);
    }
    protected override void PlaySound()
    {
        DoPlaySound("RocketShot");
    }

    protected override void SetEffetDisplayTime()
    {
        mEffectDisplayTime = 0.4f;
    }
}

