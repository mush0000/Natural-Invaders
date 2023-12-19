using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChild : CharacterScript
{
    new int enemyLife;
    protected int enemyAttack = 30;
    public int enemyMaxLife = 20;
    private bool enemyChargeFlag = false;
    // Start is called before the first frame update

    public void EnemyCharge()
    {
        this.enemyAttack *= 1 + (50 / 100); //!1.5倍 Float型ではなかったため整数で百分率で1.5倍
        this.enemyChargeFlag = true;
    }

    public void EnemyChargeInvalid()
    {
        this.enemyAttack /= 1 + (50 / 100); //!1.5倍の攻撃力を1.5で割っているためAtkを1倍に戻す
        this.enemyChargeFlag = false;
    }

    public void EnemySingleAttack(List<CharacterScript> characters)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].position == 1)
            {

            }
            else
            {

            }

        }
    }

    public void EnemyGroupAttack()
    {

    }

    public void SelectTarget(List<CharacterScript> characters)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].position >= 3) //前列指定
            {
                int randPosition = (int)UnityEngine.Random.Range(1.0f, 4.0f);
            }
            else if (characters[i].position >= 6) //中列指定
            {
                int position = (int)UnityEngine.Random.Range(6.0f, 7.0f);
            }
            else //後列
            {
                int position = (int)UnityEngine.Random.Range(1.0f, 4.0f);
            }

        }
    }

}