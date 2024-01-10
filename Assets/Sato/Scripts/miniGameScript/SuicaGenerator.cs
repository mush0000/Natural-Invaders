using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuicaGenerator : MonoBehaviour
{
    [SerializeField] SuicaDirector suicaDirector;
    [SerializeField] public GameObject[] previewImages;
    [SerializeField] public GameObject[] prefabs;
    private GameObject nextObject;
    private GameObject nextImage;
    [SerializeField] GameObject crane;
    private int num;    //ランダム用数値
    [SerializeField] private float height;  //クレーンからの高さ

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetNextObject()
    {   //プレビューにランダムイメージをセット
        num = Random.Range(0, 4);
        nextImage = previewImages[num];
        nextImage.SetActive(true);
    }

    public void SetObjectToCacther()
    {   //クレーンにObjectを作成して配置。numをもとに生成
        nextObject = suicaDirector.GetObject(prefabs[num]);
        nextObject.transform.SetParent(crane.transform);
        nextObject.transform.localPosition = new Vector2(0, height);
        nextImage.SetActive(false); //nextImageを非表示にして
        SetNextObject();    //新しいのを作成
    }
}
