using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
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
    List<GridCheck> grids;  //gridのリスト

    // Start is called before the first frame update
    void Start()
    {
        //gameDirector(js)の取得
        gameDirectorObject = GameObject.Find("GameDirector");
        gameDirector = gameDirectorObject.GetComponent<GameDirector>();
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
    }

    // Update is called once per frame
    void Update()
    {

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
