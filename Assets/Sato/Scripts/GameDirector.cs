using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public List<GameObject> AllCharacters = new List<GameObject>(); //全キャラリスト
    public List<GameObject> PartyMembers = new List<GameObject>();  //全パーティメンバーリスト
    [SerializeField] GameObject Character1;     //動作確認用
    [SerializeField] GameObject Character2;
    [SerializeField] GameObject Character3;
    [SerializeField] GameObject Character4;
    [SerializeField] GameObject Character5;
    [SerializeField] GameObject Character6;
    [SerializeField] GameObject Character7;

    public static GameDirector Instance { get; private set; }   //シングルトンインスタンス

    private void Awake()
    {
        // インスタンスが既に存在していた場合は破棄する
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // このインスタンスをシングルトンインスタンスとして登録
        Instance = this;

        // シーン遷移時に破棄されないように設定
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        AllCharacters.Add(Character1);
        AllCharacters.Add(Character2);
        AllCharacters.Add(Character3);
        AllCharacters.Add(Character4);
        AllCharacters.Add(Character5);
        AllCharacters.Add(Character6);
        AllCharacters.Add(Character7);

    }

    // Update is called once per frame
    void Update()
    {

    }


}
