using System;
using System.Collections.Generic;
using System.Text;


public class SoldierAttr : ICharacterAttr
{
    public SoldierAttr(IAttrStrategy strategy) : base(strategy)
    {
    }
}

