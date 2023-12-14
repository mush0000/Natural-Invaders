using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    string characterName = "name";
    int characterLife = 20; //任意の値
    void FrontAction()
    {
        Debug.Log("前列攻撃");
    }
    void MiddleAction()
    {
        Debug.Log("中列攻撃");
    }
    void BackAction()
    {
        Debug.Log("後列行動");
    }
    void Death()
    {
        Debug.Log("死亡した");
        //destroy()
    }






    // Start is called before the first frame update
    // void Start()
    // {

    // }

    // Update is called once per frame
    // void Update()
    // {

    // }
}
