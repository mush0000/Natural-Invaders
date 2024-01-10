using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmClickManager : MonoBehaviour
{
    //このクラスの役割
    //1.スクロールビューから選択した種を、畑に植える(クリックマネージャー)
    //2.植えた種を、(field == true)に変更する。(『FreshCount』により戦闘終了時に鮮度が1進む)
    //3.Xボタンを押すと、自身を捨てる処理が行われる(キャラクター自身の消滅メソッドがあればそれを呼び出す)

    //public GameObject[] characters;//動作確認用のキャラクター配列
    [SerializeField] Button button;

    static CharacterScript currentSelectChar; //Charインスタンスを受け取るChar型変数
    Image image;

    static FujiedaTomato seeds;

    public FarmGameDirector testGameDirector;

    public static void SetSelectSeed(FujiedaTomato sd)//CharacterManagerクラスのSelectButton()から渡されたインスタンスを受け取る
    {
        // Debug.Log("click");//デバック用
        seeds = sd;//受け取ったインスタンスをchに格納
    }

    public void SetPositionOnTileButton(FarmField farm) //FarmField型を受け渡し
    {
        Debug.Log(seeds.gameObject.name);//動作確認用
        if (seeds != null && farm.isEnpty == true)//キャラを選択中 かつ 畑が空なら処理を行う
        {
            Debug.Log(seeds.gameObject.name);//動作確認用
            image = farm.transform.GetChild(0).GetComponent<Image>();//自身の子要素の画像を取得
            //if (seeds.gameObject.isUsed == true) return;//種がすでに植えてあるなら処理を行わない
            image.sprite = seeds.image.sprite;//画像を差し替え(sprite 自身の画像)
            image.gameObject.SetActive(true);//自身の画像を変更する
            seeds.isPlanted = true;//種を植えたことにする
            farm.isEnpty = false;//畑が植えられたことにする
            // sasaki案(仮)
            FreshCountVer couuntVer = farm.GetComponentInChildren<FreshCountVer>();
            couuntVer.tomato = seeds;

            testGameDirector.PlantedSeedCharacters[farm.farmField] = (FujiedaTomato)seeds;//(植えた種リスト)に選択したキャラクターを追加
            seeds = null;//シードの選択を解除する
        }
    }

    // public void AddTagFarmFieldButton() //クリックされたらタグを追加
    // {
    //     if (farmFieldTag <= 6)//farmFieldに追加されたインスタンスにタグを追加する(最大6つ)
    //     {
    //         for (int j = 0; j < 6; j++)//i<6 => 『charactersのfarmFieldTag』の数値を取得
    //         {
    //             characters[j].tag = "farmField" + j;//空いているタグを引きつぐ「実行するとインスタンスに新しいタグを追加。

    //             Button btn = GetComponent<Button>();//タグがある種はクリック出来なくする
    //             btn.interactable = false;
    //         }
    //     }
    // }

    // Start is called before the first frame update
    void Start()
    {
        // for (int i = 0; i < characters.Length; i++)
        // {
        //     // //GameObject.FindGameObjectsWithTag()で、同じタグ名のGameObjectを一挙に取得できる。
        //     // GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("farmField");

        //     // foreach (GameObject gameObj in gameObjects)
        //     // {
        //     //     Button btn = GetComponent<Button>();//タグがある種はクリック出来なくする
        //     //     btn.interactable = false;
        //     // }

        //     //植える際の処理に必要?
        //     //image = transform.GetChild(0).GetComponent<Image>();
        //     //image.gameObject.SetActive(false);
        // }
    }

    // Update is called once per frame
    void Update()
    {
    }



}
