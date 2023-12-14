using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveManager : MonoBehaviour
{
    //Bing『Unityでボタンをタップして、違うボタンを押したらそこにオブジェクトを移動させる方法』------------
    // 移動させたいオブジェクトをインスペクターからアタッチする
    public GameObject target;

    // ボタンの配列をインスペクターからアタッチする
    public Button[] buttons;

    // 最初にタップしたボタンのインデックスを保持する変数
    private int firstIndex;

    // 二回目のタップかどうかを判定するフラグ
    private bool secondTap;

    void Start()
    {
        // ボタンの配列の要素数を確認する
        if (buttons.Length > 0)
        {
            // ボタンの配列の各要素に対して
            for (int i = 0; i < buttons.Length; i++)
            {
                // ボタンのインデックスをローカル変数に保存する
                int index = i;

                // ボタンにクリックイベントを追加する
                buttons[i].onClick.AddListener(() =>
                {
                    // 二回目のタップでなければ
                    if (!secondTap)
                    {
                        // 最初にタップしたボタンのインデックスを保存する
                        firstIndex = index;

                        // 二回目のタップにする
                        secondTap = true;
                    }
                    else
                    {
                        // 二回目にタップしたボタンのインデックスと最初にタップしたボタンのインデックスが違えば
                        if (index != firstIndex)
                        {
                            // 最初にタップしたボタンの位置を取得する
                            Vector3 firstPos = buttons[firstIndex].transform.position;

                            // 二回目にタップしたボタンの位置を取得する
                            Vector3 secondPos = buttons[index].transform.position;

                            // 最初にタップしたボタンと二回目にタップしたボタンの位置を入れ替える
                            buttons[firstIndex].transform.position = secondPos;
                            buttons[index].transform.position = firstPos;

                            // オブジェクトを二回目にタップしたボタンの位置に移動させる
                            target.transform.position = secondPos;
                        }

                        // 二回目のタップを解除する
                        secondTap = false;
                    }
                });
            }
        }
        //-------------------------------------------------------------------------------------
        //このスクリプトを空のオブジェクトにアタッチして、移動させたいオブジェクトをインスペクターからtargetに設定します。
        //また、ボタンの配列のサイズを設定して、ボタンをインスペクターからbuttonsに設定します。すると、ボタンをタップして、違うボタンをタップすると、ボタンとオブジェクトが移動します。
        //このスクリプトでは、ボタンにクリックイベントを追加して、最初にタップしたボタンのインデックスと二回目にタップしたボタンのインデックスを比較して、
        //位置を入れ替えるようにしています。また、secondTapというフラグを使って、二回目のタップかどうかを判定しています3。
    }

    // Update is called once per frame
    void Update()
    {

    }
}
