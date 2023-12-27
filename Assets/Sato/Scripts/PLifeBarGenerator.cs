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
        Camera mainCamera = Camera.main; // MainCameraを取得します
        foreach (GameObject ptchara in gameDirector.PartyMembers)
        {
            GameObject lifebarCanvas = Instantiate(pLifePrefab);
            lifebarCanvas.transform.SetParent(ptchara.transform, false);
            lifebarCanvas.transform.localPosition = new(0, 0.15f, -0.5f);
            // lifebarCanvas.transform.localScale = new(0, 0.15f, -0.5f);
            Canvas canvas = lifebarCanvas.GetComponent<Canvas>();
            canvas.worldCamera = mainCamera; // CanvasのRender CameraをMainCameraに設定します
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
