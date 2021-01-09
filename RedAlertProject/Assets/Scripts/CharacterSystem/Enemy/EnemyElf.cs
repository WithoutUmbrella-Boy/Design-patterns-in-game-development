using System;
using System.Collections.Generic;
using System.Text;


public class EnemyElf : IEnemy
{
    protected override void PlayEffect()
    {
        DoPlayEffect("ElfHitEffect");
    }
}

