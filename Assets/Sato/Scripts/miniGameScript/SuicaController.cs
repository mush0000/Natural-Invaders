using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicaController : MonoBehaviour
{
    private Vector3 mousePos;
    private bool isDrag;

    [SerializeField] GameObject crane;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // マウスの位置をワールド座標に変換
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            mousePos.y = crane.transform.position.y;
            isDrag = true;
            Debug.Log("マウスのpos" + mousePos);
        }
        if (Input.GetMouseButton(0) && isDrag)
        {
            crane.transform.position = mousePos;
            // Debug.Log("クレーンの" + crane.transform.position);
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDrag = false;
        }
    }
}
