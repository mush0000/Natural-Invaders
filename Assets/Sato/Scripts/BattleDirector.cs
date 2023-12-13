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

    bool isWin = false;
    bool isLose = false;

    // Start is called before the first frame update
    void Start()
    {
        //キャラクター1～5に割り当てる
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
        // if (enemy.life <= 0)
        // {
        //     isWin = true;
        // }
    }

    void RotateFormation()  //ポジションロール
    {
        foreach (GameObject Character in characterList)
        {
            float posz = (Character.transform.position.z - 1 == -2) ?
            Character.transform.position.z + 2 : Character.transform.position.z - 1;
            //前列が中列へ移動～後列は前列へ
            Character.transform.position =
            new Vector3(Character.transform.position.x, Character.transform.position.y, posz);
        }
    }
}
