using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameD : MonoBehaviour
{
    [SerializeField] private GameObject beetle;
    [SerializeField] private GameObject cube1;
    [SerializeField] private GameObject cube2;
    [SerializeField] private GameObject cube3;
    // PlayerChildTest playerChildTest;
    BeetleEnemyChild_1 beetleEnemyChild_1;
    List<PlayerChildTest> players = new();
    private List<Vector3> allPosList;
    public List<Vector3> AllPosList { get => allPosList; set => allPosList = value; }

    private void Awake()
    {
        Vector3 pos1 = new Vector3(-1, 0, 0);
        Vector3 pos2 = new Vector3(0, 0, 0);
        Vector3 pos3 = new Vector3(1, 0, 0);

        //* デバック定義開始
        cube1 = GameObject.Find("Cube1");
        cube1.transform.position = pos1;
        PlayerChildTest cubePCT1 = cube1.GetComponent<PlayerChildTest>();

        cube2 = GameObject.Find("Cube2");
        cube2.transform.position = pos2;

        PlayerChildTest cubePCT2 = cube2.GetComponent<PlayerChildTest>();

        cube3 = GameObject.Find("Cube3");
        cube3.transform.position = pos3;
        PlayerChildTest cubePCT3 = cube3.GetComponent<PlayerChildTest>();

        players.Add(cubePCT1);
        players.Add(cubePCT2);
        players.Add(cubePCT3);

        beetle = GameObject.Find("Beetle");
        beetleEnemyChild_1 = beetle.GetComponent<BeetleEnemyChild_1>();
        beetleEnemyChild_1.Initialize(EnemyKind_1.beetle, beetleEnemyChild_1.EnemyHealValue);
        //* デバック定義_終了

        // Debug.Log($"{cubePCT1.PlayerLife}, {cubePCT1.PlayerPosition}");
        // Debug.Log($"{cubePCT2.PlayerLife}, {cubePCT2.PlayerPosition}");
        // Debug.Log($"{cubePCT3.PlayerLife}, {cubePCT3.PlayerPosition}");

        // beetleEnemyChild_1.EnemySingleAttack_1(players);

        // Debug.Log($"{cubePCT1.PlayerLife}, {cubePCT1.PlayerPosition}");
        // Debug.Log($"{cubePCT2.PlayerLife}, {cubePCT2.PlayerPosition}");
        // Debug.Log($"{cubePCT3.PlayerLife}, {cubePCT3.PlayerPosition}");

        // Debug.Log($"{cubePCT1.PlayerLife}, {cubePCT1.PlayerPosition}");
        // Debug.Log($"{cubePCT2.PlayerLife}, {cubePCT2.PlayerPosition}");
        // Debug.Log($"{cubePCT3.PlayerLife}, {cubePCT3.PlayerPosition}");
        StartCoroutine(beetleEnemyChild_1.EnemyGroupAttack_1(players));
        // Debug.Log($"{cubePCT1.PlayerLife}, {cubePCT1.PlayerPosition}");
        // Debug.Log($"{cubePCT2.PlayerLife}, {cubePCT2.PlayerPosition}");
        // Debug.Log($"{cubePCT3.PlayerLife}, {cubePCT3.PlayerPosition}");

        Debug.Log(beetleEnemyChild_1.name);
        Debug.Log(beetleEnemyChild_1.EnemyHealValue);
        // SoundManager.instance.PlayBGM(SoundManager.BGM_Type.titel);


    }


}