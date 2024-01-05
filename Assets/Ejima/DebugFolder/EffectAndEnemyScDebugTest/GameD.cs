using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameD : MonoBehaviour
{
    GameObject humanObject;
    GameObject beetle;
    Human human;
    BeetleEnemyChild_1 beetleEnemyChild_1;
    List<PlayerChildTest> players = new();
    private List<Vector3> allPosList;
    public List<Vector3> AllPosList { get => allPosList; set => allPosList = value; }

    private void Awake()
    {
        //     humanObject = GameObject.Find("Human");
        //     human = humanObject.GetComponent<Human>();

        beetle = GameObject.Find("Beetle");
        beetleEnemyChild_1 = beetle.GetComponent<BeetleEnemyChild_1>();

        beetleEnemyChild_1.Initialize(EnemyKind_1.beetle, beetleEnemyChild_1.EnemyHealValue);
        Debug.Log(beetleEnemyChild_1.name);
        Debug.Log(beetleEnemyChild_1.EnemyHealValue);
        Debug.Log(beetleEnemyChild_1.particleObject);
        beetleEnemyChild_1.AttackParticleSystem();
        // SoundManager.instance.PlayBGM(SoundManager.BGM_Type.titel);

        Vector3 pos1 = new Vector3(-1, 0, 0);
        Vector3 pos2 = new Vector3(0, 0, 0);
        Vector3 pos3 = new Vector3(1, 0, 0);

        AllPosList = new List<Vector3> { pos1, pos2, pos3 };

        beetleEnemyChild_1.GetPos();

    }


}