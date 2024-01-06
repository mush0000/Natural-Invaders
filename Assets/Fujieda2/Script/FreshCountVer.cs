using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//機能として収穫までの時間をバーにして表示する
public class FreshCountVer : MonoBehaviour
{
    //最大freshと現在のHP。
    int minFtesh = 0;
    int currentFtesh;
    //Sliderを入れる
    public Slider slider;

    public FarmField farm;
    public TestGameDirector testGameDirector;
    GameObject gameDirectorObject;
    FarmField FarmField;
    TestGameDirector gameDirector;
    [SerializeField] GameObject seedWindowPrefab;
    [SerializeField] Transform scrollViewContent;
    List<FujiedaTomato> SeedCharacters = new List<FujiedaTomato>();
    public FujiedaTomato tomato;

    // Start is called before the first frame update
    void Start()
    {

        //Sliderを満タンにする。
        slider.value = 1;
        //現在のfreshを入れる。
        gameDirectorObject = GameObject.Find("TestGameDirector");
        gameDirector = gameDirectorObject.GetComponent<TestGameDirector>();
        //int farmFieldNum = FarmField.farmField;
        // currentFtesh = SeedCharacters[farmFieldNum].fresh;
        //Debug.Log("Start currentFtesh : " + currentFtesh);

    }

    //ColliderオブジェクトのIsTriggerにチェック入れること。
    // private void OnTriggerEnter(Collider collider)
    // {
    //     //Enemyタグのオブジェクトに触れると発動
    //     //現在のHPからダメージを引く
    //     // currentFtesh = currentFtesh - minFtesh;
    //     Debug.Log("After currentFtesh : " + currentFtesh);

    //     //最大HPにおける現在のHPをSliderに反映。
    //     //int同士の割り算は小数点以下は0になるので、
    //     //(float)をつけてfloatの変数として振舞わせる。
    //     // slider.value = (float)currentFtesh / (float)minFtesh; ;
    //     Debug.Log("slider.value : " + slider.value);
    // }

    // //ColliderオブジェクトのIsTriggerにチェック入れること。
    // private void OnTriggerEnter(Collider collider)
    // {
    //     //Enemyタグのオブジェクトに触れると発動
    //     if (collider.gameObject.tag == "Enemy")
    //     {
    //         //ダメージは1～100の中でランダムに決める。
    //         int damage = Random.Range(1, 100);
    //         Debug.Log("damage : " + damage);

    //         //現在のHPからダメージを引く
    //         currentFtesh = currentFtesh - damage;
    //         Debug.Log("After currentFtesh : " + currentFtesh);

    //         //最大HPにおける現在のHPをSliderに反映。
    //         //int同士の割り算は小数点以下は0になるので、
    //         //(float)をつけてfloatの変数として振舞わせる。
    //         slider.value = (float)currentFtesh / (float)maxFtesh; ;
    //         Debug.Log("slider.value : " + slider.value);
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        if (tomato != null)
        {
            slider.value = tomato.fresh;
        }
    }
}
