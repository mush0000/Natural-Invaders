using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleEnemyChild : EnemyParent
{
    List<PlayerChildTest> players = new();
    public override void EnemyAction(int turnCount)
    {
        //! 10回周期
        int actionPatternCalc = turnCount % 10;
        switch (actionPatternCalc)
        {
            case 2:
                EnemyCharge();
                break;
            case 7:
                EnemyGroupAttack(players);
                break;
            case 9:
                for (int i = 0; i < 3; i++)
                {
                    EnemySingleAttack(players);
                }
                break;
            case 10:
                break;
            default:
                EnemySingleAttack(players);
                break;
        }
    }
}
