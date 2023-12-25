using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : CharacterScript
{
    public int maxLifeTest = 30;
    public int CharacterLifeTest
    {
        get { return characterLife; }
        set
        {
            // 任意の制御や処理を追加できます
            characterLife = value;
            if (OnLifeChanged != null)
            {
                OnLifeChanged.Invoke(); //着火しまーす！
            }
        }
    }
    public int MaxCharacterLifeTest
    {
        get { return MaxCharacterLife; }

    }

    public delegate void OnLifeChangedDelegate();
    public event OnLifeChangedDelegate OnLifeChanged;

    // Start is called before the first frame update
    void Start()
    {
        maxLifeTest = 30;
        characterLife = 30;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void MiddleAction()
    {
        CharacterLifeTest -= 5;
        Debug.Log("5点食らった");
        base.MiddleAction();
    }
}
