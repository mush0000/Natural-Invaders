/*
 *  Author: ariel oliveira [o.arielg@gmail.com]
 */

using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ELifeBarController : MonoBehaviour
{
    private GameObject[] heartContainers;
    private Image[] heartFills;
    [SerializeField] GameObject enemy;
    private EnemyParent enemyScript;
    public Transform heartsParent;
    public GameObject heartContainerPrefab;
    private void Awake()
    {

    }
    private void Start()
    {
        enemyScript = enemy.GetComponent<EnemyParent>();
        heartContainers = new GameObject[(int)enemyScript.EnemyMaxLife];
        // heartFills = new Image[(int)PlayerStats.Instance.MaxTotalHealth];
        heartFills = new Image[(int)enemyScript.EnemyLife];
        enemyScript.OnLifeChanged += UpdateHeartsHUD;
        InstantiateHeartContainers();
        UpdateHeartsHUD();
    }

    public void UpdateHeartsHUD()
    {
        SetHeartContainers();
        SetFilledHearts();
    }

    void SetHeartContainers()
    {
        for (int i = 0; i < heartContainers.Length; i++)
        {
            if (i < enemyScript.EnemyMaxLife)
            {
                heartContainers[i].SetActive(true);
            }
            else
            {
                heartContainers[i].SetActive(false);
            }
        }
    }

    void SetFilledHearts()
    {
        for (int i = 0; i < heartFills.Length; i++)
        {
            if (i < enemyScript.EnemyLife)
            {
                heartFills[i].fillAmount = 1;   //Imageが表示される
            }
            else
            {
                heartFills[i].fillAmount = 0;   //Imageが表示されない
            }
        }

        if (enemyScript.EnemyLife % 1 != 0)
        {
            int lastPos = Mathf.FloorToInt(enemyScript.EnemyLife);
            heartFills[lastPos].fillAmount = enemyScript.EnemyLife % 1;
        }
    }

    void InstantiateHeartContainers()
    {
        // // 必要に応じてheartFills配列の長さを調整？
        // if (heartFills.Length < enemyScript.enemyMaxLife){
        //     Array.Resize(ref heartFills, enemyScript.enemyMaxLife);
        // }
        for (int i = 0; i < enemyScript.EnemyMaxLife; i++)
        {
            GameObject temp = Instantiate(heartContainerPrefab);
            temp.transform.SetParent(heartsParent, false);
            // Debug.Log(heartContainers.Length);
            heartContainers[i] = temp;
            heartFills[i] = temp.transform.Find("HeartFill").GetComponent<Image>();
        }
    }
}
