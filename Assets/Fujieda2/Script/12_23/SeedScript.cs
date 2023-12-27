using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class SeedScript : MonoBehaviour
{
    //動作確認用 キャラクターインスタンススクリプト
    //仕様によってはリスト型にしてそのまま使うことになるかも?
    //1.畑に植える=>(farm.isEnpty = true)かつ(isUsed = false)の時植えられる
    //2.(isUsed = true) の時はボタンが押せない
    public bool isPlanted = false;
    public Image image;

    public int fresh = -5;

    public SeedScript(int fresh)
    {
        this.fresh = fresh;
    }

    public void SeedSelectButton()
    {
        Debug.Log("SeedSelectbutton");//動作確認用
        //FarmClickManager.SetSelectSeed(this);//ClickManagerクラスのSetSelectSeed()へインスタンスを渡す
    }
    // Start is called before the first frame update
    void Start()
    {
        if (isPlanted == true)
        {
            Button btn = GetComponent<Button>();
            btn.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlanted == true)
        {
            Button btn = GetComponent<Button>();
            btn.interactable = false;
        }
    }
}
