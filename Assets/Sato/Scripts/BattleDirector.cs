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
    [SerializeField] GameObject playerActionPopup; //プレイヤーアクションポップアップ
    [SerializeField] UnityEngine.UI.Button skill1Button;
    [SerializeField] UnityEngine.UI.Button skill2Button;
    [SerializeField] UnityEngine.UI.Button skill3Button;
    List<UnityEngine.UI.Button> skillButtons = new List<UnityEngine.UI.Button>();


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
    List<Vector3> allPositions;
    bool isSkillUsed = false;   //スキルを使ったかどうか、使ってたらtrue
    bool playerHasActed = false;    //プレイヤーが行動したかどうか

    // Start is called before the first frame update
    IEnumerator Start()
    {
        // フレームレートを60に
        Application.targetFrameRate = 60;
        // タイルのポジションをリスト化
        allPositions = new List<Vector3> { pos1, pos2, pos3, pos4, pos5, pos6, pos7, pos8, pos9 };
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
        // ボタンリストに追加
        Debug.Log(skill1Button);
        Debug.Log(skill2Button);
        Debug.Log(skill3Button);
        skillButtons.Add(skill1Button);
        skillButtons.Add(skill2Button);
        skillButtons.Add(skill3Button);
        // enemyにenemyを割り当てる
        enemy = GameObject.FindWithTag("Enemy");
        // enemyのEnemy1という名前のスクリプトをenemyScriptへ代入
        enemyScript = enemy.GetComponent<Enemy1>();

        // バトルの開始
        yield return StartCoroutine(BattleStart());
        StartCoroutine(BattleMainLoop());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // RotateFormation();
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
            //3列目回復
            yield return StartCoroutine(BackLineHeal());
            //ロール
            // RotateFormation();
            yield return StartCoroutine(PlayerAction());
        }
    }

    IEnumerator ActionPlayerTurn()
    {
        RaycastHit hit;
        foreach (Vector3 pos in allPositions)   //全部のタイルから
        {
            Vector3 groundPos = new Vector3(pos.x, 0, pos.z); // y座標を0に設定
            if (Physics.Raycast(groundPos, Vector3.up, out hit))
            {
                CharacterScript characterScript = hit.transform.GetComponent<CharacterScript>();
                if (characterScript != null)
                {
                    // posのz座標(Line)によってアクションを決定
                    if (pos.z == 1)
                    {
                        characterScript.FrontAction();
                    }
                    else if (pos.z == 0)
                    {
                        characterScript.MiddleAction();
                    }
                    else // pos.z == -1
                    {
                        characterScript.BackAction();
                    }
                    Judge();    //生死判定
                    if (isWin || isLose) // 勝利または敗北が確定した場合
                    {
                        break; // ループを抜ける
                    }
                    yield return new WaitForSeconds(0.2f);  //0.2秒待って
                }
            }
        }
    }

    IEnumerator BackLineHeal()  //3列目の回復行動
    {
        RaycastHit hit;
        foreach (Vector3 pos in allPositions)
        {
            if (pos.z == -1)    //最後列かどうか
            {
                Vector3 groundPos = new Vector3(pos.x, 0, pos.z); // y座標を0に設定
                if (Physics.Raycast(groundPos, Vector3.up, out hit))
                {
                    CharacterScript characterScript = hit.transform.GetComponent<CharacterScript>();
                    if (characterScript != null)    //そこにキャラクターがいるなら
                    {
                        characterScript.AutoHeal();
                        yield return new WaitForSeconds(0.2f);  //0.2秒待って
                    }
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
            EndingStage();
        }
        else
        {
            int deathCount = 0;
            foreach (CharacterScript cs in characterScripts)
            {
                if (cs.characterLife <= 0)
                {
                    cs.Death();
                    deathCount++;
                }
            }
            if (deathCount >= characterScripts.Count)  //もし全員Deadなら負け、characterScriptsがPTMと同じ要素数であることが前提条件
            {
                isLose = true;
                EndingStage();
            }
        }
    }

    void EndingStage()  //ステージエンド用
    {
        //タグの削除と
        //すべてのキャラクタースクリプトのPosを0に初期化する処理を行う
        if (isWin == true)
        {
            winEffect.SetActive(true);
        }
        if (isLose == true)
        {
            loseEffect.SetActive(true);
        }
    }

    IEnumerator PlayerAction()
    {
        playerActionPopup.SetActive(true);
        SkillButtonCheck();
        // プレイヤーが行動を選択するまで待つ
        while (!playerHasActed)
        {
            yield return null;
        }
        // プレイヤーが行動を選択した後の処理
        playerActionPopup.SetActive(false);
        playerHasActed = false;
    }

    void SkillButtonCheck()
    {
        foreach (UnityEngine.UI.Button button in skillButtons)
        {
            if (isSkillUsed)
            {
                Color color = button.image.color;
                color.a = 0.8f; // 透明度を80%に設定
                button.image.color = color;
                button.interactable = false; // ボタンを押下不可能に設定
            }
            else
            {
                Color color = button.image.color;
                color.a = 1f; // 透明度を100%に設定
                button.image.color = color;
                button.interactable = true; // ボタンを押下可能に設定
            }
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
    public void RotateFormation()  //ポジションロール
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

    public void playerActed()
    {
        playerHasActed = true;
    }
    public void OnButtonClickSkill1()
    {
        StartCoroutine(Skill1DmgEnemy());
        isSkillUsed = true;
        playerActed();
    }
    IEnumerator Skill1DmgEnemy()
    {
        int dmg = (int)(enemyScript.Life * 0.1);
        if (dmg <= 0) { dmg = 1; };
        enemyScript.Life -= dmg;
        //何かしらのエフェクト、効果音
        yield return new WaitForSeconds(0.5f); //エフェクトや効果音の再生時間
    }

    public void OnButtonClickSkill2()
    {
        StartCoroutine(Skill2Resurrection());
        isSkillUsed = true;
        playerActed();
    }
    IEnumerator Skill2Resurrection()
    {
        foreach (CharacterScript cs in characterScripts)
        {
            if (cs.isDead == true)
            {
                cs.ResurrectionHP1();
            }
        }
        yield return new WaitForSeconds(0.5f); //エフェクトや効果音の再生時間
    }

    public void OnButtonClickSkill3()
    {
        StartCoroutine(Skill3AutoHealAll());
        isSkillUsed = true;
        playerActed();
    }
    IEnumerator Skill3AutoHealAll()
    {
        RaycastHit hit;
        foreach (Vector3 pos in allPositions)
        {
            Vector3 groundPos = new Vector3(pos.x, 0, pos.z); // y座標を0に設定
            if (Physics.Raycast(groundPos, Vector3.up, out hit))
            {
                CharacterScript characterScript = hit.transform.GetComponent<CharacterScript>();
                if (characterScript != null)    //そこにキャラクターがいるなら
                {
                    characterScript.AutoHeal();
                    yield return new WaitForSeconds(0.1f);  //0.2秒待って
                }
            }
        }
    }
}