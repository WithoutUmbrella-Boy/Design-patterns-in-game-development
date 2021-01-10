using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//享元模式，封装共有字段
public class WeaponBaseAttr
{
    protected string mName;
    protected int mAtk;
    protected float mAtkRange;
    protected string mAssetName;
    public WeaponBaseAttr(string name, int atk, float atkRange, string assetName)
    {
        mName = name;
        mAtk = atk;
        mAtkRange = atkRange;
        mAssetName = assetName;
    }
    public string name { get { return mName; } }
    public int atk { get { return mAtk; } }
    public float atkRange { get { return mAtkRange; } }
    public string assetName { get { return mAssetName; } }
}
