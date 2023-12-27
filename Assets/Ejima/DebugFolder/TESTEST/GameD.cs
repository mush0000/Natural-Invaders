using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameD : MonoBehaviour
{
    GameObject human;
    GameObject beetle;
    Human humanH;
    BeetleEnemyChild_1 beetleEnemyChild_1;

    private void Awake()
    {
        human = GameObject.Find("Human");
        humanH = human.GetComponent<Human>();

        beetle = GameObject.Find("Beetle");
        beetleEnemyChild_1 = beetle.GetComponent<BeetleEnemyChild_1>();

        beetleEnemyChild_1.Initialize(EnemyKind_1.beetle, beetleEnemyChild_1.EnemyHealValue);
        Debug.Log(beetleEnemyChild_1.name);
        Debug.Log(beetleEnemyChild_1.EnemyHealValue);

        SoundManager.instance.PlayBGM(SoundManager.BGM_Type.titel);
    }
}