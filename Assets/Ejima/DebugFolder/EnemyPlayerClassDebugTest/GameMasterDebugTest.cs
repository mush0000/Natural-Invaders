using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterDebugTest : MonoBehaviour
{
    void Start()
    {
        List<CharacterScript> characters = new();
        for (int i = 1; i <= 5; i++)
        {
            // AddComponentを使用してPlayerChildTestを追加
            CharacterScript characterScript = gameObject.AddComponent<CharacterScript>();
            // 初期化メソッドを呼び出してパラメータを設定
            // characterScript.Initialize(200 * i, 0 * i, 4 * i, 3 + i);
            characters.Add(characterScript);
        }

        //* debugStart
        int pCount = 0;
        foreach (CharacterScript items in characters)
        {
            Debug.Log("野菜" + pCount + ": " + items);
            pCount++;
        }
        //* debugEnd

        BeetleEnemyChild beetleEnemyChild = gameObject.AddComponent<BeetleEnemyChild>();
        Debug.Log(beetleEnemyChild.EnemyChargeMagnification);

        beetleEnemyChild.EnemyCharge(); //* 「溜める」行動
        beetleEnemyChild.EnemyGroupAttack(characters); //* 最前列攻撃
        beetleEnemyChild.EnemySingleAttack(characters); //* 最前列中対象ランダム単体攻撃
        beetleEnemyChild.EnemyHeal(); //* 100固定自己回復
    }
}