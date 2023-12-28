using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleEnemyChild_1 : EnemyParent_1
{
    List<PlayerChildTest> players = new();

    public override void EnemyAction_1(int turnCount)
    {
        //! 10回周期
        int actionPatternCalc = turnCount % 10;
        switch (actionPatternCalc)
        {
            case 2:
                EnemyCharge_1();
                break;
            case 7:
                EnemyGroupAttack_1(players);
                break;
            case 9:
                for (int i = 0; i < 3; i++)
                {
                    EnemySingleAttack_1(players);
                }
                break;
            default:
                EnemySingleAttack_1(players);
                break;
        }
    }
}