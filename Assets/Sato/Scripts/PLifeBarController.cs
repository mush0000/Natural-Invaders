using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
public class PLifeBarController : MonoBehaviour
{
    // private GameObject character;   //このスクリプトがアタッチされているGameObjectの親キャラクター
    private Knight characterScript; //そのスクリプト
    // Start is called before the first frame update
    [SerializeField] GameObject fillImageObject;
    private UnityEngine.UI.Image fillImage;
    void Start()
    {
        // character = this.gameObject.transform.parent.gameObject;
        characterScript = this.gameObject.GetComponentInParent<Knight>();
        characterScript.OnLifeChanged += LifeBarUpdate;
        fillImage = fillImageObject.GetComponent<UnityEngine.UI.Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //MaxLife100％分のCharacterLifeTest分fill
    void LifeBarUpdate()
    {
        float lifeAmount = 0.0f;
        // lifeAmount = characterScript.CharacterLifeTest / characterScript.MaxCharacterLifeTest;
        lifeAmount = (float)characterScript.CharacterLifeTest / (float)characterScript.maxLifeTest;
        Debug.Log(characterScript.CharacterLifeTest + "現在Life");
        Debug.Log(characterScript.maxLifeTest + "最大Life");
        Debug.Log(lifeAmount + "この数値にFill");
        fillImage.fillAmount = lifeAmount;
    }
}
