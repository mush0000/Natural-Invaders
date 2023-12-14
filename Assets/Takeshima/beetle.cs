using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetle : EnemyScript
{
    public Beetle() : base("Beetle", 500, 10, 10, 80)
    {
        // 親クラス(CharacterScript)のコンストラクタを呼び出す
        // ここで追加の初期化などを行うこともできます
    }

    public override void EnemyAction()
    {
        base.EnemyAction();
        // 敵独自の行動の処理を追加
    }
    public override void EnemyHealAction()
    {
        base.EnemyHealAction();

    }

    public override void EnemyDeath()
    {
        base.EnemyDeath();
        // 敵の死
    }





    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
