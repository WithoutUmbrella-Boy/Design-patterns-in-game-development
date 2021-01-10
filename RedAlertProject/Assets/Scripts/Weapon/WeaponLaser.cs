using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WeaponLaser : IWeapon
{
    public WeaponLaser(int atk, float atkRange, GameObject gameObject) : base(atk, atkRange, gameObject) { }


    protected override void PlayBulletEffect(Vector3 targetPosition)
    {
        throw new NotImplementedException();
    }

    protected override void PlaySound()
    {
        throw new NotImplementedException();
    }

    protected override void SetEffetDisplayTime()
    {
        throw new NotImplementedException();
    }
}

