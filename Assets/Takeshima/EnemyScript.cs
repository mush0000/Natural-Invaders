using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : CharacterScript
{
    // コンストラクタ
    public EnemyScript(
        string enemyName = "DefaultName",
        int enemyLife = 0,
        int enemyAtk = 0,
        int enemySpd = 0,
        int enemyHeal = 0)

        : base(enemyName, enemyLife, enemyAtk, enemySpd, enemyHeal)
    {
        // 追加の初期化があればここに書く
    }

    // EnemyScript独自のメソッド
    public override void FrontAction()
    {
        // CharacterScriptのFrontActionメソッドが実行される
        base.FrontAction();

        // 追加の処理をここに書く
    }

    // EnemyScript独自のメソッド
    public virtual void EnemyAction()
    {
        Debug.Log("敵の攻撃");


    }
    public virtual void EnemyCharge()
    {
        Debug.Log("力をためる");
    }
    public virtual void EnemyAttack()
    {
        Debug.Log("敵の攻撃");
    }

    public virtual void EnemyPowerAction()
    {
        Debug.Log("敵の強い攻撃");
    }

    public virtual void EnemyLineAction()
    {
        Debug.Log("敵の三列攻撃");
    }

    public virtual void EnemyHealAction()
    {
        Debug.Log("敵の回復行動");
    }

}

// public virtual void EnemyDeath()
// {
//     Debug.Log("倒された");
//     // 適切な処理をここに書く
// }
