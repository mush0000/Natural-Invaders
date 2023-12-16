using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerrManager : MonoBehaviour
{
    //1.キャラクターインスタンスの『フィールド:position』を書き換える
    //2.キャラクターインスタンスにタグを追加する
    //3.上記2つの処理を行い、『バトル画面』に引き継ぐ

    public int position;//プレイヤーごとの配置を保存

    // Start is called before the first frame update
    void Start()
    {
        //ゲームオブジェクトにコンポーネントとして追加します。実行すると AddTag メソッドに渡した文字列が新しいタグとして追加されていきます。
        // AddTag("PartyMember1");
        // AddTag("PartyMember2");
        // AddTag("PartyMember3");
        // AddTag("PartyMember4");
        // AddTag("PartyMember5");
    }

    //スクリプトから新しいタグを追加する
    // static void AddTag(string tagname) {
    //     UnityEngine.Object[] asset = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset");
    //     if ((asset != null) && (asset.Length > 0)) {
    //         SerializedObject so = new SerializedObject(asset[0]);
    //         SerializedProperty tags = so.FindProperty("tags");

    //         for (int i = 0; i < tags.arraySize; ++i) {
    //             if (tags.GetArrayElementAtIndex(i).stringValue == tagname) {
    //                 return;
    //             }
    //         }

    //         int index = tags.arraySize;
    //         tags.InsertArrayElementAtIndex(index);
    //         tags.GetArrayElementAtIndex(index).stringValue = tagname;
    //         so.ApplyModifiedProperties();
    //         so.Update();
    //     }
    // }

    // Update is called once per frame
    void Update()
    {

    }
}
