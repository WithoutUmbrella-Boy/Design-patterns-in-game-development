using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//外观模式
public class GameFacade
{
    private static GameFacade _instance = new GameFacade();

    private bool mIsGameOver = false;//游戏是否结束

    public static GameFacade Insance { get { return _instance; } }


    public bool isGameOver { get { return mIsGameOver; } }

    private GameFacade()
    {

    }

    public void Init()
    {

    }


    public void Update()
    {

    }

    public void Release()
    {

    }


}

