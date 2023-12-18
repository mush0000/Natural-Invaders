using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
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

    }

    // Update is called once per frame
    void Update()
    {

    }


}
