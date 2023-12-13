using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
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
    List<GameObject> characterList = new List<GameObject>();
    Enemy1 enemyScript;
    bool isWin = false;
    bool isLose = false;

    // Start is called before the first frame update
    void Start()
    {
        // フレームレートを60に
        Application.targetFrameRate = 60;
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
        // enemyにenemyを割り当てる
        enemy = GameObject.FindWithTag("Enemy");
        // enemyのEnemy1という名前のスクリプトをenemyScriptへ代入
        enemyScript = enemy.GetComponent<Enemy1>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RotateFormation();
        }
    }

    void Judge()
    {
        if (enemyScript.Life <= 0)
        {
            isWin = true;
            return;
        }
        // if ()
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
