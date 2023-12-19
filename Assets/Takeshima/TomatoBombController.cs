using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoBombController : MonoBehaviour
{
    public void Shoot(Vector3 dir)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(new Vector3(2000, 200, 0));

    }

    void OnCollisionEnter(Collision colision)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        // this.transform.localScale = Vector3.zero;
    }
    public void Start()
    {
        Application.targetFrameRate = 60;
        Shoot(new Vector3(2000, 200, 0));
    }

    // Update is called once per frame
    void Update()
    {
        // マウスの左クリックが押されたら
        if (Input.GetMouseButtonDown(0))
        {
            // Start メソッドを呼び出す
            Start();
        }
    }

}
