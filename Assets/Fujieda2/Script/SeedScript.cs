using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class SeedScript : MonoBehaviour
{
    //動作確認用のキャラクターインスタンススクリプト
    //1.畑に植える=>farmField == falseの時植えられる
    //2.field == true の時はボタンが押せない
    public bool field;
    public Image image;

    public int fresh;

    public SeedScript(int fresh)
    {
        this.fresh = fresh;
    }

    public void SelectButton()
    {
        Debug.Log("selectbutton");
        FarmClickManager.SetSelectSeed(this);//ClickManagerクラスのSetSelectChar()へインスタンスを渡す
        field = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (field == true)
        {
            Button btn = GetComponent<Button>();
            btn.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (field == true)
        {
            Button btn = GetComponent<Button>();
            btn.interactable = false;
        }
    }
}
