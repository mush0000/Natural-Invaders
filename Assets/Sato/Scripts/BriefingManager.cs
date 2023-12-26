using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class BriefingManager : MonoBehaviour
{
    GameObject gameDirectorObject;
    GameDirector gameDirector;

    [SerializeField] GameObject memberWindowPrefab;
    [SerializeField] Transform scrollViewContent;
    [SerializeField] GameObject battleMemberAlert;
    [SerializeField] GameObject gridParent;
    [SerializeField] GameObject grid1;
    [SerializeField] GameObject grid2;
    [SerializeField] GameObject grid3;
    [SerializeField] GameObject grid4;
    [SerializeField] GameObject grid5;
    [SerializeField] GameObject grid6;
    [SerializeField] GameObject grid7;
    [SerializeField] GameObject grid8;
    [SerializeField] GameObject grid9;
    [SerializeField] GameObject partyInfoSumObject;    //PTキャラの合計情報
    private Text partySumInfo;
    List<GridCheck> grids;  //gridのリスト
    List<GameObject> frontLine;     //前列のGridObject
    List<GameObject> middleLine;    //中列のGridObject
    private int preSum; //パーティ情報の合計直前情報
    // Start is called before the first frame update
    void Start()
    {
        //gameDirector(js)の取得
        gameDirectorObject = GameObject.Find("GameDirector");
        gameDirector = gameDirectorObject.GetComponent<GameDirector>();
        // PT情報表示用Textの取得
        partySumInfo = partyInfoSumObject.GetComponent<Text>();
        //すべてのキャラクターの分だけインスタンス生成
        foreach (GameObject character in gameDirector.AllCharacters)
        {
            // 可視化
            character.SetActive(true);
            // MemberWindowのPrefabからインスタンスを作成
            GameObject memberWindow = Instantiate(memberWindowPrefab, scrollViewContent);
            GameObject characterWindow = memberWindow.transform.GetChild(0).gameObject;
            // キャラクターのGameObjectをCharacterWindowの子要素として設定
            character.transform.SetParent(characterWindow.transform);
            // キャラクターのGameObjectを特定の位置に移動
            character.transform.localPosition = new Vector3(0, -140, -40);
            character.transform.localScale = new Vector3(80, 80, 80);
            character.transform.localRotation = Quaternion.Euler(0, 180, 0);
            // すべてのDragObjにUpdatePartySumInfoを追加
            DragObj dragObj = characterWindow.GetComponent<DragObj>();
            dragObj.OnPartySumInfoChanged += UpdatePartySumInfo;
        }
        //gridのリストを作成
        grids = new List<GridCheck>(){
            grid1.GetComponent<GridCheck>(),
            grid2.GetComponent<GridCheck>(),
            grid3.GetComponent<GridCheck>(),
            grid4.GetComponent<GridCheck>(),
            grid5.GetComponent<GridCheck>(),
            grid6.GetComponent<GridCheck>(),
            grid7.GetComponent<GridCheck>(),
            grid8.GetComponent<GridCheck>(),
            grid9.GetComponent<GridCheck>()
        };
        // 前列中列のリスト作成
        frontLine = new List<GameObject> { grid1, grid2, grid3 };
        middleLine = new List<GameObject> { grid4, grid5, grid6 };
        SoundManager.instance.PlayBGM(SoundManager.BGM_Type.titel);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdatePartySumInfo()
    {
        int AtkSum = 123;
        int MatkSum = 456;
        int DefASum = 789;
        int AtkASum = 101;
        // パーティのステータス合計
        List<CharacterScript> frontCsList = new List<CharacterScript>();
        foreach (GameObject frontObj in frontLine)
        {
            frontCsList.Add(frontObj.GetComponentInChildren<CharacterScript>());
        }
        List<CharacterScript> middleCsList = new List<CharacterScript>();
        foreach (GameObject middleObj in middleLine)
        {
            middleCsList.Add(middleObj.GetComponentInChildren<CharacterScript>());
        }
        foreach (CharacterScript cs in frontCsList)
        {
            // AtkSum += cs.characterAtk;
            // MatkSum += cs.characterMatk;
        }
        foreach (CharacterScript cs in middleCsList)
        {
            // DefASum += cs.characterDaux;
            // AtkASum += cs.characterAaux;
        }
        partySumInfo.text =
        $"前列\nATK {AtkSum}\nMatk {MatkSum}\n中列補助\nDefA {DefASum}\nAtkA {AtkASum}";
    }

    public void OnClickBattleStartButton()
    {
        //5人以下かどうかチェック
        int battleMemberCount = 0;
        foreach (GridCheck grid in grids)
        {
            if (grid.attached)
            {
                battleMemberCount++;
            }
        }
        if (battleMemberCount <= 5)
        {
            GetChara getChara = gridParent.GetComponent<GetChara>();
            List<GameObject> list = getChara.Get();
            gameDirector.PartyMembers = list;
            foreach (GameObject partyCharacter in gameDirector.PartyMembers)
            {
                CharacterScript cs = partyCharacter.GetComponent<CharacterScript>();
                GridCheck gc = partyCharacter.GetComponentInParent<GridCheck>();
                cs.position = gc.position;
                partyCharacter.transform.parent = null;
                DontDestroyOnLoad(partyCharacter);
            }
            foreach (GameObject allchara in gameDirector.AllCharacters)
            {
                allchara.transform.parent = null;
                DontDestroyOnLoad(allchara);
                allchara.SetActive(false);
            }
            foreach (GameObject ptchara in gameDirector.PartyMembers)
            {
                ptchara.SetActive(true);
            }
            SceneManager.LoadScene("Battle");
        }
        else
        {
            //警告文
            battleMemberAlert.SetActive(true);
        }
    }
}
