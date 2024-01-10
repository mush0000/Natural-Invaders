using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleEnemyChild : EnemyParent
{
    List<CharacterScript> characters = new();

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
                EnemyGroupAttack(characters);
                break;
            case 9:
                for (int i = 0; i < 3; i++)
                {
                    EnemySingleAttack(characters);
                }
                break;
            default:
                EnemySingleAttack(characters);
                break;
        }
    }
}