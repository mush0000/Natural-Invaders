using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public int Life = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnemyAction()
    {
        Debug.Log("EnemyActionだよよよ!");
        Debug.Log("勝手に1点食らうよ");
        Life--;
    }
}
