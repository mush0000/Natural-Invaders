using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato : CharacterScript
{
    public Potato() : base("Potato", 25, 5, 0, 0, 15)
    {
        // 親クラス(CharacterScript)のコンストラクタを呼び出す
        // ここで追加の初期化などを行うこともできます
    }

    public override void FrontAction()
    {
        base.FrontAction();
        // Potato独自の前列行動の処理を追加
    }
    public override void MiddleAction()
    {
        base.MiddleAction();
        // Potato独自の中列行動の処理を追加
    }
    public override void BackAction()
    {
        base.BackAction();
        // Potato独自の後列行動の処理を追加
    }

    public override void Death()
    {
        base.Death();
        // Potatoの死
    }




    // Start is called before the first frame update
    // void Start()
    // {

    // }

    // // Update is called once per frame
    // void Update()
    // {

    // }
}
