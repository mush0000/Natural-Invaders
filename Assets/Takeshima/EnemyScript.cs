using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : CharacterScript
{
    // コンストラクタ
    public EnemyScript(
        string nameE = "DefaultName",
        int lifeE = 0,
        int atkE = 0,
        int spdE = 0,
        int healE = 0)
        : base(nameE, lifeE, atkE, spdE, 0, 0, 0, 0)
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

    public virtual void EnemyDeath()
    {
        Debug.Log("倒された");
        // 適切な処理をここに書く
    }
}
