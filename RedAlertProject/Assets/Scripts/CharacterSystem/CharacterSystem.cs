using System;
using System.Collections.Generic;
using System.Text;


public class CharacterSystem : IGameSystem
{
    private List<ICharacter> mEnemys = new List<ICharacter>();
    private List<ICharacter> mSoldiers = new List<ICharacter>();


    public void AddEnemy(IEnemy enemy)
    {
        mEnemys.Add(enemy);
    }

    public void RemoveEnemy(IEnemy enemy)
    {
        mEnemys.Remove(enemy);
    }

    public void AddSoldier(ISoldier soldier)
    {
        mSoldiers.Add(soldier);
    }

    public void RemoveSoldier(ISoldier soldier)
    {
        mSoldiers.Remove(soldier);
    }


    public override void Update()
    {
        UpdateEnemy();
        UpdateSoldier();
    }


    private void UpdateEnemy()
    {
        foreach (IEnemy e in mEnemys)
        {
            e.Update();
            e.UpdateFSMAI(mSoldiers);
        }
    }

    private void UpdateSoldier()
    {
        foreach (ISoldier s in mSoldiers)
        {
            s.Update();
            s.UpdateFSMAI(mEnemys);
        }
    }
}

