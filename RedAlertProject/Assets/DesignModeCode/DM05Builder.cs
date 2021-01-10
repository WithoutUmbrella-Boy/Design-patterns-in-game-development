using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DM05Builder : MonoBehaviour
{
    void Start()
    {
        IBuilder fatBuilder = new FatPersonBuilder();
        //IBuilder thinBuilder = new ThinPersonBuilder();

        Person fatPerson = Director.Construct(fatBuilder);
        fatPerson.Show();
    }
}
class Person
{
    //存放所有的组件
    List<string> parts = new List<string>();

    //添加一个部分的方法
    public void AddPart(string part)
    {
        parts.Add(part);//添加到集合中
    }
    public void Show()
    {
        //遍历显示
        foreach (string part in parts)
        {
            Debug.Log(part);
        }
    }
}
class FatPerson : Person { }
class ThinPerson : Person { }

//建造者
interface IBuilder
{
    void AddHead();//添加头部
    void AddBody();//添加身体
    void AddHand();//添加手部
    void AddFeet();//添加脚部
    Person GetResult();//组装结果返回给用户
}

//
class FatPersonBuilder : IBuilder
{
    private Person person;

    public FatPersonBuilder()
    {
        person = new FatPerson();
    }

    public void AddHead()
    {
        person.AddPart("胖人头");
    }

    public void AddBody()
    {
        person.AddPart("胖人身体");
    }

    public void AddHand()
    {
        person.AddPart("胖人手");
    }

    public void AddFeet()
    {
        person.AddPart("胖人脚");
    }

    public Person GetResult()
    {
        return person;
    }
}

class ThinPersonBuilder : IBuilder
{
    private Person person;

    public ThinPersonBuilder()
    {
        person = new ThinPerson();
    }

    public void AddHead()
    {
        person.AddPart("瘦人头");
    }

    public void AddBody()
    {
        person.AddPart("瘦人身体");
    }

    public void AddHand()
    {
        person.AddPart("瘦人手");
    }

    public void AddFeet()
    {
        person.AddPart("瘦人脚");
    }

    public Person GetResult()
    {
        return person;
    }
}

//工程师
class Director
{
    //组装方法
    public static Person Construct(IBuilder builder)
    {
        builder.AddBody();
        builder.AddFeet();
        builder.AddHand();
        builder.AddHead();
        return builder.GetResult();
    }
}