using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WeaponRifle : IWeapon
{
    public  override void Fire(Vector3 targetPositon)
    {
        Debug.Log("显示特效 Rifle");
        Debug.Log("播放声音 Rifle");

    }

}

