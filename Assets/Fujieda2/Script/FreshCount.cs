using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreshCount : MonoBehaviour
{
    //このクラスの役割:戦闘終了時に動くクラス(メソッド)
    //戦闘終了時に鮮度値(FRESHCOUNT)を進める
    //1.戦闘終了後に野菜の鮮度を1進める
    //2.戦闘終了後に畑に植えてある種の鮮度を1進める

    //種(field == true)の種は(FRESHCOUNTが1になったら)種=>野菜になり仲間に加わる(畑画面から外れる)
    //畑画面(fresh <= 0)のインスタンスを表示
    //編成画面と仲間確認画面(fresh > 0)のインスタンスを表示


    //CharacterScriptに下記二つの変数を追加------------------------------
    public int fresh;//プレイヤーごとの鮮度を保存
    public bool field;//種プレイヤーが畑に植えてあるか
    //-----------------------------------------------------------------
    public int FRESHCOUNT = 1;//戦闘終了時に鮮度が進む(定数)
    public CharacterScript[] characters;//動作確認用のキャラクター配列

    // public void NextFreshCount() //キャラクターの鮮度が進む
    // {
    //     for (int i = 0; i < characters.Length; i++)
    //     {
    //         if (characters[i].fresh <= 0 && characters[i].field == false)//鮮度0以下かつ畑に植えていない
    //         {
    //             continue;//スキップ
    //         }
    //         else if (characters[i].fresh <= 0 && characters[i].field == true)//鮮度0以下かつ畑に植えている
    //         {
    //             characters[i].fresh += FRESHCOUNT;//鮮度を1進める
    //         }
    //         else
    //         {
    //             characters[i].fresh += FRESHCOUNT;//鮮度を1進める
    //         }

    //         if (characters[i].fresh > 0 && characters[i].field == true)//鮮度1かつ畑に植えている
    //         {
    //             characters[i].field == false;//畑から出し、仲間に加わる
    //         }
    //     }
    // }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
