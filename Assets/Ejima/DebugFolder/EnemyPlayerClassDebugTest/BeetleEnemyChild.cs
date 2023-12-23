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
            case 1:
                EnemySingleAttack(players);
                break;
            case 2:
                EnemySingleAttack(players);
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
        }

    }

}
