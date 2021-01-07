using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WeaponLaser : IWeapon
{
    public override void Fire(Vector3 targetPosition)
    {
        Debug.Log("显示特效 Laser");
        Debug.Log("播放声音 Laser");
    }
}

