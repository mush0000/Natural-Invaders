using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    string name = "";
    int Life = 20;

    void FrontAttack()
    {
        Debug.Log("攻撃した");
    }
    void MiddleAttack()
    {
        Debug.Log("中列攻撃");
    }
    void BackAttack()
    {
        Debug.Log("後列回復");
    }

    void AutoHeal()
    {
        Debug.Log("自動回復");

    }
    void Death()
    {
        Debug.Log("死亡した");
        //destroy()
    }
}


// Start is called before the first frame update
// void Start()
// {

// }

// Update is called once per frame
// void Update()
// {

// }
// }
