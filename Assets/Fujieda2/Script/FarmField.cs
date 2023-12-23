using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmField : MonoBehaviour
{
    //このクラスの役割
    //畑画面に必要な処理全般を行う
    //1.種状態のものをスクロールビューに追加する
    //2.種(field == true)のものを畝(ウネ)に表示する
    //3.畑に種があるなら、その畑ボタンは押せないようにする
    //4.畑に種があるなら、その種インスタンスのボタンは押せないようにする

    public int fresh;//プレイヤーごとの鮮度を保存
    public int FRESHCOUNT = 1;//戦闘終了時に鮮度が進む(定数)
    public CharacterScript[] characters;//動作確認用のキャラクター配列

    public SeedScript seeds;//確認用seedスクリプト
    public bool isEnpty;

    //[SerializeField] Button button;

    // public void AddTagGoBattleButton() //クリックされたらタグを追加
    // {
    //     for (int i = 0; i < characters.Length; i++)
    //     {
    //         if (characters[i].position == 0) return;//ポジション0の場合はリターン

    //         for (int j = 1; j < 6; j++)
    //         {//ポジションが0以外の場合
    //             characters[i].tag = "PartyMember" + j;//実行するとオブジェクトに新しいタグを追加。
    //         }
    //     }
    // }
    public void FarmNotSeed()//ボタンを押せなくするメソッド
    {
        if (isEnpty == false)//true （種が植えてある）畑はボタンが押せなくなる
        {
            Button btn = GetComponent<Button>();
            btn.interactable = false;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        FarmNotSeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnpty == false)//true （種が植えてある）畑はボタンが押せなくなる
        {
            FarmNotSeed();
        }

        // for (int i = 0; i < characters.Length; i++)
        // {
        //     if (characters[i].position == 0) return;//ポジション0の場合はリターン
        //     button.interactable = false;
        // }
    }

}
