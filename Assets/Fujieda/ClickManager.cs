using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    static DemoChar currentSelectChar; //Charインスタンスを受け取るChar型変数
    Image image;

    public static void SetSelectChar(DemoChar ch)//CharクラスのSelectButton()から渡されたインスタンスを受け取る
    {
        //Debug.Log("click");//デバック用
        currentSelectChar = ch;//受け取ったインスタンスをchに格納
    }

    public void ButtonDown() //クリックされたら画像を表示
    {
        if (currentSelectChar != null)
        {
            image.sprite = currentSelectChar.image.sprite;//画像を差し替え(sprite 自身の画像)

        }
        this.gameObject.SetActive(true);//自身の画像を変更する
    }

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
