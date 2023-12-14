using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BattleDirector : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    Vector3 pos1 = new(-1, 1, 1);
    Vector3 pos2 = new(0, 1, 1);
    Vector3 pos3 = new(1, 1, 1);
    Vector3 pos4 = new(-1, 1, 0);
    Vector3 pos5 = new(0, 1, 0);
    Vector3 pos6 = new(1, 1, 0);
    Vector3 pos7 = new(-1, 1, -1);
    Vector3 pos8 = new(0, 1, -1);
    Vector3 pos9 = new(1, 1, -1);
    [SerializeField] GameObject Character1;
    [SerializeField] GameObject Character2;
    [SerializeField] GameObject Character3;
    [SerializeField] GameObject Character4;
    [SerializeField] GameObject Character5;
    [SerializeField] GameObject winEffect;  //勝利文字
    [SerializeField] GameObject loseEffect; //敗北文字
    [SerializeField] GameObject battleStartEffect; //出撃文字


    CharacterScript characterScript1;
    CharacterScript characterScript2;
    CharacterScript characterScript3;
    CharacterScript characterScript4;
    CharacterScript characterScript5;

    List<CharacterScript> characterScripts = new List<CharacterScript>();
    List<GameObject> characterList = new List<GameObject>();
    Enemy1 enemyScript;
    bool isWin = false;
    bool isLose = false;
    List<Vector3> frontLine = new List<Vector3>();  //前列ポジ
    List<Vector3> middleLine = new List<Vector3>();
    List<Vector3> backLine = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        // フレームレートを60に
        Application.targetFrameRate = 60;
        // Lineの設定
        frontLine.Add(pos1);
        frontLine.Add(pos2);
        frontLine.Add(pos3);
        middleLine.Add(pos4);
        middleLine.Add(pos5);
        middleLine.Add(pos6);
        backLine.Add(pos7);
        backLine.Add(pos8);
        backLine.Add(pos9);
        //キャラクター1～5に場所を割り当てる
        Character1.transform.position = pos1;
        Character2.transform.position = pos2;
        Character3.transform.position = pos6;
        Character4.transform.position = pos7;
        Character5.transform.position = pos9;
        // リストにキャラクターを追加
        characterList.Add(Character1);
        characterList.Add(Character2);
        characterList.Add(Character3);
        characterList.Add(Character4);
        characterList.Add(Character5);
        // それぞれのキャラクタースクリプトを割り当てる
        characterScript1 = Character1.GetComponent<CharacterScript>();
        characterScript2 = Character2.GetComponent<CharacterScript>();
        characterScript3 = Character3.GetComponent<CharacterScript>();
        characterScript4 = Character4.GetComponent<CharacterScript>();
        characterScript5 = Character5.GetComponent<CharacterScript>();
        // スクリプトリストの作成
        characterScripts.Add(characterScript1);
        characterScripts.Add(characterScript2);
        characterScripts.Add(characterScript3);
        characterScripts.Add(characterScript4);
        characterScripts.Add(characterScript5);
        // enemyにenemyを割り当てる
        enemy = GameObject.FindWithTag("Enemy");
        // enemyのEnemy1という名前のスクリプトをenemyScriptへ代入
        enemyScript = enemy.GetComponent<Enemy1>();

        // バトルの開始
        StartCoroutine(BattleStart());
        StartCoroutine(BattleMainLoop());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RotateFormation();
        }
    }

    IEnumerator BattleMainLoop()   //バトルの基本ループ
    {
        while (isWin == false && isLose == false)
        {
            //味方のターン        
            yield return StartCoroutine(ActionPlayerTurn());
            if (isWin || isLose)
            {
                break;
            }
            //敵のターン
            ActionEnemyTurn();
            Judge();
            //ロール
            RotateFormation();
        }
    }

    IEnumerator ActionPlayerTurn()
    {
        //前列のアクション
        RaycastHit hit;
        foreach (Vector3 pos in frontLine)
        {
            Vector3 groundPos = new Vector3(pos.x, 0, pos.z); // y座標を0に設定
            if (Physics.Raycast(groundPos, Vector3.up, out hit))
            {
                Debug.Log("フロントアクション");
                CharacterScript characterScript = hit.transform.GetComponent<CharacterScript>();
                if (characterScript != null)
                {
                    characterScript.FrontAction();
                    Judge();    //生死判定
                    if (isWin || isLose) // 勝利または敗北が確定した場合
                    {
                        break; // ループを抜ける
                    }
                    yield return new WaitForSeconds(0.2f);  //2秒待って
                }
            }
        }
        // 勝利または敗北が確定した場合、それ以降のアクションを停止
        if (isWin || isLose) yield break;
        //中列のアクション
        foreach (Vector3 pos in middleLine)
        {
            Vector3 groundPos = new Vector3(pos.x, 0, pos.z); // y座標を0に設定
            if (Physics.Raycast(groundPos, Vector3.up, out hit))
            {
                Debug.Log("middleアクション");
                CharacterScript characterScript = hit.transform.GetComponent<CharacterScript>();
                if (characterScript != null)
                {
                    characterScript.MiddleAction();
                    Judge();    //生死判定
                    if (isWin || isLose) // 勝利または敗北が確定した場合
                    {
                        break; // ループを抜ける
                    }
                    yield return new WaitForSeconds(0.2f);  //2秒待って
                }
            }
        }
        // 勝利または敗北が確定した場合、それ以降のアクションを停止
        if (isWin || isLose) yield break;
        //後列のアクション
        foreach (Vector3 pos in backLine)
        {
            Vector3 groundPos = new Vector3(pos.x, 0, pos.z); // y座標を0に設定
            if (Physics.Raycast(groundPos, Vector3.up, out hit))
            {
                Debug.Log("backアクション");
                CharacterScript characterScript = hit.transform.GetComponent<CharacterScript>();
                if (characterScript != null)
                {
                    characterScript.BackAction();
                    Judge();    //生死判定
                    if (isWin || isLose) // 勝利または敗北が確定した場合
                    {
                        break; // ループを抜ける
                    }
                    yield return new WaitForSeconds(0.2f);  //2秒待って
                }
            }
        }
    }

    void ActionEnemyTurn()
    {
        enemyScript.EnemyAction();
    }
    IEnumerator BattleStart()
    {
        //バトルスタート演出
        battleStartEffect.SetActive(true);
        // 3秒待つ
        yield return new WaitForSeconds(3);
        // 3秒後にSetActiveをfalseにする
        battleStartEffect.SetActive(false);
    }

    void Judge()    //生死判定
    {
        if (enemyScript.Life <= 0)  //敵のライフが0なら即勝利
        {
            isWin = true;
        }
        else
        {
            bool isPartyAlive = false;
            foreach (CharacterScript cs in characterScripts)
            {
                if (cs.characterLife > 0)
                {
                    isPartyAlive = true;
                    break;
                }
            }
            if (isPartyAlive == false)  //もし誰もisPartyAliveしなかったら負け
            {
                isLose = true;
            }
        }
        EndingStage();
    }

    void EndingStage()  //ステージエンド用
    {
        if (isWin == true)
        {
            winEffect.SetActive(true);
        }
        if (isLose == true)
        {
            loseEffect.SetActive(true);
        }
    }

    IEnumerator MoveOverTime(GameObject character, Vector3 targetPosition, float duration, float jumpHeight)
    {
        Vector3 startPosition = character.transform.position;
        // スタートポジションとエンドポジションの中間地点を計算
        Vector3 midPosition = (startPosition + targetPosition) / 2;
        // Y座標の高さが最大値になるようにピークポジションを設定
        Vector3 peakPosition = midPosition + new Vector3(0, jumpHeight, 0);
        Vector3 endPosition = targetPosition;
        endPosition.y = 1;
        float elapsed = 0;  //日本語で経過時間
        // durationは日本語で間隔、経過時間が指定した時間の半分に満ちたら走るwhile文が変わるよ
        // 上昇
        while (elapsed < duration / 2)
        {
            character.transform.position = Vector3.Lerp(startPosition, peakPosition, elapsed / (duration / 2));
            elapsed += Time.deltaTime;
            yield return null;
        }
        elapsed = 0;
        // 下降
        while (elapsed < duration / 2)
        {
            character.transform.position = Vector3.Lerp(peakPosition, targetPosition, elapsed / (duration / 2));
            elapsed += Time.deltaTime;
            yield return null;
        }
        character.transform.position = endPosition;
    }
    void RotateFormation()  //ポジションロール
    {
        foreach (GameObject Character in characterList)
        {
            float posz = (Character.transform.position.z - 1 <= -2) ?
            Character.transform.position.z + 2 : Character.transform.position.z - 1;
            //前列が中列へ移動～後列は前列へ
            Vector3 targetPosition = new Vector3(Character.transform.position.x, Character.transform.position.y, posz);
            float jumpHeight = (posz == 1) ? 0.8f : 0.3f;   //左が最後列から前へ飛ぶ高さ、右がその他の列の高さ
            StartCoroutine(MoveOverTime(Character, targetPosition, 0.2f, jumpHeight));
        }
    }
}
