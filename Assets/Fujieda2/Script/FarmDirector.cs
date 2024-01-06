using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class FarmDirector : MonoBehaviour
{//このクラスの役割
 //Findメソッドで( Find TestGameDirectorを取得
 //ゲットコンポーネント
 //ゲームディレクターccを取得
 //拡張for文でインスタンスを作る
 //if判定で鮮度が-のものだけを格納
 //スクロールビュー用のプレファブ作成 ← 12/26今ココ
 //スクロールビューのコンテント親要素に指定
 //画像を所持しており、自身の画像を表示(植えた時には種画像を書き換える)
 //植えた種リストを生成(シーン起動時に判定し、成長したかどうかを判定して消す、消したらnullにしておく)

    //佐藤さんのコード借りたので明日書き換えます↓----------------------------------------------------

    GameObject gameDirectorObject;
    TestGameDirector gameDirector;
    [SerializeField] GameObject seedWindowPrefab;
    [SerializeField] Transform scrollViewContent;
    //[SerializeField] GameObject battleMemberAlert;
    //[SerializeField] GameObject gridParent;
    // [SerializeField] GameObject grid1;
    // [SerializeField] GameObject grid2;
    // [SerializeField] GameObject grid3;
    // [SerializeField] GameObject grid4;
    // [SerializeField] GameObject grid5;
    // [SerializeField] GameObject grid6;
    // List<GridCheck> grids;  //gridのリスト

    List<FujiedaTomato> SeedCharacters = new List<FujiedaTomato>();

    public TestGameDirector testGameDirector;

    // Start is called before the first frame update
    void Start()
    {
        //gameDirector(js)の取得
        gameDirectorObject = GameObject.Find("TestGameDirector");
        gameDirector = gameDirectorObject.GetComponent<TestGameDirector>();
        //すべてのキャラクターの分だけインスタンス生成
        for (int i = 0; i < gameDirector.AllCharacters.Count; i++)
        {
            if (gameDirector.AllCharacters[i].fresh > 1 && gameDirector.AllCharacters[i].isPlanted == true)
            {//植えていて鮮度が1以上になったら、植える判定をfalse
                gameDirector.AllCharacters[i].isPlanted = false;
            }
            else if (gameDirector.AllCharacters[i].fresh > 1) { continue; }
            else
            {
                Debug.Log("test");

                SeedCharacters.Add(gameDirector.AllCharacters[i]);
                // 可視化
                gameDirector.AllCharacters[i].gameObject.SetActive(true);

                //Instantiateの使い方
                //戻り値・・・既存オブジェクトのクローン
                //第1引数(original)・・・ コピーしたい既存オブジェクト

                // MemberWindowのPrefabからインスタンスを作成
                GameObject seedWindow = Instantiate(seedWindowPrefab, scrollViewContent);
                GameObject characterWindowImage = seedWindow.transform.GetChild(0).gameObject;
                GameObject characterWindowText = seedWindow.transform.GetChild(1).gameObject;

                // キャラクターのGameObjectをCharacterWindowの子要素として設定
                SeedCharacters[i].transform.SetParent(characterWindowImage.transform);

                //キャラクター自身の画像を表示
                characterWindowImage.GetComponent<Image>().sprite = SeedCharacters[i].image.sprite;

                //キャラクター自身のステータスをテキストで表示
                characterWindowText.GetComponent<Text>().text =
                     $"Fresh:{-1 * SeedCharacters[i].fresh} \nName:\n{SeedCharacters[i].name} ";//キャラのステータスを取得Life:{ SeedCharacters[i].life } 

                // キャラクターのGameObjectを特定の位置に移動
                SeedCharacters[i].transform.localPosition = new Vector3(180, -10, 0);
                SeedCharacters[i].transform.localScale = new Vector3(250, 490, 0);
                //SeedCharacters[i].transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            // if (i <= 5 &&testGameDirector.PlantedSeedCharacters[i].fresh >= 1)//鮮度1以上かつ畑に植えていたら
            // {
            //     //植えた種リストから、キャラクターを削除、PlantedSeedCharactersをnullにする
            //     testGameDirector.PlantedSeedCharacters[farm.farmField] = null;//(植えた種リスト)に選択したキャラクターを追加
            //     //farmFieldのisEnptyをfalseにする
            //     farm.farmField
            // }
        }
        //gridのリストを作成
        // grids = new List<GridCheck>(){
        //     grid1.GetComponent<GridCheck>(),
        //     grid2.GetComponent<GridCheck>(),
        //     grid3.GetComponent<GridCheck>(),
        //     grid4.GetComponent<GridCheck>(),
        //     grid5.GetComponent<GridCheck>(),
        //     grid6.GetComponent<GridCheck>(),
        // };

    }
    //畑フィールド PlantedSeedCharacters

    // Update is called once per frame
    void Update()
    {

    }

    // public void OnClickBattleStartButton()
    // {
    //     //5人以下かどうかチェック
    //     int battleMemberCount = 0;
    //     foreach (GridCheck grid in grids)
    //     {
    //         if (grid.attached)
    //         {
    //             battleMemberCount++;
    //         }
    //     }
    //     if (battleMemberCount <= 5)
    //     {
    //         GetChara getChara = gridParent.GetComponent<GetChara>();
    //         List<FujiedaTomato> list = getChara.Get();
    //         gameDirector.PlantedSeedCharacters = list;
    //         foreach (FujiedaTomato partyCharacter in gameDirector.PlantedSeedCharacters)
    //         {
    //             CharacterScript cs = partyCharacter.GetComponent<CharacterScript>();
    //             GridCheck gc = partyCharacter.GetComponentInParent<GridCheck>();
    //             cs.position = gc.position;
    //             partyCharacter.transform.parent = null;
    //             DontDestroyOnLoad(partyCharacter);
    //         }
    //         foreach (FujiedaTomato allchara in gameDirector.AllCharacters)
    //         {
    //             allchara.transform.parent = null;
    //             DontDestroyOnLoad(allchara);
    //             allchara.gameObject.SetActive(false);
    //         }
    //         foreach (FujiedaTomato ptchara in gameDirector.PlantedSeedCharacters)
    //         {
    //             ptchara.gameObject.SetActive(true);
    //         }
    //         SceneManager.LoadScene("Battle");
    //     }
    //     else
    //     {
    //         //警告文
    //         battleMemberAlert.SetActive(true);
    //     }
    // }
}
