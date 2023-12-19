using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    public int position;
    static CharacterScript currentSelectChar; //Charインスタンスを受け取るChar型変数
    Image image;

    public CharacterScript[] characters;

    public static void SetSelectChar(CharacterScript ch)//CharacterManagerクラスのSelectButton()から渡されたインスタンスを受け取る
    {
        //Debug.Log("click");//デバック用
        currentSelectChar = ch;//受け取ったインスタンスをchに格納
    }

    public void SetPositionOnTileButton() //クリックされたら画像を表示
    {
        if (currentSelectChar != null)//キャラを選択中なら処理を行う
        {
            if (currentSelectChar.position != 0) return;//ポジションが0以外の場合処理を行わない
            currentSelectChar.position = position;
            image.sprite = currentSelectChar.image.sprite;//画像を差し替え(sprite 自身の画像)
            image.gameObject.SetActive(true);//自身の画像を変更する
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        image = transform.GetChild(0).GetComponent<Image>();
        image.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
