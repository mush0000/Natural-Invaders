using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameDirector : MonoBehaviour
{
    //このクラスの役割
    //ゲームオブジェクト(オールキャラクターリスト)を所持(インスタンスは（仮:FujiedaTomato）)
    //植えた種リストを所持

    public List<FujiedaTomato> AllCharacters = new List<FujiedaTomato>(); //全キャラリスト
    //public List<GameObject> PartyMembers = new List<GameObject>(); //全パーティメンバーリスト
    public List<FujiedaTomato> PlantedSeedCharacters = new List<FujiedaTomato>(); //植えた種リスト
    [SerializeField] FujiedaTomato Character1;//動作確認用
    [SerializeField] FujiedaTomato Character2;
    [SerializeField] FujiedaTomato Character3;
    [SerializeField] FujiedaTomato Character4;
    [SerializeField] FujiedaTomato Character5;
    [SerializeField] FujiedaTomato Character6;
    [SerializeField] FujiedaTomato Character7;

    public static TestGameDirector Instance { get; private set; }   //シングルトンインスタンス

    // private void Awake()
    // {
    //     // インスタンスが既に存在していた場合は破棄する
    //     if (Instance != null)
    //     {
    //         Destroy(gameObject);
    //         return;
    //     }

    //     // このインスタンスをシングルトンインスタンスとして登録
    //     Instance = this;

    //     // シーン遷移時に破棄されないように設定
    //     DontDestroyOnLoad(gameObject);
    // }

    // Start is called before the first frame update
    void Start()
    {
        //フレームレートを60に
        Application.targetFrameRate = 60;
        AllCharacters.Add(Character1);
        AllCharacters.Add(Character2);
        AllCharacters.Add(Character3);
        AllCharacters.Add(Character4);
        AllCharacters.Add(Character5);
        AllCharacters.Add(Character6);
        AllCharacters.Add(Character7);

        //畑用に追記------------------------------------------------------------------
        //畑に植えた時なのでFarmDirectorへ移動
        // for (int i = 0; i < AllCharacters.Count; i++)
        //     if (AllCharacters[i].fresh < 0)
        //     {
        //         PlantedSeedCharacters.Add(AllCharacters[i]);
        //     }
    }
    void Update()
    {

    }
    // void RemoveNull()   //partyMemberで死亡した時にAllCharactersにnullが出てしまうためその要素を削除する
    // {
    //     AllCharacters.RemoveAll(character => character == null);
    // }


}
