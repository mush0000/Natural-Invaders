using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEditor.Animations;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class BriefingManager : MonoBehaviour
{
    GameObject gameDirectorObject;
    GameDirector gameDirector;
    [SerializeField] GameObject memberWindowPrefab;
    [SerializeField] Transform scrollViewContent;

    // Start is called before the first frame update
    void Start()
    {
        //gameDirector(js)の取得
        gameDirectorObject = GameObject.Find("GameDirector");
        GameDirector gameDirector = gameDirectorObject.GetComponent<GameDirector>();
        //すべてのキャラクターの分だけインスタンス生成
        foreach (GameObject character in gameDirector.AllCharacters)
        {
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
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickBattleStartButton()
    {
        SceneManager.LoadScene("Battle");
    }
}
