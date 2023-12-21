using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmField : MonoBehaviour
{
    //このクラスの役割
    //畑画面に必要な処理全般を行う
    //1.種状態で植えられるものをスクロールビューに追加する
    //2.tagがついているものを畝(ウネ)に表示する


    public int fresh;//プレイヤーごとの鮮度を保存
    public int FRESHCOUNT = 1;//戦闘終了時に鮮度が進む(定数)
    public CharacterScript[] characters;//動作確認用のキャラクター配列

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


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // for (int i = 0; i < characters.Length; i++)
        // {
        //     if (characters[i].position == 0) return;//ポジション0の場合はリターン
        //     button.interactable = false;
        // }
    }

}
