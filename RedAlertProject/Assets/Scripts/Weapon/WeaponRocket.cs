using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WeaponRocket : IWeapon
{

    public override void Fire(Vector3 targetPositon)
    {
        Debug.Log("显示特效 Rocket");
        Debug.Log("播放声音 Rocket");

    }
}

