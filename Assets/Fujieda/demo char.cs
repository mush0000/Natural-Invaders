using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class demochar : MonoBehaviour
{
    public int position = 0;


    public GameObject image; //クリックされたら画像を表示→クリックマネージャーに移動

    // public void msg()    //デバック用
    // {
    //     Debug.Log("クリックされた");
    // }

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

    //クリックされたら画像を表示→クリックマネージャーに移動
    // public void buttonDown()
    // {
    //     image.SetActive(true);
    // }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
