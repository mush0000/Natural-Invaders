using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLifeBarGenerator : MonoBehaviour
{
    [SerializeField] GameObject pLifePrefab;  //ライフバーUIPrefab
    GameObject gameDirectorObject;   //gameDirector
    private GameDirector gameDirector;
    // Start is called before the first frame update
    void Start()
    {
        gameDirectorObject = GameObject.Find("GameDirector");
        gameDirector = gameDirectorObject.GetComponent<GameDirector>();
        foreach (GameObject ptchara in gameDirector.PartyMembers)
        {
            GameObject lifebar = Instantiate(pLifePrefab);
            lifebar.transform.SetParent(ptchara.transform, false);
            lifebar.transform.localPosition = new(0, 0.3f, -0.7f);
            lifebar.transform.localScale = new(0.15f, 0.15f, 0.15f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
