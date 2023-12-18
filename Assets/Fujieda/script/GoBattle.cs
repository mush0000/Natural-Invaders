using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoBattle : MonoBehaviour
{
    //出撃ボタンを押したときの処理
    //1.出撃メンバーをリスト内から探す(if文 ポジションが0以外の場合)
    //2.出撃メンバー(キャラクターインスタンス)にタグを追加する(for文)
    //3.タグをつけた出撃メンバーおよびインスタンスを『バトル画面』に引き継ぐ
    //4.配置キャラが一人もいない場合は出撃できない(ボタンは押せない)


    public int position;//プレイヤーごとの配置を保存
    public CharacterScript[] characters;//動作確認用のキャラクター配列

    [SerializeField] Button button;

    public void AddTagGoBattleButton() //クリックされたらタグを追加
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].position == 0) return;//ポジション0の場合はリターン

            for (int j = 1; j < 6; j++)
            {//ポジションが0以外の場合
                characters[i].tag = "PartyMember" + j;//実行するとオブジェクトに新しいタグを追加。
            }
        }

    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].position == 0) return;//ポジション0の場合はリターン
            button.interactable = false;
        }
    }
}
