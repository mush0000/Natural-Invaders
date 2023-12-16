using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public int position = 0;
    public Image image;

    //ポジションのゲット・セット------------------------
    public int GetPositon()
    {
        Debug.Log(this.position);
        return this.position;

    }

    public void SetPositon(int position)
    {
        this.position = position;
        Debug.Log(this.position);
    }
    //-------------------------------------------------

    public void SelectButton()
    {
        Debug.Log("selectbutton");
        ClickManager.SetSelectChar(this);//ClickManagerクラスのSetSelectChar()へインスタンスを渡す
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
