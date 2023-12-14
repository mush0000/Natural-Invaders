using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    // Start is called before the first frame update
    public string characterName = "name";
    public int characterLife = 20; //任意の値
    public void FrontAction()
    {
        Debug.Log("前列攻撃");
        characterLife -= 10;
    }
    public void MiddleAction()
    {
        Debug.Log("中列攻撃");
    }
    public void BackAction()
    {
        Debug.Log("後列行動");
    }
    public void Death()
    {
        Debug.Log("死亡した");
    }

    public void AutoHeal()
    {
        int gainLife = (int)(characterLife * 0.2);
        characterLife += gainLife;
        Debug.Log($"{gainLife}回復した");
    }
}
